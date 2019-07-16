# CodeReview

This repository contains files which related for one test feature.


Please note, that:
Before and After Scenario hooks located in the BaseSteps class. This class also create the IWebDriver variable.
The ChromeDriver starts when tag @chrome is present before scenario. In the other case the IE driver starts.
Some common steps which used in those scenarious is located in the CommonSteps.cs class.
The test precondition and postcondition is realized with using REST API or SQL Query for DB.