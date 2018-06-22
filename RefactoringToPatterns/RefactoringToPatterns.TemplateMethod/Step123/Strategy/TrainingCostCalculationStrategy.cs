using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step123.Strategy
{
    internal class TrainingCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        public override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.ItemCost;

            totalCost += CalculateSideCosts(item.SideCosts);

            return totalCost;
        }

        private decimal CalculateSideCosts(SideCosts sideCosts)
        {
            decimal totalSideCosts = 0;

            if (sideCosts.IncludeAccommodationCost)
            {
                totalSideCosts += sideCosts.AccommodationCost;
            }

            if (sideCosts.IncludeDailyAllowanceCost)
            {
                totalSideCosts += sideCosts.DailyAllowanceCost;
            }

            if (sideCosts.IncludeTransportCost)
            {
                totalSideCosts += sideCosts.TransportCost;
            }

            return totalSideCosts;
        }
    }
}