// using System;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework;

// namespace theCaspianSeaMonster.Interfaces;

// class Sprite : IDrawable
// {
//     private Texture2D _texture;
//     private Vector2 _origin;
//     private int _frame = 0;
//     private int _frames = 0;
//     private double _time = 0;

//     public Sprite(
//             int width, 
//             int height, 
//             Texture2D texture, 
//             int frames
//         )
//     {
//         Width = width;
//         Height = height;
//         _texture = texture;
//         _origin = new(width / 2, height / 2);
//         _frames = frames;
//         Position = new();
//     }

//     public int Width { get; set; }

//     public int Height { get; set; }

//     public Vector2 Position { get; set; }

//     public float Rotation { get; set; }

//     public void LoadContent() { }

//     public void Update(GameTime gameTime)
//     {
//         if (Math.Abs(_time - gameTime.TotalGameTime.TotalMilliseconds) > 1000 / 7)
//         {
//             _frame = (_frame + 1) % _frames;
//             _time = gameTime.TotalGameTime.TotalMilliseconds;
//         }
//     }

//     public void Draw(GameTime gameTime = null)
//     {
//         Globals.SpriteBatch.Begin();

//         Globals.SpriteBatch.Draw(
//                 _texture,
//                 Position,
//                 new Rectangle(
//                     new Point(_frame * Width, 0),
//                     new Point(Width, Height)
//                 ),
//                 Color.White,
//                 Rotation,
//                 _origin,
//                 2f,
//                 SpriteEffects.None,
//                 0f
//             );
        
//         Globals.SpriteBatch.End();
//     }

//     public void UpdatePosition(Vector2 position)
//     {
//         Position = position;
//     }

//     public void UpdateRotation(float rotation)
//     {
//         Rotation = rotation;
//     }
// }