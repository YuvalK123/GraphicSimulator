using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.ComponentModel;

namespace ex1.controls
{
    public partial class Joystick : UserControl,INotifyPropertyChanged
    {
        public Joystick()
        {
            InitializeComponent();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }

        }

        private double _rudder;
        private double _elevator;
        public double rudder
        {
            set
            {
                _rudder = value;
                NotifyPropertyChanged("rudder");
            }
            get
            {
                return _rudder;
            }
        }

        public double elevator
        {
            set
            {
                _elevator = value;
                NotifyPropertyChanged("elevator");
            }
            get
            {
                return _elevator;
            }
        }

        public Point MousewDownLocation;
private void Knob_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ChangedButton == System.Windows.Input.MouseButton.Left)
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
                if(Math.Sqrt(x*x + y*y) < innerCircle.Width/2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    rudder = Math.Round(x / (innerCircle.Width / 2),2);
                    elevator = Math.Round(y / (innerCircle.Height / 2), 2) * (-1);

                }
            }
        }

        private void Knob_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //return the start position
            //animation??
            knobPosition.X = 0;
            knobPosition.Y = 0;
            rudder = 0;
            elevator = 0;
            Knob.ReleaseMouseCapture();

        }
    }

   
}
