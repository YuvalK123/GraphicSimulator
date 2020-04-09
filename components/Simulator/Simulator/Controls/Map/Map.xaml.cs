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

        public MapViewModel VM;
        public Map()
        {
            
            InitializeComponent();
            VM = new MapViewModel();
            DataContext = VM;
            MapModel model = new MapModel(VM);
            VM.setVM(this, model);
        }


        public void connect(Client c)
        {
            VM.setClient(c);
            VM.start();
        }
        public void disconnect(Client c)
        {
            VM.stop();
        }
    }
}
