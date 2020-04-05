using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Simulator.Controls.Map
{
    class MapViewModel : ViewModel
    {
        View view;
        MapModel model;

        public void setVM(View v, ref MapModel m)
        {
            this.view = v;

            //model
            this.model = m;
            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.ToString());
            };
        }

    }
}
