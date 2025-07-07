using MonoGame.Extended;
using theCaspianSeaMonster.Collisions;

namespace theCaspianSeaMonster.Systems;

public class RenderSystem : EntityDrawSystem
{
    private readonly SpriteBatch _spriteBatch;
    private readonly OrthographicCamera _camera;
    private readonly Texture2D _pixelTexture;
    private ComponentMapper<AnimatedSprite> _animatedSpriteMapper;
    private ComponentMapper<Sprite> _spriteMapper;
    private ComponentMapper<Body> _bodyMapper;
    private ComponentMapper<Transform2> _transforMapper;

    public RenderSystem(
        SpriteBatch spriteBatch,
        OrthographicCamera camera,
        GraphicsDevice graphicsDevice
        )
        : base(
            Aspect.All(
                typeof(Transform2)
                ).One(
                    typeof(AnimatedSprite),
                    typeof(Sprite))
                )
    {
        _spriteBatch = spriteBatch;
        _camera = camera;

        _pixelTexture = new Texture2D(graphicsDevice, 1, 1);
        _pixelTexture.SetData(new[] { Color.White });
    }

    public override void Initialize(IComponentMapperService mapperService)
    {
        _transforMapper = mapperService.GetMapper<Transform2>();
        _animatedSpriteMapper = mapperService.GetMapper<AnimatedSprite>();
        _spriteMapper = mapperService.GetMapper<Sprite>();
        _bodyMapper = mapperService.GetMapper<Body>();

    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin(
            samplerState: SamplerState.PointClamp, 
            transformMatrix: _camera.GetViewMatrix()
            );

        foreach (var entity in ActiveEntities)
        {
            var sprite = _animatedSpriteMapper.Has(entity)
                ? _animatedSpriteMapper.Get(entity)
                : _spriteMapper.Get(entity);
            var transform = _transforMapper.Get(entity);

            if (sprite is AnimatedSprite animatedSprite)
                animatedSprite.Update(gameTime);

            _spriteBatch.Draw(sprite, transform);

            Body body = _bodyMapper.Get(entity); // TODO: should move to debug rander system. 
            if(null != body)
            {
                var rect = new Rectangle((int)body.Position.X, (int)body.Position.Y, (int)body.Size.X, (int)body.Size.Y);
                _spriteBatch.Draw(_pixelTexture, rect, Color.Red * 0.5f);

                // _spriteBatch.Draw(_spriteBatch, transform.Position);
            }
        }   

        _spriteBatch.End();
    }
}
