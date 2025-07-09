using MonoGame.Extended;
using MonoGame.Extended.Input;
using theCaspianSeaMonster.Collisions;
using theCaspianSeaMonster.Entities;

namespace theCaspianSeaMonster.Systems;

class PlayerSystem : EntityProcessingSystem
{
    private ComponentMapper<Body> _bodyMapper;
    private ComponentMapper<Sprite> _spriteMapper;
    private ComponentMapper<AnimatedSprite> _animatedSpriteMapper;
    private ComponentMapper<Transform2> _transformMapper;

    public PlayerSystem()
        : base(
            Aspect.All(
                typeof(Body)
                , typeof(Transform2)
                , typeof(Sprite)
                , typeof(AnimatedSprite)
                , typeof(Player)
                )
            )
    { }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _bodyMapper = mapperService.GetMapper<Body>();
        _spriteMapper = mapperService.GetMapper<Sprite>();
        _animatedSpriteMapper = mapperService.GetMapper<AnimatedSprite>();
        _transformMapper = mapperService.GetMapper<Transform2>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {

        var animaton = _animatedSpriteMapper.Get(entityId);
        var body = _bodyMapper.Get(entityId);
        var transform = _transformMapper.Get(entityId);
        // var sprite = _spriteMapper.Get(entityId);

        KeyboardStateExtended keyboardState = KeyboardExtended.GetState();

        animaton.SetAnimation("Forward");

        if (keyboardState.IsKeyDown(Keys.Right)
            || keyboardState.IsKeyDown(Keys.D)
            )
        {
            animaton.SetAnimation("Right");
            body.Position.X += 7;
        }

        if (keyboardState.IsKeyDown(Keys.Left)
            || keyboardState.IsKeyDown(Keys.A)
            )
        {
            animaton.SetAnimation("Left");
            body.Position.X -= 7;
        }

        if (keyboardState.IsKeyDown(Keys.Up)
            || keyboardState.IsKeyDown(Keys.W)
            )
        {
            body.Position.Y -= 7;
        }

        if (keyboardState.IsKeyDown(Keys.Down)
            || keyboardState.IsKeyDown(Keys.S)
            )
        {
            body.Position.Y += 7;
        }


    }
}