using Io.Cucumber.Messages.Types;
using NUnit.Framework.Internal;
using Reqnroll.BoDi;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AltoroSite_TestExploration.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        private readonly DriverContext driverContext;
        private IObjectContainer container;

        public TestHooks(DriverContext driverContext, IObjectContainer _container)
        {
            this.driverContext = driverContext;
            this.container = _container;
        }

        [BeforeScenario()]
        public async Task BeforeScenarioWithTag()
        {
            driverContext._page = await driverContext.CreateSession();
            container.RegisterInstanceAs<IPage>(driverContext._page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await driverContext.QuitBrowser();
        }
    }
}
