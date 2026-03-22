namespace UKBA_TestExploration.Model
{
    public class PurposeOfTravelModel
    {
        public required string Purpose { get; set; }
    }

    public class PurposeOfTravel
    {
        private static readonly Dictionary<string, string> Map =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["Tourism"] = "response-0",
                ["Work and academic visit"] = "response-1",
                ["Study"] = "response-2",
                ["Transit"] = "response-3",
                ["Join partner or family for a long stay"] = "response-4",
                ["Get married or enter into a civil partnership"] = "response-5",
                ["Medical treatment"] = "response-7"
            };

        public static Task Select(IPage page, PurposeOfTravelModel model) =>
            page.Locator($"label[for='{Map[model.Purpose]}']").ClickAsync();
    }
}