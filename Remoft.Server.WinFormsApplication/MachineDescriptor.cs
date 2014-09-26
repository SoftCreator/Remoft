using System;
using System.Drawing;
using System.Windows.Forms;
using Remoft.Common;

namespace Remoft.Server.WinFormsApplication
{
    public partial class MachineDescriptor : UserControl
    {
        private NetworkMachineDTO _networkMachine;
        public MachineDescriptor(NetworkMachineDTO networkMachine)
        {
            InitializeComponent();
            _networkMachine = networkMachine;
            if (_networkMachine != null)
            {
                lblHostName.Text = _networkMachine.HostName;
                lblUserName.Text = _networkMachine.UserName;
            }
        }

        public DateTime LastUpdated { get; set; }

        public NetworkMachineDTO GetNetworkMachine()
        {
            return _networkMachine;
        }

        public void SetComputerIcon(Image image)
        {
            this.pictureBox1.Image = image;
        }

        
    }
}
