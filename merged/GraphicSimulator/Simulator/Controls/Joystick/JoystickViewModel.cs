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
        public void moveSlider(double throttle, double ailerion)
        {
            model.moveSlider(throttle, ailerion);
            VM_throttle = throttle;
            VM_ailerion = ailerion;
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
        public void setClient(Client c)
        {
            model.setClient(ref c);
        }
        public void start()
        {
            model.start();
        }
        public void stop()
        {
            model.stopConnection();
        }

        private double _VM_rudder;
        private double _VM_elevator;
        private double _VM_throttle;
        private double _VM_ailerion;
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

        public double VM_throttle
        {
            set
            {
                _VM_throttle = value;
                NotifyPropertyChanged("VM_throttle");
            }
            get
            {
                return model.throttle;
            }
        }

        public double VM_ailerion
        {
            set
            {
                _VM_ailerion = value;
                NotifyPropertyChanged("VM_ailerion");
            }
            get
            {
                return model.ailerion;
            }
        }

    }
}
