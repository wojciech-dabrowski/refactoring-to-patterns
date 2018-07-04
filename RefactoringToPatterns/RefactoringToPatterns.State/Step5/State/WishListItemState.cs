using System;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step5.State
{
    internal abstract class WishListItemState
    {
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

        internal virtual void AcceptBy(User user, WishListItem item)
        {
            throw new CannotAcceptWishListItemWithCurrentStatusException(Status);
        }

        internal virtual void RejectBy(User user, WishListItem item)
        {
            throw new CannotRejectWishListItemWithCurrentStatusException(Status);
        }

        internal virtual void StartRealizationBy(User user, WishListItem item)
        {
            throw new CannotStartWishListItemRealizationWithCurrentStatusException(Status);
        }

        internal virtual void FinishRealizationBy(User user, WishListItem item)
        {
            throw new CannotFinishWishListItemRealizationWithCurrentStatusException(Status);
        }
    }
}