using Autofac;
using MonoGame.Extended;
using MonoGame.Extended.Input;
using theCaspianSeaMonster.BL;
using theCaspianSeaMonster.Systems;

namespace theCaspianSeaMonster;

public class GameMain : Game
{
    private OrthographicCamera _camera;
    // private double _lastUpdateTime = 0;
    // private double _updateInterval = 1000 / 18;
    private World _world;
    // private PenumbraComponent _penumbra;
    private EntityFactory _entityFactory;

    // private PointLight _light = new PointLight
    // {
    //     Scale = new(1000),
    //     Position = new(400, 240),
    //     Color = Color.White,
    //     Intensity = 1f,
    //     ShadowType = ShadowType.Solid
    // };
    private Entity _playerEntity;

    public GameMain()
    {
        // _penumbra = new(this);
        // Components.Add(_penumbra);

        // Globals.Penumbra = _penumbra;
    }


    protected override void RegisterDependencies(ContainerBuilder builder)
    {
        _camera = new OrthographicCamera(GraphicsDevice);
        // // builder.RegisterInstance(_penumbra);
        // builder.RegisterInstance(new SpriteBatch(GraphicsDevice));
        // builder.RegisterInstance(_camera);
    }

    protected override void LoadContent()
    {
        _world = new WorldBuilder()
                        .AddSystem(new WorldSystem())
                        .AddSystem(new PlayerSystem())
                        .AddSystem(
                            new RenderSystem(
                                new SpriteBatch(GraphicsDevice), 
                                _camera)
                                )
                        .Build();

        Components.Add(_world);

        _entityFactory = new EntityFactory(_world, Content);
        _playerEntity = _entityFactory.CreatePlayer();
        
        //_background = new (GraphicsDevice);
        // Globals.SpriteBatch = new (GraphicsDevice);;

        // Globals.Content = Content;

        // _player = new ();
        // _player.UpdatePosition(new(250, 250));
        // _player.LoadContent();

        // Noise.Seed = 209323094; // Optional


        // _penumbra.Lights.Add(
        //     _light
        //     );

        // float rad = 100;

        // for(float ang = 0; Math.PI * 2 > ang; ang += (float)Math.PI / 16)
        // {

        //     Vector2 offset = new(
        //         (float)Math.Cos(ang) * rad,
        //         (float)Math.Sin(ang) * rad
        //         );

        //     _penumbra.Hulls.Add(
        //         new Hull(
        //             new Vector2(405, 405) + offset,
        //             new Vector2(405, 395) + offset,
        //             new Vector2(395, 395)+ offset,
        //             new Vector2(395, 405)+ offset
                    
        //             )
        //     );
        // }
        // _penumbra.Hulls.Add(
        //     new Hull(
        //         new Vector2(100, 100),
        //         new Vector2(200, 100),
        //         new Vector2(200, 200),
        //         new Vector2(100, 200)
        //         )
        // );

        //_background.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _world.Update(gameTime);
        _camera.LookAt(_playerEntity.Get<Transform2>().Position);
        KeyboardExtended.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // _penumbra.BeginDraw();

        GraphicsDevice.Clear(Color.White);
        _world.Draw(gameTime);
        // _background.Draw(gameTime);

        // _player.Draw(gameTime);
        //_penumbra.Draw(gameTime);

        base.Draw(gameTime);
    }
}
