using System.Collections.Generic;
using NUnit.Framework;
using RefactoringToPatterns.TemplateMethod.Common.Enum;
using RefactoringToPatterns.TemplateMethod.Step4;

namespace RefactoringToPatterns.TemplateMethod.Test.Step4
{
    [TestFixture]
    public class When_calculating_education_material_cost
    {
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
            var educationMaterial = new WishListItem(
                WishListItemType.EducationMaterial,
                BasePrice,
                vendorName,
                vendorNamesWithDiscounts: _vendorNamesWithDiscounts);

            // When
            var result = educationMaterial.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void It_should_return_correct_value_for_vendor_without_discount()
        {
            // Given
            const string vendorName = "Vendor name";
            var educationMaterial = new WishListItem(
                WishListItemType.ELearningLicense,
                BasePrice,
                vendorName,
                vendorNamesWithDiscounts: _vendorNamesWithDiscounts);

            // When
            var result = educationMaterial.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(BasePrice));
        }
    }
}