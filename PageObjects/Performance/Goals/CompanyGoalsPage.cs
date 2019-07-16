using OpenQA.Selenium;
using Stable2013.Core;
using Stable2013.Modules;


namespace Stable2013.PageObjects.Perfomance.Goals
{
    public class CompanyGoalsPage
    {
        private static readonly string AddGoalXPath = new XPathBuilder().ByTag("td").WithIdContains("tdAssign").WithExactChildLookup().ByTag("a").Build();

        private static IWebDriver driver;

        private CompanyGoalsPage(IWebDriver driverArg)
        {
        }

        public static CompanyGoalsPage Init(IWebDriver driverArg)
        {
            driver = driverArg;
            driver.WaitFullLoad();
            return new CompanyGoalsPage(driverArg);
        }

        public static CompanyGoalsPage Open(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Pages.CompanyGoals);
            return new CompanyGoalsPage(driver);
        }

        internal AddCompanyGoalFrame AddCompanyGoalButtonClick()
        {
            driver.WaitFullLoad();
            var addGoalButton = driver.GetByPath(AddGoalXPath);
            addGoalButton.Click();
            driver.SwitchToFrameByName("Add Goal");
            return AddCompanyGoalFrame.Init(driver);
        }

        internal CompanyGoal InitQuantitativeGoal(string goalName)
        {
            return new CompanyGoal(goalName);
        }

        public struct CompanyGoal
        {
            private static readonly string GoalNameXPathTemplate = new XPathBuilder().ByTag("td").WithIdContains("DevActTitle").WithExactChildLookup().ByTag("a").WithText("{0}").Build();
            private static readonly string GoalAddInfoXPathTemplate = new XPathBuilder().ByXpathPart("/../..").ByTag("span").WithIdContains("{0}").Build();
            private static readonly string GoalStatusXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "lblDevStatus");
            private static readonly string GoalWeightXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Weight");
            private static readonly string GoalStartDateXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "DevStartDate");
            private static readonly string GoalEndDateXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "DueDate");
            private static readonly string GoalPersentCompleteXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "PercentComplete");
            private static readonly string QuantitiveGoalMaxResultXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label6");
            private static readonly string QuantitiveGoalTargetResultXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label8");
            private static readonly string QuantitiveGoalThresholdXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label10");
            private static readonly string QuantitiveGoalActualResultXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label12");
            private string goalName;


            public CompanyGoal(string goalName)
            {
                this.goalName = goalName;
            }

            public string GoalStatus
            {
                get
                {
                    string xPath = string.Format(GoalStatusXPath, goalName);
                    string message = $"No {goalName} goal is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string GoalWeight
            {
                get
                {
                    string xPath = string.Format(GoalWeightXPath, goalName);
                    string message = $"No {goalName} goal weight is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string GoalPersentComplete
            {
                get
                {
                    string xPath = string.Format(GoalPersentCompleteXPath, goalName);
                    string message = $"No {goalName} PersentComplete is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string GoalStartDate
            {
                get
                {
                    string xPath = string.Format(GoalStartDateXPath, goalName);
                    string message = $"No {goalName} goal StartDate is present";
                    return GetTextMethod(message, xPath);
                }
            }
            public string GoalEndDate
            {
                get
                {
                    string xPath = string.Format(GoalEndDateXPath, goalName);
                    string message = $"No {goalName} goal EndDate is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string QuantitativeGoalMaxResult
            {
                get
                {
                    string xPath = string.Format(QuantitiveGoalMaxResultXPath, goalName);
                    string message = $"No {goalName} quantitive goal is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string QuantitativeGoalTargetResult
            {
                get
                {
                    string xPath = string.Format(QuantitiveGoalTargetResultXPath, goalName);
                    string message = $"No {goalName} quantitive goal is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string QuantitativeGoalThreshold
            {
                get
                {
                    string xPath = string.Format(QuantitiveGoalThresholdXPath, goalName);
                    string message = $"No {goalName} quantitive goal is present";
                    return GetTextMethod(message, xPath);
                }
            }

            public string QuantitativeGoalActualResult
            {
                get
                {
                    string xPath = string.Format(QuantitiveGoalActualResultXPath, goalName);
                    string message = $"No {goalName} quantitive goal is present";
                    return GetTextMethod(message, xPath);
                }
            }

            private string GetTextMethod(string message, string xPath)
            {
                try
                {
                    var goalTextElement = driver.WaitForFindElement(By.XPath(xPath), 1);
                    return goalTextElement.Text;
                }
                catch (WebDriverTimeoutException)
                {
                    throw new NoSuchElementException(message);
                }
            }

        }

    }
}
