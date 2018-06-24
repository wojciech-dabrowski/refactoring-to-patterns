using System;

namespace RefactoringToPatterns.State.Common.Exceptions.Status
{
    public class CannotFinishWishListItemRealizationWithNotInvoicedException : Exception
    {
        public CannotFinishWishListItemRealizationWithNotInvoicedException()
            : base("Cannot finish wish list item realization with not invoiced costs.")
        {
        }
    }
}