using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    public class WishListItemRequestedToDirector : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.RequestedToDirector;
    }
}