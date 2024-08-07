using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace theCaspianSeaMonster.Interfaces;

class SpriteStack : IDrawable
{
    #region private fields

    private int _frames;
    private Texture2D _texture;
    private Vector2 _origin;
    private Effect _effect;
    private float _rotationOffset = (float)  Math.PI / -2;
    private float _rotation = 0;

    #endregion

    public SpriteStack(
            int width,
            int height,
            Texture2D texture,
            Effect effect
        )
    {
        Width = width;
        Height = height;
        _texture = texture;
        _frames = texture.Height / Height;
        _origin = new(width / 2, height / 2);
        _effect = effect;
        Position = new();
    }

    public int Width { get; }
    public int Height { get; }
    public Vector2 Position { get; set; }
    public float Rotation => _rotation;

    public Vector2 Origin => Position;

    public virtual void Update(GameTime gameTime) { }

    public void Draw(GameTime gameTime = null)
    {
        Globals.SpriteBatch.Begin(
                sortMode: SpriteSortMode.Immediate, 
                blendState: BlendState.AlphaBlend, 
                samplerState: SamplerState.PointClamp, 
                effect: _effect
            );

        for (int frame = 0; frame < _frames; frame++)
        {
            Globals.SpriteBatch.Draw(
                    _texture,
                    new(Position.X,
                        Position.Y + frame * 1),
                    new(
                        new Point(0, frame * Height),
                        new Point(Width, Height)
                    ),
                    frame > _frames - 7 ? Color.White : Color.Gray,
                    //Color.White,
                    Rotation + _rotationOffset,
                    _origin,
                    1.0f,
                    SpriteEffects.None,
                    0f
                );

        }
        Globals.SpriteBatch.End();
    }

    public void LoadContent() { }

    public void UpdatePosition(Vector2 position)
    {
        Position = position;
    }

    public void UpdateRotation(float rotation)
    {
        _rotation = rotation;
    }
}