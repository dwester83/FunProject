using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Tiles
{
    class Shadow : IDisposable
    {
        public double SunX
        { 
            get 
            { 
                //need to get total width of screen and work out an algorithm
                int position  = WindowWidth / 60;
                var second = DateTime.Now.Second;
                position = position % ((second > 0) ? second : 1);
                return position;
            } 
        }
        public double SunY { get; set; }
        public Vector2 Location { get; set; }
        public BasicEffect basicEffect { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int WindowWidth { get; set; }
        public VertexPositionColor[] vertices { get; private set; }

        public Shadow(int length, Vector2 location, int width, int height)
        {
            Height = height;
            Length = length;
            Width = width;
            WindowWidth = ConfigManager.Instance.GraphicsWidth;
            Location = location;
            vertices = new VertexPositionColor[4];
            CreateShadowPoints();
        }
        private void CreateShadowPoints()
        {
            var centerX = Location.X - (Width / 2);
            var centerY = Location.Y - (Height / 2);

            //make a perpendicular rise and run to the line connecting the sun and the shadow object
            float rise = (float)(centerX - SunX) / Width / 2;
            float run = (float)(centerY - SunY) / Height / 2;


            vertices[0] = new VertexPositionColor(new Vector3(centerX + run, centerY + rise, 0), Color.Black);
            vertices[1] = new VertexPositionColor(new Vector3(centerX - run, centerY - rise, 0), Color.Black);
            vertices[3] = new VertexPositionColor(new Vector3(vertices[1].Position.X + run, vertices[1].Position.Y - rise, 0), Color.Black);
            vertices[2] = new VertexPositionColor(new Vector3(vertices[0].Position.X + run, vertices[0].Position.Y - rise, 0), Color.Black);

        }
        public void Update()
        {
            CreateShadowPoints();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (basicEffect == null)
            {
                GraphicsDevice graphicsDevice = spriteBatch.GraphicsDevice;
                basicEffect = new BasicEffect(graphicsDevice);
                basicEffect.VertexColorEnabled = true;
                basicEffect.Projection = Matrix.CreateOrthographicOffCenter
                   (0, graphicsDevice.Viewport.Width,     // left, right
                    graphicsDevice.Viewport.Height, 0,    // bottom, top
                    0, 1);
            }

            basicEffect.CurrentTechnique.Passes[0].Apply();
            spriteBatch.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertices, 0, 2);
            
        }

        #region Disposable

        public void Dispose()
        {
            basicEffect.Dispose();
        }

        #endregion
    }
}
