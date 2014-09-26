using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Remoft.Common;
using Remoft.TCP;
using Remoft.UDP;
using System.Linq;
using System.Linq.Expressions;

namespace Remoft.Server.WinFormsApplication
{
    public partial class Form1 : Form
    {
        private readonly UDPListener _udpListener = new UDPListener();
        private readonly AsynchronousSocketListener _tcpListener = new AsynchronousSocketListener();

        private List<NetworkMachineDTO> _networkMachines = new List<NetworkMachineDTO>();

        public Form1()
        {
            InitializeComponent();
            _tcpListener.ReceiveData += _tcpListener_ReceiveData;
            var tcpListenerThread = new Thread(_tcpListener.StartListening);
            tcpListenerThread.Start();
        }

        private delegate void AddNetworkMachineDelegate(NetworkMachineDTO networkMachine);
        private delegate void RemoveNetworkMachineDelegate(MachineDescriptor machineDescriptor);

        private void AddNetworkMachine(NetworkMachineDTO networkMachine)
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                AddNetworkMachineDelegate d = AddNetworkMachine;
                this.Invoke(d, new object[] { networkMachine });
            }
            else
            {
                var md = new MachineDescriptor(networkMachine) {LastUpdated = DateTime.Now};
                md.SetComputerIcon(imageListCompImages.Images["green"]);
                flowLayoutPanel1.Controls.Add(md);
            }
        }

        private void RemoveNetworkMachine(MachineDescriptor networkMachine)
        {
            if (flowLayoutPanel1.InvokeRequired)
            {
                RemoveNetworkMachineDelegate d = RemoveNetworkMachine;
                this.Invoke(d, new object[] { networkMachine });
            }
            else
            {                
                flowLayoutPanel1.Controls.Remove(networkMachine);
            }
        }

        void _tcpListener_ReceiveData(string data)
        {
            var networkMachine = NetworkMachineDTO.Deserialize(data);

            var machineElements = flowLayoutPanel1.Controls.Cast<object>()
                            .Select(r => r as MachineDescriptor)
                            .Where(r => r != null)                            
                            .ToList();
            var machineElement = machineElements.FirstOrDefault(r => r.GetNetworkMachine().Equals(networkMachine));
            if (machineElement == null)
            {
                AddNetworkMachine(networkMachine);
            }
            else
            {
                machineElement.LastUpdated = DateTime.Now;
            }
            
        }

        private void TimerSendUdpTick(object sender, EventArgs e)
        {
            _udpListener.SendBroadcast(Commands.Echo.ToString(), new IPHelper().Broadcast);
        }

        private void timerRefreshMachinesList_Tick(object sender, EventArgs e)
        {
            foreach (var control in flowLayoutPanel1.Controls)
            {
                var md = control as MachineDescriptor;
                if (md != null)
                {                    
                    var now = DateTime.Now;
                    int updateInterval = (int)(now - md.LastUpdated).TotalMilliseconds;
                    int timerInterval = timerRefreshMachinesList.Interval;
                    if (updateInterval > timerInterval && updateInterval <= 2 * timerInterval)
                        md.SetComputerIcon(imageListCompImages.Images["green"]);
                    if (updateInterval > 2 * timerInterval && updateInterval <= 3 * timerInterval)
                        md.SetComputerIcon(imageListCompImages.Images["yellow"]);
                    if (updateInterval > 3 * timerInterval && updateInterval <= 4 * timerInterval)
                        md.SetComputerIcon(imageListCompImages.Images["gray"]);
                    if (updateInterval > 5 * timerInterval)
                        RemoveNetworkMachine(md);
                }
            }
        }
    }
}
