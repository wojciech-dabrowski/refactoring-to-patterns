using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Common.Exceptions.Status
{
    public class CannotFinishWishListItemRealizationWithCurrentStatusException : Exception
    {
        public CannotFinishWishListItemRealizationWithCurrentStatusException(
            WishListItemStatus status)
            : base($"Cannot finish wish list item realization in {status} status.")
        {
            Status = status;
        }

        public WishListItemStatus Status { get; }
    }
}