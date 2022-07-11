namespace AreaOfGeometricShapes.Tests;

public class TriangleTests
{
    public static IEnumerable<object[]> TestData_Valid => new List<object[]>
    {
        new object[] { 5, 7, 10, false, 16.25},
        new object[] { 7, 10, 12, false, 34.98 },
        new object[] { 3, 5, 4, true, 6 },
        new object[] { 15, 9, 12, true, 54 }

    };
    public static IEnumerable<object[]> TestData_Invalid => new List<object[]>
    {
        new object[] { 7, 10, 20 },
        new object[] { 3, 11, 4 },
        new object[] { 7, 16, 5 }
    };

    [Theory]
    [MemberData(nameof(TestData_Valid))]
    public void Triangle_Constructor(double a, double b, double c, bool isRight, double area)
    {
        var triangle = new Triangle(a, b, c);

        Assert.Equal(a, triangle.SideA);
        Assert.Equal(b, triangle.SideB);
        Assert.Equal(c, triangle.SideC);
        Assert.Equal(isRight, triangle.IsRight);
    }

    [Theory]
    [MemberData(nameof(TestData_Valid))]
    public void Triangle_SetSides(double a, double b, double c, bool isRight, double area)
    {
        var triangle = new Triangle(1, 2, 3);

        triangle.SetSides(a, b, c);

        Assert.Equal(a, triangle.SideA);
        Assert.Equal(b, triangle.SideB);
        Assert.Equal(c, triangle.SideC);
        Assert.Equal(isRight, triangle.IsRight);
    }

    [Theory]
    [MemberData(nameof(TestData_Valid))]
    public void Triangle_Area(double a, double b, double c, bool isRight, double area)
    {
        var triangle = new Triangle(a, b, c);

        Assert.Equal(area, Math.Round(triangle.CalculateArea(), 2));
    }

    [Theory]
    [MemberData(nameof(TestData_Invalid))]
    public void Triangle_ConstructorThrowsArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Theory]
    [MemberData(nameof(TestData_Invalid))]
    public void Triangle_SetSidesThrowsArgumentException(double a, double b, double c)
    {
        var triangle = new Triangle(1, 2, 3);
        Assert.Throws<ArgumentException>(() => triangle.SetSides(a, b, c));
    }
}
