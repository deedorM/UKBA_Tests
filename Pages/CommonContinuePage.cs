namespace UKBA_TestExploration.Pages
{
    public class CommonContinuePage
    {
        private readonly IPage _page;

        public CommonContinuePage(IPage page)
        {
            _page = page;
        }

        ILocator ContinueBtn => _page.Locator(".gem-c-button.govuk-button.gem-c-button--bottom-margin");

        public Task ClickContinue()
        {
            return ContinueBtn.ClickAsync();
        }
    }
}