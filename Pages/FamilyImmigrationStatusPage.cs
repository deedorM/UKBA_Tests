namespace UKBA_TestExploration.Pages
{
    public class FamilyImmigrationStatusPage
    {
        IPage _page;
         public FamilyImmigrationStatusPage(IPage page)
        {
            _page = page;
        }

 
        ILocator YesNoOption(string option) => _page.Locator($"//input[@name='response']/following-sibling::label[contains(text(),'Yes') or contains(text(),'{option}')]");

        public async Task ClickResponseOption(string option)
        {
            await YesNoOption(option).ClickAsync();
        }
    }
}
