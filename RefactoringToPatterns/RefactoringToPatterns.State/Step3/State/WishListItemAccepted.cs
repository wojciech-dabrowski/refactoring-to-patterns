using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step3.State
{
    public class WishListItemAccepted : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.Accepted;
    }
}