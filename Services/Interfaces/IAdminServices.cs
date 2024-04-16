using System.Drawing;
using System.Windows.Media.Imaging;

namespace Insta.Services.Interfaces
{
    public interface IAdminServices
    {
        byte[] ToByteArray(Bitmap instance);
        Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage);
    }
}
