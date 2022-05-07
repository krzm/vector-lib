namespace Vector.Lib;

//todo: clean or delete
public static class SomeAppCompute
{
    public static Vector2 ClosesestPoint(
        Vector2 lineMassCenter
        , Vector2 lineSecondPoint
        , Vector2 subLineMcSp
        , double dotBallMcLineMc)
    {
        if (dotBallMcLineMc < 0)
            return lineMassCenter;
        if (dotBallMcLineMc > subLineMcSp.Magnitude)
            return lineSecondPoint;
        subLineMcSp = subLineMcSp.Normalize();
        var projVV = dotBallMcLineMc * subLineMcSp;
        return lineMassCenter + projVV;
    }
}
