using System;
using System.Collections.Generic;
using RefactoringToPatterns.Strategy.Common;
using RefactoringToPatterns.Strategy.Common.Enum;

namespace RefactoringToPatterns.Strategy.Step1
{
    public class WishListItem
    {
        private readonly int _approachNumber;
        private readonly DateTime? _endDate;
        private readonly decimal _baseItemCost;
        private readonly LocationType _location;
        private readonly SideCosts _sideCosts;
        private readonly DateTime? _startDate;
        private readonly string _vendorName;
        private readonly IDictionary<string, decimal> _vendorsWithDiscounts;
        private readonly WishListItemType _wishListItemType;

        public WishListItem(
            WishListItemType wishListItemType,
            decimal baseItemCost,
            string vendorName = null,
            LocationType location = LocationType.Local,
            int approachNumber = 0,
            DateTime? startDate = null,
            DateTime? endDate = null,
            SideCosts sideCosts = null,
            IDictionary<string, decimal> vendorNamesWithDiscounts = null)
        {
            _wishListItemType = wishListItemType;
            _baseItemCost = baseItemCost;
            _vendorName = vendorName;
            _location = location;
            _approachNumber = approachNumber;
            _startDate = startDate;
            _endDate = endDate;
            _sideCosts = sideCosts ?? new SideCosts();
            _vendorsWithDiscounts = vendorNamesWithDiscounts ?? new Dictionary<string, decimal>();
        }

        public decimal CalculateCost()
        {
            var totalCost = _baseItemCost;

            if (_wishListItemType == WishListItemType.EducationMaterial
                || _wishListItemType == WishListItemType.ELearningLicense)
            {
                if (_vendorsWithDiscounts.ContainsKey(_vendorName))
                {
                    var discountAmount = totalCost * _vendorsWithDiscounts[_vendorName];
                    totalCost -= discountAmount;
                }
            }

            if (_wishListItemType == WishListItemType.ELearningLicense)
            {
                var duration = _endDate - _startDate;

                if (duration.HasValue && duration.Value.Days > 180)
                {
                    totalCost *= 0.8m;
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

            if (_wishListItemType == WishListItemType.Conference)
            {
                if (_location == LocationType.Foreign)
                {
                    totalCost *= 0.7m;
                }
            }

            if (_wishListItemType == WishListItemType.Conference
                || _wishListItemType == WishListItemType.Training
                || _wishListItemType == WishListItemType.Exam)
            {
                if (_sideCosts.IncludeAccommodationCost)
                {
                    totalCost += _sideCosts.AccommodationCost;
                }

                if (_sideCosts.IncludeDailyAllowanceCost)
                {
                    totalCost += _sideCosts.DailyAllowanceCost;
                }

                if (_sideCosts.IncludeTransportCost)
                {
                    totalCost += _sideCosts.TransportCost;
                }
            }

            return totalCost;
        }
    }
}