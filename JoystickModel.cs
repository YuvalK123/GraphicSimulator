using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Simulator.Controls.Joystick
{
    public class JoystickModel : Model
    {
        private Client client;
        volatile private bool _stop;
        public JoystickModel(ViewModel vm) : base(vm)
        {

        }

        public void setClient(ref Client c)
        {
            client = c;
        }

        public void moveJoystick(double rudd, double elev)
        {
            rudder = rudd;
            elevator = elev;
            sendToClient();
        }

        public void moveSlider(double throt, double ailer)
        {
            throttle = throt;
            ailerion = ailer;
            sendToClient();
        }

        public void start()
        {
            _stop = false;
        }
        public void stopConnection()
        {
            _stop = true;
        }

        // Send the joystick values(rudder,elevator) to the simulator.
        public void sendToClient()
        {
            string rudderC = "set /controls/flight/rudder " + rudder.ToString();
            string elevatorC = "set /controls/flight/elevator " + elevator.ToString();
            string throttleC = "set /controls/engines/current-engine/throttle " + throttle.ToString();
            string ailerionC = "set /controls/engines/current-engine/ailerion " + ailerion.ToString();
            List<string> joystickCommands = new List<string>();
            joystickCommands.Add(rudderC);
            joystickCommands.Add(elevatorC);
            joystickCommands.Add(throttleC);
            joystickCommands.Add(ailerionC);
            try
            {

                while (client.isConnected() && !_stop)
                {
                    var commands = client.sendCommands(joystickCommands);
                    foreach (var element in commands)
                    {
                        if (element.Key.Contains("rudder"))
                        {
                            rudder = double.Parse(element.Value);
                        }
                        else if (element.Key.Contains("elevator"))
                        {
                            elevator = double.Parse(element.Value);
                        }
                        else if (element.Key.Contains("throttle"))
                        {
                            throttle = double.Parse(element.Value);
                        }
                        else if (element.Key.Contains("ailerion"))
                        {
                            ailerion = double.Parse(element.Value);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
        }

        private double _rudder;
        private double _elevator;
        private double _throttle;
        private double _ailerion;

        public double rudder
        {
            set
            {
                _rudder = value;
                NotifyPropertyChanged("rudder");
            }
            get
            {
                return _rudder;
            }
        }

        public double elevator
        {
            set
            {
                _elevator = value;
                NotifyPropertyChanged("elevator");
            }
            get
            {
                return _elevator;
            }
        }

        public double throttle
        {
            set
            {
                _throttle = value;
                NotifyPropertyChanged("throttle");
            }
            get
            {
                return _throttle;
            }
        }

        public double ailerion
        {
            set
            {
                _ailerion = value;
                NotifyPropertyChanged("ailerion");
            }
            get
            {
                return _ailerion;
            }
        }
    }
}
