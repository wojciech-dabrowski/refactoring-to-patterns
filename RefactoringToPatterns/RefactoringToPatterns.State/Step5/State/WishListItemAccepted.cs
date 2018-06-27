using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;

namespace RefactoringToPatterns.State.Step5.State
{
    public class WishListItemAccepted : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.Accepted;

        public override void StartRealizationBy(User user, WishListItem item)
        {
            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToStartWishListItemRealizationException();
            }

            item.State = InRealization;
        }
    }
}