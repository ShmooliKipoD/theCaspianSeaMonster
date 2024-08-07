using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Penumbra;
using SimplexNoise;
using System;
using theCaspianSeaMonster.BL;
using theCaspianSeaMonster.Interfaces;

namespace theCaspianSeaMonster;

public class Game1 : Game
{
    // private GraphicsDeviceManager _graphics;
    private Player _player;
    private double _lastUpdateTime = 0;
    private double _updateInterval = 1000 / 18;
    private Background _background;
    private PenumbraComponent _penumbra;

    private PointLight _light = new PointLight
    {
        Scale = new(1000),
        Position = new(400, 240),
        Color = Color.White,
        Intensity = 1f,
        ShadowType = ShadowType.Solid
    };

    public Game1()
    {
        // _graphics = new GraphicsDeviceManager(this);
        // Content.RootDirectory = "Content";
        // IsMouseVisible = true;
        _penumbra = new(this);
        Components.Add(_penumbra);
        Globals.Penumbra = _penumbra;
    }

    protected override void Initialize()
    {
        base.Initialize();

        Globals.WindowSize = new Point(
                GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height
            );
    }

    protected override void LoadContent()
    {
        _background = new (GraphicsDevice);
        Globals.SpriteBatch = new (GraphicsDevice);;

        Globals.Content = Content;

        _player = new ();
        _player.UpdatePosition(new(250, 250));
        _player.LoadContent();

        Noise.Seed = 209323094; // Optional


        // _penumbra.Lights.Add(
        //     _light
        //     );

        float rad = 100;

        for(float ang = 0; Math.PI * 2 > ang; ang += (float)Math.PI / 16)
        {

            Vector2 offset = new(
                (float)Math.Cos(ang) * rad,
                (float)Math.Sin(ang) * rad
                );

            _penumbra.Hulls.Add(
                new Hull(
                    new Vector2(405, 405) + offset,
                    new Vector2(405, 395) + offset,
                    new Vector2(395, 395)+ offset,
                    new Vector2(395, 405)+ offset
                    
                    )
            );
        }
        _penumbra.Hulls.Add(
            new Hull(
                new Vector2(100, 100),
                new Vector2(200, 100),
                new Vector2(200, 200),
                new Vector2(100, 200)
                )
        );

        _background.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _player.Update(gameTime);

        if (gameTime.TotalGameTime.TotalMilliseconds - this._lastUpdateTime > this._updateInterval)
        {
            this._lastUpdateTime = gameTime.TotalGameTime.TotalMilliseconds;
            //_background.Update(gameTime);
            _light.Position = _light.Position + new Vector2(0, -2);
        }

        Globals.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _penumbra.BeginDraw();

        GraphicsDevice.Clear(Color.White);
        
        // _background.Draw(gameTime);

        _player.Draw(gameTime);
        //_penumbra.Draw(gameTime);

        base.Draw(gameTime);
    }

    protected override void RegisterDependencies(ContainerBuilder builder)
    {
        // throw new NotImplementedException();
    }
}
