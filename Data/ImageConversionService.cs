using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace Klooz3.Data
{
    public class ImageConversionService
    {
        public byte[] ConvertToWebP(byte[] inputImage)
        {
            using (var inputStream = new MemoryStream(inputImage))
            using (var outputStream = new MemoryStream())
            {
                using (var image = Image.Load(inputStream))
                {
                    // Ensure the WebP format is available
                    Configuration.Default.ImageFormatsManager.AddImageFormat(WebpFormat.Instance);

                    // Save the image as WebP
                    image.Save(outputStream, WebpFormat.Instance);
                }

                return outputStream.ToArray();
            }
        }
    }
}