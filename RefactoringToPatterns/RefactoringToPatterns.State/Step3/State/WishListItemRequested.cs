using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    internal class WishListItemRequested : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Requested;
    }
}