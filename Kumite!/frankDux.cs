
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
        DispatcherTimer jumpTimer = new DispatcherTimer();

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
            parent.PlayArea.Children.Add(LookLeft);
            LookRight.Visibility = Visibility.Hidden;
            parent.PlayArea.Children.Add(LookRight);
            PunchLeft.Visibility = Visibility.Hidden;
            parent.PlayArea.Children.Add(PunchLeft);
            PunchRight.Visibility = Visibility.Hidden;
            parent.PlayArea.Children.Add(PunchRight);
            JumpLeft.Visibility = Visibility.Hidden;
            parent.PlayArea.Children.Add(JumpLeft);
            JumpRight.Visibility = Visibility.Hidden;
            parent.PlayArea.Children.Add(JumpRight);
            Canvas.SetLeft(LookLeft, 900);
            Canvas.SetBottom(LookLeft, 50);
            movesTimer.Tick += movesTimer_Tick;
            movesTimer.Interval = TimeSpan.FromMilliseconds(10);
            movesTimer.Start();
            animTimer.Tick += animTimer_Tick;
            animTimer.Interval = TimeSpan.FromMilliseconds(50);
            jumpTimer.Tick += jumpTimer_Tick;
            jumpTimer.Interval = TimeSpan.FromMilliseconds(10);
   
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
                    Canvas.SetLeft(LookLeft, Canvas.GetLeft(LookRight));
                    Canvas.SetBottom(LookLeft, Canvas.GetBottom(LookRight));
                }
                if(Canvas.GetLeft(LookLeft) >= 0)
                {
                    Canvas.SetLeft(LookLeft, Canvas.GetLeft(LookLeft) - 5);
                }
            }
            if(parent.rightDown == true)
            {
                if(LookRight.Visibility != Visibility.Visible)
                {
                    LookLeft.Visibility = Visibility.Hidden;
                    LookRight.Visibility = Visibility.Visible;
                    Canvas.SetLeft(LookRight, Canvas.GetLeft(LookLeft));
                    Canvas.SetBottom(LookRight, Canvas.GetBottom(LookLeft));
                }
                if(Canvas.GetLeft(LookRight) <= 1800)
                {
                    Canvas.SetLeft(LookRight, Canvas.GetLeft(LookRight) + 5);
                }
            }
            if(parent.doJump == true)
            {
                jumpTimer.Start();
            }
            if(parent.doPunch == true)
            {

                animTimer.Start();
                parent.rightDown = false;
                parent.leftDown = false;
                parent.doPunch = false;
            }
        }

        public void animTimer_Tick(object sender, EventArgs e)
        {
             if(LookLeft.Visibility == Visibility.Visible)
            {
                PunchLeft.Visibility = Visibility.Visible;
                LookLeft.Visibility = Visibility.Hidden;
                Canvas.SetLeft(PunchLeft, Canvas.GetLeft(LookLeft));
                Canvas.SetBottom(PunchLeft, Canvas.GetBottom(LookLeft));
            }
            else if (LookRight.Visibility == Visibility.Visible)
            {
                PunchRight.Visibility = Visibility.Visible;
                LookRight.Visibility = Visibility.Hidden;
                Canvas.SetLeft(PunchRight, Canvas.GetLeft(LookRight));
                Canvas.SetBottom(PunchRight, Canvas.GetBottom(LookRight));
            }
            else if(PunchLeft.Visibility == Visibility.Visible)
            {
                PunchLeft.Visibility = Visibility.Hidden;
                LookLeft.Visibility = Visibility.Visible;
                animTimer.Stop();
            }
            else if(PunchRight.Visibility == Visibility.Visible)
            {
                PunchRight.Visibility = Visibility.Hidden;
                LookRight.Visibility = Visibility.Visible;
                animTimer.Stop();
            }

        }
        public void jumpTimer_Tick(object sender, EventArgs e)
        {

        }

    }
}
