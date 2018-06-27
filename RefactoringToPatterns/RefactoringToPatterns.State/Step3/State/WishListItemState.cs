using System;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step3.State
{
    public abstract class WishListItemState
    {
        private const decimal AdditionalAcceptanceCostAmount = 5000;

        public static WishListItemState Requested =
            new WishListItemRequested();

        public static WishListItemState RequestedToDirector =
            new WishListItemRequestedToDirector();

        public static WishListItemState Rejected =
            new WishListItemRejected();

        public static WishListItemState Accepted =
            new WishListItemAccepted();

        public static WishListItemState InRealization =
            new WishListItemInRealization();

        public static WishListItemState Realized =
            new WishListItemRealized();

        public abstract WishListItemStatus Status { get; }

        public static WishListItemState CreateState(WishListItemStatus status)
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

        public void AcceptBy(User user, WishListItem item)
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

        public void RejectBy(User user, WishListItem item)
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

        public void StartRealizationBy(User user, WishListItem item)
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

        public void FinishRealizationBy(User user, WishListItem item)
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