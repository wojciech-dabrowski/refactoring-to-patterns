using System;
using RefactoringToPatterns.State.Common.Enum;

namespace RefactoringToPatterns.State.Common.Exceptions.Status
{
    public class CannotAcceptWishListItemWithCurrentStatusException : Exception
    {
        public CannotAcceptWishListItemWithCurrentStatusException(
            WishListItemStatus status)
            : base($"Cannot accept wish list item in {status} status.")
        {
            Status = status;
        }

        public WishListItemStatus Status { get; }
    }
}