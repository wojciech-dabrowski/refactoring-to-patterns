using System;

namespace RefactoringToPatterns.State.Common.Exceptions.Permission
{
    public class UserDoesNotHavePermissionToFinishWishListItemRealizationException : Exception
    {
        public UserDoesNotHavePermissionToFinishWishListItemRealizationException()
            : base("User does not have permission to finish realization of wish list item.")
        {
        }
    }
}