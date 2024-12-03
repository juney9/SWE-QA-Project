using Calculator;
using System.Text.RegularExpressions;
namespace CalculatorWebServerApp.Components.Pages;

public partial class Calculator
{
    private CalculationResult? _result = new CalculationResult();
    private string? _inputA;
    private string ResultStyle {
        get {
            if (_result == null || _result.IsSuccess) return "resultBox";
            return "resultError";
        }
    }
    
    // Method to test if our input contains anything but numbers, comma, dot, linebreak, or -.
    private bool TestInputValidity(string input) {
        string pattern = @"^[0-9\.\-\r?\n\,]+$";
        
        if (Regex.IsMatch(input, pattern)) {
            return true;
        }

        return false;
    }
    
   
    
    private readonly Logic _logic = new Logic();

    // Clears our result when loading the page to set the default state
    protected override void OnInitialized() {
        ClearResult();
    }

    // Clears our result, all visual changes are handled via HTML binding and embedded code
    private void ClearResult() {
        _result = null;
        _inputA = "";
    }
    
    // Helper method to quickly setup Invalid Input returns
    private CalculationResult InvalidInputCreator(string error) {
        return new CalculationResult {
            Result = 0,
            IsSuccess = false,
            Operation = "Invalid input",
            Error = error
        };
    }
    
    private void ComputeSampleStdDev()
    {
        if (TestInputValidity(_inputA)) {
            _result = _logic.ComputeSampleStdDev(_inputA);
        }

        else _result = InvalidInputCreator("Sample Standard Deviation format is one value per line");
    }

    private void ComputePopStdDev() {
        if (TestInputValidity(_inputA)) {
            _result = _logic.ComputePopDev(_inputA);
        }

        else _result = InvalidInputCreator("Population Standard Deviation format is one value per line");
    }

    private void ComputeMean() {
        if (TestInputValidity(_inputA)) {
            _result = _logic.CalculateMean(_inputA);
        }

        else _result = InvalidInputCreator($"Mean format is one value per line");
    }

    private void ComputeZScore() {
        if (TestInputValidity(_inputA)) {
            _result = _logic.ComputerZScore(_inputA);
        }

        else _result = InvalidInputCreator("Z score format is value, mean, stdDev in one line separated by commas");
    }

    private void ComputeSingleLinearRegression() {
        if (TestInputValidity(_inputA)) {
            _result = _logic.SingleLinearRegressionFormula(_inputA);
        }

        else _result = InvalidInputCreator("Linear Regression Format is one x,y pair per line");
    }

    private void ComputeYSingleLinearRegression() {
        if (TestInputValidity(_inputA)) {
            _result = _logic.YLinearRegressionFormula(_inputA);
        }

        else _result = InvalidInputCreator("Predict Y format is \"x,m,b\" on one line separated by commas");
    }
}