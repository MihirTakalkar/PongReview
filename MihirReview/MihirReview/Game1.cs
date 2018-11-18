using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MihirReview
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Ball ball;
        Paddle leftpaddle;
        Paddle rightpaddle;
        KeyboardState ks;

        //Texture2D pixel1;
        //Texture2D pixel2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ball = new Ball(Content.Load<Texture2D>("pong"), new Vector2(50, 50), new Vector2(12,12));
            leftpaddle = new Paddle(Content.Load<Texture2D>("GreenPaddle"), new Vector2(0, 100), new Vector2(0, 5));
            rightpaddle = new Paddle(Content.Load<Texture2D>("RedPaddle"), new Vector2(GraphicsDevice.Viewport.Width - 18, 100), new Vector2(0, 5));

            //pixel1 = new Texture2D(GraphicsDevice, 1, 1);
            //pixel1.SetData(new Color[] { Color.White });

            //pixel2 = new Texture2D(GraphicsDevice, 1, 1);
            //pixel2.SetData(new Color[] { Color.White });
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Up))
            {
                rightpaddle.moveup(GraphicsDevice.Viewport.Bounds);
            }

            if(ks.IsKeyDown(Keys.Down))
            {
                rightpaddle.movedown(GraphicsDevice.Viewport.Bounds);
            }

            if (ks.IsKeyDown(Keys.W))
            {
                leftpaddle.moveup(GraphicsDevice.Viewport.Bounds);
            }

            if (ks.IsKeyDown(Keys.S))
            {
                leftpaddle.movedown(GraphicsDevice.Viewport.Bounds);
            }

            ball.Move(GraphicsDevice.Viewport.Bounds);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            ball.Draw(spriteBatch);
            leftpaddle.Draw(spriteBatch);
            rightpaddle.Draw(spriteBatch);
            //spriteBatch.Draw(pixel1, ball.ballhitbox, Color.Red);
            //spriteBatch.Draw(pixel2, leftpaddle.paddlehitbox, Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
