using System;
using RefactoringToPatterns.TemplateMethod.Common.Enum;

namespace RefactoringToPatterns.TemplateMethod.Step123.Strategy
{
    internal abstract class WishListItemCostCalculationStrategy
    {
        internal abstract decimal CalculateCost(WishListItem item);

        internal static WishListItemCostCalculationStrategy CreateStrategy(WishListItemType itemType)
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