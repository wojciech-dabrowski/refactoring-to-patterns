namespace RefactoringToPatterns.TemplateMethod.Step4.Strategy
{
    internal class TrainingCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        public override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.ItemCost;

            totalCost += CalculateSideCosts(item.SideCosts);

            return totalCost;
        }
    }
}