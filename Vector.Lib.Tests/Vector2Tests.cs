using Xunit;

namespace Vector.Lib.Tests;

public class Vector2Tests
{
    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0)]
    [InlineData(640, 682, 640, 168, 0, 514)]
    [InlineData(648, 420, 640, 682, 8, -262)]
    public void TestSubstraction(
        double x1
        , double y1
        , double x2
        , double y2
        , double x3
        , double y3)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);
        var expected = new Vector2(x3, y3);

        var actual = v1 - v2;
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(8, -262, 0, -1, 262)]
    public void TestDotProduct(
        double x1
        , double y1
        , double x2
        , double y2
        , double expected)
    {
        var v1 = new Vector2(x1, y1);
        var v2 = new Vector2(x2, y2);

        var actual = Vector2.DotProduct(v1, v2);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(640, 682, 640, 168, 0, -514, 262, 640, 420)]
    public void TestClosesestPoint(
        double mcX
        , double mcY
        , double spX
        , double spy
        , double vX
        , double vY
        , double projV
        , double expectedX
        , double expectedY)
    {
        var lineMassCenter = new Vector2(mcX, mcY);
        var lineSecondPoint = new Vector2(spX, spy);
        var segV = new Vector2(vX, vY);
        var expected = new Vector2(expectedX, expectedY);

        var acctual = VectorCompute.ClosesestPoint(lineMassCenter, lineSecondPoint, segV, projV);
        
        Assert.Equal(expected, acctual);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(4, 3, 5)]
    [InlineData(-4, -3, 5)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
    public void TestMagnitude(
        double x
        , double y
        , double expected)
    {
        var acctual = new Vector2(x, y).Magnitude;
        
        Assert.Equal(expected, acctual);
    }

    //todo: needs Equals7DigitPrecision method
    // [Theory]
    // [InlineData(4, 3, 4 / 5d, 3 / 5d)]
    // [InlineData(-4, -3, -4 / 5d, -3 / 5d)]
    // [InlineData(0, -514, 0, -1)]
    // public void TestNormalize(double x, double y, double expectedNormX, double expectedNormY)
    // {
    //     var expected = new Vector2(expectedNormX, expectedNormY);

    //     var acctual = new Vector2(x, y).Normalize();

    //     Assert.True(expected.X.Equals7DigitPrecision(acctual.X));
    //     Assert.True(expected.Y.Equals7DigitPrecision(acctual.Y));
    // }

    [Theory]
    [InlineData(0, 0)]
    public void TestNormalize0Magnitude(double x, double y) =>
        Assert.Throws<NormalizeVectorException>(() => new Vector2(x, y).Normalize());

    [Theory]
    [InlineData(double.NaN, double.NaN)]
    [InlineData(0, double.NaN)]
    [InlineData(double.NaN, 0)]
    public void TestNormalizeNaNMagnitude(double x, double y) =>
        Assert.Throws<NormalizeVectorException>(() => new Vector2(x, y).Normalize());

    [Theory]
    [InlineData(double.PositiveInfinity, 1)]
    public void TestNormalizeInfMagnitude(double x, double y) =>
        Assert.Throws<NormalizeVectorException>(() => new Vector2(x, y).Normalize());
}