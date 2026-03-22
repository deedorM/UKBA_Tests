namespace AltoroSite_TestExploration.Drivers
{
    public class DriverContext
    {
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        public IPage? _page;
        public async Task<IPage> CreateSession()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new()
            {
                Channel = "chrome",
                SlowMo = 50,
                Headless = false
            });

            _page = await _browser.NewPageAsync(new()
            {
                ViewportSize = new ViewportSize()
                {
                    Width = 1440,
                    Height = 775
                }

            });

            await Task.Delay(1000);
            return _page;
        }

        public async Task QuitBrowser()
        {

            if (_page != null)
            {
                await _page.CloseAsync();
            }

            if (_browser != null)
            {
                await _browser.CloseAsync();
            }

            _playwright?.Dispose();
        }
    }
}