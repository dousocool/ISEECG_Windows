using System;
using System.Collections.Generic;
//这段代码是使用C#编写的，它定义了一个名为 LogFile 的类，用于记录日志文件并保存数据。以下是对每个部分的详细解释：

//导入命名空间：

//using System：引入了基本的C#系统命名空间。
//using System.Collections.Generic：引入了集合类的命名空间，用于操作和管理数据集合。
//定义 LogFile 类：

//string logPath：私有字段，表示日志文件的路径。
//构造函数 LogFile(string fileName)：

//接收一个文件名参数 fileName，用于初始化日志文件路径。
//调用 createLog() 方法创建日志文件并写入起始行。
//私有方法 createLog(string log)：

//接收一个日志路径参数 log，用于创建日志文件并写入起始行。
//创建起始行字符串，包含当前时间信息，并将其写入到日志文件中。
//私有方法 writeLogTo(string fileName, List<double> text)：

//接收文件名和一个 List<double> 参数，将数据列表写入指定的文件。
//如果未提供文件名，则默认使用构造函数中设置的日志文件路径。
//调用 FileTools.SaveListTo() 方法将数据写入文件。
//公共方法 saveData(List<double> text)：

//接收一个 List<double> 参数，将数据列表保存到日志文件中，使用默认的日志文件路径。
//公共方法 saveAsData(string fileName, List<double> text)：

//接收一个文件名参数和一个 List<double> 参数，将数据列表保存到指定的文件。
//这段代码主要定义了一个名为 LogFile 的类，用于创建和管理日志文件，并提供了方法来将数据写入日志文件中。通过这个类，可以方便地记录和保存数据到日志文件中，适用于在C#应用程序中需要记录数据操作的场景。
namespace EcgChart
{
	public class LogFile
	{
		string logPath;
		public LogFile(string fileName)
		{
			logPath = fileName; 
			createLog(logPath);
		}
		void createLog(string log) {
			string firstLine = String.Format("Log started: {0:dd.MM.yyy HH:mm:ss}",DateTime.Now)+Environment.NewLine;
			FileTools.WriteTo(log,firstLine);
		}
		bool writeLogTo(string fileName, List<double> text)
		{
			fileName = fileName ?? logPath;
			return FileTools.SaveListTo(fileName,text);
		}
		public bool saveData(List<double> text)
		{
			return writeLogTo(null,text);
		}
		public bool saveAsData(string fileName,List<double> text)
		{
			return writeLogTo(fileName,text);
		}
	}
}
