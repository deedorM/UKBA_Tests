namespace UKBA_TestExploration.Pages
{
    public class UkVisaCheckerPage
    {
        IPage _page;
        readFromConfig _readFromConfig;

        public UkVisaCheckerPage(IPage page, readFromConfig readFromConfig)
        {
            _page = page;
            _readFromConfig = readFromConfig;
        }

        public async Task GoToSite()
        {
            await _page.GotoAsync(_readFromConfig.GetJsonData("env:testdevlab"));
        }

        private ILocator AcceptCookiesButton =>
            _page.Locator("[data-accept-cookies='true']");

        private ILocator StartNowButton => _page.Locator("a.govuk-button--start span:has-text('Start now')");

        public async Task ClickAcceptCookies()
        {
            await AcceptCookiesButton.ClickAsync();
        }

        public async Task ClickStartNowButton()=> await StartNowButton.ClickAsync();
        }
    }