using System;
using FigureAreaCalcLib;
using Xunit;

namespace AreaLibTest;

public class FigureLibTest
{
    private const int Accurate = 2;
    
    [Theory]
    [InlineData(new double[] { 0 }, 0)]
    [InlineData(new double[] { 5 }, 78.50)]
    [InlineData(new double[] { 1000 }, 3140000)]
    [InlineData(new[] { 69.69 }, 15250.03)]
    [InlineData(new[] { 33.33 }, 3488.19)]
    [InlineData(new double[] { 5, 4, 3 }, 6)]
    [InlineData(new[] { 5.6, 3.4, 6.7 }, 9.51)]
    public void TestCalculateArea_ValidSides_TrueCompareWithValidArea(double[] sides, double actualArea)
    {
        var area = FigureHelper.CalculateArea(Accurate, sides);
        var areaComparison = Math.Abs(area - actualArea) < double.Epsilon;

        Assert.True(areaComparison);
    }

    [Theory]
    [InlineData(1.0, 2.0)]
    [InlineData(1.0, 2.0, 3.0, 4.0)]
    [InlineData(69.2, 126.0, 222.0, 21512.2)]
    [InlineData(-2121.222)]
    public void TestCalculateArea_InvalidSides_ThrowArgumentException(params double[] sides)
    {
        Assert.Throws<ArgumentException>(() => FigureHelper.CalculateArea(Accurate, sides));
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 6, 6, false)]
    public void TestRectangularTriangle_ValidSides_IsRectangular(double a, double b, double c, bool isRectangular)
    {
        var isTriangleRectangular = FigureHelper.IsTriangleRectangular(a, b, c);

        Assert.Equal(isTriangleRectangular, isRectangular);
    }
}