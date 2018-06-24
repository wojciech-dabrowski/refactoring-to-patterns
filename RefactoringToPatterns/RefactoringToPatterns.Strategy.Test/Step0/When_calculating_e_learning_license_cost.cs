using System;
using System.Collections.Generic;
using NUnit.Framework;
using RefactoringToPatterns.Strategy.Common.Enum;
using RefactoringToPatterns.Strategy.Step0;

namespace RefactoringToPatterns.Strategy.Test.Step0
{
    [TestFixture]
    public class When_calculating_e_learning_license_cost
    {
        private const decimal LongLicenseMultiplicator = 0.8m;
        private const string FirstVendorWithDiscountName = "First vendor with discount";
        private const string SecondVendorWithDiscountName = "Second vendor with discount";

        private readonly IDictionary<string, decimal> _vendorNamesWithDiscounts = new Dictionary<string, decimal>
        {
            {FirstVendorWithDiscountName, 0.2m},
            {SecondVendorWithDiscountName, 0.3m}
        };

        private const decimal BasePrice = 300;

        [TestCase(FirstVendorWithDiscountName)]
        [TestCase(SecondVendorWithDiscountName)]
        public void It_should_return_correct_value_for_vendor_with_discount(string vendorName)
        {
            // Given
            var expectedResult = BasePrice - BasePrice * _vendorNamesWithDiscounts[vendorName];
            var license = new WishListItem(
                WishListItemType.ELearningLicense,
                BasePrice,
                vendorName,
                vendorNamesWithDiscounts: _vendorNamesWithDiscounts);

            // When
            var result = license.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

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
                endDate: endDate,
                vendorNamesWithDiscounts: _vendorNamesWithDiscounts);

            // When
            var result = license.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void It_should_return_correct_value_for_vendor_with_discount_and_license_with_long_duration()
        {
            // Given
            var startDate = new DateTime(DateTime.Now.Year, 1, 1);
            var endDate = new DateTime(DateTime.Now.Year, 12, 1);

            var expectedResult = (BasePrice - BasePrice * _vendorNamesWithDiscounts[FirstVendorWithDiscountName]) *
                                 LongLicenseMultiplicator;

            var license = new WishListItem(
                WishListItemType.ELearningLicense,
                BasePrice,
                FirstVendorWithDiscountName,
                startDate: startDate,
                endDate: endDate,
                vendorNamesWithDiscounts: _vendorNamesWithDiscounts);

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
                vendorName,
                vendorNamesWithDiscounts: _vendorNamesWithDiscounts);

            // When
            var result = license.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(BasePrice));
        }
    }
}