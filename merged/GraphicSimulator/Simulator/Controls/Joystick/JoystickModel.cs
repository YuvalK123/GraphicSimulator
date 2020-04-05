using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Simulator.Controls.Joystick
{
    public class JoystickModel : Model
    {
        private Client client;
        public JoystickModel(ViewModel vm):base(vm)
        {

        }

        public void setClient(ref Client c)
        {
            client = c;
        }

        public void moveJoystick(double rudd, double elev)
        {
            rudder = rudd;
            elevator = elev;
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
    }
}
