namespace Calculator;

//C#

public class CalculationResult {
    public double Result { get; set;} = 0.0;
    public bool IsSuccess { get; set; }
    public bool IsSuccess2 { get; set; } // for Linear Regression Formula
    public string? ResultString { get; set; } // for Linear Regression Formula
    public string? Operation { get; set; } // for example, "1.25 + 3.8 ="
    public string? Error { get; set; } // for example, "" or "Not A Number"
}