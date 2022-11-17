using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Windows;
using System.ComponentModel;
namespace Kumite_
{
    public class badGuy
    {
        public Image Badguylookleft;
        public Image Badguylookright;
        public Image Badguypunchleft;
        public Image Badguypunchright;
        MainWindow parent;

        DispatcherTimer actionTimer = new DispatcherTimer();
        DispatcherTimer animTimer = new DispatcherTimer();

        public badGuy(MainWindow _parent)
        {
            int enu = 2;
            parent = _parent;
            Badguylookleft = new Image();
            Badguylookright = new Image();
            Badguypunchleft = new Image();
            Badguypunchright = new Image();
            Badguylookleft.Source = ToBitmapSource(Resource1.badguyrunleft);
            Badguylookright.Source = ToBitmapSource(Resource1.badguyrunright);
            Badguypunchleft.Source = ToBitmapSource(Resource1.badguypunchleft);
            Badguypunchright.Source = ToBitmapSource(Resource1.badguypunchright);
            actionTimer.Interval = TimeSpan.FromMilliseconds(100);
            actionTimer.Start();

        }
        public BitmapSource ToBitmapSource(System.Drawing.Bitmap source)
        {
            BitmapSource bitSrc = null;

            var hBitmap = source.GetHbitmap();

            try
            {
                bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }
            finally
            {

            }

            return bitSrc;
        }
    }
   
}
