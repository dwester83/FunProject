using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShapes
{
    public class Hexagon : AbstractGameShape
    {

        protected int count = 0;
        
        public Hexagon(int sideLength)
        {
            SideLength = sideLength;
            Vertices = new VertexPositionColor[18];
        }
        
        public override void changeLocation(float x, float y)
        {
            Vertices[0] = new VertexPositionColor(new Vector3(x, y, 0), InsideColor);
            Vertices[1] = new VertexPositionColor(Vectors[0].Position, OutsideColor);
            Vertices[2] = new VertexPositionColor(Vectors[1].Position, OutsideColor);
            Vertices[3] = new VertexPositionColor(new Vector3(x, y, 0), InsideColor);
            Vertices[4] = new VertexPositionColor(Vectors[1].Position, OutsideColor);
            Vertices[5] = new VertexPositionColor(Vectors[2].Position, OutsideColor);

            Vertices[6] = new VertexPositionColor(new Vector3(x, y, 0), InsideColor);
            Vertices[7] = new VertexPositionColor(Vectors[2].Position, OutsideColor);
            Vertices[8] = new VertexPositionColor(Vectors[3].Position, OutsideColor);
            Vertices[9] = new VertexPositionColor(new Vector3(x, y, 0), InsideColor);
            Vertices[10] = new VertexPositionColor(Vectors[3].Position, OutsideColor);
            Vertices[11] = new VertexPositionColor(Vectors[4].Position, OutsideColor);

            Vertices[12] = new VertexPositionColor(new Vector3(x, y, 0), InsideColor);
            Vertices[13] = new VertexPositionColor(Vectors[4].Position, OutsideColor);
            Vertices[14] = new VertexPositionColor(Vectors[5].Position, OutsideColor);
            Vertices[15] = new VertexPositionColor(new Vector3(x, y, 0), InsideColor);
            Vertices[16] = new VertexPositionColor(Vectors[5].Position, OutsideColor);
            Vertices[17] = new VertexPositionColor(Vectors[0].Position, OutsideColor);
        }
        protected override VertexPositionColor[] CalculateVertices(float sideLength, Vector3 center)
        {
            VertexPositionColor[] tempVectors = new VertexPositionColor[6];
            double angle;
            VertexPositionColor temp = new VertexPositionColor();

            for (int i = 0; i < tempVectors.Length; i++)
            {
                angle = 2 * Math.PI / 6.0 * (i + 0.05) - 10;
                temp.Position.X = (float)(center.X + sideLength * Math.Cos(angle));
                temp.Position.Y = (float)(center.Y + sideLength * Math.Sin(angle));
                temp.Position.Z = 0f;
                tempVectors[i] = temp;
            }
            return tempVectors;
        }
        protected override void createBorder()
        {
            Borders = new VertexPositionColor[12];

            Borders[0] = Vectors[0];
            
            Borders[1] = Vectors[1];
            Borders[2] = Vectors[1];
            Borders[3] = Vectors[2];
            Borders[4] = Vectors[2];
            Borders[5] = Vectors[3];
            Borders[6] = Vectors[3];
            Borders[7] = Vectors[4];
            Borders[8] = Vectors[4];
            Borders[9] = Vectors[5];
            Borders[10] = Vectors[5];
            Borders[11] = Vectors[0];
            Borders[0] = Vectors[0];

            setBorderColor(Color.Black);
        }
        public override void setBorderColor(Color color)
        {
            for (int i = 0; i < Borders.Length; i++)
            {
                Borders[i].Color = color;
            }
        }
        public override void setInsideColor(Color color)
        {
            InsideColor = color;
            for (int i = 0; i < Vertices.Length; i++)
            {
                if (i % 3 == 0) { Vertices[i].Color = color; }
            }
        }
        public override void setOutsideColor(Color color)
        {
            OutsideColor = color;
            for (int i = 0; i < Vertices.Length; i++)
            {
                if (i % 3 != 0) { Vertices[i].Color = color; }
            }
        }
        public override void updateHover()
        {
            if (count % 5 == 0)
            {
                hoverPosition = (hoverPosition + 1) % 12;
                setBorderColor(Color.Red);
                int positionOne = hoverPosition;
                int positionTwo = (hoverPosition + 11) % 12;
                Borders[positionOne].Color = Color.Black;
                Borders[positionTwo].Color = Color.Black;
            }
            count++;
        }


    }
    
}
