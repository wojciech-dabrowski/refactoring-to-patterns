using System;
using RefactoringToPatterns.Strategy.Common.Enum;

namespace RefactoringToPatterns.Strategy.Step4.Strategy
{
    public abstract class WishListItemCostCalculationStrategy
    {
        public abstract decimal CalculateCost(WishListItem item);

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