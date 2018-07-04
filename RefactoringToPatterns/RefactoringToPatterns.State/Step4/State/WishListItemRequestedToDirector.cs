using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;

namespace RefactoringToPatterns.State.Step4.State
{
    internal class WishListItemRequestedToDirector : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.RequestedToDirector;

        internal void AcceptBy(User user, WishListItem item)
        {
            if (!user.IsDirectorOf(item.Owner))
            {
                throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
            }

            item.State = Accepted;
        }

        internal void RejectBy(User user, WishListItem item)
        {
            if (!user.IsDirectorOf(item.Owner))
            {
                throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
            }

            item.State = Rejected;
        }
    }
}