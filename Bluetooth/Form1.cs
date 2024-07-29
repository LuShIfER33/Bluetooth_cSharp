using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bluetooth;
using InTheHand.Net.Sockets;

namespace Bluetooth
{
    public partial class Form1 : Form
    {
        List<BluetoothDeviceInfo> _bluetoothDevices;
        bool _isSearchingForDevices;
        
        public bool IsSearchingForDevices
        {
            get => _isSearchingForDevices;
            set
            {
                _isSearchingForDevices = value;
                button1.Enabled = !_isSearchingForDevices;
            }
        }


        public Form1()
        {
            InitializeComponent();
            _bluetoothDevices = new List<BluetoothDeviceInfo>();
            Devices.DisplayMember = "DeviceName";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // List<BluetoothDeviceInfo> _bluetoothDevices;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            IsSearchingForDevices=true;
            _bluetoothDevices.clear();
            Devices.Controls.Clear();
            groupBox1.Items.Clear();
            try
            {
                var bluetoothDevices = await SearchDevicesAsync();
                _bluetoothDevices.AddRange(bluetoothDevices);
            }
            IsSeachingForDevices = false;
        }
    }
}
