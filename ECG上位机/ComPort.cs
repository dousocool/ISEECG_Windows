using System;
using System.IO.Ports;
namespace EcgChart
{
	/// <summary>
	/// Description of ComPort.
	/// </summary>
    /// 这段代码是使用C#编写的，它用于实现与串口通信相关的功能。以下是对每个部分的详细解释：

//导入命名空间：

//using System：引入了基本的C#系统命名空间。
//using System.IO.Ports：引入了串口通信相关的命名空间，用于管理串口通信。
//定义 ComPort 类：

//const string defaultPort：私有字段，表示默认的串口名称，被设置为"COM3"。
//static int baud：静态字段，表示波特率，被设置为57600。
//public SerialPort _sPort：公共字段，表示一个 SerialPort 对象，用于实现串口通信。
//public delegate void PassControl(object sender)：声明一个委托类型 PassControl，用于在控件之间传递控制。
//public PassControl passControl：公共字段，表示 PassControl 委托的实例，用于控件之间的控制传递。
//构造函数 ComPort(string PortName = null)：

//接收一个可选的 PortName 参数，用于设置要打开的串口名称。
//如果未提供 PortName 参数，则使用默认的串口名称。
//调用 initPort() 方法初始化串口通信对象 _sPort。
//静态方法 GetPorts()：

//返回一个字符串数组，包含当前系统中可用的串口名称列表。
//私有方法 initPort(string portName)：

//接收一个串口名称参数 portName，用于初始化一个 SerialPort 对象。
//在 try 块中，创建一个新的串口对象，设置串口名称和波特率，以及指定 DataReceived 事件处理函数 sp_DataReceived。
//如果出现异常，返回 null。
//事件处理方法 sp_DataReceived(object sender, SerialDataReceivedEventArgs e)：

//当串口接收到数据时触发的事件处理函数。
//首先检查串口是否打开，如果未打开则直接返回。
//获取接收缓冲区中的字节数，并创建一个字节数组作为缓冲区。
//从串口读取数据到缓冲区中。
//委托类型 SerialDataReceivedEventHandler：

//这是一个用于处理串口数据接收事件的委托类型，实际上在代码中并没有直接使用。
//委托类型 SetTextDeleg：

//这是一个用于设置文本的委托类型，实际上在代码中并没有直接使用。
//这段代码主要定义了一个名为 ComPort 的类，用于管理串口通信，包括串口的初始化、数据接收等功能。它提供了对串口进行配置和数据传输的基本操作，适用于在C#应用程序中与外部设备进行串口通信。
	public class ComPort
	{
		const string defaultPort = "COM3";
		static int baud = 57600;
		public SerialPort _sPort;
		public delegate void PassControl(object sender);
	    // Create instance (null)
	    public PassControl passControl;
	    
		public ComPort(string PortName=null)
		{
			PortName=PortName??defaultPort;
			_sPort=initPort(PortName);
		}
		static public string[] GetPorts()
		{
			return SerialPort.GetPortNames();
		}
		SerialPort initPort(string portName)
		{
			
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
		void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			if (!_sPort.IsOpen) return;
			int bytes = _sPort.BytesToRead;
			byte[] buffer = new byte[bytes];
			_sPort.Read(buffer, 0, bytes);
		}
		public delegate void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e);
		
		delegate void SetTextDeleg(byte[] text);
	}
}
