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
            _game = new GameWindow {WindowState = WindowState.Fullscreen};

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
                GL.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.End();

                _game.SwapBuffers();
            };

            // Run the game at 60 updates per second
            _game.Run(60.0);
            _game.Dispose();
        }
    }
}
