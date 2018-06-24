using NUnit.Framework;
using RefactoringToPatterns.Strategy.Common;
using RefactoringToPatterns.Strategy.Common.Enum;
using RefactoringToPatterns.Strategy.Step4;

namespace RefactoringToPatterns.Strategy.Test.Step4
{
    [TestFixture]
    public class When_calculating_conference_cost
    {
        private const decimal BasePrice = 1500;
        private const decimal ForeignConferenceMultiplicator = 0.7m;

        [TestCase(LocationType.Local)]
        [TestCase(LocationType.Domestic)]
        public void It_should_return_correct_value_for_non_foreign_conference_without_side_costs(LocationType location)
        {
            // Given
            var conference = new WishListItem(
                WishListItemType.Conference,
                BasePrice,
                location: location);

            // When
            var result = conference.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(BasePrice));
        }

        [TestCase(LocationType.Local)]
        [TestCase(LocationType.Domestic)]
        public void It_should_return_correct_value_for_non_foreign_conference_with_side_costs(LocationType location)
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

            var conference = new WishListItem(
                WishListItemType.Conference,
                BasePrice,
                location: location,
                sideCosts: sideCosts);

            const decimal expectedResult = BasePrice + accommodationCost + transportCost;

            // When
            var result = conference.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void It_should_return_correct_value_for_foreign_conference_without_side_costs()
        {
            // Given
            var conference = new WishListItem(
                WishListItemType.Conference,
                BasePrice,
                location: LocationType.Foreign);

            const decimal expectedResult = BasePrice * ForeignConferenceMultiplicator;

            // When
            var result = conference.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void It_should_return_correct_value_for_foreing_conference_with_side_costs()
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

            var conference = new WishListItem(
                WishListItemType.Conference,
                BasePrice,
                location: LocationType.Foreign,
                sideCosts: sideCosts);

            const decimal conferenceCost = BasePrice * ForeignConferenceMultiplicator;
            const decimal expectedResult = conferenceCost + accommodationCost + transportCost;

            // When
            var result = conference.CalculateCost();

            // Then
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}