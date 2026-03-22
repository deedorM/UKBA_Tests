namespace UKBA_TestExploration.Pages
{
  public class PlannedStudyDurationPage
    {
        IPage _page;
        public PlannedStudyDurationPage(IPage   page)
        {
            _page = page;
        }

        ILocator HowLongPageHeader => _page.Locator("[id='response-label']");
        ILocator DurationRadioBtn(string text) => _page.Locator($"//input[@name='response']//following-sibling::label[.='{text}']");


        public async Task AssertNationalityQuestionHeading(string expectedTitle)
        {
            var actualTitle = await HowLongPageHeader.TextContentAsync();
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }

        public async Task ClickDuration(string text)
        {
            await DurationRadioBtn(text).ClickAsync();
        }
    }
}