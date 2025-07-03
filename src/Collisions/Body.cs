namespace theCaspianSeaMonster.Collisions;

public enum BodyType
{
    Static, 
    Dynamic
}

public class Body
{
    public BodyType BodyType = BodyType.Static;
    public Vector2 Position;
    public Vector2 Velocity;
    public AABB BoundingBox => new (Position - Size / 2f, Position + Size / 2f);
// BoundingBox
    public Vector2 Size;
}

