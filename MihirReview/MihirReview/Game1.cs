using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        int rightscore = 0;
        int leftscore = 0;
        bool right = true;
        bool left = true;
        SpriteFont font;

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

            ball = new Ball(Content.Load<Texture2D>("pong"), new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), new Vector2(7,7));
            leftpaddle = new Paddle(Content.Load<Texture2D>("GreenPaddle"), new Vector2(0, 100), new Vector2(0, 5));
            rightpaddle = new Paddle(Content.Load<Texture2D>("RedPaddle"), new Vector2(GraphicsDevice.Viewport.Width - 18, 100), new Vector2(0, 5));

            font = Content.Load<SpriteFont>("font1");

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

            if (right == true && left == true)
            {
                if (ball.ballhitbox.Intersects(rightpaddle.paddlehitbox))
                {
                    ball.Speed = new Vector2(-Math.Abs(ball.Speed.X), ball.Speed.Y);
                }

                if (ball.ballhitbox.Intersects(leftpaddle.paddlehitbox))
                {
                    ball.Speed = new Vector2(Math.Abs(ball.Speed.X), ball.Speed.Y);
                }
           
                if (ks.IsKeyDown(Keys.Up))
                {
                    rightpaddle.moveup(GraphicsDevice.Viewport.Bounds);
                }

                if (ks.IsKeyDown(Keys.Down))
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

                if (ball.HitLeft)
                {
                    rightscore++;
                }

                if (ball.HitRight)
                {
                    leftscore++;
                }

                if (leftscore >= 10)
                {
                    right = false;
                    leftscore = 0;
                }

                if (rightscore >= 10)
                {
                    left = false;
                    rightscore = 0;
                }
            }
            else
            {
                //check if the r key is pressed
                //and restart

            }


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
            spriteBatch.DrawString(font, rightscore.ToString(), new Vector2(GraphicsDevice.Viewport.Width / 2 + 20, 0), Color.White);
            spriteBatch.DrawString(font, leftscore.ToString(), new Vector2(GraphicsDevice.Viewport.Width / 2 - 20, 0), Color.White);
            if(left == false)
            {
                spriteBatch.DrawString(font, $"Right Side Wins", new Vector2(GraphicsDevice.Viewport.Width - 250, 0 ), Color.Red);
                spriteBatch.DrawString(font, $"Press R to Reset", new Vector2(300, 200), Color.Green);
            }
            if (right == false)
            {
                spriteBatch.DrawString(font, $"Left Side Wins", new Vector2(0, 0), Color.Red);
                spriteBatch.DrawString(font, $"Press R to Reset", new Vector2(300, 200), Color.Green);

            }
            //spriteBatch.Draw(pixel1, ball.ballhitbox, Color.Red);
            //spriteBatch.Draw(pixel2, leftpaddle.paddlehitbox, Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
