namespace UKBA_TestExploration.Pages
{
    public class InformationPage
    {
        IPage _page;

        public InformationPage(IPage page)
        {
            _page = page;
        }

        private ILocator headerMsg =>
            _page.Locator("//div[@class='gem-c-heading govuk-!-margin-bottom-6']/h2");

        public async Task<string> GetHeaderMsgText() => headerMsg.TextContentAsync().Result;
    }
}