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

        public const float characterSpeed = 100f;


        public TestCharacterClass(Sprite sprite, KeyboardListener listener)
        {
            listener.AddSubscriber(this);
            CharacterSprite = sprite;
            Velocity = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
            CharacterSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var texture = CharacterSprite.Texture;
            int width = texture.Width / CharacterSprite.Columns;
            int height = texture.Height / CharacterSprite.Rows;
            int row = (int)((float)CharacterSprite.currentFrame / (float)CharacterSprite.Columns);
            int column = CharacterSprite.currentFrame % CharacterSprite.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
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
                                            };

            var velocity = Vector2.Zero;

            foreach (var key in keyDictonary)
            {
                if(keyboardChangeState.CurrentState.IsKeyDown(key.Key))
                {
                    velocity += key.Value;
                }

            }

            //normolizes the vector so you don't move dignal faster than other directions
            if(velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            Velocity = velocity * characterSpeed;

            Position += (Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
