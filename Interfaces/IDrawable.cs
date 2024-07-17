using Microsoft.Xna.Framework;

namespace theCaspianSeaMonster.Interfaces;

public interface IDrawable
{
    void LoadContent();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime = null);
}