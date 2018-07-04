using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;

namespace RefactoringToPatterns.State.Step5.State
{
    internal class WishListItemRequested : WishListItemState
    {
        private const decimal AdditionalAcceptanceCostAmount = 5000;

        internal override WishListItemStatus Status => WishListItemStatus.Requested;

        internal override void AcceptBy(User user, WishListItem item)
        {
            if (!user.IsLeaderOf(item.Owner))
            {
                throw new UserDoesNotHavePermissionToAcceptRequestedWishListItemException();
            }

            item.State = ShouldBeRequestedToDirector(item.ItemCost) 
                ? RequestedToDirector 
                : Accepted;
        }

        internal override void RejectBy(User user, WishListItem item)
        {
            if (!user.IsLeaderOf(item.Owner))
            {
                throw new UserDoesNotHavePermissionToRejectRequestedWishListItemException();
            }

            item.State = Rejected;
        }

        private bool ShouldBeRequestedToDirector(decimal itemCost)
        {
            return itemCost >= AdditionalAcceptanceCostAmount;
        }
    }
}