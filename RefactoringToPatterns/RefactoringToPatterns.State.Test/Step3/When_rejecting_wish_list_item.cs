using System;
using NUnit.Framework;
using RefactoringToPatterns.State.Common;
using RefactoringToPatterns.State.Common.Enum;
using RefactoringToPatterns.State.Common.Exceptions.Permission;
using RefactoringToPatterns.State.Common.Exceptions.Status;
using RefactoringToPatterns.State.Step3;

namespace RefactoringToPatterns.State.Test.Step3
{
    [TestFixture]
    public class When_rejecting_wish_list_item
    {
        private const decimal CostAmountWithoutAdditionalAcceptance = 500;
        private const decimal CostAmountWithAdditionalAcceptance = 6000;

        private readonly Guid _userId = Guid.NewGuid();
        private readonly Guid _leaderId = Guid.NewGuid();
        private readonly Guid _directorId = Guid.NewGuid();

        private const string UserName = "User name";
        private const string LeaderName = "Leader name";
        private const string DirectorName = "Director name";
        private const string DepartmentName = "Department name";

        [TestCase(WishListItemStatus.Accepted)]
        [TestCase(WishListItemStatus.InRealization)]
        [TestCase(WishListItemStatus.Realized)]
        [TestCase(WishListItemStatus.Rejected)]
        public void It_should_throw_exception_for_incorrect_status(WishListItemStatus status)
        {
            // Given
            var leader = new User(_leaderId, LeaderName);
            var user = new User(_userId, UserName, leader);

            var item = new WishListItem(
                status,
                user,
                CostAmountWithoutAdditionalAcceptance);

            // When
            // Then
            Assert.Throws<CannotRejectWishListItemWithCurrentStatusException>(() => { item.RejectBy(leader); });
        }

        [Test]
        public void It_should_change_status_to_rejected_when_requested()
        {
            // Given
            var leader = new User(_leaderId, LeaderName);
            var user = new User(_userId, UserName, leader);
            var item = new WishListItem(
                WishListItemStatus.Requested,
                user,
                CostAmountWithAdditionalAcceptance);

            // When
            item.RejectBy(leader);

            // Then
            Assert.That(item.Status, Is.EqualTo(WishListItemStatus.Rejected));
        }

        [Test]
        public void It_should_change_status_to_rejected_when_requested_to_director()
        {
            // Given
            var director = new User(_directorId, DirectorName);
            var department = new Department(DepartmentName, director);
            var user = new User(
                _userId,
                UserName,
                department: department);

            var item = new WishListItem(
                WishListItemStatus.RequestedToDirector,
                user,
                CostAmountWithAdditionalAcceptance);

            // When
            item.RejectBy(director);

            // Then
            Assert.That(item.Status, Is.EqualTo(WishListItemStatus.Rejected));
        }

        [Test]
        public void It_should_throw_exception_for_changing_from_requested_to_director_without_permission()
        {
            // Given
            var director = new User(_directorId, DirectorName);
            var department = new Department(DepartmentName, director);
            var user = new User(
                _userId,
                UserName,
                department: department);

            var item = new WishListItem(
                WishListItemStatus.RequestedToDirector,
                user,
                CostAmountWithAdditionalAcceptance);

            // When
            // Then
            Assert.Throws<UserDoesNotHavePermissionToRejectRequestedWishListItemException>(() =>
            {
                item.RejectBy(user);
            });
        }

        [Test]
        public void It_should_throw_exception_for_changing_from_requested_without_permission()
        {
            // Given
            var leader = new User(_leaderId, LeaderName);
            var user = new User(_userId, UserName, leader);
            var item = new WishListItem(
                WishListItemStatus.Requested,
                user,
                CostAmountWithoutAdditionalAcceptance);

            // When
            // Then
            Assert.Throws<UserDoesNotHavePermissionToRejectRequestedWishListItemException>(() =>
            {
                item.RejectBy(user);
            });
        }
    }
}