using Avalonia.Media.Imaging;

namespace ElectroDepotClassLibrary.Utility
{
    public static class ImageConverterUtility
    {
        public static byte[] BitmapToBytes(Bitmap image)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                return new byte[] { };
            }
        }

        public static Bitmap BytesToBitmap(byte[] image)
        {
            try
            {
                using (Stream stream = new MemoryStream(image))
                {
                    return new Bitmap(stream);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
