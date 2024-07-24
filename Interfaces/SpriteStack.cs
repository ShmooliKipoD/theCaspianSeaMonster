using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace theCaspianSeaMonster.Interfaces;

class SpriteStack : IDrawable
{
    private int _frames;
    // private int _frame = 0;
    private double _time = 0;
    private Texture2D _texture;
    private Vector2 _position = new(400, 200);
    private Vector2 _origin;

    private Effect _effect;

    private float _rotation = 0.6f;

    public SpriteStack(
            int width, 
            int height, 
            Texture2D texture
        ) 
    {
        Width = width;
        Height = height;
        _texture = texture;
        _frames = texture.Height / Height;
        _origin = new(width / 2, height / 2);
        _effect = Globals.Content.Load<Effect>("Shaders/ShipColor");
    }

    public int Width { get; }
    public int Height { get; }

    public void Update(GameTime gameTime)
    {
        if (Math.Abs(_time - gameTime.TotalGameTime.TotalMilliseconds) > 1000 / 7)
        {
            _time = gameTime.TotalGameTime.TotalMilliseconds;
        }
        _rotation = _rotation + 0.05f;
    }

    public void Draw(GameTime gameTime = null)
    {
            Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, _effect);

        for (int frame = 0; frame < _frames; frame++)
        {

            Globals.SpriteBatch.Draw(
                    _texture,
                    new(_position.X,
                         _position.Y + frame * 2),
                    new(
                        new Point(0, frame * Height),
                        new Point(Width, Height)
                    ),
                    //frame > _frames - 7 ? Color.White : Color.Gray,
                    Color.White,
                    _rotation,
                    _origin,
                    2.7f,
                    SpriteEffects.None,
                    0f
                );

        }
            Globals.SpriteBatch.End();


    }

    public void LoadContent()
    {
        // throw new NotImplementedException();
    }
}