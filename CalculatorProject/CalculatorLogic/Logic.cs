using Calculator;

public class Logic
{

    
       private static readonly CalculationResult Result = new CalculationResult();
       // Method to parse input string into a list of doubles.
       private List<double> ParseInput(string input)
       {
           var values = new List<double>();
           var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    
           foreach (var line in lines)
           {
               if (double.TryParse(line.Trim(), out var value))
               {
                   values.Add(value);
               }
               else
               {
                   throw new InvalidOperationException($"Invalid value '{line}' found. Please enter numeric values only.");
               }
           }

           return values;
       }
       // Method to parse input string into a list of tuples containing x and y pairs.
       private List<(double x, double y)> ParseXYInput(string input)
       {
           var values = new List<(double x, double y)>();
           var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

           foreach (var line in lines)
           {
               var parts = line.Split(',');
               if (parts.Length != 2)
               {
                   throw new InvalidOperationException($"Invalid line format '{line}'. Each line must contain exactly two comma-separated values (x, y).");
               }

               if (double.TryParse(parts[0].Trim(), out var x) && double.TryParse(parts[1].Trim(), out var y))
               {
                   values.Add((x, y));
               }
               else
               {
                   throw new InvalidOperationException($"Invalid values in line '{line}'. Please enter numeric values only.");
               }
           }

           return values;
       }
    private void ClearResult()
    {
        Result.Result = 0;
        Result.Operation = "";
        Result.Error = "";
        Result.IsSuccess = false;
        Result.IsSuccess2 = false;
    }

    public CalculationResult ComputeSampleStdDev(string input)
    {
        try
        {
            ClearResult();
            var values = ParseInput(input);
            if (values.Count < 2)
                throw new InvalidOperationException("At least two values are required to calculate the sample standard deviation.");

            var mean = values.Average();
            var variance = values.Sum(x => Math.Pow(x - mean, 2)) / (values.Count - 1);
            var stdDev = Math.Sqrt(variance);

            return new CalculationResult
            {
                Result = stdDev,
                IsSuccess = true,
                Operation = "Sample Standard Deviation"
            };
        }
        catch (Exception ex)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }

    public CalculationResult ComputePopDev(string input) {
        try
        {
            ClearResult();
            var values = ParseInput(input);
            if (values.Count < 2)
                throw new InvalidOperationException("At least two values are required to calculate the population standard deviation.");

            var mean = values.Average();
            var variance = values.Sum(x => Math.Pow(x - mean, 2)) / (values.Count);
            var stdDev = Math.Sqrt(variance);

            return new CalculationResult
            {
                Result = stdDev,
                IsSuccess = true,
                Operation = "Sample Standard Deviation"
            };
        }
        catch (Exception ex)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }

    public CalculationResult CalculateMean(string input)   {
        try
        {
            ClearResult();
            var values = ParseInput(input);
            if (values.Count == 0) throw new InvalidOperationException("No values provided.");

            var mean = values.Average();
            return new CalculationResult
            {
                Result = mean,
                IsSuccess = true,
                Operation = "Mean"
            };
        }
        catch (Exception ex)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }
    
    public CalculationResult ComputerZScore(string input) {
        try
        {
            ClearResult();
            var values = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(val => double.Parse(val.Trim()))
                .ToList();

            if (values.Count != 3)
            {
                throw new InvalidOperationException("Please enter exactly three values: x, mean, and stdDev, separated by commas.");
            }

            var x = values[0];
            var mean = values[1];
            var stdDev = values[2];

            if (stdDev == 0) throw new InvalidOperationException("Standard deviation cannot be zero.");

            // Calculate Z-Score
            var zScore = (x - mean) / stdDev;

            return new CalculationResult
            {
                Result = zScore,
                IsSuccess = true,
                Operation = "Z-Score"
            };
        }
        catch (Exception ex)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }

    public CalculationResult SingleLinearRegressionFormula(string input) {
        try
        {
            ClearResult();
            var xyPairs = ParseXYInput(input);
            if (xyPairs.Count < 2)
                throw new InvalidOperationException("At least two data points are required to calculate a linear regression.");

            // Calculate necessary sums
            double sumX = xyPairs.Sum(pair => pair.x);
            double sumY = xyPairs.Sum(pair => pair.y);
            double sumXY = xyPairs.Sum(pair => pair.x * pair.y);
            double sumXSquare = xyPairs.Sum(pair => Math.Pow(pair.x, 2));
            int n = xyPairs.Count;

            // Calculate slope (m) and intercept (b)
            double slope = (n * sumXY - sumX * sumY) / (n * sumXSquare - Math.Pow(sumX, 2));
            double intercept = (sumY - slope * sumX) / n;
            if (Double.IsNaN(slope))
            {
                throw new InvalidOperationException("Unable to calculate slope. Please check your data.");
            }
            return new CalculationResult
            {
                Result = slope,
                IsSuccess = true,
                IsSuccess2 = true,
                Operation = "Single Linear Regression Formula:",
                ResultString = $"y = {slope}x + {intercept}"
            };
        }
        catch (Exception ex)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }

    public CalculationResult YLinearRegressionFormula(string input) {
        ClearResult();
        try
        {
            // Split input string to extract x, m, b (all should be comma-separated)
            var values = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(val => double.Parse(val.Trim()))
                .ToList();

            if (values.Count != 3)
            {
                throw new InvalidOperationException("Please enter exactly three values: x, m, and b, separated by commas.");
            }

            var x = values[0];
            var m = values[1];
            var b = values[2];

            // Calculate y using the formula y = mx + b
            var y = m * x + b;

            return new CalculationResult
            {
                IsSuccess = true,
                IsSuccess2 = true,
                Result = y,
                Operation = "Single Linear Regression Prediction",
                ResultString = "y= "+y
            };
        }
        catch (Exception ex)
        {
            return new CalculationResult
            {
                IsSuccess = false,
                Error = ex.Message
            };
        }
    }
}
