using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace OpenTK.GameStructure
{
    public class DrawSpriteState : IGameObject
    {
        private TextureManager _textureManager;

        public DrawSpriteState(TextureManager textureManager)
        {
            _textureManager = textureManager;
        }

        public void Update(double elapsedTime)
        {
        }

        public void Render()
        {
            double height = 200;
            double width = 200;
            var halfHeight = height/2;
            var halfWidth = width/2;

            double x = 0, 
                y = 0, 
                z = 0;

            float topUV = 0;
            float bottomUV = 1;
            float leftUV = 0;
            float rightUV = 1;

            float red = 1;
            float green = 0;
            float blue = 0;
            float alpha = 1;

            var texture = _textureManager.Get("face_alpha");
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Begin(PrimitiveType.Triangles);
            {
                GL.Color4(red, green, blue, alpha);
                GL.TexCoord2(leftUV, topUV);
                GL.Vertex3(x - halfWidth, y + halfHeight, z); //top left
                GL.TexCoord2(rightUV, topUV);
                GL.Vertex3(x + halfWidth, y + halfHeight, z); //top right
                GL.TexCoord2(leftUV, bottomUV);
                GL.Vertex3(x - halfWidth, y - halfHeight, z); //bottom left

                GL.TexCoord2(rightUV, topUV);
                GL.Vertex3(x + halfWidth, y + halfHeight, z); //top right
                GL.TexCoord2(rightUV, bottomUV);
                GL.Vertex3(x + halfWidth, y - halfHeight, z); //bottom right
                GL.TexCoord2(leftUV, bottomUV);
                GL.Vertex3(x - halfWidth, y - halfHeight, z); //bottom left
            }
            GL.End();
        }
    }
}
