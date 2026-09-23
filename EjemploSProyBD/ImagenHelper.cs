using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EjemploSProyBD
{
    public static class ImagenHelper
    {
        /// <summary>
        /// Convierte un objeto Image a un arreglo de bytes (byte[]) para almacenar en la Base de Datos.
        /// </summary>
        public static byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            try
            {
                var converter = new ImageConverter();
                var bytes = converter.ConvertTo(image, typeof(byte[])) as byte[];
                if (bytes != null && bytes.Length > 0)
                    return bytes;
            }
            catch
            {
                // Fallback si falla ImageConverter
            }

            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Convierte un arreglo de bytes (byte[]) recuperado de la BD de vuelta a un objeto Image.
        /// </summary>
        public static Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (var ms = new MemoryStream(bytes))
            {
                using (var bmp = new Bitmap(ms))
                {
                    return new Bitmap(bmp); // Clona el Bitmap para evitar problemas de liberación de recursos en memoria
                }
            }
        }
    }
}