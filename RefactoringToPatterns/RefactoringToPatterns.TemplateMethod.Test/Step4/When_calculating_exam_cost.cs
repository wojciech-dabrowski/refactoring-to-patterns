using NUnit.Framework;
using RefactoringToPatterns.TemplateMethod.Common;
using RefactoringToPatterns.TemplateMethod.Common.Enum;
using RefactoringToPatterns.TemplateMethod.Step4;

namespace RefactoringToPatterns.TemplateMethod.Test.Step4
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
        public void It_should_return_correct_value_for_exam_without_side_costs(
            int aproachNumber,
            decimal expectedPriceMultiplicator)
        {
            // Given
            var exam = new WishListItem(
                WishListItemType.Exam,
                BasePrice,
                VendorName,
                approachNumber: aproachNumber);

            var expectedResult = BasePrice * expectedPriceMultiplicator;

            // When
            var result = exam.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 1)]
        [TestCase(2, 0.5)]
        [TestCase(3, 0.25)]
        [TestCase(4, 0)]
        public void It_should_return_correct_value_for_exam_with_side_costs(
            int aproachNumber,
            decimal expectedPriceMultiplicator)
        {
            // Given
            const decimal accommodationCost = 200;
            const decimal transportCost = 300;

            var sideCosts = new SideCosts
            {
                AccommodationCost = accommodationCost,
                DailyAllowanceCost = transportCost,
                IncludeAccommodationCost = true,
                IncludeDailyAllowanceCost = true
            };

            var exam = new WishListItem(
                WishListItemType.Exam,
                BasePrice,
                VendorName,
                approachNumber: aproachNumber,
                sideCosts: sideCosts);

            var expectedExamPrice = BasePrice * expectedPriceMultiplicator;
            var expectedTotalPrice = expectedExamPrice + accommodationCost + transportCost;

            // When
            var result = exam.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedTotalPrice));
        }
    }
}