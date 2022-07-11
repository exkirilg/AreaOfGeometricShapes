namespace AreaOfGeometricShapes.Shapes;

public class Triangle : GeometricShape
{
    public double SideA { get; private set; }
    public double SideB { get; private set; }
    public double SideC { get; private set; }
    public bool IsRight { get; private set; }

    public Triangle(double a, double b, double c)
    {
        SetSides(a, b, c);
    }

    public void SetSides(double a, double b, double c)
    {
        if (IsImpossible(a, b, c))
            throw new ArgumentException($"Triangle with sides {a} - {b} - {c} is not possible");

        SideA = a;
        SideB = b;
        SideC = c;

        SetIsRight();
    }

    public override double CalculateArea()
    {
        if (IsRight)
        {
            var (hypotenuse, legA, legB) = GetHypotenuseAndLegs();
            return legA * legB / 2;
        }

        var p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    private bool IsImpossible(double a, double b, double c)
    {
        return a + b < c
            || a + c < b
            || b + c < a;
    }
    private void SetIsRight()
    {
        IsRight = Math.Pow(SideA, 2) == Math.Pow(SideB, 2) + Math.Pow(SideC, 2)
            || Math.Pow(SideB, 2) == Math.Pow(SideA, 2) + Math.Pow(SideC, 2)
            || Math.Pow(SideC, 2) == Math.Pow(SideA, 2) + Math.Pow(SideB, 2);
    }
    private (double hypotenuse, double legA, double legB) GetHypotenuseAndLegs()
    {
        (double hypotenuse, double legA, double legB) result = (hypotenuse: 0, legA: 0, legB: 0);
        
        var sides = typeof(Triangle).GetProperties()
            .Where(p => p.Name.StartsWith("Side"))
            .Select(p => (double)p.GetValue(this)!)
            .OrderByDescending(v => v);

        result.hypotenuse = sides.Take(1).First();
        result.legA = sides.TakeLast(2).First();
        result.legB = sides.TakeLast(2).Last();

        return result;
    }
}
