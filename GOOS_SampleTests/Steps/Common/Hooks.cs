using System.Linq;
using FluentAutomation;

using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps.Common
{
    [Binding]
    public sealed class Hooks
    {
        public static IUnityContainer UnityContainer { get; set; }

        [BeforeFeature]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            CleanTableByTags();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CleanTableByTags();
        }

        /// <summary>
        ///     在Test hook 裡實作 Unity 進行依賴注入
        /// </summary>
        [BeforeTestRun]
        public static void RegisterDIContainer()
        {
            UnityContainer = new UnityContainer();
            
        }

        private static void CleanTableByTags()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));

            if (!tags.Any())
                return;

            //using (var dbcontext = new GOOSEntities())
            //{
            //    foreach (var tag in tags)
            //        dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");

            //    dbcontext.SaveChangesAsync();
            //}
        }
    }
}