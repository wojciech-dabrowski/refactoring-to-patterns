using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Common.Exceptions.Status
{
    public class CannotStartWishListItemRealizationWithCurrentStatusException : Exception
    {
        public CannotStartWishListItemRealizationWithCurrentStatusException(
            WishListItemStatus status)
            : base($"Cannot start wish list item realization in {status} status.")
        {
            Status = status;
        }

        public WishListItemStatus Status { get; }
    }
}