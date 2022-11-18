using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kumite_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool rightDown = false;
        public bool leftDown = false;
        public bool gameOver = false;
        public bool doJump = false;
        public bool doPunch = false;
        frankDux frank;
        public MainWindow()
        {
            InitializeComponent();
            frank = new frankDux(this);
        }

        private void PlayArea_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Left:
                    leftDown = true;
                    break;
                case Key.Right:
                    rightDown = true;
                    break;
                case Key.Up:
                    doJump = true;
                    break;
                case Key.Space:
                    doPunch = true;
                    break;
            }
        }
       private void PlayArea_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    leftDown = false;
                    break;
                case Key.Right:
                    rightDown = false;
                    break;
            }
        } 

    }
}
