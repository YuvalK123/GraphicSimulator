using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ex1
{
    class ViewModel: INotifyPropertyChanged
    {
        private ISimulatorModel model;
        
        public ViewModel(ISimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate(Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM" + e.PropertyName);
                
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



    }
}
