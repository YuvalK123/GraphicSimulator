using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace Simulator.Controls.Map
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl, View
    {

        MapViewModel VM;
        Client client;
        public Map()
        {
            InitializeComponent();
            VM = new MapViewModel();
            MapModel model = new MapModel(VM);
            VM.setVM(this,ref model);
            //connect();
        }

        public void setClient(ref Client c)
        {
            client = c;
            DataContext = client;
            //new Task(() => client.server()).Start();
        }

        private void connect()
        {
            //mapObject.Center = new Location(32.002644, 34.888781);
            Client client = new Client(5402, "127.0.0.1");
            mapObject.DataContext = client;
            texti.DataContext = client;
            Task t = new Task(() => client.server());
            t.Start();
        }
    }
}
