using System;
using System.Collections.Generic;
using RefactoringToPatterns.TemplateMethod.Common;
using RefactoringToPatterns.TemplateMethod.Common.Enum;
using RefactoringToPatterns.TemplateMethod.Step0.Strategy;

namespace RefactoringToPatterns.TemplateMethod.Step0
{
    public class WishListItem
    {
        private readonly WishListItemCostCalculationStrategy _calculationStrategy;

        public WishListItem(
            WishListItemType wishListItemType,
            decimal itemCost,
            string vendorName = null,
            LocationType location = LocationType.Local,
            int approachNumber = 0,
            DateTime? startDate = null,
            DateTime? endDate = null,
            SideCosts sideCosts = null,
            IDictionary<string, decimal> vendorNamesWithDiscounts = null)
        {
            WishListItemType = wishListItemType;
            ItemCost = itemCost;
            VendorName = vendorName;
            Location = location;
            ApproachNumber = approachNumber;
            StartDate = startDate;
            EndDate = endDate;
            SideCosts = sideCosts ?? new SideCosts();
            VendorsWithDiscounts = vendorNamesWithDiscounts ?? new Dictionary<string, decimal>();

            _calculationStrategy = WishListItemCostCalculationStrategy.CreateStrategy(WishListItemType);
        }

        public int ApproachNumber { get; }
        public DateTime? EndDate { get; }
        public decimal ItemCost { get; }
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