using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulator.Controls.Steerings
{
    /// <summary>
    /// Interaction logic for Steerings.xaml
    /// </summary>
    public partial class Steerings : UserControl, View, INotifyPropertyChanged
    {
        public SteeringViewModel vm;
        public Steerings()
        {
            InitializeComponent();
            this.vm = new SteeringViewModel();
            DataContext = vm;
            SteeringsModel model = new SteeringsModel(vm);
            this.vm.setVM(this,ref model);
            
        }


        


        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void NotifyPropertyChanged(string propName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void connect(Client c)
        {
            vm.setClient(c);
            vm.start();
            //client = c;
            //new Task(() => ClientValues()).Start();
        }
        public void disconnect(Client c)
        {

        }
    }


        


}

