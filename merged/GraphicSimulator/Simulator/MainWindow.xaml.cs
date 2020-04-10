using Simulator.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setComponentsToClient();
        }
        private void setComponentsToClient()
        {
            c.connect += map.connect;
            c.connect += joystick.connect;
            c.connect += steerings.connect;
            c.disconnect += map.disconnect;
            c.disconnect += joystick.disconnect;
            c.disconnect += steerings.disconnect;
        }
    }
}
