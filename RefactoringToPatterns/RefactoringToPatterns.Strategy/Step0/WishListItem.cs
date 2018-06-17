using System.Collections.Generic;
using RefactoringToPatterns.Strategy.Common;

namespace RefactoringToPatterns.Strategy.Step0
{
    public class WishListItem
    {
        private readonly int _approachNumber;
        private readonly NonMeritoricalCosts _nonMeritoricalCosts;
        private readonly string _vendorName;
        private readonly IDictionary<string, decimal> _vendorsWithDiscounts;
        private readonly decimal _wishListItemCost;
        private readonly WishListItemType _wishListItemType;

        public WishListItem(
            WishListItemType wishListItemType,
            int approachNumber,
            decimal wishListItemCost,
            string vendorName,
            NonMeritoricalCosts nonMeritoricalCosts,
            IDictionary<string, decimal> vendorsWithDiscounts)
        {
            _wishListItemType = wishListItemType;
            _approachNumber = approachNumber;
            _wishListItemCost = wishListItemCost;
            _nonMeritoricalCosts = nonMeritoricalCosts;
            _vendorName = vendorName;
            _vendorsWithDiscounts = vendorsWithDiscounts;
        }

        public decimal CalculateCost()
        {
            var totalCost = _wishListItemCost;

            if (_wishListItemType == WishListItemType.EducationMaterial
                || _wishListItemType == WishListItemType.ELearningLicense)
            {
                if (_vendorsWithDiscounts.ContainsKey(_vendorName))
                {
                    var discountAmount = totalCost * _vendorsWithDiscounts[_vendorName];
                    totalCost -= discountAmount;
                }
            }

            if (_wishListItemType == WishListItemType.Exam)
            {
                if (_approachNumber == 2)
                {
                    totalCost /= 2;
                }

                if (_approachNumber > 2)
                {
                    totalCost = 0;
                }
            }

            if (_wishListItemType == WishListItemType.Conference
                || _wishListItemType == WishListItemType.Training)
            {
                if (_nonMeritoricalCosts.IncludeAccommodationCost)
                {
                    totalCost += _nonMeritoricalCosts.AccommodationCost;
                }

                if (_nonMeritoricalCosts.IncludeDailyAllowanceCost)
                {
                    totalCost += _nonMeritoricalCosts.DailyAllowanceCost;
                }

                if (_nonMeritoricalCosts.IncludeTransportCost)
                {
                    totalCost += _nonMeritoricalCosts.TransportCost;
                }
            }

            return totalCost;
        }
    }
}