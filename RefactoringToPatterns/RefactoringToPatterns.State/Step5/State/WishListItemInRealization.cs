using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step5.State
{
    internal class WishListItemInRealization : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.InRealization;

        internal override void FinishRealizationBy(User user, WishListItem item)
        {
            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToFinishWishListItemRealizationException();
            }

            if (!item.AreCostsInvoiced)
            {
                throw new CannotFinishWishListItemRealizationWithNotInvoicedException();
            }

            item.State = Realized;
        }
    }
}