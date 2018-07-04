using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
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
    }
}