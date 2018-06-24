using System;

namespace RefactoringToPatterns.State.Common.Exceptions.Permission
{
    public class UserDoesNotHavePermissionToAcceptRequestedWishListItemException : Exception
    {
        public UserDoesNotHavePermissionToAcceptRequestedWishListItemException()
            : base("User does not have permission to accept requested wish list item.")
        {
        }
    }
}