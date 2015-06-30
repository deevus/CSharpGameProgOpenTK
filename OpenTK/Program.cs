using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK
{
    class Program
    {
        private static GameWindow _game;
        [STAThread]
        static void Main(string[] args)
        {
            _game = new GameWindow {};

            _game.Load += (sender, e) =>
            {
                _game.VSync = VSyncMode.On;
            };

            _game.Resize += (sender, e) =>
            {
                GL.Viewport(0, 0, _game.Width, _game.Height);
            };

            _game.UpdateFrame += (sender, e) =>
            {
                // add game logic, input handling
                if (_game.Keyboard[Key.Escape])
                {
                    _game.Exit();
                }
            };

            _game.RenderFrame += (sender, e) =>
            {
                // render graphics
                GL.ClearColor(0f, 0f, 0f, 1f);
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.Rotate(100 * e.Time, 0, 1, 0);
                GL.Begin(PrimitiveType.TriangleStrip);
                {
                    GL.Color3(1d, 0, 0);
                    GL.Vertex3(-0.5, 0, 0);
                    GL.Color3(0d, 1, 0);
                    GL.Vertex3(0.5, 0, 0);
                    GL.Color3(0d, 0, 1);
                    GL.Vertex3(0, 0.5, 0);
                }
                GL.End();

                GL.Finish();

                _game.SwapBuffers();
            };

            // Run the game at 60 updates per second
            _game.Run(60.0);
            _game.Dispose();
        }
    }
}
