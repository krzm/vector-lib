namespace Vector.Lib;

public partial struct Vector2
    : IEquatable<Vector2>
{
    public override string ToString() => $"({X}, {Y})";

    public override bool Equals(object? other)
    {
        if (other is Vector2 otherVector)
        {
            return otherVector.Equals(this);
        }
        else
        {
            return false;
        }
    }

    public bool Equals(Vector2 other) =>
        X.Equals(other.X) &&
        Y.Equals(other.Y);

    public bool Equals(object other, double tolerance)
    {
        if (other is Vector2)
        {
            return Equals((Vector2)other, tolerance);
        }
        return false;
    }

    public bool Equals(Vector2 other, double tolerance) =>
        AlmostEqualsWithAbsTolerance(X, other.X, tolerance) &&
        AlmostEqualsWithAbsTolerance(Y, other.Y, tolerance);

    public static bool AlmostEqualsWithAbsTolerance(double a, double b, double maxAbsoluteError)
    {
        double diff = Math.Abs(a - b);
        if (a.Equals(b))
        {
            return true;
        }
        return diff <= maxAbsoluteError;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = X.GetHashCode();
            hashCode = (hashCode * 397) ^ Y.GetHashCode();
            return hashCode;
        }
    }
}