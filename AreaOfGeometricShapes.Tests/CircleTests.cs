namespace AreaOfGeometricShapes.Tests;

public class CircleTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(5, 78.54)]
    [InlineData(10, 314.16)]
    [InlineData(4.27, 57.28)]
    [InlineData(13.55, 576.8)]
    public void CircleArea(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        Assert.Equal(expectedArea, Math.Round(circle.Area, 2));
    }
}