namespace Vector.Lib;

public partial struct Vector2
    : IComparable
    , IComparable<Vector2>
{
    public int CompareTo(object other)
    {
        if (other is Vector2)
        {
            return CompareTo((Vector2)other);
        }
        throw new ArgumentException(
            $"{NonVectorComparision}{Environment.NewLine}{ArgumentType}{other.GetType().ToString()}", nameof(other));
    }

    public int CompareTo(Vector2 other)
    {
        if (this < other)
        {
            return -1;
        }
        else if (this > other)
        {
            return 1;
        }
        return 0;
    }

    public int CompareTo(object other, double tolerance)
    {
        if (other is Vector2)
        {
            return CompareTo((Vector2)other, tolerance);
        }
        throw new ArgumentException(
            $"{NonVectorComparision}{Environment.NewLine}{ArgumentType}{other.GetType().ToString()}", nameof(other));
    }

    public int CompareTo(Vector2 other, double tolerance)
    {
        var bothInfinite = double.IsInfinity(SumComponentSqrs()) &&
            double.IsInfinity(other.SumComponentSqrs());
        if (Equals(other, tolerance) || bothInfinite)
        {
            return 0;
        }
        if (this < other)
        {
            return -1;
        }
        return 1;
    }
}