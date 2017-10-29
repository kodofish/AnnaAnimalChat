using System;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace AnnaAnimalChatWebSite.Tests.Steps.Common
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeFeature]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            var timespan = TimeSpan.FromMinutes(3);
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome, timespan );
        }
    }
}