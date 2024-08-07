using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using Penumbra;
using theCaspianSeaMonster.Interfaces;

namespace theCaspianSeaMonster.BL;

class Player : IGameObject
{
    private KeyboardListener _keyboardListener;
    private float _valosity = 0;
    private double _time = 0;
    private float _rotation;
    private float _lightPositionOffset = 0.0f;
    private Vector2 _position;
    private PointLight _ambientLight = new PointLight{
        Color = Color.LightGray,
        Intensity = 0.15f,
        Scale = new(600),
        Position = new(),
        ShadowType = ShadowType.Solid
    };
    
    private SpriteAnimation _shipModel = new(
                      32
                    , 32
                    , Globals.Content.Load<Texture2D>("Player/bluebirdSheet")
                    , 1
                    // , Globals.Content.Load<Effect>("Shaders/ShipColor")
                );

    private Spotlight _light = new Spotlight
    {
        Scale = new(300),
        Position = new(),
        Color = Color.DarkOrange,
        Intensity = 0.4f,
        ShadowType = ShadowType.Solid,
        Rotation = 0,
    };

    public Player()
    {
        _keyboardListener = new();
    }

    public Vector2 Position => _position;

    public float Rotation => _rotation;

    public void Draw(GameTime gameTime = null)
    {
        _shipModel.Draw(gameTime);
    }

    public void LoadContent()
    {
        _shipModel.LoadContent();
        _lightPositionOffset = _shipModel.Height / 2;
        _light.Position = Position + new Vector2(_lightPositionOffset, 5);
        _ambientLight.Position = Position;
        Globals.Penumbra.Lights.Add(_light);
        Globals.Penumbra.Lights.Add(_ambientLight);

        _keyboardListener.KeyPressed += (s, e) =>
        {
            Action act = e.Key switch
            {
                Keys.A => () => UpdateRotation(Rotation - 0.1f),
                Keys.D => () => UpdateRotation(Rotation + 0.1f),
                _ => () => { }
            };
            act();
        };

        _keyboardListener.KeyPressed += (s, e) =>
        {
            Action act = e.Key switch
            {
                Keys.W => () => _valosity += 0.1f,
                Keys.S => () => _valosity -= 0.1f,
                _ => () => { }
            };
            act();
        };
    }

    public void Update(GameTime gameTime)
    {
        if (Math.Abs(_time - gameTime.TotalGameTime.TotalMilliseconds) > 1000 / 7)
        {
            _time = gameTime.TotalGameTime.TotalMilliseconds;
        }
        _keyboardListener.Update(gameTime);
        UpdatePosition(new Vector2((float)Math.Cos(Rotation) * _valosity, (float)Math.Sin(Rotation) * _valosity));
    }

    public void UpdatePosition(Vector2 position)
    {
        _light.Position = _light.Position + position;//Position + new Vector2(_lightPositionOffset, 5);
        _ambientLight.Position = _ambientLight.Position + position;
        _shipModel.UpdatePosition(Position + position);
        _position += position;
    }

    public void UpdateRotation(float rotation)
    {
        _rotation = rotation;   
        _shipModel.UpdateRotation(rotation);
        //UpdateRotation(rotation);
        _light.Rotation = rotation;
        _light.Position = _shipModel.Position + new Vector2(
            (float)Math.Cos(rotation) * _lightPositionOffset,
            (float)Math.Sin(rotation) * _lightPositionOffset
            );
    }
}