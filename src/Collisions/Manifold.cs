using Microsoft.Xna.Framework;

namespace theCaspianSeaMonster.Collisions;

public struct Manifold
{
    public float Penetration;
    public Vector2 Normal;
    public Vector2 Overlap;
}