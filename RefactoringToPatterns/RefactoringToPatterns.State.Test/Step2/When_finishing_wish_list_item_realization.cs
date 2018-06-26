using System;
using NUnit.Framework;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;
using RefactoringToPatterns.State.Step2;

namespace RefactoringToPatterns.State.Test.Step2
{
    [TestFixture]
    public class When_finishing_wish_list_item_realization
    {
        private const decimal CostAmount = 500;

        private readonly Guid _userId = Guid.NewGuid();
        private readonly Guid _supervisorId = Guid.NewGuid();

        private const string UserName = "User name";
        private const string SupervisorName = "Supervisor name";

        [TestCase(WishListItemStatus.Rejected)]
        [TestCase(WishListItemStatus.Accepted)]
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
            Assert.Throws<CannotFinishWishListItemRealizationWithCurrentStatusException>(() =>
            {
                item.FinishRealizationBy(
                    supervisor);
            });
        }

        [Test]
        public void It_should_change_status_for_item_in_realization_with_invoiced_costs()
        {
            // Given
            var supervisor = new User(_supervisorId, SupervisorName, isSupervisor: true);
            var user = new User(_userId, UserName);
            var item = new WishListItem(
                WishListItemStatus.InRealization,
                user,
                CostAmount);

            // When
            item.FinishRealizationBy(supervisor);

            // Then
            Assert.That(item.Status, Is.EqualTo(WishListItemStatus.Realized));
        }

        [Test]
        public void It_should_throw_exception_for_changing_without_invoiced_costs()
        {
            // Given
            var supervisor = new User(_supervisorId, SupervisorName, isSupervisor: true);
            var user = new User(_userId, UserName);

            var item = new WishListItem(
                WishListItemStatus.InRealization,
                user,
                CostAmount,
                false);

            // When
            // Then
            Assert.Throws<CannotFinishWishListItemRealizationWithNotInvoicedException>(() =>
            {
                item.FinishRealizationBy(
                    supervisor);
            });
        }

        [Test]
        public void It_should_throw_exception_for_changing_without_permission()
        {
            // Given
            var user = new User(_userId, UserName);

            var item = new WishListItem(
                WishListItemStatus.InRealization,
                user,
                CostAmount);

            // When
            // Then
            Assert.Throws<UserDoesNotHavePermissionToFinishWishListItemRealizationException>(() =>
            {
                item.FinishRealizationBy(
                    user);
            });
        }
    }
}