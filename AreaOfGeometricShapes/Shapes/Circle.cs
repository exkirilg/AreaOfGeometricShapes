namespace AreaOfGeometricShapes.Shapes;

public class Circle: GeometricShape
{
    private double _radius;

    public double Radius
    {
        get => _radius;
        set
        {
            if (value < 0)
                throw new Exception("Circle radius cannot be less then 0");
            _radius = value;
        }
    }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
