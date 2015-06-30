using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using DrawingPixelFormat = System.Drawing.Imaging.PixelFormat;

namespace OpenTK.GameStructure
{
    public class TextureManager : IDisposable
    {
        private readonly IDictionary<string, Texture> _textureDatabase = new Dictionary<string, Texture>();

        public Texture Get(string textureId)
        {
            return _textureDatabase[textureId];
        }

        public void LoadTexture(string textureId, string path)
        {
            Debug.Assert(File.Exists(path));

            var id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            var image = new Bitmap(path);
            var width = image.Width;
            var height = image.Height;

            image.RotateFlip(RotateFlipType.Rotate180FlipY);

            var data = image.LockBits(
                new Rectangle(0, 0, width, height), 
                ImageLockMode.ReadOnly, 
                DrawingPixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, 
                PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            image.UnlockBits(data);

            _textureDatabase.Add(textureId, new Texture(id, width, height));
        }

        public void Dispose()
        {
            GL.DeleteTextures(_textureDatabase.Count, _textureDatabase.Values.Select(t => t.Id).ToArray());
        }
    }
}
