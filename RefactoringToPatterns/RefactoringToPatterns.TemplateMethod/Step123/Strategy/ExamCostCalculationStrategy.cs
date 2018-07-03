using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step123.Strategy
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

        private decimal CalculateSideCosts(SideCosts sideCosts)
        {
            decimal totalSideCosts = 0;

            if (sideCosts.IncludeAccommodationCost)
            {
                totalSideCosts += sideCosts.AccommodationCost;
            }

            if (sideCosts.IncludeDailyAllowanceCost)
            {
                totalSideCosts += sideCosts.DailyAllowanceCost;
            }

            if (sideCosts.IncludeTransportCost)
            {
                totalSideCosts += sideCosts.TransportCost;
            }

            return totalSideCosts;
        }
    }
}