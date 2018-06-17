using System.Collections.Generic;
using RefactoringToPatterns.Strategy.Common;

namespace RefactoringToPatterns.Strategy.Step0
{
    public class WishListItem
    {
        private readonly int _approachNumber;
        private readonly decimal _itemCost;
        private readonly NonMeritoricalCosts _nonMeritoricalCosts;
        private readonly string _vendorName;
        private readonly IDictionary<string, decimal> _vendorsWithDiscounts;
        private readonly WishListItemType _wishListItemType;

        public WishListItem(
            WishListItemType wishListItemType,
            decimal itemCost,
            string vendorName,
            int approachNumber = 0,
            NonMeritoricalCosts nonMeritoricalCosts = null,
            IDictionary<string, decimal> vendorNamesWithDiscounts = null)
        {
            _wishListItemType = wishListItemType;
            _approachNumber = approachNumber;
            _itemCost = itemCost;
            _vendorName = vendorName;
            _nonMeritoricalCosts = nonMeritoricalCosts ?? new NonMeritoricalCosts();
            _vendorsWithDiscounts = vendorNamesWithDiscounts ?? new Dictionary<string, decimal>();
        }

        public decimal CalculateCost()
        {
            var totalCost = _itemCost;

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
                else if (_approachNumber == 3)
                {
                    totalCost /= 4;
                }
                else if (_approachNumber > 3)
                {
                    totalCost = 0;
                }
            }

            if (_wishListItemType == WishListItemType.Conference
                || _wishListItemType == WishListItemType.Training
                || _wishListItemType == WishListItemType.Exam)
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