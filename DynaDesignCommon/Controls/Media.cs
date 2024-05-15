using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DynaDesignCommon.Controls
{
    public class Media
    {
        private Media() { }

        public static Image CreateImage(string path)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(path, UriKind.Absolute));

            Image image = new Image
            {
                Source = bitmapImage
            };

            return image;
        }
    }
}
