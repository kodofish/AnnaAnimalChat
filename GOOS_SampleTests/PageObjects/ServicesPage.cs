using System;
using System.Reflection;
using FluentAutomation;
using GOOS_SampleTests.Steps.Common;

namespace GOOS_SampleTests.PageObjects
{
    public class ServicesPage : PageObject<ServicesPage>
    {
        
        public ServicesPage(FluentTest test) : base(test)
        {
            Url = $"{PageContext.ChatDomain}Services";
        }

        /// <summary>
        /// Fulls the name.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns></returns>
        public ServicesPage FullName(string fullName)
        {
            I.Enter(fullName).In("#Name");
            return this;
        }

        /// <summary>
        /// Lines the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        public ServicesPage LINE(string line)
        {
            I.Enter(line).In("#LINE");
            return this;
        }

        /// <summary>
        /// 輸入自稱
        /// </summary>
        /// <param name="nickName">Name of the nick.</param>
        /// <returns></returns>
        public ServicesPage Nickname(string nickName)
        {
            I.Enter(nickName).In("#NickName");
            return this;
        }

        /// <summary>
        /// 旁聽家人的全名
        /// </summary>
        /// <param name="familyName">Name of the family.</param>
        /// <returns></returns>
        public ServicesPage FamilyName(string familyName)
        {
            I.Enter(familyName).In("#FamilyName");
            return this;
        }


        /// <summary>
        /// Selects the pet status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public ServicesPage SelectStatus(string status)
        {
            I.Select(Option.Text, status).From("select[name='petStatus']");
            
            return this;
        }

        /// <summary>
        /// Selects the pet amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public ServicesPage SelectPetAmount(int amount)
        {
            I.Select(Option.Text, amount.ToString()).From("select[name='petAmount']");

            return this;
        }

        /// <summary>
        /// Enters the pet name a.
        /// </summary>
        /// <param name="PetName">Name of the pet.</param>
        /// <returns></returns>
        public ServicesPage EnterPetNameA(string PetName)
        {
            I.Enter(PetName).In("#AnimalNameA");

            return this;
        }

        /// <summary>
        /// Enters the pet name b.
        /// </summary>
        /// <param name="PetName">Name of the pet.</param>
        /// <returns></returns>
        public ServicesPage EnterPetNameB(string PetName)
        {
            I.Enter(PetName).In("#AnimalNameB");

            return this;
        }

        /// <summary>
        /// Uploads the pic for pet a.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public ServicesPage UploadPicForPetA(string fileName)
        {
            
            var virtualPath = $"{AssemblyExtenstions.AssemblyDirectory}\\Content\\{fileName}";
            I.Upload("#PicA", virtualPath);
            I.Press("{ENTER}");

            return this;
        }

        /// <summary>
        /// Uploads the pic for pet b.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public ServicesPage UploadPicForPetB(string fileName)
        {
            var virtualPath = $"{AssemblyExtenstions.AssemblyDirectory}\\Content\\{fileName}";
            I.Upload("#PicB", virtualPath);
            I.Press("{ENTER}");
            return this;
        }

        /// <summary>
        /// Selects the chat.
        /// </summary>
        /// <param name="chatWay">The chat way.</param>
        /// <returns></returns>
        public ServicesPage SelectChat(string chatWay)
        {
            I.Select(Option.Text, chatWay).From("select[name='chat']");

            return this;
        }

        /// <summary>
        /// Selects the lengthTime.
        /// </summary>
        /// <param name="lengthTime">The lengthTime.</param>
        /// <returns></returns>
        public ServicesPage SelectChatLength(string lengthTime)
        {
            I.Select(Option.Text, lengthTime).From("select[name='lengthTime']");

            return this;
        }

        /// <summary>
        /// Fees the should be.
        /// </summary>
        /// <param name="fee">The fee.</param>
        /// <returns></returns>
        public ServicesPage FeeShouldBe(string fee)
        {
            I.Assert.Text(fee).In("#fee");
            return this;
        }

        /// <summary>
        /// Selects the time period.
        /// </summary>
        /// <param name="Period">The period.</param>
        /// <returns></returns>
        public ServicesPage SelectTimePeriod(string Period)
        {
            I.Click($"#{Period}");
            return this;
        }



    }
}