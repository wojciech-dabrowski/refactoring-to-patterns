using System;
using NUnit.Framework;
using RefactoringToPatterns.Strategy.Common.Enum;
using RefactoringToPatterns.Strategy.Step3;

namespace RefactoringToPatterns.Strategy.Test.Step3
{
    [TestFixture]
    public class When_calculating_e_learning_license_cost
    {
        private const decimal LongLicenseMultiplicator = 0.8m;
        private const decimal BasePrice = 300;

        [Test]
        public void It_should_return_correct_value_for_license_with_long_duration()
        {
            // Given
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var endDate = new DateTime(DateTime.Now.Year, 12, 1);
            const string vendorName = "Vendor name";

            const decimal expectedResult = BasePrice * LongLicenseMultiplicator;

            var license = new WishListItem(
                WishListItemType.ELearningLicense,
                BasePrice,
                vendorName,
                startDate: startDate,
                endDate: endDate);

            // When
            var result = license.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void It_should_return_correct_value_for_vendor_without_discount()
        {
            // Given
            const string vendorName = "Vendor name";
            var license = new WishListItem(
                WishListItemType.ELearningLicense,
                BasePrice,
                vendorName);

            // When
            var result = license.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(BasePrice));
        }
    }
}