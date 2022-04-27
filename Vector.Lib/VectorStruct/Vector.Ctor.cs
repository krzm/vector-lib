using System.Runtime.Serialization;

namespace Vector.Lib;

public partial struct Vector2
{
    public Vector2(double x, double y) 
        : this()
    {
        this.x = x;
        this.y = y;
    }

    public Vector2(double[] xyz)
    {
        if (xyz.Length == 2)
        {
            x = xyz[0];
            y = xyz[1];
        }
        else
        {
            throw new ArgumentException(TwoComponents);
        }
    }

    public Vector2(Vector2 v1)
    {
        x = v1.X;
        y = v1.Y;
    }

    public Vector2(
        SerializationInfo info,
        StreamingContext text) : this()
    {
        x = info.GetDouble("X");
        y = info.GetDouble("Y");
    }
}