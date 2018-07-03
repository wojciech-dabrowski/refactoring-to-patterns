using RefactoringToPatterns.TemplateMethod.Common.Enum;

namespace RefactoringToPatterns.TemplateMethod.Step4.Strategy
{
    internal class ConferenceCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        internal override decimal CalculateCost(WishListItem item)
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
    }
}