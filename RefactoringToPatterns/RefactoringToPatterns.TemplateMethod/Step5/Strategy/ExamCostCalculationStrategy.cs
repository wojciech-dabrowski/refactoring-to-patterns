namespace RefactoringToPatterns.TemplateMethod.Step5.Strategy
{
    internal class ExamCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        protected override decimal ModifyCostBySpecificRules(WishListItem item, decimal totalCost)
        {
            if (item.ApproachNumber == 2)
            {
                totalCost /= 2;
            }
            else if (item.ApproachNumber == 3)
            {
                totalCost /= 4;
            }
            else if (item.ApproachNumber > 3)
            {
                totalCost = 0;
            }

            return totalCost;
        }
    }
}