namespace RefactoringToPatterns.TemplateMethod.Step5.Strategy
{
    internal class TrainingCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        protected override decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            return totalCost;
        }
    }
}