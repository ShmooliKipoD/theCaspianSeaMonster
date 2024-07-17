using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimplexNoise;
using theCaspianSeaMonster.Interfaces;

namespace theCaspianSeaMonster;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _pixel;
    private SpriteStack _player;
    private int _resolution = 3;
    private int _rows;
    private int _cols;
    private double _lastUpdateTime = 0;
    private double _updateInterval = 1000 / 18;
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
        Globals.WindowSize = new Point(
                GraphicsDevice.Viewport.Width, 
                GraphicsDevice.Viewport.Height
            );

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;

        _squareTexture = new Texture2D(GraphicsDevice, 1, 1);
        _squareTexture.SetData(new[] { Color.White });

        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        this._cols = GraphicsDevice.Viewport.Width / this._resolution;
        this._rows = GraphicsDevice.Viewport.Height / this._resolution;

        Globals.Content = Content;

        _player = new (52, 70, Content.Load<Texture2D>("ship.stack"));

        Noise.Seed = 209323094; // Optional
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            _player.Update(gameTime);

        if (gameTime.TotalGameTime.TotalMilliseconds - this._lastUpdateTime > this._updateInterval)
        {
            this._lastUpdateTime = gameTime.TotalGameTime.TotalMilliseconds;
            this._zoff += 1;
            this._yoff += 1;
        }

        Globals.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();


        Color color = Color.Blue;
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _cols; col++)
            {
                int alpha = (int)(Math.Pow(Noise.CalcPixel3D(row - _yoff , col, _zoff, 0.1f)/255,4)*255);

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

        _player.Draw(gameTime);


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
