using Game_DX.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Game_DX.Input;
using Game_DX.Character;

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
        Sprite testCharacterSprite;
        Texture2D grassTexture;
        Texture2D ballTexture;
        Texture2D colors;
        Texture2D bwTexture;
        Texture2D grassyDirtTexture;
        Texture2D testCharacterTexture;
        Texture2D testGlovesTexture;
        Texture2D testChestTexture;
        Texture2D testPantsTexture;
        Texture2D testBootsTexture;
        Texture2D testHelmetTexture;
        Texture2D testCloakTexture;
        Texture2D testEmptyTexture;
        TestCharacterClass testCharacter;



        Map map;
        KeyboardListener keyboardListener;
        int ticks = 0;

        // Frame counts for keeping an eye on performace
        private int frameRate = 0;
        private int frameCounter = 0;
        private TimeSpan elapsedTime = TimeSpan.Zero;

        public MainGame() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            // If we do a settings screen, this stuff can be moved to a method there and just called here.
            graphics.PreferredBackBufferWidth = ConfigManager.Instance.GraphicsWidth;
            graphics.PreferredBackBufferHeight = ConfigManager.Instance.GraphicsHeight;
            graphics.IsFullScreen = ConfigManager.Instance.FullScreen;
            graphics.ApplyChanges();
            keyboardListener = new KeyboardListener();
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
            
            ball = new Sprite(ballTexture, 1, 12, 4);
            map = new Map(30, 50, grassTexture, grassyDirtTexture);
            testCharacterSprite = new Sprite(testCharacterTexture, 1, 1, 4);
            testCharacter = new TestCharacterClass(testCharacterSprite, keyboardListener, testGlovesTexture, testChestTexture
                                                , testPantsTexture, testHelmetTexture, testCloakTexture, testBootsTexture, testEmptyTexture);
            map.Initialize();
            IsMouseVisible = true;
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            testCharacterTexture = Content.Load<Texture2D>(@"test_character\test_character_body");
            testGlovesTexture = Content.Load<Texture2D>(@"test_character\test_character_gloves");
            testBootsTexture = Content.Load<Texture2D>(@"test_character\test_character_boots");
            testHelmetTexture = Content.Load<Texture2D>(@"test_character\test_character_helmet");
            testChestTexture = Content.Load<Texture2D>(@"test_character\test_character_chest");
            testPantsTexture = Content.Load<Texture2D>(@"test_character\test_character_pants");
            testCloakTexture = Content.Load<Texture2D>(@"test_character\test_character_cloak");
            testEmptyTexture = Content.Load<Texture2D>(@"test_character\test_character_empty");
            ballTexture = Content.Load<Texture2D>("Basic_Ball");
            grassTexture = Content.Load<Texture2D>("grass_motion_simple_background");
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
            var state = Keyboard.GetState();
            keyboardListener.Update(state, gameTime);
            if (ConfigManager.Instance.FPS)
                ticks++;

            // Move the object first, then update side things...
            //ball.moveDirection(Keyboard.GetState().GetPressedKeys());
            //ball.Update();
            testCharacter.Update(gameTime);
            

            // Map delay needs to be built into the map... Sorry Josh.
            map.Update();

            // Update to change this debug flag to a setting in our app.config... F it, I'll just do it now...
            if (ConfigManager.Instance.FPS)
            {
                // Update the title bar so we can see FPS easier.
                elapsedTime += gameTime.ElapsedGameTime;
                if (elapsedTime > TimeSpan.FromSeconds(1))
                {
                    elapsedTime -= TimeSpan.FromSeconds(1);
                    frameRate = frameCounter;
                    Window.Title = $"Game_Title!!   FPS:{frameRate}   Ticks:{ticks}";
                    frameCounter = 0;
                    ticks = 0;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (ConfigManager.Instance.FPS)
                frameCounter++;

            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            map.Draw(spriteBatch);
            testCharacter.Draw(spriteBatch);
            //ball.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
