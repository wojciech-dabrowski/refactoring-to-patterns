using RefactoringToPatterns.TemplateMethod.Common.Enum;

namespace RefactoringToPatterns.TemplateMethod.Step5.Strategy
{
    internal class ConferenceCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        protected override decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            if (item.Location == LocationType.Foreign)
            {
                totalCost *= 0.7m;
            }

            return totalCost;
        }
    }
}