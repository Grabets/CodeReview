Feature: Goals

Background: 
	Given I verify that items in "Employee Qualitative Goals" list is deleted
	Given I verify that items in "Employee Quantitative Goals" list is deleted


@chrome
@Performance
Scenario: Employee create qualitative goal
	
	Given I Sign In as Manager

	When I open My goal page
	When I create qualitative goals
	Then I verify qualitative goals creation

	Given I verify that items in "Employee Qualitative Goals" list is deleted

@chrome	
@Performance
Scenario: Employee create quantitative goal

	Given I Sign In as Manager

	When I open My goal page
	When I create quantitative goals
	Then I verify quantitative goals creation

	Given I verify that items in "Employee Qualitative Goals" list is deleted

@Performance
Scenario: HR create quantitative company goal
	
	Given I verify that items in "Company Goals" list is deleted

	Given I Sign In as HR
	When I open company goals page
	When I schedule quantitative company goal
	Then I verify that quantitative company goal created on company goal page

	Given I Sign In as Manager
	Given I switch to Employee role
	When I open My goal page
	Then I verify that company goal applicable for employee

	Given I verify that items in "Company Goals" list is deleted

@sql
@Performance
Scenario: HR create qualitative company goal
	
	Given I verify that items in "Company Goals" list is deleted
	
	Given I Sign In as HR
	When I open company goals page
	When I schedule qualitative company goal
	Then I verify that qualitative company goal created on company goal page

	Given I Sign In as Manager
	Given I switch to Employee role
	When I open My goal page
	Then I verify that qualitative company goal applicable for employee

	Given I verify that items in "Company Goals" list is deleted