using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimplexNoise;

namespace theCaspianSeaMonster;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _pixel;
    private int _resolution = 10;
    private int _rows;
    private int _cols;
    private double _lastUpdateTime = 0;
    private double _updateInterval = 1000 / 30;
    private int _zoff = 0;

    private int _yoff = 0;

    private Texture2D _squareTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _squareTexture = new Texture2D(GraphicsDevice, 1, 1);
        _squareTexture.SetData(new[] { Color.White });

        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        this._cols = GraphicsDevice.Viewport.Width / this._resolution;
        this._rows = GraphicsDevice.Viewport.Height / this._resolution;

        Noise.Seed = 209323094; // Optional


        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (gameTime.TotalGameTime.TotalMilliseconds - this._lastUpdateTime > this._updateInterval)
        {
            this._lastUpdateTime = gameTime.TotalGameTime.TotalMilliseconds;
            this._zoff += 1;
            this._yoff += 1;
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        Color color = Color.Blue;
        for (int row = 0; row < this._rows; row++)
        {
            for (int col = 0; col < this._cols; col++)
            {
                int alpha = (int)Noise.CalcPixel3D(row , col, _zoff, 0.05f);

                Color colorWithAlpha = new Color(color.R, color.G, color.B, alpha);

                _spriteBatch.Draw(_squareTexture,
                        new Rectangle(
                                col * _resolution,
                                row * _resolution,
                                _resolution,
                                _resolution
                            ),
                        colorWithAlpha
                    );
            }
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    void DrawLine(Vector2 startPoint, Vector2 endPoint, Color color)
    {
        float distance = Vector2.Distance(startPoint, endPoint);
        float angle = (float)Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);

        _spriteBatch.Draw(
                _pixel, 
                startPoint, 
                null, 
                color, 
                angle, 
                Vector2.Zero, 
                new Vector2(distance, 1), 
                SpriteEffects.None, 
                0
            );
    }
}
