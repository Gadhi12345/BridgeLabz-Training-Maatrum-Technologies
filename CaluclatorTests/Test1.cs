using Microsoft.VisualStudio.TestTools.UnitTesting;

public class Calculator
{
    public int Add(int a,int b)
    {
        return a + b;
    }
    public int divide(int a, int b)
    {
        
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }
}

[TestClass]
public class CalculatorTests
{
    [DataTestMethod]
    [DataRow(10, 5, 15)]     // normal
    [DataRow(0, 0, 0)]       // edge
    [DataRow(-10, -5, -15)]  // variation
    public void Add_AllCases(int a, int b, int expected)
    {
        Calculator calc = new Calculator();
        int result = calc.Add(a, b);

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Divide_ExceptionCase()
    {
        Calculator calc = new Calculator();

        Assert.ThrowsException<DivideByZeroException>(() =>
     calc.divide(10, 0)
        ); 
    }
}