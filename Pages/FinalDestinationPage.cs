
namespace UKBA_TestExploration.Pages
{
    public class FinalDestinationPage
    {
        IPage _page;
        public FinalDestinationPage(IPage page)
        {
            _page = page;
        }

        ILocator DestinationRadio=> _page.Locator("//input[@id='response-0']");

        public async Task ClickDestinationButton()
        { 
           await DestinationRadio.ClickAsync();
        }

        public async Task AssertTransitDestination(string dst)
        {
            await Assertions.Expect(DestinationRadio).ToBeVisibleAsync();
        }
    }
}