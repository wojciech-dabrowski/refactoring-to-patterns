using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    internal class WishListItemRequested : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Requested;
    }
}