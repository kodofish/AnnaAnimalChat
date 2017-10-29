using System;
using FluentAutomation;

namespace GOOS_SampleTests.PageObjects
{
    public class BudgetCreatePage : PageObject<BudgetCreatePage>
    {
        public BudgetCreatePage(FluentTest test) : base(test)
        {
            Url = $"{PageContext.Domain}/budget/add";
        }

        public BudgetCreatePage Amount(int amount)
        {
            I.Enter(amount.ToString()).In("#amount");
            return this;
        }

        public BudgetCreatePage Month(String yearMonth)
        {
            I.Enter(yearMonth).In("#month");
            return this;
        }

        public BudgetCreatePage AddBudget()
        {
            I.Click("input[type=\"submit\"]");
            return this;
        }

        public void ShouldDisplay(String message)
        {
            I.Assert.Text(message).In("#message");
        }
    }
}