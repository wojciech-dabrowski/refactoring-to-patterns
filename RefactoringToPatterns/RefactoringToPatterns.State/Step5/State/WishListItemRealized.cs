using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step5.State
{
    public class WishListItemRealized : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.Realized;
    }
}