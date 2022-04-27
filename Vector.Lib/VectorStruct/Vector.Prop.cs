namespace Vector.Lib;

public partial struct Vector2
{
    private const string TwoComponents =
        "Array must contain exactly two components, (x,y)";
    private const string NonVectorComparision =
        "Cannot compare a Vector2 to a non-Vector2";
    private const string ArgumentType =
        "The argument provided is a type of ";

    private readonly double x;
    private readonly double y;

    public double X => x;

    public double Y => y;

    public double[] Array => new double[] { X, Y };

    public double this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: { return X; }
                case 1: { return Y; }
                default: throw new ArgumentException(TwoComponents, "index");
            }
        }
    }

    public double Magnitude => Math.Sqrt(SumComponentSqrs());
}