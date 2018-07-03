using System;
using System.Collections.Generic;
using RefactoringToPatterns.Strategy.Common;
using RefactoringToPatterns.Strategy.Common.Enum;

namespace RefactoringToPatterns.Strategy.Step3
{
    public class WishListItem
    {
        private readonly WishListItemCostCalculationStrategy _calculationStrategy;

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
            WishListItemType = wishListItemType;
            BaseItemCost = baseItemCost;
            VendorName = vendorName;
            Location = location;
            ApproachNumber = approachNumber;
            StartDate = startDate;
            EndDate = endDate;
            SideCosts = sideCosts ?? new SideCosts();
            VendorsWithDiscounts = vendorNamesWithDiscounts ?? new Dictionary<string, decimal>();

            _calculationStrategy = new WishListItemCostCalculationStrategy();
        }

        public int ApproachNumber { get; }
        public DateTime? EndDate { get; }
        public decimal BaseItemCost { get; }
        public LocationType Location { get; }
        public SideCosts SideCosts { get; }
        public DateTime? StartDate { get; }
        public string VendorName { get; }
        public IDictionary<string, decimal> VendorsWithDiscounts { get; }
        public WishListItemType WishListItemType { get; }

        public decimal CalculateCost()
        {
            var result = _calculationStrategy.CalculateCost(this);
            return result;
        }
    }
}