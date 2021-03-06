﻿using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;

namespace RefactoringToPatterns.State.Step4.State
{
    internal class WishListItemAccepted : WishListItemState
    {
        internal override WishListItemStatus Status => WishListItemStatus.Accepted;

        internal void StartRealizationBy(User user, WishListItem item)
        {
            if (!user.IsSupervisor)
            {
                throw new UserDoesNotHavePermissionToStartWishListItemRealizationException();
            }

            item.State = InRealization;
        }
    }
}