using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ExCollection
{
    public static class ExImage
    {
        /// <summary>
        /// Convert Image to Byte[]
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(this Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;
            }
        }

        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(this byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(this byte[] buffer, string fileName)
        {
            string file = fileName;
            Image image = BytesToImage(buffer);
            ImageFormat format = image.RawFormat;
            if (format.Equals(ImageFormat.Jpeg))
            {
                file += ".jpeg";
            }
            else if (format.Equals(ImageFormat.Png))
            {
                file += ".png";
            }
            else if (format.Equals(ImageFormat.Bmp))
            {
                file += ".bmp";
            }
            else if (format.Equals(ImageFormat.Gif))
            {
                file += ".gif";
            }
            else if (format.Equals(ImageFormat.Icon))
            {
                file += ".icon";
            }
            System.IO.FileInfo info = new System.IO.FileInfo(file);
            System.IO.Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllBytes(file, buffer);
            return file;
        }

        /// <summary>
        /// 从大图中截取图像
        /// </summary>
        /// <param name="source">原图像</param>
        /// <param name="rects">截取区域列表</param>
        /// <returns></returns>
        public static Image[] Partial(this Image source, Rectangle[] rects)
        {
            if (rects == null || rects.Length == 0)
                return new Bitmap[0];

            var images = new Image[rects.Length];
            var fullRect = new Rectangle(0, 0, source.Width, source.Height);

            for (int i = 0; i < images.Length; i++)
            {
                var rect = Rectangle.Intersect(fullRect, rects[i]);
                using (var bitmap = new Bitmap(rect.Width, rect.Height))
                {
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.DrawImage(source, new Rectangle(Point.Empty, bitmap.Size), rect, GraphicsUnit.Pixel);
                        images[i] = Image.FromHbitmap(bitmap.GetHbitmap());
                    }
                }
            }
            return images;
        }

        /// <summary>
        /// 从大图中截取图像
        /// </summary>
        /// <param name="source"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Image Partial(this Image source, Rectangle rect)
        {
            return Partial(source, new Rectangle[] { rect })[0];
        }
    }
}
