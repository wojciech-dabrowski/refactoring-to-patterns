using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
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
    }
}