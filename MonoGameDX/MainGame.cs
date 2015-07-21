using Game_DX.Tiles;
using GameShapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_DX
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ball;
        Texture2D grassTexture;
        Texture2D ballTexture;
        Texture2D colors;
        Texture2D bwTexture;
        Texture2D grassyDirtTexture;
        Map map;
        int count = 0;
        //test stuff
        int x = 100;
        int y = 100;
        bool reverse = false;
        public MainGame()
            : base()
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

            base.Initialize();
            ball = new Sprite(ballTexture, 1, 12);
            map = new Map(30, 50, grassTexture, grassyDirtTexture);
            map.Initialize();
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTexture = Content.Load<Texture2D>("Basic_Ball");
            grassTexture = Content.Load<Texture2D>("grass_motion");
            grassyDirtTexture = Content.Load<Texture2D>("grassy_dirt");
            colors = Content.Load<Texture2D>("Colors");
            bwTexture = Content.Load<Texture2D>("black_white");
            // TODO: use this.Content to load your game content here
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            count++;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (count % 1 == 0)
            {
                map.Update();
            }
            // TODO: Add your update logic here
            if (count % 3 == 0)
            {
                ball.Update();
            }

            if (reverse)
            {
                x--;
            }
            else
            {
                x++;
            }

            if (x > 500) reverse = true;
            if (x < 100) reverse = false;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            map.Draw(spriteBatch);
            ball.Draw(spriteBatch, new Vector2(x, y),2);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
