namespace AreaOfGeometricShapes.Shapes;

public class Circle: IShape
{
    public double Radius { get; set; }
    public double Area => Math.PI * Math.Pow(Radius, 2);

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Circle radius cannot be less then 0", nameof(radius));

        Radius = radius;
    }
}
