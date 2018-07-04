using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    internal class WishListItemRequestedToDirector : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.RequestedToDirector;
    }
}