using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    internal class WishListItemAccepted : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Accepted;
    }
}