using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
namespace CalculatorEndToEndTests;


[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    //preq-E2E-TEST-5
    [Test]
    public async Task CalculatorWebUi_PageTitle_IsCalculator()
    {
        const string pageTitle = "Calculator";
        await Page.GotoAsync("http://localhost:5295/");

        // Expect a title to be Calculator
        await Expect(Page).ToHaveTitleAsync(pageTitle);
    }
    //preq-E2E-TEST-6
    [Test]
    public async Task CalculatorWebUi_ValidInputForSampleStdDev_ReturnsCorrectResult()
    {
        
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByLabel("inputBoxA").ClickAsync();
        await Page.GetByLabel("inputBoxA").FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Sample Standard" }).ClickAsync();
        // Expect a title to be Calculator
        Expect(Page.GetByText("3.0607876523260447"));
    }
    //preq-E2E-TEST-7
    [Test]
    public async Task CalculatorWebUi_EmptyInput_ReturnsErrorMessage()
    {
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Population Standard" }).ClickAsync();
        Expect (Page.GetByText("Invalid input"));
        
    }
    //preq-E2E-TEST-8
    [Test]
    public async Task CalculatorWebUi_OneInput_ReturnsErrorMessage()
    {
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear" }).ClickAsync();
        await Page.GetByLabel("inputBoxA").ClickAsync();
        await Page.GetByLabel("inputBoxA").FillAsync("1");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Sample Standard" }).ClickAsync();
        Expect (Page.GetByText("At least two values are"));
    }
    //preq-E2E-TEST-9
    [Test]
    public async Task CalculatorWebUi_ValidInputForMean_ReturnsCorrectResult()
    {
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear" }).ClickAsync();
        await Page.GetByLabel("inputBoxA").ClickAsync();
        await Page.GetByLabel("inputBoxA").FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4\n");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Mean | one value per" }).ClickAsync();
        Expect (Page.GetByText("7"));
    }
    //preq-E2E-TEST-10
    [Test]
    public async Task CalculatorWebUi_ValidInputForZScore_ReturnsCorrectResult()
    {
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear" }).ClickAsync();
        await Page.GetByLabel("inputBoxA").ClickAsync();
        await Page.GetByLabel("inputBoxA").FillAsync("5.5,7,3.060787652326");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Z Score | value, mean" }).ClickAsync();
        Expect (Page.GetByText("-0.49006993309715474"));
    }
    //preq-E2E-TEST-11
    [Test]
    public async Task CalculatorWebUi_ValidInputForSingleLinear_ReturnsCorrectResult()
    {
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear" }).ClickAsync();
        await Page.GetByLabel("inputBoxA").ClickAsync();
        await Page.GetByLabel("inputBoxA").FillAsync("5,3\n3,2\n2,15\n1,12.3\n7.5,-3\n4,5\n3,17\n4,3\n6.42,4\n34,5\n12,17\n3,-1");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Compute Single Linear" }).ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Table)).ToContainTextAsync("y = -0.045961532930936355x + 6.933587781374592");
    }
    //preq-E2E-TEST-12
    [Test]
    public async Task CalculatorWebUi_ValidInputForPredictY_ReturnsCorrectResult()
    {
        await Page.GotoAsync("http://localhost:5295/");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear" }).ClickAsync();
        await Page.GetByLabel("inputBoxA").ClickAsync();
        await Page.GetByLabel("inputBoxA").FillAsync("6,-0.04596,6.9336");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Predict Y from Linear" }).ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Table)).ToContainTextAsync("y= 6.65784");
    }
}