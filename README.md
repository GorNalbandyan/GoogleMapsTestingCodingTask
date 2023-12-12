# Google Maps Automation Testing Solution
The Automation Testing Solution for Google Maps is a comprehensive framework designed to validate critical scenarios representing real-world use cases within the Google Maps application. 
This testing solution aims to ensure the  reliability of the searching functionality by automating key workflows and scenarios.

## Technology Stack

### Programming Language and Framework:
- C# 8: The primary programming language for the development of the automation testing framework.
- .NET 6: The framework is built on .NET 6, providing modern features and improved performance.

### External Main Packages:

- NUnit (Version 3.13.3): A unit testing framework for .NET.
- NUnit3TestAdapter (Version 4.5.0): An adapter for running NUnit tests in Visual Studio which facilitates the integration of NUnit tests into the Visual Studio testing environment.
- Selenium.WebDriver (Version 4.15.0): Enables interaction with web elements and browsers for automated testing.
- SpecFlow (Version 3.9.74): A behavior-driven development (BDD) framework for .NET which enables the creation of executable specifications using Gherkin language.

## Automation Framework Structure
The Google Maps Testing automation solution is organized into two main projects: **GoogleMapsTesting** and **GMapAPITesting**.

### GoogleMapsTesting Project
The GoogleMapsTesting project is structured with a modular and organized approach to ensure maintainability and scalability.
#### Helpers:  
Helpers folder plays a crucial role in facilitating the creation and execution of all test cases. It includes the following essential helper classes:
1. Hooks: Responsible for organizing before and after hooks efficiently, ensuring proper setup and teardown procedures for test execution.
2. BrowserHelper: Enables dynamic solutions to achieve cross-browser testing. This helper class manages browser-related configurations and interactions.
3. SettingsHelper: Allows interaction with .runsettings files. This helper class is instrumental in configuring and managing global settings and variables.
4. Logger: Creates logs for steps and actions, providing a detailed record of test execution. The logging mechanism enhances visibility and aids in troubleshooting.

#### Tests:
Test scenarios are expressed using .feature files, employing the Gherkin language to embrace Behavior-Driven Development (BDD) principles with the assistance of SpecFlow.
#### StepDefinitions: 
The StepDefinitions section provides the implementation of test cases outlined in the .feature files.
The inclusion of the BaseSteps class centralizes handling for drivers and loggers, with each step class inheriting these essential functionalities.
#### Pages
Adhering to the Page Object Model design pattern, the Pages section incorporates dedicated classes housing appropriate objects.
The BasePage class is introduced to streamline Selenium actions, enhancing efficiency and reducing development time for command additions.
Every page class inherits from BasePage, ensuring standardized waiting mechanisms and driver initialization are incorporated.

![BasePage](https://github.com/GorNalbandyan/GoogleMapsTestingCodingTaskForWooga/assets/61111839/e479e20f-4375-4d24-b6db-67d7ac709058)

### GMapAPITesting
GMapAPITesting has been developed to facilitate API-level testing. API test cases operate at a faster pace and a more granular level, enabling us to promptly receive feedback and detect issues in the early stages of development.
The framework is built upon the gmaps-api-net NuGet package (https://github.com/ericnewton76/gmaps-api-net) and adheres to its documentation. You'll discover foundational implementations of its methods designed specifically for testing purposes. While these implementations may not be functional due to the requirement for a Google Maps API Key, they provide a valuable structural foundation. Additionally, the framework exclusively utilizes NUnit, adding to its interest and simplicity.

## Setup Guide
To execute the test cases locally follow the steps outlined below. Ensure that you have Visual Studio 2022 installed on your machine before proceeding.

### Clone the Project:
- Open a terminal or command prompt.
- Execute the following command to clone the project from the GitHub repository to your local machine:
 ***git clone https://github.com/GorNalbandyan/GoogleMapsTestingCodingTaskForWooga.git***

### Open the Project with Visual Studio:
- Launch Visual Studio 2022.
- Choose "Open a project or solution" from the Visual Studio start page.
- Navigate to the directory where you cloned the project and select the solution file (.sln).

### Install NUnit3TestAdapter Extension:
- In Visual Studio, go to the "Extensions" menu.
- Select "Manage Extensions."
- In the "Extensions and Updates" window, switch to the "Online" tab.
- Search for "NUnit 3 Test Adapter" in the search bar.
- Locate and install the "NUnit 3 Test Adapter" extension.

### Install SpecFlow Extension:
- Do the first 3 steps of the previous action
- Search for "SpecFlow" in the search bar.
- Locate and install the "SpecFlow for Visual Studio" extension.

  ![image](https://github.com/GorNalbandyan/GoogleMapsTestingCodingTaskForWooga/assets/61111839/6bc7e830-8d3a-4267-9d1c-5622c1d5beaf)


## Running Tests

### Build the Solution:
Build the solution in Visual Studio to ensure that all dependencies are resolved. This step is crucial to prepare the testing environment and compile the necessary components for test execution.

### Select Test Settings(.runsseting file)
#### Purpose of .runsettings File:
The .runsettings file is utilized in our solution to control the testing environment and manage global variables such as tokens, URLs, and other configuration parameters.

#### Selecting the .runsettings File:
Before executing the tests, ensure you select the appropriate .runsettings file that corresponds to the desired testing environment:
- Open Visual Studio and navigate to the "Test" menu.
- Choose "Select Test Settings" and then "Select Test Settings File."
-Browse to the location of the relevant .runsettings file and select it.

![image](https://github.com/GorNalbandyan/GoogleMapsTestingCodingTaskForWooga/assets/61111839/dcfdfec2-8f1c-4f9f-8b69-a32b91eae5ed)

***This step is essential for configuring the testing environment accurately, and it ensures that tests run with the specified settings and configurations.***

### Execute Tests:
Open the "Test Explorer" Window:
- In Visual Studio, go to the "View" menu, select "Test Explorer" to open the Test Explorer window.
- The Test Explorer displays all available tests within the solution.
- Click "Run All Tests"
- In the Test Explorer window, click the "Run All Tests" button to initiate the execution of all tests in the solution. Or make right-click on a given test case and click run.

![image](https://github.com/GorNalbandyan/GoogleMapsTestingCodingTaskForWooga/assets/61111839/3b2c0301-95c3-4713-a612-594b9442b28c)


