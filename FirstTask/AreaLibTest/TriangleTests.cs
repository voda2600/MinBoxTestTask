using AreaLibTest.Common;
using FigureAreaCalcLib.Figures;
using System;
using System.Collections.Generic;
using Xunit;

namespace AreaLibTest;

public class TriangleTests
{
    private static readonly IEqualityComparer<double> DoubleComparer = new DoubleComparer();

    [Fact]
    public void ShouldCreateCorrectTriangle()
    {
        var side1 = 4;
        var side2 = 5;
        var side3 = 7;
        var triangle = new Triangle(side1, side2, side3);

        Assert.NotNull(triangle);
    }

    [Fact]
    public void ShouldNotCreateTriangleWithZeroSides()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(0, 0, 0));
    }

    [Fact]
    public void ShouldNotCreateLineTriangle()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
    }

    [Fact]
    public void ShouldNotCreateTriangleWithBiggestSide()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(10, 2, 3));
    }

    [Theory]
    [InlineData(3,5,7, 6.49519052838329)]
    [InlineData(0.07,0.04,0.05, 0.00098)]
    [InlineData(1999, 1999, 1999, 1730319.189774)]
    public void GetAreaReturnsCorrectValue(double a, double b, double c, double res)
    {
        var triangle = new Triangle(a, b, c);

        Assert.Equal(res, triangle.CalculateArea(), DoubleComparer);
    }

    [Fact]
    public void IsRightAngledReturnsTrueForRightAngled()
    {
        var triangle1 = new Triangle(3, 4, 5);
        var triangle2 = new Triangle(5, 10, 11.1803398875);

        Assert.True(triangle1.IsRectangular());
        Assert.True(triangle2.IsRectangular());
    }

    [Fact]
    public void IsRightAngledReturnsFalseForNotRightAngled()
    {
        var triangle1 = new Triangle(6, 6, 6);
        var triangle2 = new Triangle(4, 5, 6.12);

        Assert.False(triangle1.IsRectangular());
        Assert.False(triangle2.IsRectangular());
    }
}