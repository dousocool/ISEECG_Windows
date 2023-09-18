using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace EcgChart
{
	public partial class Form1 : Form
	{
		SerialPort _sPort;
		string defPort;
		string openButtonText;
		string closeButtonText;
		string logPath;
		List<double> allValues = new List<double>();
		LogFile log; 
		MyChart myChart;
		ComPort myPort;
		public Form1()
		{
			InitializeComponent();
			defPort = "COM3";
			openButtonText = "开始采集";
			closeButtonText = "停止采集";
			logPath = @".\log.txt";
			myPort = new ComPort();
			initAll();
		}
		
		void button1_Click(object sender, EventArgs e)
		{
			message.DataSource=null;
			if(_sPort.IsOpen)
			{
				_sPort.Close();
				message.Items.Add("Port closed: " + _sPort.PortName);
				log.saveData(allValues);
				button1.Text=openButtonText;
			}
			else
			{
				message.Items.Clear();
				try
				{
					_sPort.Open();
					
					message.Items.Add("Port Opened: " + _sPort.PortName);
					button1.Text=closeButtonText;
				}
				catch
				{
                    message.Items.Add("Port Open failed: " + _sPort.PortName);
				}	
			}
		}

		void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			if (!_sPort.IsOpen) return;
			int bytes = _sPort.BytesToRead;
			byte[] buffer = new byte[bytes];
			_sPort.Read(buffer, 0, bytes);
			
			BeginInvoke(new SetTextDeleg(si_DataReceived),
			                 new object[] {buffer});
		}

		public delegate void SetTextDeleg(byte[] text);
		
		public void si_DataReceived(byte[] data)
		{
			List<double> values = new List<double>();
			foreach(double v in IncomingData.parseBytes(data))
			{
				values.Add(v);
				myChart.AddPoint(v);
			}
			allValues.AddRange(values);
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			_sPort.Close();
		}
		void initComboPorts()
		{
			string[] ports = ComPort.GetPorts();
			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(ports);
			comboBox1.Text = defPort;
		}
		SerialPort initPort(string portName)
		{
			int baud = 57600;
			try {
				SerialPort port = new SerialPort(portName,baud);
				port.DataReceived += sp_DataReceived;
				return port;
			}
			catch
			{
				return null;
			}
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(_sPort.IsOpen) {
				_sPort.Close(); button1.Text=openButtonText;
			}
			_sPort = initPort(comboBox1.Text);
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			initAll();
		}
		void initAll()
		{
			button1.Text=openButtonText;
			_sPort = initPort(defPort);
			initComboPorts();
			message.DataSource=null;	
			message.Items.Clear();
			log = new LogFile(logPath);
			myChart = new MyChart(zedGraphControl1);
		}
		
		void fileOpenClick(object sender, EventArgs e)
		{
			string fileName=FileTools.GetOpenFileName();
			if(fileName==null) return; 
			List<double>v = FileTools.LoadListFromFile(fileName);
			message.DataSource = v;
			myChart.DrawGraph(v,null,false);
		}
        
        void AddFromFileClick(object sender, EventArgs e)
        {
			string fileName=FileTools.GetOpenFileName();
			if(fileName==null) return; 
			List<double>v = FileTools.LoadListFromFile(fileName);
			message.DataSource = v;
			string f = FileTools.GetFileName(fileName);
			myChart.DrawGraph(v,f,true);
        }
        
        void SaveFileClick(object sender, EventArgs e)
        {
        	string fileName=FileTools.GetSaveFileName();
		    log.saveAsData(fileName,allValues);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void designByDSYToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 心电采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
	}
}
