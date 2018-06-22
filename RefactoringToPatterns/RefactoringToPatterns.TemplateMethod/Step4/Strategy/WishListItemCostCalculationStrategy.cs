using System;
using RefactoringToPatterns.TemplateMethod.Common;

namespace RefactoringToPatterns.TemplateMethod.Step4.Strategy
{
    public abstract class WishListItemCostCalculationStrategy
    {
        public abstract decimal CalculateCost(WishListItem item);

        protected decimal CalculateSideCosts(SideCosts sideCosts)
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

        public static WishListItemCostCalculationStrategy CreateStrategy(WishListItemType itemType)
        {
            switch (itemType)
            {
                case WishListItemType.ELearningLicense:
                    return new ELearningLicenseCostCalculationStrategy();
                case WishListItemType.EducationMaterial:
                    return new EducationMaterialCostCalculationStrategy();
                case WishListItemType.Exam:
                    return new ExamCostCalculationStrategy();
                case WishListItemType.Conference:
                    return new ConferenceCostCalculationStrategy();
                case WishListItemType.Training:
                    return new TrainingCostCalculationStrategy();
                default:
                    throw new ArgumentOutOfRangeException(nameof(itemType), itemType,
                                                          "Unrecognized wish list item type.");
            }
        }
    }
}