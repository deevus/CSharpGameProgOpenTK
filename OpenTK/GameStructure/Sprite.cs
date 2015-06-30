using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK.GameStructure
{
    public class Sprite
    {
        internal const int VertexAmount = 6;
        Texture _texture = new Texture();

        public Sprite()
        {
            VertexPositions = new Vector[VertexAmount];
            VertexColors = new Color[VertexAmount];
            VertexUVs = new Point[VertexAmount];

            InitVertexPositions(new Vector(0, 0, 0), 1, 1);
            SetColor(new Color(1, 1, 1, 1));
            SetUVs(new Point(0, 0), new Point(1, 1));
        }

        public Texture Texture
        {
            get
            {
                return _texture;
            }
            set
            {
                _texture = value;
                InitVertexPositions(GetCenter(), _texture.Width, _texture.Height);
            }
        }

        public Vector[] VertexPositions { get; set; }
        public Color[] VertexColors { get; set; }
        public Point[] VertexUVs { get; set; }

        private Vector GetCenter()
        {
            double halfWidth = GetWidth()/2;
            double halfHeight = GetHeight()/2;

            return new Vector(
                VertexPositions[0].X + halfWidth,
                VertexPositions[0].Y - halfHeight,
                VertexPositions[0].Z);
        }

        private void InitVertexPositions(Vector position, double width, double height)
        {
            var halfWidth = width/2;
            var halfHeight = height/2;

            //clockwise creation of two triangles makes a quad
            
            //topleft, topright, bottomleft
            VertexPositions[0] = new Vector(position.X - halfWidth, position.Y + halfHeight, position.Z);
            VertexPositions[1] = new Vector(position.X + halfWidth, position.Y + halfHeight, position.Z);
            VertexPositions[2] = new Vector(position.X - halfWidth, position.Y - halfHeight, position.Z);

            //topright, bottomright, bottomleft
            VertexPositions[3] = new Vector(position.X + halfWidth, position.Y + halfHeight, position.Z);
            VertexPositions[4] = new Vector(position.X + halfWidth, position.Y - halfHeight, position.Z);
            VertexPositions[5] = new Vector(position.X - halfWidth, position.Y - halfHeight, position.Z);
        }

        public double GetWidth()
        {
            //topright - topleft
            return VertexPositions[1].X - VertexPositions[0].X;
        }

        public double GetHeight()
        {
            //topleft - bottomleft
            return VertexPositions[0].Y - VertexPositions[2].Y;
        }

        public void SetWidth(float width)
        {
            InitVertexPositions(GetCenter(), width, GetHeight());
        }

        public void SetHeight(float height)
        {
            InitVertexPositions(GetCenter(), GetWidth(), height);
        }

        public void SetPosition(double x, double y)
        {
            SetPosition(new Vector(x, y, 0));
        }

        public void SetPosition(Vector position)
        {
            InitVertexPositions(position, GetWidth(), GetHeight());
        }

        public void SetColor(Color color)
        {
            for (var i = 0; i < VertexAmount; i++)
            {
                VertexColors[i] = color;
            }
        }

        public void SetUVs(Point topLeft, Point bottomRight)
        {
            //topleft, topright, bottomleft
            VertexUVs[0] = topLeft;
            VertexUVs[1] = new Point(bottomRight.X, topLeft.Y);
            VertexUVs[2] = new Point(topLeft.X, bottomRight.Y);

            //topright, bottomright, bottomleft
            VertexUVs[3] = new Point(bottomRight.X, topLeft.Y);
            VertexUVs[4] = bottomRight;
            VertexUVs[5] = new Point(topLeft.X, bottomRight.Y);
        }
    }
}
