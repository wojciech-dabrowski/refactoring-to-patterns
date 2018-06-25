using System;
using NUnit.Framework;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;
using RefactoringToPatterns.State.Step0;

namespace RefactoringToPatterns.State.Test.Step0
{
    [TestFixture]
    public class When_starting_wish_list_item_realization
    {
        private const decimal CostAmount = 500;

        private readonly Guid _userId = Guid.NewGuid();
        private readonly Guid _supervisorId = Guid.NewGuid();

        private const string UserName = "User name";
        private const string SupervisorName = "Supervisor name";

        [TestCase(WishListItemStatus.Rejected)]
        [TestCase(WishListItemStatus.InRealization)]
        [TestCase(WishListItemStatus.Realized)]
        [TestCase(WishListItemStatus.Requested)]
        [TestCase(WishListItemStatus.RequestedToDirector)]
        public void It_should_throw_exception_for_incorrect_status(WishListItemStatus status)
        {
            // Given
            var supervisor = new User(_supervisorId, SupervisorName, isSupervisor: true);
            var user = new User(_userId, UserName);

            var item = new WishListItem(
                status,
                user,
                CostAmount);

            // When
            // Then
            Assert.Throws<CannotStartWishListItemRealizationWithCurrentStatusException>(() =>
            {
                item.StartRealizationBy(
                    supervisor);
            });
        }

        [Test]
        public void It_should_change_status_for_accepted_item()
        {
            // Given
            var supervisor = new User(_supervisorId, SupervisorName, isSupervisor: true);
            var user = new User(_userId, UserName);
            var item = new WishListItem(
                WishListItemStatus.Accepted,
                user,
                CostAmount);

            // When
            item.StartRealizationBy(supervisor);

            // Then
            Assert.That(item.Status, Is.EqualTo(WishListItemStatus.InRealization));
        }

        [Test]
        public void It_should_throw_exception_for_changing_without_permission()
        {
            // Given
            var user = new User(_userId, UserName);

            var item = new WishListItem(
                WishListItemStatus.Accepted,
                user,
                CostAmount);

            // When
            // Then
            Assert.Throws<UserDoesNotHavePermissionToStartWishListItemRealizationException>(() =>
            {
                item.StartRealizationBy(
                    user);
            });
        }
    }
}