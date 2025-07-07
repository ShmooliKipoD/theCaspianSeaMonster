namespace theCaspianSeaMonster.Collisions;

public struct AABB(
    Vector2 min
    , Vector2 max
    )
{
    public Vector2 Min = min;
    public Vector2 Max = max;
    public Vector2 Center => new Vector2(CenterX, CenterY);
    public float CenterX => (Max.X - Min.X) / 2f;
    public float CenterY => (Max.Y - Min.Y) / 2f;
    public float Width => Max.X - Min.X;
    public float Height => Max.Y - Min.Y;
}
