using RefactoringToPatterns.Strategy.Common.Enum;

namespace RefactoringToPatterns.Strategy.Step2
{
    internal class WishListItemCostCalculationStrategy
    {
        internal decimal CalculateCost(WishListItem item)
        {
            var totalCost = item.BaseItemCost;

            if (item.WishListItemType == WishListItemType.EducationMaterial
                || item.WishListItemType == WishListItemType.ELearningLicense)
            {
                if (item.VendorsWithDiscounts.ContainsKey(item.VendorName))
                {
                    var discountAmount = totalCost * item.VendorsWithDiscounts[item.VendorName];
                    totalCost -= discountAmount;
                }
            }

            if (item.WishListItemType == WishListItemType.ELearningLicense)
            {
                var duration = item.EndDate - item.StartDate;

                if (duration.HasValue && duration.Value.Days > 180)
                {
                    totalCost *= 0.8m;
                }
            }

            if (item.WishListItemType == WishListItemType.Exam)
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
            }

            if (item.WishListItemType == WishListItemType.Conference)
            {
                if (item.Location == LocationType.Foreign)
                {
                    totalCost *= 0.7m;
                }
            }

            if (item.WishListItemType == WishListItemType.Conference
                || item.WishListItemType == WishListItemType.Training
                || item.WishListItemType == WishListItemType.Exam)
            {
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
            }

            return totalCost;
        }
    }
}