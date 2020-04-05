using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Controls;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Simulator.Controls
{
    public class Client: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        int _port;
        string _IP;
        static TcpClient _server = null;
        static StreamReader _reader = null;
        static StreamWriter _writer = null;
        Mutex _mutex = new Mutex();

        public bool isConnected()
        {
            return _server.Connected;
        }

        private string _location;
        public string location
        {
            get
            {
                return _location;
            }
            set
            {
                _mutex.WaitOne();
                _location = value;
                notifyPropertyChanged("location");
                _mutex.ReleaseMutex();
            }
        }


        private Location _mapCenter = null;
        public Location mapCenter
        {
            get
            {
                return _mapCenter;
            }
            set
            {
                location = value.ToString();

                _mutex.WaitOne();
                _mapCenter = value;
                notifyPropertyChanged("mapCenter");
                _mutex.ReleaseMutex();
            }
        }

        public Client(int port, string ip)
        {
            _port = port;
            _IP = ip;
        }
        public void server()
        {
            connect();
            Task task = new Task(() => locationFromServer());
            task.Start();
        }

        public void notifyPropertyChanged(string propName)
        {

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void connect()
        {
            location = "connect";
            while (_server == null)
            {
                try
                {
                    _server = new TcpClient(_IP, _port);
                    _reader = new StreamReader(_server.GetStream());
                    _writer = new StreamWriter(_server.GetStream());
                    Console.WriteLine("connected to " + _server.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
        }
        public void disconnect()
        {
            try
            {
                if (_server != null)
                {
                    _server.Close();
                }
                if (_reader != null)
                {
                    _reader.Close();
                }
                if (_writer != null)
                {
                    _writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
        }
        public Dictionary<string, string> sendCommands(List<string> commands)
        {
            _mutex.WaitOne();
            string s, get = "get", set = "set";
            var values = new Dictionary<string, string>();
            foreach (string command in commands)
            {
                _writer.WriteLine(command);
                _writer.Flush();
                try
                {
                    s = _reader.ReadLine();
                    if (command.Contains(get))
                    {
                        values.Add(command, s);
                    }
                    else if (command.Contains(set))
                    {
                        //If needed speciel command
                    }
                    else
                    {
                        Console.WriteLine("not legal command");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
            _mutex.ReleaseMutex();
            return values;
        }

        private void locationFromServer()
        {

            double langt, longt;
            string longtitude = "get /position/longitude-deg\n", lang = "get /position/latitude-deg\n", tmp;
            try
            {
                while (_server.Connected)
                {
                    _mutex.WaitOne();
                    _writer.WriteLine(longtitude);
                    _writer.Flush();
                    tmp = _reader.ReadLine();
                    longt = double.Parse(tmp);
                    _writer.WriteLine(lang);
                    _writer.Flush();
                    tmp = _reader.ReadLine();
                    langt = double.Parse(tmp);
                    mapCenter = new Location(langt, longt);
                    _mutex.ReleaseMutex();
                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                location = "error";
                Console.WriteLine(e.Data);
            }



        }
    }
}
