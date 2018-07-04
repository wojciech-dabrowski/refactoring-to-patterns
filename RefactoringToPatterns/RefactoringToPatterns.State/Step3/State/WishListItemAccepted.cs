using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    internal class WishListItemAccepted : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Accepted;
    }
}