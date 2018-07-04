using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;

namespace RefactoringToPatterns.State.Step4.State
{
    internal class WishListItemInRealization : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.InRealization;

        internal void FinishRealizationBy(User user, WishListItem item)
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