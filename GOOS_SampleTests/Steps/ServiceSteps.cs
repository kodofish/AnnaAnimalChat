using System;
using System.Threading;
using FluentAutomation;
using GOOS_SampleTests.PageObjects;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps
{

    [Scope(Feature = "預約服務")]
    [Binding]
    public class ServiceSteps : FluentTest
    {
        private readonly ServicesPage _servicePage;

        public ServiceSteps()
        {
            _servicePage = new ServicesPage(this);
        }

        [Given(@"開啟 ""to Book 來聊愛"" 頁面")]
        public void Given開啟頁面()
        {
            this._servicePage.Go();
        }


        [Given(@"我必須先填寫基本資料")]
        public void Given我必須先填寫基本資料(Table table)
        {
            var data = table.Rows[0];

            _servicePage.FullName(data["FullName"])
                .LINE(data["LineId"])
                .Nickname(data["Claim"])
                .FamilyName(data["Family"])
                .SelectStatus(data["AnimalStatus"])
                .SelectPetAmount(Convert.ToInt32(data["AnimalAmount"]))
                .EnterPetNameA(data["A_AnimalName"]).UploadPicForPetA(data["A_AnimalPic"])
                .EnterPetNameB(data["B_AnimalName"]).UploadPicForPetB(data["B_AnimalPic"]);
        }
        
        [Given(@"選擇聊天方式 ""(.*)"", 聊天時間 ""(.*)""")]
        public void Given選擇聊天方式聊天時間(string chatWay, string chatLength)
        {
            _servicePage.SelectChat(chatWay).SelectChatLength(chatLength);
        }
        
        [Given(@"預約的時段選擇 ""(.*)""")]
        public void Given預約的時段選擇(string Period)
        {
            _servicePage.SelectTimePeriod(Period);

            
        }
        
        [When(@"當我按下確認表單後")]
        public void When當我按下確認表單後()
        {
            _servicePage.SubmitForm();
        }
        
        [Then(@"應該能得到 ""(.*)"" 的訊息")]
        public void Then應該能得到的訊息(string text)
        {
            _servicePage.ShouldDisplay(text);
        }
    }
}
