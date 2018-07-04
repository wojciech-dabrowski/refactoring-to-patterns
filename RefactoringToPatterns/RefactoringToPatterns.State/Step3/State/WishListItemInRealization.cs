using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    internal class WishListItemInRealization : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.InRealization;
    }
}