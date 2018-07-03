namespace RefactoringToPatterns.Strategy.Step4.Strategy
{
    internal class EducationMaterialCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        internal override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.BaseItemCost;

            if (item.VendorsWithDiscounts.ContainsKey(item.VendorName))
            {
                var discountAmount = totalCost * item.VendorsWithDiscounts[item.VendorName];
                totalCost -= discountAmount;
            }

            return totalCost;
        }
    }
}