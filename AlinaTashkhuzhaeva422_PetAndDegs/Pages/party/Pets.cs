using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AlinaTashkhuzhaeva422_PetAndDegs
{
    public partial class Pets
    {
        public BitmapImage img
        {
            get
            {
                if (PhotoPath != null)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    using (MemoryStream byteStream = new MemoryStream(PhotoPath))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = byteStream;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze(); // Предотвращает ошибки доступа из других потоков
                    }
                    return bitmapImage;
                }
                else
                {
                    try
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri("pack://application:,,,/Component/Images/picture.png", UriKind.Absolute);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        return bitmap;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка загрузки изображения: {ex.Message}");
                        return null;
                    }
                }
            }
        }
    }
}
