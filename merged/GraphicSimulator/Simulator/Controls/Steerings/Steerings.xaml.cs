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
        Client client;
        public Steerings()
        {
            InitializeComponent();
            //DataContext = vm;
            this.vm = new SteeringViewModel();
            SteeringsModel model = new SteeringsModel(vm);
            this.vm.setVM(this,ref model);
            
        }

        public void InitSteerings(ref Client c)
        {
            initDic();
            this.client = c;
            this.vm.setClient(ref c);
            new Task(ClientValues).Start();
        }



        Dictionary<string, string> commandsDict;
        List<string> commands;

        private void initDic()
        {
            commands = new List<string>();
            commandsDict = new Dictionary<string, string>();
            commandsDict.Add("get /orientation/heading-deg", "headingDeg");
            commandsDict.Add("get /velocities/vertical-speed-fps", "verticalSpeed");
            //commandsDict.Add("get gps_indicated-ground-speed-kt", "groundSpeed");
            //commandsDict.Add("get airspeed-indicator_indicated-speed-kt", "indicatedSpeed");
            //commandsDict.Add("get gps_indicated-altitude-ft", "gpsAltitude");
            //commandsDict.Add("get attitude-indicator_internal-roll-deg", "internalRollDeg");
            //commandsDict.Add("get attitude-indicator_internal-pitch-deg", "internalPitchDeg");
            //commandsDict.Add("get altimeter_indicated-altitude-ft", "altimeterAltitude");
            foreach (string key in commandsDict.Keys)
            {
                commands.Add(key);
            }
        }

        private void ClientValues()
        {
            if (client != null)
            {
                try
                {
                    while (client.isConnected())
                    {
                        var type = typeof(SteeringsModel);
                        var dict = client.sendCommands(commands);
                        foreach (var element in dict)
                        {
                            type.GetProperty(commandsDict[element.Key]).SetValue(this, element.Value);
                            NotifyPropertyChanged(commandsDict[element.Key]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void NotifyPropertyChanged(string propName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string _VM_headingDeg;
        public string VM_headingDeg
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

    }

        


}

