using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShapes
{
    public abstract class AbstractGameShape
    {
        private BasicEffect BasicEffect { get; set; }
        protected int SideLength { get; set; }

        //this is an array used for determining if a point is inside shape
        protected VertexPositionColor[] Vectors { get; set; }
        //This is an array of Verticies that holds that shapes positions
        protected VertexPositionColor[] Vertices { get; set; }

        // This is an array of Vertices that hold the border positions 
        protected VertexPositionColor[] Borders { get; set; }

        protected int NumberOfSides { get; set; }

        protected int hoverPosition = 0;
        
        protected Color InsideColor { get; set; }
        protected Color OutsideColor { get; set; }
        protected Color BorderColor { get; set; }
        protected Color HoverInsideColor { get; set; }
        protected Color HoverOutsideColor { get; set; }
        protected Color HoverBorderColor { get; set; }

        public void Initialize(float x, float y, GraphicsDevice graphicsDevice)
        {
            InsideColor = Color.Gray;
            OutsideColor = Color.Gray;
            BorderColor = Color.Black;
            HoverInsideColor = Color.LightGray;
            HoverOutsideColor = Color.LightGray;
            HoverBorderColor = Color.Black;

            BasicEffect = new BasicEffect(graphicsDevice);
            BasicEffect.VertexColorEnabled = true;
            BasicEffect.Projection = Matrix.CreateOrthographicOffCenter
               (0, graphicsDevice.Viewport.Width,     // left, right
                graphicsDevice.Viewport.Height, 0,    // bottom, top
                0, 1); // near, far plane

            changeSize(x, y, SideLength);
            changeLocation(x, y);

        }
        public void Initialize(float x, float y, GraphicsDevice graphicsDevice, Color insideColor, Color outsideColor, Color borderColor)
        {
            InsideColor = insideColor;
            OutsideColor = outsideColor;
            BorderColor = borderColor;
            HoverInsideColor = OutsideColor;
            HoverOutsideColor = InsideColor;
            HoverBorderColor = BorderColor;

            BasicEffect = new BasicEffect(graphicsDevice);
            BasicEffect.VertexColorEnabled = true;
            BasicEffect.Projection = Matrix.CreateOrthographicOffCenter
               (0, graphicsDevice.Viewport.Width,     // left, right
                graphicsDevice.Viewport.Height, 0,    // bottom, top
                0, 1); // near, far plane

            changeSize(x, y, SideLength);
            changeLocation(x, y);

        }

        public void changeSize(float x, float y, int sideLength)
        {
            this.SideLength = sideLength;
            Vectors = CalculateVertices(SideLength, new Vector3(x, y, 0));
            createBorder();
        }

        public abstract void changeLocation(float x, float y);

        protected abstract VertexPositionColor[] CalculateVertices(float sideLength, Vector3 center);

        protected abstract void createBorder();

        public abstract void setBorderColor(Color color);

        public abstract void setInsideColor(Color color);

        public abstract void setOutsideColor(Color color);

        public abstract void updateHover();

        public bool IsPointInPolygon(int pointX, int pointY)
        {

            bool isInside = false;
            VertexPositionColor temp1;
            VertexPositionColor temp2;
            for (int i = 0, j = Vectors.Length - 1; i < Vectors.Length; j = i++)
            {
                temp1 = Vectors[i];
                temp2 = Vectors[j];
                if (((temp1.Position.Y > pointY) != (temp2.Position.Y > pointY)) &&
                    (pointX < (temp2.Position.X - temp1.Position.X) * (pointY - temp1.Position.Y) / (temp2.Position.Y - temp1.Position.Y) + temp1.Position.X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        public void draw(SpriteBatch spriteBatch)
        {

            BasicEffect.CurrentTechnique.Passes[0].Apply();
            spriteBatch.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, Vertices, 0, NumberOfSides);
            spriteBatch.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, Borders, 0, NumberOfSides);

        }
    }
}
