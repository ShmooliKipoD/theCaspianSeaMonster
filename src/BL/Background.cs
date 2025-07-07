using SimplexNoise;

namespace theCaspianSeaMonster.BL;

class Background(
    GraphicsDevice graphicsDevice
    )//: Interfaces.IDrawable
{
    #region privates

    private int _rows;
    private int _cols;
    private Texture2D _pixel;
    private GraphicsDevice _graphicsDevice = graphicsDevice;
    private Texture2D _squareTexture;
    private int _resolution = 3;
    private int _zoff = 0;
    private int _yoff = 0;

    #endregion

    public Vector2 Position { get; private set; } = new();

    public float Rotation { get; private set; }

    public Vector2 Origin { get; } = new();

    public void Draw(GameTime gameTime = null)
    {
        //TODO: need to fix this
        // Globals.SpriteBatch.Begin();

        Color color = Color.Blue;
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _cols; col++)
            {
                int alpha = (int)(Math.Pow(Noise.CalcPixel3D(row - _yoff, col, _zoff, 0.1f) / 255, 4) * 255);

                Color colorWithAlpha = new Color(color.R, color.G, color.B, alpha);
                //TODO: need to fix this
                // Globals.SpriteBatch.Draw(_squareTexture,
                //         new Rectangle(
                //                 col * _resolution,
                //                 row * _resolution,
                //                 _resolution,
                //                 _resolution
                //             ),
                //         colorWithAlpha
                //     );
            }
        }
        //TODO: need to fix this
        // Globals.SpriteBatch.End();
    }

    public void LoadContent()
    {
        _pixel = new Texture2D(_graphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        _cols = _graphicsDevice.Viewport.Width / this._resolution;
        _rows = _graphicsDevice.Viewport.Height / this._resolution;

        _squareTexture = new Texture2D(_graphicsDevice, 1, 1);
        _squareTexture.SetData(new[] { Color.White });
    }

    public void Update(GameTime gameTime)
    {
        this._zoff += 1;
        this._yoff += 1;
    }

    public void UpdatePosition(Vector2 position) { }

    public void UpdateRotation(float rotation)
    {
        Rotation = rotation;
    }

    #region private Methods

    void DrawLine(Vector2 startPoint, Vector2 endPoint, Color color)
    {
        float distance = Vector2.Distance(startPoint, endPoint);
        float angle = (float)Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);

        //TODO: need to fix this
        // Globals.SpriteBatch.Draw(
        //         _pixel,
        //         startPoint,
        //         null,
        //         color,
        //         angle,
        //         Vector2.Zero,
        //         new Vector2(distance, 1),
        //         SpriteEffects.None,
        //         0
        //     );
    }

    #endregion
}
