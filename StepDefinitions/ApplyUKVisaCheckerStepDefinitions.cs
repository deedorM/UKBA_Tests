namespace UKBA_TestExploration.StepDefinitions
{
    [Binding]
    public class ApplyUKVisaCheckerStepDefinitions
    {
        IPage _page;
        UkVisaCheckerPage ukVisaCheckerPage;
        NationalitySelectionPage nationalitySelectionPage;
        CommonReasonPage purposeOfTravelPage;
        PlannedStudyDurationPage plannedStudyDurationPage;
        InformationPage informationPage;
        PlannedJobTypes plannedJobTypes;
        CommonContinuePage commonContinuePage;
        CommonReasonPage commonReasonPage;
        FinalDestinationPage finalDestinationPage;
        FamilyImmigrationStatusPage familyImmigrationStatusPage;
        public ApplyUKVisaCheckerStepDefinitions(IObjectContainer container)
        {
            _page = container.Resolve<IPage>();
            ukVisaCheckerPage = new UkVisaCheckerPage(_page, new readFromConfig());
            nationalitySelectionPage = new NationalitySelectionPage(_page);
            purposeOfTravelPage = new CommonReasonPage(_page);
            plannedStudyDurationPage = new PlannedStudyDurationPage(_page);
            informationPage = new InformationPage(_page);
            plannedJobTypes = new PlannedJobTypes(_page);
            commonContinuePage = new CommonContinuePage(_page);
            commonReasonPage = new CommonReasonPage(_page);
            finalDestinationPage = new FinalDestinationPage(_page);
            familyImmigrationStatusPage = new FamilyImmigrationStatusPage(_page);
        }

        [Given("I am on the UK visa checker website")]
        public async Task GivenIAmOnTheUKVisaCheckerWebsiteAsync()
        {
            await ukVisaCheckerPage.GoToSite();
        }

        [Given("I accept additional cookies")]
        public async Task GivenIAcceptAdditionalCookies()
        {
            await ukVisaCheckerPage.ClickAcceptCookies();
        }

        [Given("I click on the StartNow button")]
        public async Task GivenIClickOnTheStartNowButton()
        {
            await ukVisaCheckerPage.ClickStartNowButton();
        }

        [Then("page title should be {string}")]
        public async Task ThenPageTitleShouldBe(string expectedTitle)
        {
            await nationalitySelectionPage.AssertNationalityQuestionHeading(expectedTitle);
        }

        [When("I provide nationality {string}")]
        public async Task WhenIProvideNationality(string country)
        {
            await nationalitySelectionPage.FillCountry(country);
        }

        [Given(@"I click continue")]
        [When(@"I click continue")]
        [Then("I click continue")]
        public async Task WhenIClickContinue()
        {
            await commonContinuePage.ClickContinue();
        }

        [Given("I select reason {string}")]
        [When("I select reason {string}")]
        [Then("I select reason {string}")]
        public async Task WhenISelectReason(string res)
        {
            await commonReasonPage.SelectPurposeOfTravelling(res);
        }

        [Given("I check duration question {string}")]
        [When("I check duration question {string}")]
        [Then("I check duration question {string}")]
        public async Task WhenICheckDurationQuestion(string duration)
        {
            await plannedStudyDurationPage.ClickDuration(duration);
        }

        [Then("I should see {string}")]
        public async Task ThenIShouldSee(string expectedHeaderText)
        {
            var actualHeaderText = await informationPage.GetHeaderMsgText();
            Assert.That(actualHeaderText.Trim(), Is.EqualTo(expectedHeaderText));
        }

        [Then("I select {string}")]
        public async Task ThenISelect(string jobT)
        {
            await plannedJobTypes.ClickJobType(jobT);
        }

        [Then("information is displayed on {string}")]
        public async Task ThenInformationIsDisplayedOn(string expectedTexts)
        {
            await plannedJobTypes.AssertResultCard(expectedTexts.Split('|'));
        }

        [When("I select final destination {string}")]
        public async Task WhenISelectFinalDestination(string finalD)
        {
            await finalDestinationPage.ClickDestinationButton();
        }

        [Then("{string} is presented as a transit destination")]
        public async Task ThenIsPresentedAsATransitDestinationAsync(string dst)
        {
           await finalDestinationPage.AssertTransitDestination(dst);
        }

        [Then("I click {string} option immigration status question")]
        public void ThenIClickYesOptionImmigrationStatusQuestion(string option)
        {
            familyImmigrationStatusPage.ClickResponseOption(option).GetAwaiter().GetResult();
        }
    }
}