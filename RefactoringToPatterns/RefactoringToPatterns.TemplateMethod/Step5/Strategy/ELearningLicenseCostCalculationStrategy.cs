using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step5.Strategy
{
    internal class ELearningLicenseCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        protected override decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            var duration = item.EndDate - item.StartDate;

            if (duration.HasValue && duration.Value.Days > 180)
            {
                totalCost *= 0.8m;
            }

            return totalCost;
        }

        protected override decimal CalculateSideCosts(SideCosts sideCosts)
        {
            return 0;
        }
    }
}