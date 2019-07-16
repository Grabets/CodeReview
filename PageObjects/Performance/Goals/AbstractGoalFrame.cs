using OpenQA.Selenium;
using Stable2013.Modules;


namespace Stable2013.PageObjects.Perfomance.Goals
{
    internal abstract class AbstractGoalFrame : AbstractFrame
    {
        protected static readonly string TitleXPath = new XPathBuilder().ByAttribute("title", "Title Required Field").Build();
        protected static readonly string StartDateXPath = new XPathBuilder().ByAttribute("title", "Start Date Required Field").Build();
        protected static readonly string StatusXPath = new XPathBuilder().ByAttribute("title", "Status Required Field").Build();
        private static readonly string WeightXPath = new XPathBuilder().ByAttribute("title", "Weight").Build();
        private static readonly string DueDateXPath = new XPathBuilder().ByAttribute("title", "Due Date").Build();


        protected AbstractGoalFrame(IWebDriver driverArg) : base(driverArg)
        {
        }

        internal string Title
        {
            get => GetWebElement(TitleXPath).Text;
            set => GetClearedElement(TitleXPath).SendKeys(value);
        }
        internal string StartDate
        {
            get => GetWebElement(StartDateXPath).Text;
            set => GetClearedElement(StartDateXPath).SendKeys(value);
        }

        internal virtual string Weight
        {
            get => GetWebElement(WeightXPath).Text;
            set => GetClearedElement(WeightXPath).SendKeys(value);
        }

        internal virtual string DueDate
        {
            get => GetWebElement(DueDateXPath).Text;
            set => GetClearedElement(DueDateXPath).SendKeys(value);
        }

    }
}
