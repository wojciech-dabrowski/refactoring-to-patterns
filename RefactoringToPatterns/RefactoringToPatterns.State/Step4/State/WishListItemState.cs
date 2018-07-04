using System;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step4.State
{
    internal abstract class WishListItemState
    {
        private const decimal AdditionalAcceptanceCostAmount = 5000;

        internal static WishListItemState Requested =
            new WishListItemRequested();

        internal static WishListItemState RequestedToDirector =
            new WishListItemRequestedToDirector();

        internal static WishListItemState Rejected =
            new WishListItemRejected();

        internal static WishListItemState Accepted =
            new WishListItemAccepted();

        internal static WishListItemState InRealization =
            new WishListItemInRealization();

        internal static WishListItemState Realized =
            new WishListItemRealized();

        internal abstract WishListItemStatus Status { get; }

        internal static WishListItemState CreateState(WishListItemStatus status)
        {
            switch (status)
            {
                case WishListItemStatus.Requested:
                    return Requested;
                case WishListItemStatus.RequestedToDirector:
                    return RequestedToDirector;
                case WishListItemStatus.Rejected:
                    return Rejected;
                case WishListItemStatus.Accepted:
                    return Accepted;
                case WishListItemStatus.InRealization:
                    return InRealization;
                case WishListItemStatus.Realized:
                    return Realized;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        internal void AcceptBy(User user, WishListItem item)
        {
            if (Status != WishListItemStatus.Requested &&
                Status != WishListItemStatus.RequestedToDirector)
            {
                throw new CannotAcceptWishListItemWithCurrentStatusException(Status);
            }

            if (Status == WishListItemStatus.Requested)
            {
                if (!user.IsLeaderOf(item.Owner))
                {
                    throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
                }

                if (ShouldBeRequestedToDirector(item.ItemCost))
                {
                    item.State = RequestedToDirector;
                }
                else
                {
                    item.State = Accepted;
                }

                return;
            }

            if (!user.IsDirectorOf(item.Owner))
            {
                throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
            }

            item.State = Accepted;
        }

        internal void RejectBy(User user, WishListItem item)
        {
            if (Status != WishListItemStatus.Requested &&
                Status != WishListItemStatus.RequestedToDirector)
            {
                throw new CannotRejectWishListItemWithCurrentStatusException(Status);
            }

            if (Status == WishListItemStatus.Requested)
            {
                if (!user.IsLeaderOf(item.Owner))
                {
                    throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
                }

                item.State = Rejected;

                return;
            }

            if (!user.IsDirectorOf(item.Owner))
            {
                throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
            }

            item.State = Rejected;
        }

        internal void StartRealizationBy(User user, WishListItem item)
        {
            if (Status != WishListItemStatus.Accepted)
            {
                throw new CannotStartWishListItemRealizationWithCurrentStatusException(Status);
            }

            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToStartWishListItemRealizationException();
            }

            item.State = InRealization;
        }

        internal void FinishRealizationBy(User user, WishListItem item)
        {
            if (Status != WishListItemStatus.InRealization)
            {
                throw new CannotFinishWishListItemRealizationWithCurrentStatusException(Status);
            }

            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToFinishWishListItemRealizationException();
            }

            if (!item.AreCostsInvoiced)
            {
                throw new CannotFinishWishListItemRealizationWithNotInvoicedException();
            }

            item.State = Realized;
        }

        private bool ShouldBeRequestedToDirector(decimal itemCost)
        {
            return itemCost >= AdditionalAcceptanceCostAmount;
        }
    }
}