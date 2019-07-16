using OpenQA.Selenium;
using Stable2013.Core;
using Stable2013.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stable2013.PageObjects.Perfomance.Goals
{
    public class MyGoalsPage
    {
        private static readonly string PersonalGoalsTabXPath = "//span[text()='Personal Goals']";
        private static readonly string OrgUnitGoalsTabXPath = "//span[text()='OrgUnit Goals']";
        private static readonly string CompanyGoalsTabXPath = "//span[text()='Company Goals']";

        private static IWebDriver driver;

        private MyGoalsPage(IWebDriver driverArg)
        {
            driver = driverArg;
        }

        public static MyGoalsPage Init(IWebDriver driverArg)
        {
            return new MyGoalsPage(driverArg);
        }

        public static MyGoalsPage Open(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Pages.MyGoalsPage);
            return new MyGoalsPage(driver);
        }

        public PersonalGoals PersonalGoalsTabClick()
        {
            Thread.Sleep(500);
            driver.WaitFullLoad();
            var personalGoalsTabElement = driver.WaitForFindElement(PersonalGoalsTabXPath);
            personalGoalsTabElement.Click();
            return new PersonalGoals();
        }

        public void CompanyGoalsTabClick()
        {
            driver.WaitFullLoad();
            var companyGoalsTabElement = driver.GetByPath(CompanyGoalsTabXPath);
            companyGoalsTabElement.Click();
        }

        public void OrgUnitGoalsTabClick()
        {
            driver.WaitFullLoad();
            var orgUnitGoalsTabElement = driver.GetByPath(OrgUnitGoalsTabXPath);
            orgUnitGoalsTabElement.Click();
        }

        public struct PersonalGoals
        {
            private static readonly string AssignQualitativeGoalButtonXPath = new XPathBuilder().ByTag("a").WithText(" Assign Qualitative Goal").Build();
            private static readonly string AssignQuantitativeGoalButtonXPath = new XPathBuilder().ByTag("a").WithText(" Assign Quantitative Goal").Build();
            private static readonly string TotalScoreLabelXPath = new XPathBuilder().ByTag("span").WithIdContains("TotalScore").Build();
            private static readonly string TotalWeightLabelXPath = new XPathBuilder().ByTag("span").WithIdContains("TotalWeight").Build();
            private static readonly string GoalNameXPathTemplate = new XPathBuilder().ByTag("span").WithIdContains("lblTitle").WithExactChildLookup().ByTag("a").WithText("{0}").Build();
            private static readonly string GoalStatusXPath = GoalNameXPathTemplate + "/../.." + new XPathBuilder().WithExactChildLookup().ByTag("span").WithIdContains("lblStatus").Build();
            private static readonly string GoalScoreXPath = GoalNameXPathTemplate + new XPathBuilder().ByXpathPart("/../../..").ByTag("span").WithIdContains("lblPercentComplete").Build();
            private static readonly string GoalAddInfoXPathTemplate = new XPathBuilder().ByXpathPart("/../../../following-sibling::div[1]").ByTag("span").WithIdContains("{0}").Build();
            private static readonly string GoalWeightXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Weight");
            private static readonly string GoalKeyResultActivitiesXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "SupportingActivities");
            private static readonly string GoalKPIsXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "HowToMeasure");
            private static readonly string GoalFinalEvaluationXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "FinalEvaluation");
            private static readonly string QuantitiveGoalMaxResultXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label6");
            private static readonly string QuantitiveGoalTargetResultXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label8");
            private static readonly string QuantitiveGoalThresholdXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label10");
            private static readonly string QuantitiveGoalActualResultXPath = GoalNameXPathTemplate + string.Format(GoalAddInfoXPathTemplate, "Label12");


            public string TotalScore
            {
                get
                {
                    var totalScoreElement = driver.GetByPath(TotalScoreLabelXPath);
                    var totalScore = totalScoreElement.Text.Replace("Total Score: ", "");
                    return totalScore;
                }
            }
            public string TotalWeight
            {
                get
                {
                    var totalWeightElement = driver.GetByPath(TotalWeightLabelXPath);
                    var totalWeight = totalWeightElement.Text.Replace("Total Weight: ", "");
                    return totalWeight;
                }
            }

            internal EmployeeQualitativeGoalFrame AssignQualitativeGoalButtonClick()
            {
                var buttonElement = driver.GetByPath(AssignQualitativeGoalButtonXPath);
                buttonElement.Click();
                return EmployeeQualitativeGoalFrame.SwitchAndInit(driver);
            }

            internal EmployeeQuantitativeGoalFrame AssignQuantitativeGoalButtonClick()
            {
                var buttonElement = driver.GetByPath(AssignQuantitativeGoalButtonXPath);
                buttonElement.Click();
                return EmployeeQuantitativeGoalFrame.SwitchAndInit(driver);
            }

            public string GetGoalStatus(string goalName)
            {
                string xPath = string.Format(GoalStatusXPath, goalName);
                string message = $"No {goalName} goal is present";
                return GetTextMethod(message, xPath);
            }

            public string GetGoalScore(string goalName)
            {
                string xPath = string.Format(GoalScoreXPath, goalName);
                string message = $"No {goalName} score is present";
                return GetTextMethod(message, xPath).Replace("Score: ", "");
            }
            public string GetGoalWeight(string goalName)
            {
                string xPath = string.Format(GoalWeightXPath, goalName);
                string message = $"No {goalName} weight is present";
                return GetTextMethod(message, xPath).Replace("Weight: ", "");
            }
            public string GetGoalKeyResultActivities(string goalName)
            {
                string xPath = string.Format(GoalKeyResultActivitiesXPath, goalName);
                string message = $"No {goalName} key result activities is present";
                return GetTextMethod(message, xPath).Replace("Key Result Activities: ", "");
            }
            public string GetGoalKeyKPIs(string goalName)
            {
                string xPath = string.Format(GoalKPIsXPath, goalName);
                string message = $"No {goalName} KPIs is present";
                return GetTextMethod(message, xPath).Replace("KPIs: ", "");
            }
            public string GetGoalKeyFinalEvaluation(string goalName)
            {
                string xPath = string.Format(GoalFinalEvaluationXPath, goalName);
                string message = $"No {goalName} final evaluation is present";
                return GetTextMethod(message, xPath).Replace("Final Evaluation: ", "");
            }
            public string GetQuantitativeGoalMaxResult(string goalName)
            {
                string xPath = string.Format(QuantitiveGoalMaxResultXPath, goalName);
                string message = $"No {goalName} quantitive goal is present";
                return GetTextMethod(message, xPath);
            }

            public string GetQuantitativeGoalTargetResult(string goalName)
            {
                string xPath = string.Format(QuantitiveGoalTargetResultXPath, goalName);
                string message = $"No {goalName} quantitive goal is present";
                return GetTextMethod(message, xPath);
            }

            public string GetQuantitativeGoalThreshold(string goalName)
            {
                string xPath = string.Format(QuantitiveGoalThresholdXPath, goalName);
                string message = $"No {goalName} quantitive goal is present";
                return GetTextMethod(message, xPath);
            }

            public string GetQuantitativeGoalActualResult(string goalName)
            {
                string xPath = string.Format(QuantitiveGoalActualResultXPath, goalName);
                string message = $"No {goalName} quantitive goal is present";
                return GetTextMethod(message, xPath);
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
