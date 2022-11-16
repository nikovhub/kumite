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
        private bool rightDown = false;
        private bool leftDown = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void frankDux_KeyDown(object sender, KeyEventArgs e)
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
                    //frankDux.Jump();
                    break;
                case Key.Space:
                    //frankDux.Punch();
                    break;
            }
        }
       private void frankDux_KeyUp(object sender, KeyEventArgs e)
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
