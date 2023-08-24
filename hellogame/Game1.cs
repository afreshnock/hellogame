using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace hellogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _ballTexture;
        private Vector2 _ballposition;
        private Vector2 _ballvelocity;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ballposition = new Vector2((_graphics.GraphicsDevice.Viewport.Width - 64) / 2,( _graphics.GraphicsDevice.Viewport.Height - 64) / 2);
            System.Random rnd = new System.Random(); ;
            _ballvelocity = new Vector2((float)rnd.NextDouble(), (float)rnd.NextDouble());
            _ballvelocity.Normalize();
            _ballvelocity *= 100;

            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ballTexture = Content.Load<Texture2D>("ball");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _ballposition += _ballvelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if( _ballposition.X < _graphics.GraphicsDevice.Viewport.X || _ballposition.X > _graphics.GraphicsDevice.Viewport.Width - 64)
            {
                _ballvelocity.X *= -1; 
            }
            if (_ballposition.Y < _graphics.GraphicsDevice.Viewport.Y || _ballposition.Y > _graphics.GraphicsDevice.Viewport.Height - 64)
            {
                _ballvelocity.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_ballTexture, _ballposition, Color.White);

            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}