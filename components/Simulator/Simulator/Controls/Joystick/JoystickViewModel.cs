using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Simulator.Controls.Joystick
{
    public class JoystickViewModel : ViewModel
    {
        JoystickModel model;
        View view;


        public JoystickViewModel()
        {

        }


        public void moveJoystick(double rudd, double elev)
        {
            model.moveJoystick(rudd,elev);
            VM_rudder = rudd;
            VM_elevator = elev;
        }

        public void setVM(View v, ref JoystickModel m)
        {
            this.view = v;

            //model
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        private double _VM_rudder;
        private double _VM_elevator;
        public double VM_rudder
        {

            get
            {
                return model.rudder;
            }
            set
            {

                _VM_rudder = value;
                NotifyPropertyChanged("VM_rudder");
            }
        }

        public double VM_elevator
        {
            set
            {
                _VM_elevator = value;
                NotifyPropertyChanged("VM_elevator");
            }
            get
            {
                return model.elevator;
            }
        }

    }
}
