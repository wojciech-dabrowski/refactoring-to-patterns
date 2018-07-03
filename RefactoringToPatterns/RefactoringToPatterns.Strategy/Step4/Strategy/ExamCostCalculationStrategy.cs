namespace RefactoringToPatterns.Strategy.Step4.Strategy
{
    internal class ExamCostCalculationStrategy : WishListItemCostCalculationStrategy
    {
        internal override decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.BaseItemCost;

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

            if (item.SideCosts.IncludeAccommodationCost)
            {
                totalCost += item.SideCosts.AccommodationCost;
            }

            if (item.SideCosts.IncludeDailyAllowanceCost)
            {
                totalCost += item.SideCosts.DailyAllowanceCost;
            }

            if (item.SideCosts.IncludeTransportCost)
            {
                totalCost += item.SideCosts.TransportCost;
            }

            return totalCost;
        }
    }
}