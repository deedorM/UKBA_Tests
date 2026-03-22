namespace UKBA_TestExploration.Pages
{
    public class CommonReasonPage
    {
        IPage _page;
        public CommonReasonPage(IPage page)
        {
            _page = page;
        }

        ILocator ReasonRadio(string res) => _page.Locator($"//label[contains(@for, 'response')][contains(text(), '{res}')]");

        public async Task SelectPurposeOfTravelling(string res) => await ReasonRadio(res).ClickAsync();
    }
}