using Microsoft.Xna.Framework;

namespace theCaspianSeaMonster.Interfaces;

public interface IDrawable
{
    Vector2 Position { get; }
    Vector2 Origin { get; }
    float Rotation { get;  }
    

    void UpdateRotation(float rotation);
    void UpdatePosition(Vector2 position);
    void LoadContent();
    // void Update(GameTime gameTime);
    void Draw(GameTime gameTime = null);
}