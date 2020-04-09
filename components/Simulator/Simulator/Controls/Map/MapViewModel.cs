using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;


namespace Simulator.Controls.Map
{
    public class MapViewModel : ViewModel
    {
        public MapViewModel() : base()
        {
            
        }

        View view;
        MapModel model;

        public void setVM(View v,  MapModel m)
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
            model.setClient(c);
        }
        public void start()
        {
            model.start();
        }
        public void stop()
        {
            model.stopConnection();
        }
        private Location _VM_location;
        public Location VM_location
        {
            get
            {
                return model.location;
            }
            set
            {
                _VM_location = value;
                //NotifyPropertyChanged("VM_location");
            }
        }


    }
}
