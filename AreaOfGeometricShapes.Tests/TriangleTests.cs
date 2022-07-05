namespace AreaOfGeometricShapes.Tests;

public class TriangleTests
{
    [Theory]
    [InlineData(6, 8, 10)]
    [InlineData(7, 10, 12)]
    public void TriangleIsPossible(double a, double b, double c)
    {
        _ = new Triangle(a, b, c);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 5, 9)]
    public void TriangleIsNotPossible(double a, double b, double c)
    {
        Assert.ThrowsAny<Exception>(() => new Triangle(a, b, c));
    }

    [Theory]
    [InlineData(7, 10, 12, 34.98)]
    [InlineData(5, 7, 10, 16.25)]
    [InlineData(6, 8, 10, 24)]
    public void TriangleArea(double a, double b, double c, double? expectedArea)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expectedArea, Math.Round(triangle.Area, 2));
    }

    [Theory]
    [InlineData(6, 8, 10)]
    [InlineData(4, 7, 8.06)]
    public void TriangleIsRight(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.True(triangle.IsRightTriangle);
    }

    [Theory]
    [InlineData(7, 10, 12)]
    [InlineData(5, 7, 10)]
    public void TriangleNotIsRight(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);
        Assert.False(triangle.IsRightTriangle);
    }
}
