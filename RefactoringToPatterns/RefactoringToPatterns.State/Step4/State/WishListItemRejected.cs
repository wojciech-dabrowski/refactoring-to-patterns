using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step4.State
{
    internal class WishListItemRejected : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Rejected;
    }
}