using Autofac;

namespace theCaspianSeaMonster;
public abstract class Game : Microsoft.Xna.Framework.Game
{
    protected GraphicsDeviceManager GraphicsDeviceManager { get; }
    protected IContainer Container { get; private set; }
    public int Width { get; }
    public int Height { get; }

    protected Game(int width = 800, int height = 480)
    {
        Width = width;
        Height = height;
        GraphicsDeviceManager = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = width,
            PreferredBackBufferHeight = height
        };
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        ContainerBuilder containerBuilder = new();

        RegisterDependencies(containerBuilder);
        
        Container = containerBuilder.Build();

        base.Initialize();
    }

    protected abstract void RegisterDependencies(ContainerBuilder builder);
}
