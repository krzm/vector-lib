namespace Vector.Lib;

public partial struct Vector2
{
    public static Vector2 Interpolate(Vector2 v1, Vector2 v2, double control)
    {
        return Interpolate(v1, v2, control, false);
    }

    public Vector2 Interpolate(Vector2 other, double control)
    {
        return Interpolate(this, other, control);
    }

    public Vector2 Interpolate(Vector2 other, double control, bool allowExtrapolation)
    {
        return Interpolate(this, other, control);
    }

    private const string INTERPOLATION_RANGE =
        "Control parameter must be a value between 0 & 1";

    public static Vector2 Max(Vector2 v1, Vector2 v2) => v1 >= v2 ? v1 : v2;

    public Vector2 Max(Vector2 other) => Max(this, other);

    public static Vector2 Min(Vector2 v1, Vector2 v2) => v1 <= v2 ? v1 : v2;

    public Vector2 Min(Vector2 other) => Min(this, other);

    public static bool IsPerpendicular(Vector2 v1, Vector2 v2)
    {
        // Use normalization of special cases to handle special cases of IsPerpendicular
        v1 = NormalizeSpecialCasesOrOrigional(v1);
        v2 = NormalizeSpecialCasesOrOrigional(v2);

        // If either vector is vector(0,0,0) the vectors are not perpendicular
        if (v1 == Zero || v2 == Zero)
        {
            return false;
        }

        // Is perpendicular
        return v1.DotProduct(v2).Equals(0);
    }

    public bool IsPerpendicular(Vector2 other)
    {
        return IsPerpendicular(this, other);
    }

    private static Vector2 NormalizeSpecialCasesOrOrigional(Vector2 v1)
    {
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
            
            return new Vector2(x, y);
        }

        return v1;
    }
}