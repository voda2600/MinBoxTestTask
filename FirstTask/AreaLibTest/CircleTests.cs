using AreaLibTest.Common;
using FigureAreaCalcLib.Figures;
using System;
using System.Collections.Generic;
using Xunit;

namespace AreaLibTest;

public class CircleTests
{
    private static readonly IEqualityComparer<double> DoubleComparer = new DoubleComparer();

    [Fact]
    public void ShouldCreateCorrectCircles()
    {
        var radius = double.Epsilon;

        var circle = new Circle(radius);

        Assert.NotNull(circle);
        Assert.Equal(circle.GetRadius(), radius);
    }

    [Fact]
    public void ShouldNotCreateCircleWithZeroRadius()
    {
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }

    [Fact]
    public void ShouldNotCreateNegativeCircle()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Theory]
    [InlineData(8, 201.06193)]
    [InlineData(0.01, 0.00031415926535897936)]
    [InlineData(1029.12, 3327222.99988)]
    public void GetAreaReturnsCorrectValue(double r, double res)
    {
        var circle = new Circle(r);

        Assert.Equal(res, circle.CalculateArea(), DoubleComparer);
    }
}