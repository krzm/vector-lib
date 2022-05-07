namespace Vector.Lib;

public partial struct Vector2
{
    public static Vector2 NormalizeOrDefault(Vector2 v1)
    {
        /* Check that we are not attempting to normalize a vector of magnitude 1;
            if we are then return v(0,0,0) */
        if (v1.Magnitude == 0)
        {
            return Origin;
        }

        /* Check that we are not attempting to normalize a vector with NaN components;
            if we are then return v(NaN,NaN,NaN) */
        if (v1.IsNaN())
        {
            return NaN;
        }

        // Special Cases
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

            // If this was a special case return the special case result otherwise return NaN
            return result.IsNaN() ? NaN : result;
        }

        // Run the normalization as usual
        return NormalizeOrNaN(v1);
    }

    public Vector2 NormalizeOrDefault()
    {
        return NormalizeOrDefault(this);
    }

    public static Double Abs(Vector2 v1) => v1.Magnitude;

    public double Abs() => Magnitude;

    public static double Angle(Vector2 v1, Vector2 v2)
    {
        if (v1 == v2)
        {
            return 0;
        }
        return
            Math.Acos(
                Math.Min(1.0f, NormalizeOrDefault(v1).DotProduct(NormalizeOrDefault(v2))));
    }

    public double Angle(Vector2 other) => Angle(this, other);

    public static bool IsBackFace(Vector2 normal, Vector2 lineOfSight) => normal.DotProduct(lineOfSight) < 0;

    public bool IsBackFace(Vector2 lineOfSight) => IsBackFace(this, lineOfSight);

    public static double Distance(Vector2 v1, Vector2 v2) => Math.Sqrt
        (
            (v1.X - v2.X) * (v1.X - v2.X) +
            (v1.Y - v2.Y) * (v1.Y - v2.Y)
        );

    public double Distance(Vector2 other) => Distance(this, other);

    public static Vector2 Interpolate(
        Vector2 v1,
        Vector2 v2,
        double control,
        bool allowExtrapolation)
    {
        if (!allowExtrapolation && (control > 1 || control < 0))
        {
            // Error message includes information about the actual value of the argument
            throw new ArgumentOutOfRangeException(
                "control",
                control,
                INTERPOLATION_RANGE + "\n" + /*ARGUMENT_VALUE*/ + control);
        }

        return new Vector2(
            v1.X * (1 - control) + v2.X * control,
            v1.Y * (1 - control) + v2.Y * control);
    }
}