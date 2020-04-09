using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;
using System.ComponentModel;

namespace Simulator.Controls.Map
{
    public class MapModel : Model
    {

        Client _client;
        volatile private bool _stop;
        public MapModel(ViewModel vm):base(vm)
        {
            
        }
        public void setClient(Client c)
        {
            if(_client == null)
            {
                _client = c;
            }
         }
        public void start()
        {
            _stop = false;
            if(_client != null)
            {
                locationFromServer();
                //new Task(() => locationFromServer()).Start();
            }
        }
        public void stopConnection()
        {
            _stop = true;
        }
        private void locationFromServer()
        {

            double langt = 0, longt = 0, zero = 0, flag = 0;
            string longtitude = "get /position/longitude-deg\n", lang = "get /position/latitude-deg\n";
            List<string> locationCommands = new List<string>();
            locationCommands.Add(longtitude);
            locationCommands.Add(lang);
            try
            {
                //while (_client.isConnected() && !_stop)
                //{
                var commands = _client.sendCommands(locationCommands);
                foreach (var element in commands)
                {
                    bool canConvert = double.TryParse(element.Value, out zero);
                    if (element.Key.Contains("latitude-deg"))
                    {
                        if (canConvert)
                        {
                            langt = Math.Round(double.Parse(element.Value),3);
                            flag++;
                        }
                    }
                    else if (element.Key.Contains("longitude-deg"))
                    {
                        if (canConvert)
                        {
                            longt = Math.Round(double.Parse(element.Value),3);
                            flag++;

                        }
                    }
                }
                if(flag == 2)
                {
                    location = new Location(langt, longt);
                }

                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
        }

        private Location _location;

        public Location location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                NotifyPropertyChanged("location");
            }
        }

    }
}
