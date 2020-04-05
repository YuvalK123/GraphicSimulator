using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

public abstract class Model : INotifyPropertyChanged
{
    public ViewModel VM;

    public Model(ViewModel vm)
    {
        this.VM = vm;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}