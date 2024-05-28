using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PDKacha.ImageDownloader
{
    static class DownloadImage
    {
        public static async Task<Image> LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    Uri uri = new Uri(url);
                    byte[] imageData = await webClient.DownloadDataTaskAsync(uri);
                    using (var stream = new MemoryStream(imageData))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
                return null;
            }
        }
    }
}
