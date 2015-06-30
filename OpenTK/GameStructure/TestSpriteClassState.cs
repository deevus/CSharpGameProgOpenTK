using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace OpenTK.GameStructure
{
    public class TestSpriteClassState : IGameObject
    {
        private Renderer _renderer = new Renderer();
        private TextureManager _textureManager;
        Sprite _testSprite = new Sprite();
        Sprite _testSprite2 = new Sprite();

        public TestSpriteClassState(TextureManager textureManager)
        {
            _textureManager = textureManager;
            _testSprite.Texture = _textureManager.Get("face_alpha");
            _testSprite.SetHeight(256*0.5f);

            _testSprite2.Texture = _textureManager.Get("face_alpha");
            _testSprite2.SetPosition(-256, -256);
            _testSprite2.SetColor(new Color(1, 0, 0, 1));
        }

        public void Update(double elapsedTime) { } 

        public void Render()
        {
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _renderer.DrawSprite(_testSprite);
            _renderer.DrawSprite(_testSprite2);
            GL.Finish();
        }
    }
}
