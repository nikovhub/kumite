
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Windows;
using System.ComponentModel;

namespace Kumite_
{
    public class frankDux
    {
        public Image LookLeft;
        public Image LookRight;
        public Image PunchLeft;
        public Image PunchRight;
        public Image JumpLeft;
        public Image JumpRight;
        MainWindow parent;

        DispatcherTimer movesTimer = new DispatcherTimer();
        DispatcherTimer animTimer = new DispatcherTimer();

        public frankDux(MainWindow _parent)
        {
            parent = _parent;
            LookLeft = new Image();
            LookRight = new Image();
            PunchLeft = new Image();
            PunchRight = new Image();
            JumpLeft = new Image();
            JumpRight = new Image();
            LookLeft.Source = ToBitmapSource(Resource1.lookleft);
            LookRight.Source = ToBitmapSource(Resource1.lookright);
            PunchLeft.Source = ToBitmapSource(Resource1.punchleft);
            PunchRight.Source = ToBitmapSource(Resource1.punchright);
            JumpLeft.Source = ToBitmapSource(Resource1.jumpleft);
            JumpRight.Source = ToBitmapSource(Resource1.jumpright);
            LookLeft.Visibility = Visibility.Visible;
            parent.PlayerCanvas.Children.Add(LookLeft);
            LookRight.Visibility = Visibility.Hidden;
            parent.PlayerCanvas.Children.Add(LookRight);
            PunchLeft.Visibility = Visibility.Hidden;
            parent.PlayerCanvas.Children.Add(PunchLeft);
            PunchRight.Visibility = Visibility.Hidden;
            parent.PlayerCanvas.Children.Add(PunchRight);
            JumpLeft.Visibility = Visibility.Hidden;
            parent.PlayerCanvas.Children.Add(JumpLeft);
            JumpRight.Visibility = Visibility.Hidden;
            parent.PlayerCanvas.Children.Add(JumpRight);
            Canvas.SetLeft(LookLeft, 900);
            Canvas.SetBottom(LookLeft, 50);
            movesTimer.Interval = TimeSpan.FromMilliseconds(20);
            movesTimer.Start();

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

        public void movesTimer_Tick(object sender, EventArgs e)
        {
            if(parent.leftDown == true)
            {
                if(LookLeft.Visibility != Visibility.Visible)
                {
                    LookRight.Visibility = Visibility.Hidden;
                    LookLeft.Visibility = Visibility.Visible;
                }
                if(Canvas.GetLeft(LookLeft) > 0)
                {
                    Canvas.SetLeft(LookLeft, Canvas.GetLeft(LookLeft) - 5);
                }
            }
            if(parent.rightDown == true)
            {

            }
            if(parent.doJump == true)
            {

            }
            if(parent.doPunch == true)
            {

            }
        }

    }
}
