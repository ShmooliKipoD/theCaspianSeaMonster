using Microsoft.Xna.Framework;

namespace theCaspianSeaMonster.Interfaces;

interface IGameObject
{
    Vector2 Position { get; }
    float Rotation { get; }

    void UpdateRotation(float rotation);
    void UpdatePosition(Vector2 position);
    void LoadContent();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime = null);
}