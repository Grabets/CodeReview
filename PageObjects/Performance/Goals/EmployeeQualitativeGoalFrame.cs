using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Stable2013.Core;
using Stable2013.Modules;

namespace Stable2013.PageObjects.Perfomance.Goals
{
    internal class EmployeeQualitativeGoalFrame : AbstractGoalFrame
    {
        private const string NewFrameName = "Employee Qualitative Goals - New Item";
        private static readonly string WeightXPath = new XPathBuilder().ByAttribute("title", "Weight Required Field").Build();
        private static readonly string PersentCompleteXPath = new XPathBuilder().ByAttribute("title", "Percent Complete Required Field").Build();
        private static readonly string KeyResultActivitiesXPath = new XPathBuilder().ByAttribute("title", "Key Result Activities").Build();
        private static readonly string KPIsXPath = new XPathBuilder().ByAttribute("title", "KPIs").Build();
        private static readonly string FinalEvaluationXPath = new XPathBuilder().ByAttribute("title", "Final Evaluation").Build();


        private EmployeeQualitativeGoalFrame(IWebDriver driverArg) : base(driverArg)
        {
        }
        internal static EmployeeQualitativeGoalFrame SwitchAndInit(IWebDriver driverArg)
        {
            driverArg.SwitchToFrameByName(NewFrameName);
            return new EmployeeQualitativeGoalFrame(driverArg);
        }

        internal string Status
        {
            get => GetSelectElement(StatusXPath).SelectedOption.Text;
            set => GetSelectElement(StatusXPath).SelectByValue(value);
        }
        internal override string Weight
        {
            get => GetWebElement(WeightXPath).Text;
            set => GetClearedElement(WeightXPath).SendKeys(value);
        }
        internal string PersentComplete
        {
            get => GetWebElement(PersentCompleteXPath).Text;
            set => GetClearedElement(PersentCompleteXPath).SendKeys(value);
        }
        internal string KeyResultActivities
        {
            get => GetWebElement(KeyResultActivitiesXPath).Text;
            set => GetClearedElement(KeyResultActivitiesXPath).SendKeys(value);
        }
        internal string KPIs
        {
            get => GetWebElement(KPIsXPath).Text;
            set => GetClearedElement(KPIsXPath).SendKeys(value);
        }
        internal string FinalEvaluation
        {
            get => GetWebElement(FinalEvaluationXPath).Text;
            set => GetClearedElement(FinalEvaluationXPath).SendKeys(value);
        }

    }
}