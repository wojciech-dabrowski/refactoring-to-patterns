using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    public class WishListItemInRealization : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.InRealization;
    }
}