using System.Collections.Generic;
using NUnit.Framework;
using RefactoringToPatterns.Strategy.Common;
using RefactoringToPatterns.Strategy.Step0;

namespace RefactoringToPatterns.Strategy.Test.Step0
{
    [TestFixture]
    public class When_calculating_exam_cost
    {
        private const int BasePrice = 2000;
        private const string VendorName = "Vendor Name";

        [TestCase(1, 1)]
        [TestCase(2, 0.5)]
        [TestCase(3, 0.25)]
        [TestCase(4, 0)]
        public void It_should_return_correct_value_for_exam_without_non_meritorical_costs(
            int aproachNumber,
            decimal expectedPriceMultiplicator)
        {
            // Given
            var expectedResult = BasePrice * expectedPriceMultiplicator;

            var exam = new WishListItem(
                WishListItemType.Exam,
                BasePrice,
                VendorName,
                aproachNumber,
                new NonMeritoricalCosts(),
                new Dictionary<string, decimal>());

            // When
            var result = exam.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 1)]
        [TestCase(2, 0.5)]
        [TestCase(3, 0.25)]
        [TestCase(4, 0)]
        public void It_should_return_correct_value_for_exam_with_non_meritorical_costs(
            int aproachNumber,
            decimal expectedPriceMultiplicator)
        {
            // Given
            const decimal accommodationCost = 200;
            const decimal transportCost = 300;

            var nonMeritoricalCosts = new NonMeritoricalCosts
            {
                AccommodationCost = accommodationCost,
                DailyAllowanceCost = transportCost,
                IncludeAccommodationCost = true,
                IncludeDailyAllowanceCost = true
            };

            var expectedExamPrice = BasePrice * expectedPriceMultiplicator;
            var expectedTotalPrice = expectedExamPrice + accommodationCost + transportCost;

            var exam = new WishListItem(
                WishListItemType.Exam,
                BasePrice,
                VendorName,
                aproachNumber,
                nonMeritoricalCosts,
                new Dictionary<string, decimal>());

            // When
            var result = exam.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedTotalPrice));
        }
    }
}