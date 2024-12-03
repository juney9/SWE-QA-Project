using NUnit.Framework.Legacy;

namespace Tests;

public class SampleStdDevTests
{
    private Logic _logic;

    [SetUp]
    public void Setup()
    {
        _logic = new Logic();
    }

    [Test]
    public void ComputeSampleStdDev_ValidList_ReturnsCorrectStdDev()
    {
        //preq-UNIT-TEST-2

        // Arrange
        var input = "5\n10\n15\n20";

        // Act
        var result = _logic.ComputeSampleStdDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Sample Standard Deviation"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.InRange(6.45, 6.46)); // Expected standard deviation is about 6.45497
        });
        Assert.Pass();
    }


    [Test]
    public void ComputeSampleStdDev_ListOfAllZeros_ReturnsZero()
    {
        //preq-UNIT-TEST-2

        // Arrange
        var input = "0\n0\n0\n0";

        // Act
        var result = _logic.ComputeSampleStdDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0));
        });
        Assert.Pass();
    }

    [Test]
    public void ComputeSampleStdDev_EmptyList_ReturnsError()
    {
        //preq-UNIT-TEST-2
        // Arrange
        var input = "";

        // Act
        var result = _logic.ComputeSampleStdDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.EqualTo(0));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.IsSuccess, Is.EqualTo(false));
            Assert.That(result.Error,
                Is.EqualTo("At least two values are required to calculate the sample standard deviation."));;
            Assert.That(result.Error, !Is.EqualTo(null));
        });
        Assert.Pass();
    }

    [Test]
    public void ComputeSampleStdDev_LessThanTwoInputs_ThrowsException()
    {
        //preq-UNIT-TEST-2
        // Arrange
        var input = "1";

        // Act
        var result = _logic.ComputeSampleStdDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.EqualTo(0));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.IsSuccess, Is.EqualTo(false));
            Assert.That(result.Error,
                Is.EqualTo("At least two values are required to calculate the sample standard deviation."));
        });
        Assert.Pass();
    }

    [Test]
    public void ComputeSampleStdDev_InputWithNegativeValues_ReturnsCorrectStdDev()
    {
        //preq-UNIT-TEST-2
        // Arrange
        var input = "-5\n-10\n-15\n-20";

        // Act
        var result = _logic.ComputeSampleStdDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess,Is.EqualTo(true));
            Assert.That(result.Operation, Is.EqualTo("Sample Standard Deviation"));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Result,
                Is.InRange(6.45, 6.46)); // Standard deviation should be approximately 6.45497 for this list
        });
        Assert.Pass();
    }

    [Test]
    public void ComputeSampleStdDev_InputWithInvalidValues_ReturnsError()
    {
        //preq-UNIT-TEST-2
        // Arrange
        var input = "5\n10\nabc\n15";

        // Act
        var result = _logic.ComputeSampleStdDev(input);

        // Assert
        Assert.That(result.IsSuccess, !Is.EqualTo(true));
        Assert.That(result.Error, !Is.EqualTo(null));
        Assert.Pass();
    }
    
}

public class PopulationStdDevTests
{
    private Logic _logic;
    [SetUp]
    public void Setup()
    {
        _logic = new Logic();
    }
    [Test]
    public void ComputePopStdDev_ValidList_ReturnsCorrectStdDev()
    {
        //preq-UNIT-TEST-3

        // Arrange
        var input = "5\n10\n15\n20";

        // Act
        var result = _logic.ComputePopDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Sample Standard Deviation"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.InRange(5.59, 5.60)); // Expected standard deviation is about 5.59016
        });
        Assert.Pass();
    }
    [Test]
    public void ComputePopulationStdDev_InputWithInvalidValues_ReturnsError()
    {
        // Arrange
        var input = "5\n10\nabc\n15";

        // Act
        var result = _logic.ComputePopDev(input);

        // Assert
        Assert.That(result.IsSuccess, !Is.EqualTo(true));
        Assert.That(result.IsSuccess2, !Is.EqualTo(true));
        Assert.That(result.Error, !Is.EqualTo(null));
        Assert.Pass();
    }
    [Test]
    public void ComputePopStdDev_ListOfAllZeros_ReturnsZero()
    {
        //preq-UNIT-TEST-3

        // Arrange
        var input = "0\n0\n0\n0";

        // Act
        var result = _logic.ComputePopDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0));
        });
        Assert.Pass();
    }
    [Test]
    public void ComputePopStdDev_LessThanTwoInputs_ThrowsException()
    {
        //preq-UNIT-TEST-3
        // Arrange
        var input = "1";

        // Act
        var result = _logic.ComputePopDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.EqualTo(0));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.IsSuccess, Is.EqualTo(false));
            Assert.That(result.Error,
                Is.EqualTo("At least two values are required to calculate the population standard deviation."));
        });
        Assert.Pass();
    }
    [Test]
    public void ComputePopStdDev_EmptyList_ReturnsError()
    {
        //preq-UNIT-TEST-3
        // Arrange
        var input = "";

        // Act
        var result = _logic.ComputePopDev(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.EqualTo(0));
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.IsSuccess, Is.EqualTo(false));
            Assert.That(result.Error,
                Is.EqualTo("At least two values are required to calculate the population standard deviation."));;
            Assert.That(result.Error, !Is.EqualTo(null));
        });
        Assert.Pass();
    }
}
public class ComputeMeanTests
{
    private Logic _logic;
    [SetUp]
    public void Setup()
    {
        _logic = new Logic();
    }
    [Test]
    public void ComputeMean_ValidList_ReturnsCorrectMean()
    {
        //preq-UNIT-TEST-4

        // Arrange
        var input = "9\n6\n8\n5\n7";

        // Act
        var result = _logic.CalculateMean(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Mean"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(7));
        });
        Assert.Pass();
    }
    [Test]
    public void ComputeMean_EmptyInput_ReturnsError()
    {
        //preq-UNIT-TEST-4
        // Arrange
        var input = "";

        // Act
        var result = _logic.CalculateMean(input);

        // Assert
        Assert.That(result.IsSuccess, !Is.EqualTo(true));
        Assert.That(result.IsSuccess2, !Is.EqualTo(true));
        Assert.That(result.Error, !Is.EqualTo(null));
        Assert.Pass();
    }
    
}
public class ComputeZScoreTests
{
    private Logic _logic;
    [SetUp]
    public void Setup()
    {
        _logic = new Logic();
    }
    [Test]
    public void ComputeZScore_ValidList_ReturnsCorrectZScore()
    {
        //preq-UNIT-TEST-5

        // Arrange
        var input = "11.5,7,1.5811388300841898";

        // Act
        var result = _logic.ComputerZScore(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Z-Score"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.InRange(2.84, 2.85)); // Expected z-score is about 2.846;
        });
        Assert.Pass();
    }
    [Test]
    public void ComputeZScore_MissingParameter_ReturnsError()
    {
        //preq-UNIT-TEST-5

        // Arrange
        var input = "11.5,7";

        // Act
        var result = _logic.ComputerZScore(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, !Is.EqualTo("Z-Score"));
            Assert.That(result.IsSuccess, !Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, !Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0)); // Expected z-score is about 2.846;
        });
        Assert.Pass();
    }
    [Test]
    public void ComputeZScore_MeanIsZero_ReturnsError()
    {
        //preq-UNIT-TEST-5

        // Arrange
        var input = "11.5,0,1.5811388300841898";

        // Act
        var result = _logic.ComputerZScore(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Z-Score"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, !Is.EqualTo(0)); // Expected z-score is about 2.846;
        });
        Assert.Pass();
    }
}
public class ComputeSingleLinearRegressionEquationTests
{
    private Logic _logic;
    [SetUp]
    public void Setup()
    {
        _logic = new Logic();
    }
    [Test]
    public void ComputeSingleLinear_ValidList_ReturnsCorrectResult()
    {
        //preq-UNIT-TEST-6

        // Arrange
        var input = "1.47, 52.21\n1.50, 53.12\n1.52, 54.48\n1.55, 55.84\n1.57, 57.20\n1.60, 58.57\n1.63, 59.93\n1.65, 61.29\n1.68, 63.11\n1.70, 64.47\n1.73, 66.28\n1.75, 68.10\n1.78, 69.92\n1.80, 72.19\n1.83, 74.46";

        // Act
        var result = _logic.SingleLinearRegressionFormula(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Single Linear Regression Formula:"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, !Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.InRange(61, 62)); // Expected 61.272;
        });
        Assert.Pass();
    }
    [Test]
    public void ComputeSingleLinear_EmptyList_ReturnsError()
    {
        //preq-UNIT-TEST-6

        // Arrange
        var input = "";

        // Act
        var result = _logic.SingleLinearRegressionFormula(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess, !Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, !Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0)); 
        });
        Assert.Pass();
    }
    [Test]
    public void ComputeSingleLinear_AllXValueSame_ReturnsError()
    {
        //preq-UNIT-TEST-6

        // Arrange
        var input = "2, 52.21\n2, 53.12\n2, 54.48\n2, 55.84\n2, 57.20\n2, 58.57\n2, 59.93\n2, 61.29\n2, 63.11\n2, 64.47\n2, 66.28\n2, 68.10\n2, 69.92\n2, 72.19\n2, 74.46";

        // Act
        var result = _logic.SingleLinearRegressionFormula(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess, !Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, !Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0)); 
        });
        Assert.Pass();
    }
    [Test]
    public void ComputeSingleLinear_AllYValueSame_Returns0Slope()
    {
        //preq-UNIT-TEST-6

        // Arrange
        var input = "52.21,2\n53.12,2\n54.48,2\n55.84,2\n57.20,2\n58.57,2\n59.93,2\n61.29,2\n63.11,2\n64.47,2\n66.28,2\n68.10,2\n69.92,2\n72.19,2\n74.46,2";

        // Act
        var result = _logic.SingleLinearRegressionFormula(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Single Linear Regression Formula:"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, !Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0)); 
        });
        Assert.Pass();
    }
}
public class ComputeYLinearRegressionEquationTests
{
    private Logic _logic;
    [SetUp]
    public void Setup()
    {
        _logic = new Logic();
    }
    [Test]
    public void ComputeYLinear_ValidList_ReturnsCorrectResult()
    {
        //preq-UNIT-TEST-7

        // Arrange
        var input = "1.535,61.272186542107434,-39.061955918838656";

        // Act
        var result = _logic.YLinearRegressionFormula(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo("Single Linear Regression Prediction"));
            Assert.That(result.IsSuccess, Is.EqualTo(true));
            Assert.That(result.IsSuccess2, !Is.EqualTo(false));
            Assert.That(result.Error, Is.EqualTo(null));
            Assert.That(result.Result, Is.InRange(54, 55)); // Expected 54.9908;
        });
        Assert.Pass();
    }
    [Test]
    public void CComputeYLinear_EmptyList_ReturnsError()
    {
        //preq-UNIT-TEST-7

        // Arrange
        var input = "";

        // Act
        var result = _logic.YLinearRegressionFormula(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Operation, Is.EqualTo(null));
            Assert.That(result.IsSuccess, !Is.EqualTo(true));
            Assert.That(result.IsSuccess2, Is.EqualTo(false));
            Assert.That(result.Error, !Is.EqualTo(null));
            Assert.That(result.Result, Is.EqualTo(0)); 
        });
        Assert.Pass();
    }
}
