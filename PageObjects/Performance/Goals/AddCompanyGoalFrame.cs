using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Stable2013.Core;
using Stable2013.Modules;
using Stable2013.Modules.Elements;

namespace Stable2013.PageObjects.Perfomance.Goals
{
    internal class AddCompanyGoalFrame : EmployeeQuantitativeGoalFrame
    {
        private static readonly string DueDateXPath = new XPathBuilder().ByAttribute("title", "Due Date Required Field").Build();
        private static readonly string IsQuantitativeXPath = new XPathBuilder().ByTag("input").WithAttribute("title", "Is Quantitative").Build();
        private static readonly string OrgUnitsXPath = new XPathBuilder().ByTag("table").WithIdContains("Departments").Build();
        private static readonly string SelectOrgUnitsXPath = ".//select[contains(@id, 'SelectCandidate')]";
        private static readonly string SelectedOrgUnitsXPath = ".//select[contains(@id, 'SelectResult')]";
        private static readonly string BestValueXPath = new XPathBuilder().ByAttribute("title", "Best Value").Build();
        private static readonly string TargetResultXPath = new XPathBuilder().ByAttribute("title", "Target Result").Build();
        private static readonly string PersentCompleteXPath = new XPathBuilder().ByAttribute("title", "Percent Complete").Build();


        private AddCompanyGoalFrame(IWebDriver driverArg) : base(driverArg)
        {
        }

        internal static AddCompanyGoalFrame Init(IWebDriver driver)
        {
            return new AddCompanyGoalFrame(driver);
        }

        internal override string DueDate
        {
            get => GetWebElement(DueDateXPath).Text;
            set => GetClearedElement(DueDateXPath).SendKeys(value);
        }

        internal override string BestValue
        {
            get => GetSelectElement(BestValueXPath).SelectedOption.Text;
            set => GetSelectElement(BestValueXPath).SelectByValue(value);
        }
        internal override string TargetResult
        {
            get => GetWebElement(TargetResultXPath).Text;
            set => GetClearedElement(TargetResultXPath).SendKeys(value);
        }

        internal string PersentComplete
        {
            get => GetWebElement(PersentCompleteXPath).Text;
            set => GetClearedElement(PersentCompleteXPath).SendKeys(value);
        }

        public void SelectOrgUnit(string orgUnitName)
        {
            MultiChoiceElement orgUnits = MultiChoiceElement.Init(driver, OrgUnitsXPath, SelectOrgUnitsXPath, SelectedOrgUnitsXPath);
            orgUnits.AddElement(new List<string>() { orgUnitName });
        }

        public void SetQuantitativeGoal()
        {
            //TODO: implement verification of checkboxState
            var quantitativeCheckbox = driver.GetByPath(IsQuantitativeXPath);
            quantitativeCheckbox.Click();
        }
        

    }

}