namespace RefactoringToPatterns.TemplateMethod.Step4.Strategy
{
    internal class TrainingCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        internal override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.ItemCost;

            totalCost += CalculateSideCosts(item.SideCosts);

            return totalCost;
        }
    }
}