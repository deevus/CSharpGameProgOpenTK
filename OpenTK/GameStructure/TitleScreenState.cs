using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace OpenTK.GameStructure
{
    public class TitleScreenState : IGameObject
    {
        private double _currentRotation = 0;

        public void Update(double elapsedTime)
        {
            _currentRotation = 10*elapsedTime;
        }

        public void Render()
        {
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.PointSize(5f);

            GL.Rotate(_currentRotation, 0, 1, 0);
            GL.Begin(PrimitiveType.TriangleStrip);
            {
                GL.Color4(1.0, 0.0, 0.0, 0.5);
                GL.Vertex3(-50d, 0, 0);
                GL.Color3(0.0, 1.0, 0.0);
                GL.Vertex3(50d, 0, 0);
                GL.Color3(0.0, 0.0, 1.0);
                GL.Vertex3(0, 50d, 0);
            }
            GL.End();
            GL.Finish();
        }
    }
}
