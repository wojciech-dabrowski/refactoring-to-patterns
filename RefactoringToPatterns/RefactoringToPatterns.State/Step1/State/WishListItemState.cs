using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step1.State
{
    public class WishListItemState
    {
        public static WishListItemState Requested =
            new WishListItemState(WishListItemStatus.Requested);

        public static WishListItemState RequestedToDirector =
            new WishListItemState(WishListItemStatus.RequestedToDirector);

        public static WishListItemState Rejected =
            new WishListItemState(WishListItemStatus.Rejected);

        public static WishListItemState Accepted =
            new WishListItemState(WishListItemStatus.Accepted);

        public static WishListItemState InRealization =
            new WishListItemState(WishListItemStatus.InRealization);

        public static WishListItemState Realized =
            new WishListItemState(WishListItemStatus.Realized);

        private WishListItemState(
            WishListItemStatus status)
        {
            Status = status;
        }

        public WishListItemStatus Status { get; }

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