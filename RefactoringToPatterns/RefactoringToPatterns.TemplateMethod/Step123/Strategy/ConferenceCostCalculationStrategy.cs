using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step123.Strategy
{
    internal class ConferenceCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        public override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.ItemCost;

            totalCost = ModifyCostBySpecificRules(item, totalCost);
            totalCost += CalculateSideCosts(item.SideCosts);

            return totalCost;
        }

        private decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            if (item.Location == LocationType.Foreign)
            {
                totalCost *= 0.7m;
            }

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