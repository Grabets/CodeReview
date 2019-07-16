using NUnit.Framework;
using Stable2013.Core;
using Stable2013.PageObjects.Perfomance.Goals;
using System;
using TechTalk.SpecFlow;

namespace Stable2013.Scenarios.Perfomance
{
    [Binding]
    public class GoalsSteps : BaseSteps
    {
        private const string GoalKeyResultActivities = "You should be motivated to perform your goal";
        private const string GoalKPIs = "Performance; Good Mood";
        private const string FinalEvaluation = "Exellent ! @ #";

        private readonly string[] TitleQualitativeGoal = new string[] { "First qualitative goal", "Second qualitative goal" };
        private readonly string[] StatusQualitativeGoal = new string[] { "2 - In Process", "1 - Not Started" };
        private readonly string[] WeightQualitativeGoal = new string[] { "50", "50" };
        private readonly string[] PersentCompleteQualitativeGoal = new string[] { "50", "25" };

        private readonly string[] TitleQuantitativeGoal = new string[] { "First quantitative goal", "Second quantitative goal", "Third quantitative goal", "Fourth quantitative goal" };
        private readonly string[] TargetForQuantitativeGoal = new string[] { "8", "8", "4", "1" };
        private readonly string[] ActualResultForQuantitativeGoal = new string[] { "4", "9", "6", "2" };
        private readonly string[] BestValueQuantitativeGoal = new string[] { "More", "More", "Less", "Less" };
        private readonly string[] WeightQuantitativeGoal = new string[] { "50", "20", "10", "10" };
        private readonly string[] MaxResultForQuantitativeGoal = new string[] { "10", "10", "0", "0" };
        private readonly string[] ThresholdQuantitativeGoal = new string[] { "3", "3", "3", "3" };

        private readonly string StartGoalTime = new DateTime(DateTime.Now.Year, 1, 1).ToString("MM/dd/yyyy");
        private readonly string EndGoalTime = new DateTime(DateTime.Now.Year, 12, 31).ToString("MM/dd/yyyy");

        private decimal overallTotalScore = 0;
        private decimal overalTotalWeight = 0;

        private MyGoalsPage myGoalsPage;
        private MyGoalsPage.PersonalGoals personalGoals;
        private CompanyGoalsPage companyGoalsPage;

        #region When
        [When(@"I open My goal page")]
        public void WhenIOpenMyGoalPage()
        {
            myGoalsPage = MyGoalsPage.Open(CurrentDriver);
            personalGoals = myGoalsPage.PersonalGoalsTabClick();
        }

        [When(@"I open company goals page")]
        public void WhenIOpenCompanyGoalsPage()
        {
            companyGoalsPage = CompanyGoalsPage.Open(CurrentDriver);
        }

        [When(@"I schedule quantitative company goal")]
        public void WhenIScheduleCompanyGoal()
        {
            for (int i = 0; i < TitleQuantitativeGoal.Length; i++)
            {
                companyGoalsPage = CompanyGoalsPage.Init(CurrentDriver);
                AddCompanyGoalFrame addCompanyGoal = companyGoalsPage.AddCompanyGoalButtonClick();
                addCompanyGoal.Title = AddCompanyValueToTheGoalTitle(TitleQuantitativeGoal[i]);
                addCompanyGoal.StartDate = StartGoalTime;
                addCompanyGoal.DueDate = EndGoalTime;
                addCompanyGoal.Weight = WeightQuantitativeGoal[i];
                addCompanyGoal.SetQuantitativeGoal();
                addCompanyGoal.BestValue = BestValueQuantitativeGoal[i];
                addCompanyGoal.MaxResult = MaxResultForQuantitativeGoal[i];
                addCompanyGoal.TargetResult = TargetForQuantitativeGoal[i];
                addCompanyGoal.ThresholdResult = ThresholdQuantitativeGoal[i];
                addCompanyGoal.ActualResult = ActualResultForQuantitativeGoal[i];
                addCompanyGoal.SelectOrgUnit("Quality Control");
                addCompanyGoal.SaveButtonClick();
            }
        }

        [When(@"I schedule qualitative company goal")]
        public void WhenIScheduleQualitativeCompanyGoal()
        {
            for (int i = 0; i < TitleQualitativeGoal.Length; i++)
            {
                companyGoalsPage = CompanyGoalsPage.Init(CurrentDriver);
                AddCompanyGoalFrame addCompanyGoal = companyGoalsPage.AddCompanyGoalButtonClick();
                addCompanyGoal.Title = AddCompanyValueToTheGoalTitle(TitleQualitativeGoal[i]);
                addCompanyGoal.StartDate = StartGoalTime;
                addCompanyGoal.DueDate = EndGoalTime;
                addCompanyGoal.Weight = WeightQualitativeGoal[i];
                addCompanyGoal.PersentComplete = PersentCompleteQualitativeGoal[i];
                addCompanyGoal.SelectOrgUnit("Quality Control");
                addCompanyGoal.SaveButtonClick();
            }
        }


        [When(@"I create qualitative goals")]
        public void WhenICreateQualitativeGoals()
        {
            for (int i = 0; i < TitleQualitativeGoal.Length; i++)
            {
                EmployeeQualitativeGoalFrame employeeQualitativeGoalFrame = personalGoals.AssignQualitativeGoalButtonClick();
                employeeQualitativeGoalFrame.Title = TitleQualitativeGoal[i];
                employeeQualitativeGoalFrame.StartDate = StartGoalTime;
                employeeQualitativeGoalFrame.Status = StatusQualitativeGoal[i];
                employeeQualitativeGoalFrame.Weight = WeightQualitativeGoal[i];
                employeeQualitativeGoalFrame.PersentComplete = PersentCompleteQualitativeGoal[i];
                employeeQualitativeGoalFrame.KeyResultActivities = GoalKeyResultActivities;
                employeeQualitativeGoalFrame.KPIs = GoalKPIs;
                employeeQualitativeGoalFrame.FinalEvaluation = FinalEvaluation;
                employeeQualitativeGoalFrame.SaveButtonClick();
                myGoalsPage = MyGoalsPage.Init(CurrentDriver);
                personalGoals = myGoalsPage.PersonalGoalsTabClick();
            }
        }

        [When(@"I create quantitative goals")]
        public void WhenICreateQuantitativeGoals()
        {
            for (int i = 0; i < TitleQuantitativeGoal.Length; i++)
            {
                EmployeeQuantitativeGoalFrame employeeQuantitativeGoalFrame = personalGoals.AssignQuantitativeGoalButtonClick();
                employeeQuantitativeGoalFrame.Title = TitleQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.BestValue = BestValueQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.StartDate = StartGoalTime;
                employeeQuantitativeGoalFrame.MaxResult = MaxResultForQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.TargetResult = TargetForQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.ThresholdResult = ThresholdQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.ActualResult = ActualResultForQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.Weight = WeightQuantitativeGoal[i];
                employeeQuantitativeGoalFrame.Status = StatusQualitativeGoal[1];
                employeeQuantitativeGoalFrame.SaveButtonClick();
                myGoalsPage = MyGoalsPage.Init(CurrentDriver);
                personalGoals = myGoalsPage.PersonalGoalsTabClick();
            }
        }

        #endregion

        #region Then

        [Then(@"I verify qualitative goals creation")]
        public void ThenIVerifyQualitativeGoalsCreation()
        {
            ResetTotalWeightAndScore();
            for (int i = 0; i < TitleQualitativeGoal.Length; i++)
            {
                CountQualitativeGoalScoreAndWeight(i);
                Assert.Multiple(() =>
                {
                    Assert.That(personalGoals.GetGoalStatus(TitleQualitativeGoal[i]), Is.EqualTo(StatusQualitativeGoal[i].ToUpper()));
                    Assert.That(personalGoals.GetGoalWeight(TitleQualitativeGoal[i]), Is.EqualTo(GetStringWithPersentage(WeightQualitativeGoal[i])));
                    Assert.That(personalGoals.GetGoalScore(TitleQualitativeGoal[i]), Is.EqualTo(GetStringWithPersentage(PersentCompleteQualitativeGoal[i])));
                    Assert.That(personalGoals.GetGoalKeyResultActivities(TitleQualitativeGoal[i]), Is.EqualTo(GoalKeyResultActivities));
                    Assert.That(personalGoals.GetGoalKeyKPIs(TitleQualitativeGoal[i]), Is.EqualTo(GoalKPIs));
                    Assert.That(personalGoals.GetGoalKeyFinalEvaluation(TitleQualitativeGoal[i]), Is.EqualTo(FinalEvaluation));
                });
            }
            Assert.That(personalGoals.TotalScore, Is.EqualTo(GetTwoPointPersentValue(overallTotalScore)));
            Assert.That(personalGoals.TotalWeight, Is.EqualTo(GetTwoPointPersentValue(overalTotalWeight)));
        }

        [Then(@"I verify quantitative goals creation")]
        public void ThenIVerifyQuantitativeGoalsCreation()
        {
            for (int i = 0; i < TitleQuantitativeGoal.Length; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(personalGoals.GetGoalStatus(TitleQuantitativeGoal[i]), Is.EqualTo(StatusQualitativeGoal[1].ToUpper()));
                    Assert.That(personalGoals.GetGoalWeight(TitleQuantitativeGoal[i]), Is.EqualTo(GetStringWithPersentage(WeightQuantitativeGoal[i])));
                    Assert.That(personalGoals.GetQuantitativeGoalMaxResult(TitleQuantitativeGoal[i]), Is.EqualTo(MaxResultForQuantitativeGoal[i]));
                    Assert.That(personalGoals.GetQuantitativeGoalThreshold(TitleQuantitativeGoal[i]), Is.EqualTo(ThresholdQuantitativeGoal[i]));
                    Assert.That(personalGoals.GetQuantitativeGoalTargetResult(TitleQuantitativeGoal[i]), Is.EqualTo(TargetForQuantitativeGoal[i]));
                    Assert.That(personalGoals.GetQuantitativeGoalActualResult(TitleQuantitativeGoal[i]), Is.EqualTo(ActualResultForQuantitativeGoal[i]));
                    Assert.That(personalGoals.GetGoalScore(TitleQuantitativeGoal[i]), Is.EqualTo(EvaluateQuantitativeScore(i)));
                });
                overalTotalWeight += decimal.Parse(WeightQuantitativeGoal[i]);
                overallTotalScore += decimal.Parse(EvaluateQuantitativeScore(i).Replace("%", "")) * decimal.Parse(WeightQuantitativeGoal[i]) / 100;
            }
            Assert.Multiple(() =>
            {
                Assert.That(personalGoals.TotalScore, Is.EqualTo(GetTwoPointPersentValue(overallTotalScore)));
                Assert.That(personalGoals.TotalWeight, Is.EqualTo(GetTwoPointPersentValue(overalTotalWeight)));
            });
        }

        [Then(@"I verify that quantitative company goal created on company goal page")]
        public void ThenIVerifyThatCompanyGoalCreatedOnCompanyGoalPage()
        {
            companyGoalsPage = CompanyGoalsPage.Init(CurrentDriver);

            for (int i = 0; i < TitleQuantitativeGoal.Length; i++)
            {
                CompanyGoalsPage.CompanyGoal quantitativeGoal = companyGoalsPage.InitQuantitativeGoal(AddCompanyValueToTheGoalTitle(TitleQuantitativeGoal[i]));
                AssertForQuantitativeCompanyGoals(i, quantitativeGoal);
            }
        }

        [Then(@"I verify that qualitative company goal created on company goal page")]
        public void ThenIVerifyThatQualitativeCompanyGoalCreatedOnCompanyGoalPage()
        {
            companyGoalsPage = CompanyGoalsPage.Init(CurrentDriver);
            for (int i = 0; i < TitleQualitativeGoal.Length; i++)
            {
                Assert.Multiple(() =>
                {
                    CompanyGoalsPage.CompanyGoal qualitativeGoal = companyGoalsPage.InitQuantitativeGoal(AddCompanyValueToTheGoalTitle(TitleQualitativeGoal[i]));
                    AssertsForQualitativeCompanyGoals(i, qualitativeGoal);
                });
            }
        }

        private void AssertsForQualitativeCompanyGoals(int i, CompanyGoalsPage.CompanyGoal qualitativeGoal)
        {
            Assert.That(qualitativeGoal.GoalStatus, Is.EqualTo("Active"));
            Assert.That(qualitativeGoal.GoalWeight, Is.EqualTo(GetStringWithPersentage(WeightQualitativeGoal[i])));
            Assert.That(qualitativeGoal.GoalStartDate, Is.EqualTo(StartGoalTime));
            Assert.That(qualitativeGoal.GoalEndDate, Is.EqualTo(EndGoalTime));
            Assert.That(qualitativeGoal.GoalPersentComplete, Is.EqualTo(GetStringWithPersentage(PersentCompleteQualitativeGoal[i])));
        }

        private void AssertForQuantitativeCompanyGoals(int i, CompanyGoalsPage.CompanyGoal quantitativeGoal)
        {
            Assert.Multiple(() =>
            {
                Assert.That(quantitativeGoal.GoalStatus, Is.EqualTo("Active"));
                Assert.That(quantitativeGoal.GoalWeight, Is.EqualTo(GetStringWithPersentage(WeightQuantitativeGoal[i])));
                Assert.That(quantitativeGoal.GoalStartDate, Is.EqualTo(StartGoalTime));
                Assert.That(quantitativeGoal.GoalEndDate, Is.EqualTo(EndGoalTime));
                Assert.That(quantitativeGoal.GoalPersentComplete, Is.EqualTo(EvaluateQuantitativeScore(i)));
                Assert.That(quantitativeGoal.QuantitativeGoalMaxResult, Is.EqualTo(MaxResultForQuantitativeGoal[i]));
                Assert.That(quantitativeGoal.QuantitativeGoalTargetResult, Is.EqualTo(TargetForQuantitativeGoal[i]));
                Assert.That(quantitativeGoal.QuantitativeGoalThreshold, Is.EqualTo(ThresholdQuantitativeGoal[i]));
                Assert.That(quantitativeGoal.QuantitativeGoalActualResult, Is.EqualTo(ActualResultForQuantitativeGoal[i]));
            });
        }

        [Then(@"I verify that company goal applicable for employee")]
        public void ThenIVerifyThatCompanyGoalApplicableForEmployee()
        {
            myGoalsPage.CompanyGoalsTabClick();
            for (int i = 0; i < TitleQuantitativeGoal.Length; i++)
            {
                CompanyGoalsPage.CompanyGoal quantitativeGoal = new CompanyGoalsPage.CompanyGoal(AddCompanyValueToTheGoalTitle(TitleQuantitativeGoal[i]));
                AssertForQuantitativeCompanyGoals(i, quantitativeGoal);
            }
        }

        [Then(@"I verify that qualitative company goal applicable for employee")]
        public void ThenIVerifyThatQualitativeCompanyGoalApplicableForEmployee()
        {
            myGoalsPage.CompanyGoalsTabClick();
            for (int i = 0; i < TitleQualitativeGoal.Length; i++)
            {
                CompanyGoalsPage.CompanyGoal qualitativeGoal = new CompanyGoalsPage.CompanyGoal(AddCompanyValueToTheGoalTitle(TitleQualitativeGoal[i]));
                AssertsForQualitativeCompanyGoals(i, qualitativeGoal);
            }
        }

        private string GetTwoPointPersentValue(decimal value)
        {
            return string.Format("{0:0.00}%", value);
        }

        private string AddCompanyValueToTheGoalTitle(string title)
        {
            return "Company " + title;
        }

        private string EvaluateQuantitativeScore(int i)
        {
            if (GetDecimalFromString(ActualResultForQuantitativeGoal[i]) == 0)
            {
                return GetTwoPointPersentValue(0);
            }
            if (BestValueQuantitativeGoal[i].Equals("More"))
            {
                if (GetDecimalFromString(ThresholdQuantitativeGoal[i]) != 0 & GetDecimalFromString(ActualResultForQuantitativeGoal[i]) <= GetDecimalFromString(ThresholdQuantitativeGoal[i]))
                {
                    return GetTwoPointPersentValue(0);
                }
                else
                if (GetDecimalFromString(ActualResultForQuantitativeGoal[i]) <= GetDecimalFromString(TargetForQuantitativeGoal[i]) || GetDecimalFromString(ActualResultForQuantitativeGoal[i]) <= GetDecimalFromString(MaxResultForQuantitativeGoal[i]))
                {
                    if (GetDecimalFromString(TargetForQuantitativeGoal[i]) > 0)
                    {
                        decimal score = GetDecimalFromString(ActualResultForQuantitativeGoal[i]) / GetDecimalFromString(TargetForQuantitativeGoal[i]);
                        return GetTwoPointPersentValue(score * 100);
                    }
                    else
                    {
                        return GetTwoPointPersentValue(0);
                    }
                }
                else
                {
                    if (GetDecimalFromString(TargetForQuantitativeGoal[i]) > 0)
                    {
                        if (GetDecimalFromString(MaxResultForQuantitativeGoal[i]) > 0)
                        {
                            decimal score = GetDecimalFromString(MaxResultForQuantitativeGoal[i]) / GetDecimalFromString(TargetForQuantitativeGoal[i]);
                            return GetTwoPointPersentValue(score * 100);
                        }
                        else
                        {
                            decimal score = GetDecimalFromString(ActualResultForQuantitativeGoal[i]) / GetDecimalFromString(TargetForQuantitativeGoal[i]);
                            return GetTwoPointPersentValue(score * 100);
                        }
                    }
                    else
                    {
                        return GetTwoPointPersentValue(0);
                    }
                }
            }
            else
            {
                if (GetDecimalFromString(ThresholdQuantitativeGoal[i]) == 0)
                {
                    if (GetDecimalFromString(ActualResultForQuantitativeGoal[i]) <= GetDecimalFromString(TargetForQuantitativeGoal[i]))
                    {
                        return GetTwoPointPersentValue(1 * 100);
                    }
                    else
                    {
                        return GetTwoPointPersentValue(0);
                    }
                }
                else
                {
                    if (GetDecimalFromString(TargetForQuantitativeGoal[i]) == GetDecimalFromString(ThresholdQuantitativeGoal[i]))
                    {
                        return GetTwoPointPersentValue(0);
                    }
                    else
                    {
                        if (GetDecimalFromString(ActualResultForQuantitativeGoal[i]) >= GetDecimalFromString(ThresholdQuantitativeGoal[i]))
                        {
                            return GetTwoPointPersentValue(0);
                        }
                        else
                        {
                            if (GetDecimalFromString(ActualResultForQuantitativeGoal[i]) >= GetDecimalFromString(MaxResultForQuantitativeGoal[i]))
                            {
                                decimal score = (GetDecimalFromString(ThresholdQuantitativeGoal[i]) - GetDecimalFromString(ActualResultForQuantitativeGoal[i])) / (GetDecimalFromString(ThresholdQuantitativeGoal[i]) - GetDecimalFromString(TargetForQuantitativeGoal[i]));
                                return GetTwoPointPersentValue(score * 100);
                            }
                            else
                            {
                                decimal score = (GetDecimalFromString(ThresholdQuantitativeGoal[i]) - GetDecimalFromString(MaxResultForQuantitativeGoal[i])) / (GetDecimalFromString(ThresholdQuantitativeGoal[i]) - GetDecimalFromString(TargetForQuantitativeGoal[i]));
                                return GetTwoPointPersentValue(score * 100);
                            }
                        }
                    }
                }
            }
        }

        private string GetStringWithPersentage(string value)
        {
            return value + ".00%";
        }

        private void ResetTotalWeightAndScore()
        {
            overallTotalScore = 0;
            overalTotalWeight = 0;
        }

        private decimal GetDecimalFromString(string value)
        {
            return decimal.Parse(value);
        }

        private void CountQualitativeGoalScoreAndWeight(int i)
        {
            decimal goalScore = decimal.Parse(PersentCompleteQualitativeGoal[i]) * decimal.Parse(WeightQualitativeGoal[i]) / 100;
            overallTotalScore += goalScore;
            overalTotalWeight += decimal.Parse(WeightQualitativeGoal[i]);
        }
        #endregion


    }
}
