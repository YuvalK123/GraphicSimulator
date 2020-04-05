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

namespace Simulator.Controls.Joystick
{
    /// <summary>
    /// Interaction logic for MainJoystick.xaml
    /// </summary>
    public partial class MainJoystick : UserControl
    {
        public MainJoystick()
        {
            InitializeComponent();
            DataContext = joystick;
        }
        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
