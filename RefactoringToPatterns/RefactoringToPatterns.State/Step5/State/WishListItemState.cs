using System;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step5.State
{
    public abstract class WishListItemState
    {
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

        public virtual void AcceptBy(User user, WishListItem item)
        {
            throw new CannotAcceptWishListItemWithCurrentStatusException(Status);
        }

        public virtual void RejectBy(User user, WishListItem item)
        {
            throw new CannotRejectWishListItemWithCurrentStatusException(Status);
        }

        public virtual void StartRealizationBy(User user, WishListItem item)
        {
            throw new CannotStartWishListItemRealizationWithCurrentStatusException(Status);
        }

        public virtual void FinishRealizationBy(User user, WishListItem item)
        {
            throw new CannotFinishWishListItemRealizationWithCurrentStatusException(Status);
        }
    }
}