using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ex1.controls
{
    public partial class Joystick : UserControl
    {
        public Joystick()
        {
            InitializeComponent();
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
                    Console.WriteLine("rudder:");
                    Console.WriteLine(x / (innerCircle.Width / 2));
                    Console.WriteLine("elevator:");
                    Console.WriteLine(y / (innerCircle.Width / 2));
                    
                }
            }
        }

        private void Knob_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //return the start position
            //animation??
            knobPosition.X = 0;
            knobPosition.Y = 0;
            Knob.ReleaseMouseCapture();

        }
    }

   
}
