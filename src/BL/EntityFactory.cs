using Microsoft.Xna.Framework.Content;
using MonoGame.Extended;
using theCaspianSeaMonster.Collisions;
using theCaspianSeaMonster.Entities;

namespace theCaspianSeaMonster.BL;

internal class EntityFactory(
    MonoGame.Extended.ECS.World world
    , ContentManager content
    )
{
    private MonoGame.Extended.ECS.World _world = world;
    private ContentManager _content = content;

    public Entity CreatePlayer(Vector2 position = default)
    {
        Texture2D bluebird = _content.Load<Texture2D>("Player/bluebirdSheet");
        Texture2DAtlas atlas = Texture2DAtlas.Create(
            "Atlas/bluebirdAtlas"
            , bluebird
            , 32
            , 32
            );

        SpriteSheet spriteSheet = new ("SpriteSheet/bluebird", atlas);

        spriteSheet.DefineAnimation("Forward", builder =>
        {
            builder.IsLooping(true)
                    .AddFrame(1, TimeSpan.FromSeconds(2.5))
                    .AddFrame(2, TimeSpan.FromSeconds(0.2))
                    .AddFrame(1, TimeSpan.FromSeconds(2.5));
                    
        });

        // AddAnimationCycle(spriteSheet, "Forward",   new[] { 1 }, true,  0.5f);
        AddAnimationCycle(spriteSheet, "Left",      new[] { 0 }, false, 0.5f);
        AddAnimationCycle(spriteSheet, "Right",     new[] { 2 }, false, 0.5f);

        Entity entity = _world.CreateEntity();
        entity.Attach(new Sprite(bluebird)); // Pass the required Texture2D or appropriate argument
        entity.Attach(new AnimatedSprite(spriteSheet, "Forward"));
        entity.Attach(new Transform2(position, 0, Vector2.One * 4));
        entity.Attach(new Player());
        entity.Attach(
            new Body
            {
                Position = position,
                Size = new Vector2(32, 64),
                BodyType = BodyType.Dynamic
            });
        return entity;
    }

    private void AddAnimationCycle(
        SpriteSheet spriteSheet
        , string name
        , int[] frames
        , bool isLooping = true
        , float frameDuration = 0.1f
        )
    {
        spriteSheet.DefineAnimation(name, builder =>
        {
            builder.IsLooping(isLooping);
            for (int i = 0; i < frames.Length; i++)
            {
                builder.AddFrame(frames[i], TimeSpan.FromSeconds(frameDuration));
            }
        });
    }
}