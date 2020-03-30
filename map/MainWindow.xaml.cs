using System;
using System.Configuration;
using System.Windows;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace map
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
    public MainWindow()
        {
            InitializeComponent();
            connect();
        }
        private void connect()
        {
            mapObject.Center = new Location(32.002644, 34.888781);
            Client client = new Client(5402, "127.0.0.1");
            DataContext = client;
            Task t = new Task(()=>client.server());
            t.Start();
        }
    }
    class Client: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _location = "lock";
        public string location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                notifyPropertyChanged("location");
            }
        }

        public void notifyPropertyChanged(string propName)
        {
            
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
                _mapCenter = value;
                notifyPropertyChanged("mapCenter");
            }
        }
        int _port;
        string _IP;
        static TcpClient _server = null;
        static StreamReader _reader = null;
        static StreamWriter _writer = null;
        public Client(int port, string ip)
        {
            _port = port;
            _IP = ip;
        }
        public void server()
        {
            location = "server";
            connect();
            sendCommands("meow");
            //Task t = new Task(()=>sendCommands("meow"));
            //t.Start();
        }

        public string getLocation()
        {
            return _location;
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
        public void sendCommands(string commands)
        {
            location = "commands";
            double langt, longt;
            string empty = string.Empty;
            string longtitude = "get /position/longitude-deg\n";
            string lang = "get /position/latitude-deg\n";
            try
            {
                string s = string.Empty;
                while (true)
                {
                    s = "longitude,langtitude = ";
                    _writer.WriteLine(longtitude);
                    _writer.Flush();
                    empty = _reader.ReadLine();
                    s += empty + ", ";
                    longt = double.Parse(empty);
                    _writer.WriteLine(lang);
                    _writer.Flush();
                    empty = _reader.ReadLine();
                    s += empty;
                    langt = double.Parse(empty);
                    
                    mapCenter = new Location(langt, longt);
                    location = mapCenter.ToString();
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
