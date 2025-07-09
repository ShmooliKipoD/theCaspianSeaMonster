using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace theCaspianSeaMonster.Systems
{
    public class CheckerboardBackgroundSystem : DrawSystem
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _pixelTexture;
        private Color _color1 = Color.LightGray;
        private Color _color2 = Color.DarkGray;
        private int _tileSize = 64;
        
        private readonly OrthographicCamera _camera;

        public CheckerboardBackgroundSystem(GraphicsDevice graphicsDevice, OrthographicCamera camera)
        {
            _spriteBatch = new SpriteBatch(graphicsDevice);
            _camera = camera;
            // Create a 1x1 white pixel texture
            _pixelTexture = new Texture2D(graphicsDevice, 1, 1);
            _pixelTexture.SetData(new[] { Color.White });
            var viewport = _spriteBatch.GraphicsDevice.Viewport;
            _startX = -(viewport.Width / _tileSize) - 1;
            endX = (viewport.Width / _tileSize) + 1;
            startY = -(viewport.Height / _tileSize) - 1;
            endY = (viewport.Height / _tileSize) + 1;
        }

        int _startX;
        int endX;
        int startY;
        int endY;
        public override void Draw(GameTime gameTime)
        {
            
            // Calculate how many tiles we need to cover the screen
            // int startX = -(viewport.Width / _tileSize) - 1;
            // int endX = (viewport.Width / _tileSize) + 1;
            // int startY = -(viewport.Height / _tileSize) - 1;
            // int endY = (viewport.Height / _tileSize) + 1;

            // Begin without any transformation matrix to keep it fixed to screen coordinates
            _spriteBatch.Begin(
                samplerState: SamplerState.PointClamp, 
                transformMatrix: _camera.GetViewMatrix()
                );

            for (int x = _startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    Color color = (x + y) % 2 == 0 ? _color1 : _color2;
                    var rect = new Rectangle(x * _tileSize, y * _tileSize, _tileSize, _tileSize);
                    _spriteBatch.Draw(_pixelTexture, rect, color);
                }
            }

            _spriteBatch.End();
        }
    }
}