﻿using FluentAutomation;

namespace GOOS_SampleTests.PageObjects
{
    public class ServicesPage : PageObject<ServicesPage>
    {
        
        public ServicesPage(FluentTest test) : base(test)
        {
            Url = $"{PageContext.ChatDomain}Services";
        }

        public ServicesPage FullName(string fullName)
        {
            I.Enter(fullName).In("#Name");
            return this;
        }

        public ServicesPage LINE(string line)
        {
            I.Enter(line).In("#LINE");
            return this;
        }

        public ServicesPage Nickname(string nickName)
        {
            I.Enter(nickName).In("#Nickname");
            return this;
        }

    }
}