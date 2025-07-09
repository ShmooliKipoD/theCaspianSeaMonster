using MonoGame.Extended;
using MonoGame.Extended.Input;
using theCaspianSeaMonster.Collisions;
using theCaspianSeaMonster.Entities;

namespace theCaspianSeaMonster.Systems;

class GreenLakeBackgoundSystem : EntityDrawSystem
{
    // private TiledMap _tiledMap;
    // private TiledMapRenderer _tiledMapRenderer;

    // private AnimatedSprite _animatedSprite;

    private readonly SpriteBatch _spriteBatch;

    private AnimatedSprite _animaton;
    
    private ComponentMapper<AnimatedSprite> _animatedSpriteMapper;

    public GreenLakeBackgoundSystem(SpriteBatch spriteBatch)
        : base(
            Aspect.All(
                typeof(Sprite)
                , typeof(Transform2)
                , typeof(AnimatedSprite)
                )
        )
    {
        _spriteBatch = spriteBatch;
    }

    // protected override void LoadContent()
    // {
    //     _tiledMap = Content.Load<TiledMap>("samplemap");
    //     _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);

    //     _spriteBatch = new SpriteBatch(GraphicsDevice);
    // }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _animatedSpriteMapper = mapperService.GetMapper<AnimatedSprite>();

        // _animaton = _animatedSpriteMapper.Get(entityId);
        
        // _animaton.SetAnimation("UpwardCliff");
    }

    public override void Draw(GameTime gameTime)
    {
        // _spriteBatch.Begin(
        //         samplerState: SamplerState.PointClamp,
        //         transformMatrix: _camera.GetViewMatrix()
        //         );

        


        // _spriteBatch.End();
    }


}
