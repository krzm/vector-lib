namespace Vector.Lib;

public partial struct Vector2
{
    public static readonly Vector2 Origin = new Vector2(0, 0);
    public static readonly Vector2 XAxis = new Vector2(1, 0);
    public static readonly Vector2 YAxis = new Vector2(0, 1);

    public static readonly Vector2 MinValue =
			new Vector2(double.MinValue, double.MinValue);

    public static readonly Vector2 MaxValue =
        new Vector2(double.MaxValue, double.MaxValue);

    public static readonly Vector2 Epsilon =
        new Vector2(double.Epsilon, double.Epsilon);

    public static readonly Vector2 Zero = Origin;

    public static readonly Vector2 NaN =
        new Vector2(double.NaN, double.NaN);
    
    public static bool IsUnitVector(Vector2 v1) => v1.Magnitude == 1;

    public bool IsUnitVector() => IsUnitVector(this);

    public bool IsUnitVector(double tolerance) => IsUnitVector(this, tolerance);

    public static bool IsUnitVector(Vector2 v1, double tolerance) => 
        AlmostEqualsWithAbsTolerance(v1.Magnitude, 1, tolerance);

    public static Vector2 Normalize(Vector2 v1)
    {
        var magnitude = v1.Magnitude;

        if (magnitude == 0)
        {
            throw new NormalizeVectorException(NORMALIZE0);
        }

        if (double.IsNaN(magnitude))
        {
            throw new NormalizeVectorException(NORMALIZENaN);
        }

        if (double.IsInfinity(v1.Magnitude))
        {
            var x =
                v1.X == 0 ? 0 :
                    v1.X == -0 ? -0 :
                        double.IsPositiveInfinity(v1.X) ? 1 :
                            double.IsNegativeInfinity(v1.X) ? -1 :
                                double.NaN;
            var y =
                v1.Y == 0 ? 0 :
                    v1.Y == -0 ? -0 :
                        double.IsPositiveInfinity(v1.Y) ? 1 :
                            double.IsNegativeInfinity(v1.Y) ? -1 :
                                double.NaN;
            
            var result = new Vector2(x, y);

            if (result.IsNaN())
            {
                throw new NormalizeVectorException(NORMALIZEInf);
            }

            return result;
        }

        return NormalizeOrNaN(v1);
    }

    public Vector2 Normalize() => Normalize(this);

    private static Vector2 NormalizeOrNaN(Vector2 v1)
    {
        var inverse = 1 / v1.Magnitude;

        return new Vector2(
            v1.X * inverse
            , v1.Y * inverse);
    }

    public const string NORMALIZE0 =
        "Cannot normalize a vector when it's magnitude is zero";

    public const string NORMALIZENaN =
        "Cannot normalize a vector when it's magnitude is NaN";

    public const string NORMALIZEInf =
        "Cannot normalize a vector when it's magnitude is Infinity";
}