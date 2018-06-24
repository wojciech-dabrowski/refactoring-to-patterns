using System;

namespace RefactoringToPatterns.State.Common.Exceptions.Permission
{
    public class UserDoesNotHavePermissionToStartWishListItemRealizationException : Exception
    {
        public UserDoesNotHavePermissionToStartWishListItemRealizationException()
            : base("User does not have permission to start realization of wish list item.")
        {
        }
    }
}