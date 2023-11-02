using System;
using FigureAreaCalcLib.Dto;
using FigureAreaCalcLib.Figures;
using Xunit;

namespace AreaLibTest;
#pragma warning disable xUnit1012

public class FigureLibTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(15.5)]
    [InlineData(69.69)]
    [InlineData(12992.69)]
    public void TestCircleAreaWithValidValues(double value)
    {
        var c = new Circle(new CircleData() { R = value });

        Assert.Equal(Math.Round(Math.PI * value * value, 3), Math.Round(c.CalculateArea(), 3));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(-10.99)]
    [InlineData(-110000)]
    public void TestCircleAreaWithInvalidValues(double value)
    {
        var data = new CircleData() { R = value };
        Assert.Throws<ArgumentException>(() => new Circle(data));
    }

    [Fact]
    public void TestTriangleAreaWithValidValues()
    {
        var t = new Triangle(new TriangleData()
        {
            A = 3,
            B = 4,
            C = 5
        });
        Assert.Equal(6, t.CalculateArea());
    }

    [Theory]
    [InlineData(-1, 0, 1)]
    [InlineData(-121, 22, 222)]
    [InlineData(1, 999, 2)]
    [InlineData(5, 5, null)]
    [InlineData(null, null, null)]
    public void TestTriangleWithInvalidValues(double a, double b, double c)
    {
        var data = new TriangleData()
        {
            A = a,
            B = b,
            C = c
        };

        Assert.Throws<ArgumentException>(() => new Triangle(data));
    }

    [Theory]
    [InlineData(29, 20, 21)]
    [InlineData(5, 12, 13)]
    public void TestRectangularTriangle(double a, double b, double c)
    {
        var rectangular = new Triangle(new TriangleData()
        {
            A = a,
            B = b,
            C = c
        });
     
        Assert.True(rectangular.IsRectangular());
    }
    
    [Theory]
    [InlineData(5, 5, 3)]
    [InlineData(4, 9, 6)]
    public void TestNotRectangularTriangle(double a, double b, double c)
    {
        var notRectangular = new Triangle(new TriangleData()
        {
            A = a,
            B = b,
            C = c
        });
        Assert.False(notRectangular.IsRectangular());
    }
}