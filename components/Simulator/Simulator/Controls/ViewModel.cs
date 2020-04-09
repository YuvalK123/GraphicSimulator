using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

public abstract class ViewModel : INotifyPropertyChanged {


    public event PropertyChangedEventHandler PropertyChanged;


    public virtual void NotifyPropertyChanged(string propName)
    {

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}