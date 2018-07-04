using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step1.State
{
    internal class WishListItemState
    {
        internal static WishListItemState Requested =
            new WishListItemState(WishListItemStatus.Requested);

        internal static WishListItemState RequestedToDirector =
            new WishListItemState(WishListItemStatus.RequestedToDirector);

        internal static WishListItemState Rejected =
            new WishListItemState(WishListItemStatus.Rejected);

        internal static WishListItemState Accepted =
            new WishListItemState(WishListItemStatus.Accepted);

        internal static WishListItemState InRealization =
            new WishListItemState(WishListItemStatus.InRealization);

        internal static WishListItemState Realized =
            new WishListItemState(WishListItemStatus.Realized);

        private WishListItemState(
            WishListItemStatus status)
        {
            Status = status;
        }

        internal WishListItemStatus Status { get; }

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
    }
}