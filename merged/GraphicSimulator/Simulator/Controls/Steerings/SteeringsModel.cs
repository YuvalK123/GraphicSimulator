﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Controls.Steerings
{
    public class SteeringsModel : Model
    {
        Client client;
        Dictionary<string, string> commandsDict;
        List<string> commands;

        public SteeringsModel(ViewModel vm):base(vm)
        {
            commandsDict = new Dictionary<string, string>();
            commands = new List<string>();
            initDic();
            
        }
        
        public void setClient(ref Client c)
        {
            client = c;
            //init();
        }

        public void init()
        {
            new Task(ClientValues).Start();
        }

        private void initDic()
        {
            commandsDict.Add("get /orientation/heading-deg", "headingDeg");
            commandsDict.Add("get /velocities/vertical-speed-fps", "verticalSpeed");
            //commandsDict.Add("get gps_indicated-ground-speed-kt", "groundSpeed");
            //commandsDict.Add("get airspeed-indicator_indicated-speed-kt", "indicatedSpeed");
            //commandsDict.Add("get gps_indicated-altitude-ft", "gpsAltitude");
            //commandsDict.Add("get attitude-indicator_internal-roll-deg", "internalRollDeg");
            //commandsDict.Add("get attitude-indicator_internal-pitch-deg", "internalPitchDeg");
            //commandsDict.Add("get altimeter_indicated-altitude-ft", "altimeterAltitude");
            foreach(string key in commandsDict.Keys)
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
                catch(Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
        }

        private string _headingDeg;
        public string headingDeg
        {
            get
            {
                return _headingDeg;
            }
            set
            {
                _headingDeg = value;
                NotifyPropertyChanged("headingDeg");
            }
        }

        private string _verticalSpeed;
        public string verticalSpeed
        {
            get
            {
                return _verticalSpeed;
            }
            set
            {
                _verticalSpeed = value;
                NotifyPropertyChanged("verticalSpeed");
            }
        }

        private string _groundSpeed;
        public string groundSpeed
        {
            get
            {
                return _groundSpeed;
            }
            set
            {
                _groundSpeed = value;
                NotifyPropertyChanged("groundSpeed");
            }
        }

        private string _indicatedSpeed;
        public string indicatedSpeed
        {
            get
            {
                return _indicatedSpeed;
            }
            set
            {
                _indicatedSpeed = value;
                NotifyPropertyChanged("indicatedSpeed");
            }
        }

        private string _gpsAltitude;
        public string gpsAltitude
        {
            get
            {
                return _gpsAltitude;
            }
            set
            {
                _gpsAltitude = value;
                NotifyPropertyChanged("gpsAltitude");
            }
        }

        private string _internalRollDeg;
        public string internalRollDeg
        {
            get
            {
                return _internalRollDeg;
            }
            set
            {
                _internalRollDeg = value;
                NotifyPropertyChanged("internalRollDeg");
            }
        }

        private string _internalPitchDeg;
        public string internalPitchDeg
        {
            get
            {
                return _internalPitchDeg;
            }
            set
            {
                _internalPitchDeg = value;
                NotifyPropertyChanged("internalPitchDeg");
            }
        }

        private string _altimeterAltitude;
        public string altimeterAltitude
        {
            get
            {
                return _altimeterAltitude;
            }
            set
            {
                _altimeterAltitude = value;
                NotifyPropertyChanged("altimeterAltitude");
            }
        }
    }
}
