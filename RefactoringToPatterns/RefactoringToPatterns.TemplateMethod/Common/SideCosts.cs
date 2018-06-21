namespace RefactoringToPatterns.TemplateMethod.Common
{
    public class SideCosts
    {
        public decimal AccommodationCost { get; set; }
        public decimal TransportCost { get; set; }
        public decimal DailyAllowanceCost { get; set; }
        public bool IncludeAccommodationCost { get; set; }
        public bool IncludeDailyAllowanceCost { get; set; }
        public bool IncludeTransportCost { get; set; }
    }
}