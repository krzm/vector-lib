namespace Vector.Lib;

public partial struct Vector2
{
    public static double DotProduct(Vector2 v1, Vector2 v2) =>
        v1.X * v2.X + v1.Y * v2.Y;

    public double DotProduct(Vector2 other) => DotProduct(this, other);

    public static double SumComponents(Vector2 v1) => v1.X + v1.Y;

    public double SumComponents() => SumComponents(this);

    public static Vector2 PowComponents(Vector2 v1, double power) => new Vector2
        (
            Math.Pow(v1.X, power),
            Math.Pow(v1.Y, power)
        );

    public void PowComponents(double power) => this = PowComponents(this, power);

    public static Vector2 SqrtComponents(Vector2 v1) => new Vector2
        (
            Math.Sqrt(v1.X),
            Math.Sqrt(v1.Y)
        );

    public void SqrtComponents() => this = SqrtComponents(this);

    public static Vector2 SqrComponents(Vector2 v1) => new Vector2
        (
            v1.X * v1.X,
            v1.Y * v1.Y
        );

    public void SqrComponents() => this = SqrComponents(this);

    public static double SumComponentSqrs(Vector2 v1)
    {
        var v2 = SqrComponents(v1);
        return v2.SumComponents();
    }

    public double SumComponentSqrs() => SumComponentSqrs(this);

    public static bool IsNaN(Vector2 v1) => double.IsNaN(v1.X) || double.IsNaN(v1.Y);

    public bool IsNaN() => IsNaN(this);
}