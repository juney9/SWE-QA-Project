# KSU SWE 3643 Software Testing and Quality Assurance Semester Project: Web-Based Calculator
In this repository is is a web-based calculator built using C# and Blazor. NUnit is used for unit tests and
Playwright is used for end-to-end testing.

## Table of Contents
- [Environment](#environment)
- [Executing the Web Application](#executing-the-web-application)
- [Executing Unit Tests](#executing-unit-tests)
- [Reviewing Unit Test Coverage](#reviewing-unit-test-coverage)
- [Executing End-To-End Tests](#executing-end-to-end-tests)
- [Final Video Presentation](#final-video-presentation)

## Team Members
June Kim

## Architecture
This project uses C# and Blazor

All calculator logic are performed inside of the Calculator project, and the front-end HTML, CSS, and Blazor components are
inside the CalculatorWebServerApp project. 

NUnit was used to create unit tests for the calculator operations
and are stored within the CalculatorUnitTests project. 
Playwright was used to create end-to-end 
tests for the server and UI components.

![System Architecture Diagram](https://i.imgur.com/DEEBtr4.png)

## Environment
This is a cross-platform application and should work in Windows 10+, Mac OSx Ventura+, and various Linux 
environments. Note that the application has only been carefully tested in Windows 11.

To prepare your environment to execute this application:
* Install the [latest .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) for your operating system. This project used 9.0.
* Install the [latest version of git](https://git-scm.com/download/win) for your operating system.
* Open a terminal and navigate to your desired location to clone the repository to.

`cd <your desired directory> ... (E.g. C:\Users\user\example)`
  
* Clone the repository.

`git clone https://github.com/juney9/SWE-QA-Project.git`

To configure Playwright for end-to-end testing:
* Open up a terminal and navigate to the repository's main project folder.

`cd <directory>\SWE-QA-Project\CalculatorProject`

* Build the project.

`dotnet build`

* Navigate to the repository's CalculatorPlaywrightTests folder.

`cd CalculatorPlaywrightTests`

* Install the required Playwright browsers (for Windows).

`pwsh bin/Debug/net9.0/playwright.ps1 install`

* __NOTE: If you do not have Powershell installed, install it using the following command:__

`winget install --id Microsoft.Powershell --source winget`

## Executing the Web Application
To execute the web application: 

* Open up a terminal and navigate to the repository's CalculatorWebServerApp folder.

`cd <directory>\SWE-QA-Project\CalculatorProject\CalculatorWebServerApp`

* Run the application.

`dotnet run`

* Upon a successful run, your console should output the following:
```
$ dotnet run
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5295
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\hi6go\Documents\GitHub\SWE-QA-Project\CalculatorProject\CalculatorWebServerApp

```

* Navigate to `http://localhost:5295` in your browser.

## Executing Unit Tests
To execute the unit tests:

* Open up a terminal and navigate to the CalculatorLogicUnitTests folder.

`cd <directory>\SWE3643_Project\CalculatorLogicUnitTests`

* Run the tests.

`dotnet test`

* Upon a successful run, your console should output the following:
```
dotnet test
Restore complete (0.2s)
  CalculatorLogic succeeded (0.1s) → C:\Users\hi6go\Documents\GitHub\SWE-QA-Project\CalculatorProject\CalculatorLogic\bin\Debug\net9.0\CalculatorLogic.dll
  CalculatorLogicUnitTests succeeded (0.1s) → bin\Debug\net9.0\CalculatorLogicUnitTests.dll
NUnit Adapter 4.6.0.0: Test execution started
Running all tests in C:\Users\hi6go\Documents\GitHub\SWE-QA-Project\CalculatorProject\CalculatorLogicUnitTests\bin\Debug\net9.0\CalculatorLogicUnitTests.dll
   NUnit3TestExecutor discovered 22 of 22 NUnit test cases using Current Discovery mode, Non-Explicit run
NUnit Adapter 4.6.0.0: Test execution complete
  CalculatorLogicUnitTests test succeeded (0.5s)

Test summary: total: 22, failed: 0, succeeded: 22, skipped: 0, duration: 0.5s
Build succeeded in 1.1s
```

## Reviewing Unit Test Coverage
![Coverage Statistics](https://i.imgur.com/UfiHPSZ.png)
I was not successful with Coverage Tests.

## Executing End-To-End Tests
* With the web server app already running, open up a terminal and navigate to the CalculatorEndToEndTests folder.

`cd <directory>\SWE-QA-Project\CalculatorProject\CalculatorEndToEndTests`

* Run the tests.

`dotnet test`

* Upon a successful run, your console should output the following:
```
Restore succeeded with 1 warning(s) in 0.1s
    C:\Users\hi6go\Documents\GitHub\SWE-QA-Project\CalculatorProject\CalculatorEndToEndTests\CalculatorEndToEndTests.csproj : warning NU1903: Package 'System.Text.Json' 6.0.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-8g4q-xg66-9fp4
  CalculatorEndToEndTests succeeded with 1 warning(s) (0.3s) → bin\Debug\net9.0\CalculatorEndToEndTests.dll
    C:\Users\hi6go\Documents\GitHub\SWE-QA-Project\CalculatorProject\CalculatorEndToEndTests\CalculatorEndToEndTests.csproj : warning NU1903: Package 'System.Text.Json' 6.0.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-8g4q-xg66-9fp4
NUnit Adapter 4.6.0.0: Test execution started
Running all tests in C:\Users\hi6go\Documents\GitHub\SWE-QA-Project\CalculatorProject\CalculatorEndToEndTests\bin\Debug\net9.0\CalculatorEndToEndTests.dll
   NUnit3TestExecutor discovered 8 of 8 NUnit test cases using Current Discovery mode, Non-Explicit run
NUnit Adapter 4.6.0.0: Test execution complete
  CalculatorEndToEndTests test succeeded (7.0s)

Test summary: total: 8, failed: 0, succeeded: 8, skipped: 0, duration: 7.0s
Build succeeded with 2 warning(s) in 7.7s
```


## Final Video Presentation
[![Video Link](https://upload.wikimedia.org/wikipedia/commons/0/09/YouTube_full-color_icon_%282017%29.svg)](https://youtu.be/YyUSFXV9sag)