using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace OpenTK.GameStructure
{
    public class SplashScreenState : IGameObject
    {
        private readonly StateSystem _stateSystem;
        private double _delayInSeconds = 3;

        public SplashScreenState(StateSystem stateSystem)
        {
            _stateSystem = stateSystem;
        }

        public void Update(double elapsedTime)
        {
            _delayInSeconds -= elapsedTime;
            if (_delayInSeconds <= 0)
            {
                _delayInSeconds = 3;
                _stateSystem.ChangeState("title_menu");
            }
        }

        public void Render()
        {
            GL.ClearColor(1, 1, 1, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Finish();
        }
    }
}
