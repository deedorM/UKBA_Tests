namespace UKBA_TestExploration.Pages
{
    public class NationalitySelectionPage
    {
        IPage _page;
        public NationalitySelectionPage(IPage page)
        {
            _page = page;
        }

        ILocator PageHeading => _page.Locator("[id='response-label']");
        ILocator CountryBox => _page.Locator("select#response");
        
        public async Task AssertNationalityQuestionHeading(string expectedTitle)
        {
            var actualTitle = await PageHeading.TextContentAsync();
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }

        public async Task FillCountry(string country)
        {
            await CountryBox.SelectOptionAsync(new SelectOptionValue { Label = country });
        }
    }
}