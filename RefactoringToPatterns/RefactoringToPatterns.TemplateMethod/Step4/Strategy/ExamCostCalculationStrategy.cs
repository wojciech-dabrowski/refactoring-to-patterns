namespace RefactoringToPatterns.TemplateMethod.Step4.Strategy
{
    internal class ExamCostCalculationStrategy : WishListItemCostCalculationStrategy
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