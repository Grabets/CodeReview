using System;
using OpenQA.Selenium;
using Stable2013.Core;
using Stable2013.Modules;

namespace Stable2013.PageObjects.Perfomance.Goals
{
    internal class EmployeeQuantitativeGoalFrame : AbstractGoalFrame
    {
        private const string NewFrameName = "Employee Quantitative Goals - New Item";
        private static readonly string BestValueXPath = new XPathBuilder().ByAttribute("title", "Best Value Required Field").Build();
        private static readonly string MaxResultPath = new XPathBuilder().ByAttribute("title", "Max Result").Build();
        private static readonly string TargetResultPath = new XPathBuilder().ByAttribute("title", "Target Result Required Field").Build();
        private static readonly string ActualResultPath = new XPathBuilder().ByAttribute("title", "Actual Result").Build();
        private static readonly string ThresholdResultPath = new XPathBuilder().ByAttribute("title", "Threshold").Build();
        private static readonly string SupportingActivitiesXPath = new XPathBuilder().ByAttribute("title", "Supporting Activities").Build();
        private static readonly string HowToMeasureXPath = new XPathBuilder().ByAttribute("title", "How To Measure").Build();
        private static readonly string FinalEvaluationXPath = new XPathBuilder().ByAttribute("title", "Final Evaluation").Build();


        protected EmployeeQuantitativeGoalFrame(IWebDriver driverArg) : base(driverArg)
        {
        }
        internal static EmployeeQuantitativeGoalFrame SwitchAndInit(IWebDriver driverArg)
        {
            driverArg.SwitchToFrameByName(NewFrameName);
            return new EmployeeQuantitativeGoalFrame(driverArg);
        }

        internal virtual string BestValue
        {
            get => GetSelectElement(BestValueXPath).SelectedOption.Text;
            set => GetSelectElement(BestValueXPath).SelectByValue(value);
        }


        internal string Status
        {
            get => GetSelectElement(StatusXPath).SelectedOption.Text;
            set => GetSelectElement(StatusXPath).SelectByValue(value);
        }

        internal string MaxResult
        {
            get => GetWebElement(MaxResultPath).Text;
            set => GetClearedElement(MaxResultPath).SendKeys(value);
        }
        internal virtual string TargetResult
        {
            get => GetWebElement(TargetResultPath).Text;
            set => GetClearedElement(TargetResultPath).SendKeys(value);
        }
        internal string ActualResult
        {
            get => GetWebElement(ActualResultPath).Text;
            set => GetClearedElement(ActualResultPath).SendKeys(value);
        }
        internal string ThresholdResult
        {
            get => GetWebElement(ThresholdResultPath).Text;
            set => GetClearedElement(ThresholdResultPath).SendKeys(value);
        }
        internal string SupportingActivities
        {
            get => GetWebElement(SupportingActivitiesXPath).Text;
            set => GetClearedElement(SupportingActivitiesXPath).SendKeys(value);
        }
        internal string HowToMeasure
        {
            get => GetWebElement(HowToMeasureXPath).Text;
            set => GetClearedElement(HowToMeasureXPath).SendKeys(value);
        }
        internal string FinalEvaluation
        {
            get => GetWebElement(FinalEvaluationXPath).Text;
            set => GetClearedElement(FinalEvaluationXPath).SendKeys(value);
        }
    }
}