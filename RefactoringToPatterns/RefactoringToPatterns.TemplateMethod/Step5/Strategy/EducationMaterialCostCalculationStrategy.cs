using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step5.Strategy
{
    internal class EducationMaterialCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        protected override decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            if (item.VendorsWithDiscounts.ContainsKey(item.VendorName))
            {
                var discountAmount = totalCost * item.VendorsWithDiscounts[item.VendorName];
                totalCost -= discountAmount;
            }

            return totalCost;
        }

        protected override decimal CalculateSideCosts(SideCosts sideCosts)
        {
            return 0;
        }
    }
}