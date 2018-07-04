using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    internal class WishListItemRealized : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Realized;
    }
}