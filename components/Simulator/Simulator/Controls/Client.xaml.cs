using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Controls;
using System.ComponentModel;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulator.Controls
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : UserControl, INotifyPropertyChanged
    {

        static TcpClient _server = null;
        static StreamReader _reader = null;
        static StreamWriter _writer = null;
        Mutex _mutex = new Mutex();
        public delegate void ConnectEvent(Client client);
        public ConnectEvent connect;
        public ConnectEvent disconnect;
        bool _stop = false;
        private int _port;
        public int port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                NotifyPropertyChanged("port");
            }
        }
        private string _IP;
        public string ip
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
                NotifyPropertyChanged("ip");
            }
        }

        private string _status;
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                NotifyPropertyChanged("status");
            }
        }

        public Client():base()
        {
            InitializeComponent();
            status = "offline";
            connect = connectFunc;
            //disconnect = disconnectFunc;
            DataContext = this;
            port = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
            ip = ConfigurationManager.AppSettings["IP"].ToString();
        }

        private void connectFunc(Client client)
        {
            
            while (!isConnected() && !_stop)
            {
                try
                {
                    if(_server == null)
                    {
                        _server = new TcpClient(_IP, _port);
                        status = "server connected";
                    }
                    else
                    {
                        _server.Connect(_IP, _port);
                        status = "server connected";
                    }
                    if(_reader == null)
                    {
                        _reader = new StreamReader(_server.GetStream());
                        status = "reader connected";
                    }
                    if(_writer == null)
                    {
                        _writer = new StreamWriter(_server.GetStream());
                        status = "writer connected";

                    }
                    
                }
                catch (Exception e)
                {
                    status = e.Data.ToString();
                    Console.WriteLine(e.Data);
                }
            }
            status = "connected";
        }

        private void disconnectFunc(Client client)
        {
            try
            {
                if (_server != null)
                {
                    _server.Close();
                    _server = null;
                }
                if (_reader != null)
                {
                    _reader.Dispose();
                    _reader = null;
                }
                if (_writer != null)
                {
                    _writer.Dispose();
                    _writer = null;
                }
                status = "disconnectd";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Data);
            }
        }

        public Dictionary<string, string> sendCommands(List<string> commands)
        {
            string s, get = "get", set = "set";
            var values = new Dictionary<string, string>();
            foreach (string command in commands)
            {
                _mutex.WaitOne();
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

        public bool isConnected()
        {
            if(_server != null)
            {
                return _server.Connected;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void Connect_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            status = "connecting";
            _stop = false;
            new Task(()=> {
                
                while (!_stop)
                {
                    connect(this);
                }
            }).Start();
            
        }
        private void Disonnect_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            status = "disconnected";
            _stop = true;
            disconnect?.Invoke(this);

        }

        private void Exit_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }
}
