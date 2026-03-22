namespace UKBA_TestExploration.Pages
{
    public class PlannedJobTypes
    {
        IPage _page;
        public PlannedJobTypes(IPage page)
        {
            _page = page;
        }

        ILocator JobTypeHeading => _page.Locator(".govuk-fieldset__heading.gem-c-radio__heading-text");
        ILocator JobTypeRadio => _page.Locator("//input[@name='response']/following-sibling::label");
        ILocator ResultCard => _page.Locator("(//div[@class='app-c-result-card'])[1]");

        public async Task AssertJobTypeHeading(string expectedTitle)
        {
            var actualTitle = await JobTypeHeading.TextContentAsync();
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }

        public async Task ClickJobType(string job)
        {
            await JobTypeRadio.Locator($"text={job}").ClickAsync();
        }

        public async Task AssertResultCard(params string[] expectedTexts)
        {
            var actualText = await ResultCard.TextContentAsync();
            var normalizedActual = Regex.Replace(actualText ?? string.Empty, @"\s+", " ").ToLowerInvariant();

            foreach (var eligible in (string.Join(" ", expectedTexts) ?? string.Empty)
                     .ToLowerInvariant()
                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Assert.That(normalizedActual, Does.Contain(eligible));
            }
        }
    }
}