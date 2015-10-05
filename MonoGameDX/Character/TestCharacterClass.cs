using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_DX.Input;
using Microsoft.Xna.Framework.Input;

namespace Game_DX.Character
{
    class TestCharacterClass : IInputSubscriber
    {
        public Vector2 Position { get; set; }
        public Sprite CharacterSprite { get; set; }
        public Vector2 Velocity { get; private set; }
        public int CharacterSize { get; set; }
        public const float characterSpeed = 100f;
        private CharacterTextureFactory TextureFactory = CharacterTextureFactory.GetInstance();
        

        public TestCharacterClass(Sprite sprite, KeyboardListener listener,GraphicsDevice device, Texture2D glovesTexture)
        {
            
            TextureFactory.PlayerTexture = sprite.Texture;
            TextureFactory.GlovesTexture = glovesTexture;
            listener.AddSubscriber(this);
            CharacterSprite = sprite;
            Velocity = Vector2.Zero;
            CharacterSize = 4;
            TextureFactory.PlayerHairColor = Color.Purple;
            TextureFactory.GlovesPrimaryColor = Color.Red;
            TextureFactory.GlovesSecondaryColor = Color.Black;
            TextureFactory.Target = new RenderTarget2D(device, sprite.Texture.Width, sprite.Texture.Height);
            
        }

        public void Update(GameTime gameTime)
        {
            CharacterSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CharacterSprite.Texture = TextureFactory.GetCharacterTexture();
            CharacterSprite.Draw(spriteBatch,Position,CharacterSize);
        }

        public void NotifyOfChange(KeyboardChangeState keyboardChangeState, GameTime gameTime)
        {
            moveCharacter(keyboardChangeState, gameTime);
        }

        private void moveCharacter(KeyboardChangeState keyboardChangeState, GameTime gameTime)
        {
            var keyDictonary = new Dictionary<Keys, Vector2>
                                            {
                                                 {Keys.Left , new Vector2(-1, 0) },
                                                 {Keys.Right , new Vector2(1, 0) },
                                                 {Keys.Up , new Vector2(0, -1) },
                                                 {Keys.Down , new Vector2(0, 1) },
                                                 {Keys.A , new Vector2(-1, 0) },
                                                 {Keys.D , new Vector2(1, 0) },
                                                 {Keys.W , new Vector2(0, -1) },
                                                 {Keys.S , new Vector2(0, 1) }
                                            };

            var velocity = Vector2.Zero;

            foreach (var key in keyDictonary)
            {
                if(keyboardChangeState.CurrentState.IsKeyDown(key.Key))
                {
                    
                    velocity += key.Value;
                    if(velocity.X > 1) { velocity.X = 1; }
                    if (velocity.X < -1) { velocity.X = -1; }
                    if (velocity.Y > 1) { velocity.Y = 1; }
                    if (velocity.Y < -1) { velocity.Y = -1; }
                }

            }

            //normalizes the vector so you don't move diagnal faster than other directions
            if(velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            Velocity = velocity * characterSpeed;

            Position += (Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
