using System.Collections.Generic;
using NUnit.Framework;
using RefactoringToPatterns.Strategy.Common;
using RefactoringToPatterns.Strategy.Step0;

namespace RefactoringToPatterns.Strategy.Test.Step0
{
    [TestFixture]
    public class When_calculating_wish_list_item_cost
    {
        [TestCase(1, 1)]
        [TestCase(2, 0.5)]
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        public void It_should_return_correct_value_for_exam_without_non_meritorical_costs(
            int aproachNumber,
            decimal expectedPriceMultiplicator)
        {
            // Given
            const int basePrice = 2000;
            const string vendorName = "Vendor Name";
            var expectedResult = basePrice * expectedPriceMultiplicator;

            var item = new WishListItem(
                WishListItemType.Exam,
                aproachNumber,
                2000,
                vendorName,
                new NonMeritoricalCosts(),
                new Dictionary<string, decimal>());

            // When
            var result = item.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}