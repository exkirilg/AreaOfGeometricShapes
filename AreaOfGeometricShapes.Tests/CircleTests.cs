namespace AreaOfGeometricShapes.Tests;

public class CircleTests
{
    public static IEnumerable<object[]> TestData_Valid => new List<object[]>
    {
        new object[] { 0, 0 },
        new object[] { 1, 3.14 },
        new object[] { 5, 78.54 },
        new object[] { 10, 314.16 },
        new object[] { 13.55, 576.8 }
    };
    public static IEnumerable<object[]> TestData_ThrowsException => new List<object[]>
    {
        new object[] { -1 },
        new object[] { -5 },
        new object[] { -10 }
    };

    [Theory]
    [MemberData(nameof(TestData_Valid))]
    public void CalculateArea(double radius, double expected)
    {
        var circle = new Circle(radius);
        Assert.Equal(expected, Math.Round(circle.CalculateArea(), 2));
    }

    [Theory]
    [MemberData(nameof(TestData_ThrowsException))]
    public void ThrowsExceptionAtCtor(double radius)
    {
        Assert.Throws<Exception>(() => new Circle(radius));
    }

    [Theory]
    [MemberData(nameof(TestData_ThrowsException))]
    public void ThrowsExceptionAtRadiusPropSetter(double radius)
    {
        var circle = new Circle(0);
        Assert.Throws<Exception>(() => circle.Radius = radius);
    }
}