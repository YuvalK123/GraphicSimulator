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
    public partial class MainJoystick : UserControl,View
    {
        public JoystickViewModel vm;
        public MainJoystick()
        {
            InitializeComponent();
            DataContext = joystick;
            elev.DataContext = joystick.vm;
            rudd.DataContext = joystick.vm;
            this.vm = new JoystickViewModel();
            JoystickModel model = new JoystickModel(vm);
            this.vm.setVM(this, ref model);
        }
        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void connect(Client c)
        {
            joystick.connect(c);
        }
        public void disconnect(Client c)
        {
            joystick.disconnect(c);
        }

        private void thorttle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            vm.moveSlider(thorttle.Value, ailerion.Value);
        }

        private void ailerion_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vm.moveSlider(thorttle.Value, ailerion.Value);
        }
    }
}
