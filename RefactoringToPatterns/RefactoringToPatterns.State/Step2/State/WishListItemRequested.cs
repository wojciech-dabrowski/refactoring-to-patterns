using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    public class WishListItemRequested : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.Requested;
    }
}