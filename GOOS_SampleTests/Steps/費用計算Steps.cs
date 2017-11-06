using System;
using System.Web.Mvc;
using AnnaAnimalChatWebSite.Model;
using FluentAssertions;
using NSubstitute;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    [Scope(Feature = "費用計算")]
    public class 費用計算Steps
    {
        private static BookingModel _model;

        [BeforeFeature]
        
        public static void BeforeFeature()
        {
            
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _model = new BookingModel();
        }


        [Given(@"選擇Line文字訊息")]
        public void Given選擇Line文字訊息()
        {
            _model.Chat = 1;
        }
        
        [Given(@"交談時數選 (.*) hr")]
        public void Given交談時數選Hr(float timeLength)
        {
            _model.Time = timeLength;
        }
        
        
        [Given(@"寵物狀態是往生小天使")]
        public void Given寵物狀態是往生小天使()
        {
            _model.PetStatusId = 2;
        }
        
        [Given(@"選擇面對面溝通")]
        public void Given選擇面對面溝通()
        {
            _model.Chat = 2;
        }
        
        [Given(@"選擇家訪")]
        public void Given選擇家訪()
        {
            _model.Chat = 3;
        }
        
        [When(@"計算費用")]
        public void When計算費用()
        {
            _model.CalculateFee();
        }
        
        [Then(@"應得到 (.*) 元")]
        public void Then應得到元(decimal fee)
        {
            _model.Fee.Should().Be(fee);
        }
    }
}
