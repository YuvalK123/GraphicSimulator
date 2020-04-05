using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls.Steerings
{
    public class SteeringViewModel : ViewModel
    {

        public View view;
        public SteeringsModel model;

        public void setVM(View v, ref SteeringsModel m)
        {
            this.view = v;

            //model
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.ToString());
            };
        }

        public SteeringViewModel()
        {

        }

        public void setClient(ref Client c)
        {
            this.model.setClient(ref c);
        }

        private double _VM_headingDeg;
        public double VM_headingDeg
        {
            get
            {
                return _VM_headingDeg;
            }
            set
            {
                _VM_headingDeg = value;
                NotifyPropertyChanged("VM_headingDeg");
            }
        }

        private double _VM_verticalSpeed;
        public double VM_verticalSpeed
        {
            get
            {
                return _VM_verticalSpeed;
            }
            set
            {
                _VM_verticalSpeed = value;
                NotifyPropertyChanged("VM_verticalSpeed");
            }
        }

        private double _VM_groundSpeed;
        public double VM_groundSpeed
        {
            get
            {
                return _VM_groundSpeed;
            }
            set
            {
                _VM_groundSpeed = value;
                NotifyPropertyChanged("VM_groundSpeed");
            }
        }

        private double _VM_indicatedSpeed;
        public double VM_indicatedSpeed
        {
            get
            {
                return _VM_indicatedSpeed;
            }
            set
            {
                _VM_indicatedSpeed = value;
                NotifyPropertyChanged("VM_indicatedSpeed");
            }
        }

        private double _VM_gpsAltitude;
        public double VM_gpsAltitude
        {
            get
            {
                return _VM_gpsAltitude;
            }
            set
            {
                _VM_gpsAltitude = value;
                NotifyPropertyChanged("VM_gpsAltitude");
            }
        }

        private double _VM_internalRollDeg;
        public double VM_internalRollDeg
        {
            get
            {
                return _VM_internalRollDeg;
            }
            set
            {
                _VM_internalRollDeg = value;
                NotifyPropertyChanged("VM_internalRollDeg");
            }
        }

        private double _VM_internalPitchDeg;
        public double VM_internalPitchDeg
        {
            get
            {
                return _VM_internalPitchDeg;
            }
            set
            {
                _VM_internalPitchDeg = value;
                NotifyPropertyChanged("VM_internalPitchDeg");
            }
        }

        private double _VM_altimeterAltitude;
        public double VM_altimeterAltitude
        {
            get
            {
                return _VM_altimeterAltitude;
            }
            set
            {
                _VM_altimeterAltitude = value;
                NotifyPropertyChanged("VM_altimeterAltitude");
            }
        }

    }
}
