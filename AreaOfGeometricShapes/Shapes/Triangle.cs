namespace AreaOfGeometricShapes.Shapes;

public class Triangle: IShape
{
    private double[] _sides = new double[3];

    public double RoundAccuracy { get; set; } = 0.1;

    public IReadOnlyCollection<double> Sides => _sides;
    public bool IsRightTriangle
    {
        get
        {
            var hypotenuseIndex = GetRightTriangleHypotenuseIndex();
            var hypotenuse = _sides[hypotenuseIndex];
            var legs = GetRightTriangleLegs();

            var hypotenuseSquare = Math.Pow(hypotenuse, 2);
            var legsSquareSum = Math.Pow(legs[0], 2) + Math.Pow(legs[1], 2);

            return
                hypotenuseSquare == legsSquareSum ||
                (Math.Abs(hypotenuseSquare - legsSquareSum) / hypotenuseSquare * 100) <= RoundAccuracy;
        }
    }
    public double Area
    {
        get
        {
            if (IsRightTriangle)
            {
                var legs = GetRightTriangleLegs();
                return legs[0] * legs[1] / 2;
            }

            var p = (_sides[0] + _sides[1] + _sides[2]) / 2;
            return Math.Sqrt(p * (p - _sides[0])*(p - _sides[1]) *(p - _sides[2]));
        }
    }

    public Triangle(double a, double b, double c)
    {
        if (TriangleIsPossible(a, b, c) == false)
            throw new Exception($"Triangle with sides {a} - {b} - {c} is not possible");

        _sides[0] = a;
        _sides[1] = b;
        _sides[2] = c;
    }

    private bool TriangleIsPossible(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
    private int GetRightTriangleHypotenuseIndex()
    {
        var hypotenuse = Math.Max(_sides[0], Math.Max(_sides[1], _sides[2]));
        return Array.IndexOf(_sides, hypotenuse);
    }
    private double[] GetRightTriangleLegs()
    {
        var legs = Sides.Where(s => Array.IndexOf(_sides, s) != GetRightTriangleHypotenuseIndex());
        return new double[] { legs.First(), legs.Last() };
    }
}
