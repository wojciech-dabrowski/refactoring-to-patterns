using System;

namespace RefactoringToPatterns.State.Common.Exceptions.Permission
{
    public class UserDoesNotHavePermissionToRejectRequestedWishListItemException : Exception
    {
        public UserDoesNotHavePermissionToRejectRequestedWishListItemException()
            : base("User does not have permission to reject requested wish list item.")
        {
        }
    }
}