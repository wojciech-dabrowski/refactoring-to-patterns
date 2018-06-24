using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Common.Exceptions.Status
{
    public class CannotRejectWishListItemWithCurrentStatusException : Exception
    {
        public CannotRejectWishListItemWithCurrentStatusException(
            WishListItemStatus status)
            : base($"Cannot reject wish list item in {status} status.")
        {
            Status = status;
        }

        public WishListItemStatus Status { get; }
    }
}