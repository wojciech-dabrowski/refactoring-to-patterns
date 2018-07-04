using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    internal class WishListItemRequestedToDirector : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.RequestedToDirector;
    }
}