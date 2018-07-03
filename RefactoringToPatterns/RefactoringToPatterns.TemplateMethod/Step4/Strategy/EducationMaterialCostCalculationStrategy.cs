namespace RefactoringToPatterns.TemplateMethod.Step4.Strategy
{
    internal class EducationMaterialCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        internal override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.ItemCost;

            totalCost = ModifyCostBySpecificRules(item, totalCost);

            return totalCost;
        }

        private decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            if (item.VendorsWithDiscounts.ContainsKey(item.VendorName))
            {
                var discountAmount = totalCost * item.VendorsWithDiscounts[item.VendorName];
                totalCost -= discountAmount;
            }

            return totalCost;
        }
    }
}