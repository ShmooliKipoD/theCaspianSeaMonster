using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace theCaspianSeaMonster.Interfaces;

class Sprite
{
    private Texture2D _texture;
    private Vector2 _position = new(40, 40);
    private Vector2 _origin;
    private int _frame = 0;
    private int _frames = 0;
    private double _time = 0;

    public Sprite(int width, int height, Texture2D texture, int frames)
    {
        Width = width;
        Height = height;
        _texture = texture;
        _origin = new(width / 2, height / 2);
        _frames = frames;
    }

    public int Width { get; set; }

    public int Height { get; set; }

    internal void LoadContent() { }

    internal void Update(GameTime gameTime)
    {
        if (Math.Abs(_time - gameTime.TotalGameTime.TotalMilliseconds) > 1000 / 7)
        {
            //TODO: number of fames should be a parameter
            _frame = (_frame + 1) % _frames;
            _time = gameTime.TotalGameTime.TotalMilliseconds;
        }
    }

    internal void Draw(GameTime gameTime = null)
    {
        Globals.SpriteBatch.Begin();

        Globals.SpriteBatch.Draw(
                _texture,
                _position,
                new Rectangle(
                    new Point(_frame * Width, 0),
                    new Point(Width, Height)
                ),
                Color.White,
                0f,
                _origin,
                1f,
                SpriteEffects.None,
                0f
            );
        
        Globals.SpriteBatch.End();
    }
}