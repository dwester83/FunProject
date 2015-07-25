using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_DX.Tiles
{
    class Wind : IDisposable
    {
        private VertexPositionColor[] vertices;
        private BasicEffect basicEffect;
        public float Speed { get; set; }
        public float Direction { get; set; }
        public int DistanceLeftToTravel { get; set; }
        public bool IsWindDone { get; set; }
        public bool IsDebugging { get; set; }
        private int count = 0;
        static Random rand = new Random();
        public Wind(Vector2 point1, Vector2 point2, float speed, float direction, bool isDebugging = true)
        {
            float verticesSize;
            if (point1.Y >= point2.Y) { verticesSize = (point1.Y - point2.Y) / Map.SIZE * Map.SIZE_MULTIPLIER; }
            else { verticesSize = (point2.Y - point1.Y) / Map.SIZE * Map.SIZE_MULTIPLIER; }
            vertices = new VertexPositionColor[(int)verticesSize];
            CreateWindPoints(point1, point2);
            Speed = speed;
            Direction = direction;
            IsWindDone = false;
            DistanceLeftToTravel = 500;
            IsDebugging = isDebugging;
        }
        private void CreateWindPoints(Vector2 point1, Vector2 point2)
        {
            float rise = (point2.Y - point1.Y) / vertices.Length;
            float run = (point2.X - point1.X) / vertices.Length;

            vertices[0] = new VertexPositionColor(new Vector3(point1.X + run, point1.Y + rise, 0), Color.Blue);
            for (int i = 1; i < vertices.Length; i++)
            {
                VertexPositionColor tempVertex = vertices[i - 1];
                vertices[i] = new VertexPositionColor(new Vector3(tempVertex.Position.X + run, tempVertex.Position.Y + rise
                                                        , tempVertex.Position.Z), tempVertex.Color);
            }
        }
        public Vector3[] GetWindLocation()
        {
            Vector3[] pointsArray = new Vector3[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                pointsArray[i] = vertices[i].Position;
            }
            return pointsArray;
        }
        public void Update()
        {
            if (DistanceLeftToTravel < 0)
            {
                IsWindDone = true;

            }
            else
            {

                if (count % 3 == 0)
                {

                    double nx = Speed * Math.Cos(Direction + rand.Next(1));
                    double ny;
                    if (count % 2 == 0)
                    {
                        ny = Speed * Math.Sin(Direction + rand.Next(2));
                    }
                    else
                    {
                        ny = Speed * Math.Sin(Direction - rand.Next(2));
                    }


                    for (int i = 0; i < vertices.Length; i++)
                    {
                        vertices[i].Position.X = vertices[i].Position.X + (float)nx;
                        vertices[i].Position.Y = vertices[i].Position.Y + (float)ny;

                        DistanceLeftToTravel -= 1;
                    }
                }
                count++;
            }
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

            if (IsDebugging)
            {
                basicEffect.CurrentTechnique.Passes[0].Apply();
                spriteBatch.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineStrip, vertices, 0, 20);
            }


        }


        #region Disposable

        public void Dispose()
        {
            basicEffect.Dispose();
        }

        #endregion
    }
}
