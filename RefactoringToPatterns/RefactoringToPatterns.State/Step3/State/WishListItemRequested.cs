using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    public class WishListItemRequested : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.Requested;
    }
}