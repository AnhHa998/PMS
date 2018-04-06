using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace XuLyChung.XuLyHinhAnh
{
    public static class AppImage
    {
        /// <summary>
        /// Convert from byte array to image.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Image ByteArrayToImage(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        public static Image Base64StringToImage(string data)
        {
            if (data == null || data.Length == 0) return null;
            return ByteArrayToImage(Convert.FromBase64String(data));
        }

        /// <summary>
        /// Convert from image to byte[]
        /// </summary>
        /// <param name="img"></param>
        /// <param name="imgFormat"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(Image img, ImageFormat imgFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, imgFormat);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Mã hóa hình ảnh sang chuỗi
        /// </summary>
        /// <param name="img">Ảnh cần mã hóa</param>
        /// <param name="imgFormat">Định dạng ảnh</param>
        /// <returns>Chuỗi đã được mã hóa</returns>
        public static string ImageToBase64String(Image img, ImageFormat imgFormat)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, imgFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
