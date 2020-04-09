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
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public SteeringViewModel()
        {

        }

        public void start()
        {
            model.start();
        }

        public void setClient(Client c)
        {
            this.model.setClient(c);
        }

        private string _VM_headingDeg;
        public string VM_headingDeg
        {
            get
            {
                return model.headingDeg;
            }
            set
            {
                _VM_headingDeg = value;
                NotifyPropertyChanged("VM_headingDeg");
            }
        }

        private string _VM_verticalSpeed;
        public string VM_verticalSpeed
        {
            get
            {
                return model.verticalSpeed;
            }
            set
            {
                _VM_verticalSpeed = value;
                NotifyPropertyChanged("VM_verticalSpeed");
            }
        }

        private string _VM_groundSpeed;
        public string VM_groundSpeed
        {
            get
            {
                return model.groundSpeed;
            }
            set
            {
                _VM_groundSpeed = value;
                NotifyPropertyChanged("VM_groundSpeed");
            }
        }

        //private string _VM_indicatedSpeed;
        public string VM_indicatedSpeed
        {
            get
            {
                return model.indicatedSpeed;
            }
            set
            {
                //_VM_indicatedSpeed = value;
                //NotifyPropertyChanged("VM_indicatedSpeed");
            }
        }

        //private string _VM_gpsAltitude;
        public string VM_gpsAltitude
        {
            get
            {
                return model.gpsAltitude;
            }
            set
            {
                //_VM_gpsAltitude = value;
                //NotifyPropertyChanged("VM_gpsAltitude");
            }
        }

        //private string _VM_internalRollDeg;
        public string VM_internalRollDeg
        {
            get
            {
                return model.internalRollDeg;
            }
            set
            {
                //_VM_internalRollDeg = value;
               // NotifyPropertyChanged("VM_internalRollDeg");
            }
        }

        //private string _VM_internalPitchDeg;
        public string VM_internalPitchDeg
        {
            get
            {
                return model.internalPitchDeg;
            }
            set
            {
               // _VM_internalPitchDeg = value;
                //NotifyPropertyChanged("VM_internalPitchDeg");
            }
        }

        //private string _VM_altimeterAltitude;
        public string VM_altimeterAltitude
        {
            get
            {
                return model.altimeterAltitude;
            }
            set
            {
                //_VM_altimeterAltitude = value;
                //NotifyPropertyChanged("VM_altimeterAltitude");
            }
        }

    }
}
