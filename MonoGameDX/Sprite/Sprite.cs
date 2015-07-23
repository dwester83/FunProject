using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int updateFrame;
        private int totalFrames;

        private Vector2 nextPosition;
        private Vector2 currentPosition;

        /// <summary>
        /// Property for the sprite size being drawn. Public avalible to be changed as needed.
        /// </summary>
        private int spriteSize = 1;
        public int SpriteSize
        {
            get { return spriteSize; }
            set
            {
                if (value < 1)
                {
                    spriteSize = 1;
                }
                else
                {
                    spriteSize = value;
                }
            }
        }

        /// <summary>
        /// Property for Movement speed. Currenly can't be reverse, probably will change that...
        /// </summary>
        private int moveSpeed = 1;
        public int MoveSpeed
        {
            get { return moveSpeed; }
            set
            {
                if (value < 0)
                {
                    moveSpeed = 0;
                }
                else
                {
                    moveSpeed = value;
                }
            }
        }

        /// <summary>
        /// How fast the frame will update, lower if faster... May rework to have higher go faster...
        /// </summary>
        private int updateFrameSpeed = 1;
        public int UpdateFrameSpeed
        {
            get { return updateFrameSpeed; }
            set
            {
                if (value < 1)
                {
                    updateFrameSpeed = 1;
                }
                else
                {
                    updateFrameSpeed = value;
                }
            }
        }

        public Sprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        // Should probably just make this a new object for a character/object...
        public Sprite(Texture2D texture, int rows, int columns, Vector2 currentLocation, int moveSpeed = 1, int spriteSize = 1, int updateFrameSpeed = 1)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            updateFrame = 0;
            totalFrames = Rows * Columns;
            nextPosition = currentPosition = currentLocation; // This needs to be fixed

            // Optionals
            MoveSpeed = moveSpeed;
            SpriteSize = spriteSize;
            UpdateFrameSpeed = updateFrameSpeed;
        }

        public void Update()
        {
            if (!nextPosition.Equals(currentPosition))
            {
                // An update occured... Inital attempt, need to pass a way to refer to valid moves/collisions
                if (nextPosition.X < 0 || nextPosition.X > 500 || nextPosition.Y < 0 || nextPosition.Y > 400)
                    nextPosition = currentPosition;
                currentPosition = nextPosition;

                updateFrame++;
                if (updateFrame % moveSpeed == 0)
                    currentFrame++;

                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
            else
            {
                updateFrame = 0;
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, width * spriteSize, height * spriteSize);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        // Odd the object doesn't take care of its own location...? Should only need to be passed to it for inital location, with a method to tell it to update the location, with speed/time
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        // Size should really be told by the constructor with a method avalible to change the size, shouldn't need to always be passed...
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int increaseSizeBy)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * increaseSizeBy, height * increaseSizeBy);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void moveDirection(Keys[] keys)
        {
            if (keys.Length > 0)
            {
                nextPosition = currentPosition;
                foreach (var direction in keys)
                {
                    if (direction == Keys.Up)
                    {
                        nextPosition.Y -= MoveSpeed;
                    }
                    else if (direction == Keys.Down)
                    {
                        nextPosition.Y += MoveSpeed;
                    }
                    else if (direction == Keys.Right)
                    {
                        nextPosition.X += MoveSpeed;
                    }
                    else if (direction == Keys.Left)
                    {
                        nextPosition.X -= MoveSpeed;
                    }
                }
            }
        }

    }

}
