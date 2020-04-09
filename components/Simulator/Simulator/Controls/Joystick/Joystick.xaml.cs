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
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace Simulator.Controls.Joystick
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl, View, INotifyPropertyChanged
    {
        public JoystickViewModel vm;
        public Joystick()
        {
            DataContext = vm;
            InitializeComponent();
            this.vm = new JoystickViewModel();
            JoystickModel model = new JoystickModel(vm);
            this.vm.setVM(this, ref model);
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void connect(Client c)
        {

        }

        public void disconnect(Client c)
        {

        }



        public Point MousewDownLocation;
        private void Knob_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                MousewDownLocation = e.GetPosition(this);
                //handle the situation that the mouse is out of the knob's borders.
                Knob.CaptureMouse();
            }
        }

        private void Knob_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - MousewDownLocation.X;
                double y = e.GetPosition(this).Y - MousewDownLocation.Y;
                //check if the knob is out of border or not
                if (Math.Sqrt(x * x + y * y) < innerCircle.Width / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    double rudder = Math.Round(x / (innerCircle.Width / 2), 2);
                    double elevator = Math.Round(y / (innerCircle.Height / 2), 2) * (-1);
                    vm.moveJoystick(rudder, elevator);

                }
            }
        }

        private void Knob_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //return the start position
            //animation??
            knobPosition.X = 0;
            knobPosition.Y = 0;
            double rudder = 0;
            double elevator = 0;
            vm.moveJoystick(rudder, elevator);
            Knob.ReleaseMouseCapture();
            
        }
    }
}
