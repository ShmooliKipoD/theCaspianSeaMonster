using theCaspianSeaMonster.Collisions;

namespace theCaspianSeaMonster.Systems;

class PlayerSystem : EntityProcessingSystem
{
    private ComponentMapper<Body> _bodyMapper;
    private ComponentMapper<Sprite> _spriteMapper;
    private ComponentMapper<AnimatedSprite> _animatedSpriteMapper;

    public PlayerSystem()
        : base(
            Aspect.All(
                typeof(Body)
                , typeof(Sprite)
                , typeof(AnimatedSprite)
                )
            ) { }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _bodyMapper = mapperService.GetMapper<Body>();
        _spriteMapper = mapperService.GetMapper<Sprite>();        
        _animatedSpriteMapper = mapperService.GetMapper<AnimatedSprite>();
    }

    public override void Process(GameTime gameTime, int entityId)
    {
        
        var animaton = _animatedSpriteMapper.Get(entityId);
        animaton.SetAnimation("Forward");
    }
}