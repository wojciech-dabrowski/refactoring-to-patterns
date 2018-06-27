using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    public class WishListItemRequestedToDirector : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.RequestedToDirector;
    }
}