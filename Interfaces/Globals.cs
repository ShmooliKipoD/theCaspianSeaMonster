using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace theCaspianSeaMonster.Interfaces;

public static class Globals
{
    public static float Time { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point WindowSize { get; set; }

    public static void Update(GameTime gametime)
    {
        Time = (float)gametime.ElapsedGameTime.TotalSeconds;
    }
}
