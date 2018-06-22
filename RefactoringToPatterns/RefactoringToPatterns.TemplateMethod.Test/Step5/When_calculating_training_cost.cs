using NUnit.Framework;
using RefactoringToPatterns.TemplateMethod.Common;
using RefactoringToPatterns.TemplateMethod.Step5;

namespace RefactoringToPatterns.TemplateMethod.Test.Step5
{
    [TestFixture]
    public class When_calculating_training_cost
    {
        private const decimal BasePrice = 1500;

        [Test]
        public void It_should_return_correct_value_for_training_with_side_costs()
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

            var training = new WishListItem(
                WishListItemType.Training,
                BasePrice,
                sideCosts: sideCosts);

            const decimal expectedResult = BasePrice + accommodationCost + transportCost;

            // When
            var result = training.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void It_should_return_correct_value_for_training_without_side_costs()
        {
            // Given
            var training = new WishListItem(
                WishListItemType.Training,
                BasePrice);

            // When
            var result = training.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(BasePrice));
        }
    }
}