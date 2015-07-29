using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.GameStructure;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK
{
    class Program
    {
        private static readonly TextureManager TextureManager = new TextureManager();
        private static readonly StateSystem System = new StateSystem();
        private static readonly GameWindow Game = new GameWindow();

        [STAThread]
        static void Main(string[] args)
        {
            Game.ClientSize = new Size(1280, 720);

            //load textures
            TextureManager.LoadTexture("face", "./Assets/face.tif");
            TextureManager.LoadTexture("face_alpha", "./Assets/face_alpha.tif");

            //create state system
            System.AddState("splash", new SplashScreenState(System));
            System.AddState("title_menu", new TitleScreenState());
            System.AddState("sprite_test", new DrawSpriteState(TextureManager));
            System.AddState("test_sprite_class", new TestSpriteClassState(TextureManager));

            //set init state
            System.ChangeState("test_sprite_class");

            //set up events
            Game.Load += (sender, e) =>
            {
                Game.VSync = VSyncMode.On;
            };
            Setup2D(Game.Width, Game.Height);

            Game.Resize += (sender, e) =>
            {
                GL.Viewport(0, 0, Game.Width, Game.Height);
                Setup2D(Game.Width, Game.Height);
            };

            Game.UpdateFrame += (sender, e) =>
            {
                // add game logic, input handling
                if (Game.Keyboard[Key.Escape])
                {
                    Game.Exit();
                }
                if (Game.Keyboard[Key.AltRight] && Game.Keyboard[Key.Enter])
                {
                    if (Game.WindowState == WindowState.Normal)
                        Game.WindowState = WindowState.Fullscreen;
                    else
                        Game.WindowState = WindowState.Normal;
                }

                System.Update(e.Time);
            };

            Game.RenderFrame += (sender, e) =>
            {
                System.Render();
                Game.SwapBuffers();
            };

            // Run the game at 60 updates per second
            Game.Run(60.0);
            Game.Dispose();
        }

        private static void Setup2D(double width, double height)
        {
            var halfWidth = width/2;
            var halfHeight = height/2;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-halfWidth, halfWidth, -halfHeight, halfHeight, -100, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }
    }
}
