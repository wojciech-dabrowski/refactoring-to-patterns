using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Step2.State
{
    public class WishListItemRejected : WishListItemState
    {
        public override WishListItemStatus Status => WishListItemStatus.Rejected;
    }
}