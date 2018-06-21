using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step0.Strategy
{
    internal class ConferenceCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        public override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.ItemCost;

            if (item.Location == LocationType.Foreign)
            {
                totalCost *= 0.7m;
            }

            if (item.SideCosts.IncludeAccommodationCost)
            {
                totalCost += item.SideCosts.AccommodationCost;
            }

            if (item.SideCosts.IncludeDailyAllowanceCost)
            {
                totalCost += item.SideCosts.DailyAllowanceCost;
            }

            if (item.SideCosts.IncludeTransportCost)
            {
                totalCost += item.SideCosts.TransportCost;
            }

            return totalCost;
        }
    }
}