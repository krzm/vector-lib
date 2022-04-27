namespace Vector.Lib;

public partial struct Vector2
{
    public static Vector2 operator +(Vector2 v1, Vector2 v2) => 
        new Vector2
        (
            v1.X + v2.X,
            v1.Y + v2.Y
        );

    public static Vector2 operator -(Vector2 v1, Vector2 v2) => 
        new Vector2
        (
            v1.X - v2.X,
            v1.Y - v2.Y
        );

    public static Vector2 operator -(Vector2 v1) => 
        new Vector2
        (
            -v1.X,
            -v1.Y
        );

    public static Vector2 operator +(Vector2 v1) => 
        new Vector2
        (
            +v1.X,
            +v1.Y
        );

    public static Vector2 operator *(Vector2 v1, double s2) => 
        new Vector2
        (
            v1.X * s2,
            v1.Y * s2
        );

    public static Vector2 operator /(Vector2 v1, double s2) =>
        new Vector2
        (
            v1.X / s2,
            v1.Y / s2
        );

    public static Vector2 operator *(double s1, Vector2 v2) => 
        v2 * s1;

    public static bool operator <(Vector2 v1, Vector2 v2) => 
        v1.SumComponentSqrs() < v2.SumComponentSqrs();

    public static bool operator <=(Vector2 v1, Vector2 v2) => 
        v1.SumComponentSqrs() <= v2.SumComponentSqrs();

    public static bool operator >(Vector2 v1, Vector2 v2) => 
        v1.SumComponentSqrs() > v2.SumComponentSqrs();

    public static bool operator >=(Vector2 v1, Vector2 v2) => 
        v1.SumComponentSqrs() >= v2.SumComponentSqrs();

    public static bool operator ==(Vector2 v1, Vector2 v2) => 
        v1.X == v2.X 
        && v1.Y == v2.Y;

    public static bool operator !=(Vector2 v1, Vector2 v2) => 
        (v1 == v2) == false;
}