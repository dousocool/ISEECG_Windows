using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace EcgChart
//    这段代码是使用C#编写的，它定义了一个名为 FileTools 的类，提供了与文件操作相关的工具方法。以下是对每个部分的详细解释：

//导入命名空间：

//using System：引入了基本的C#系统命名空间。
//using System.Collections.Generic：引入了集合类的命名空间，用于操作和管理数据集合。
//using System.IO：引入了输入输出相关的命名空间，用于文件操作。
//using System.Windows.Forms：引入了Windows窗体相关的命名空间，用于创建文件对话框等窗体组件。
//定义 FileTools 类：

//static string WorkingDir：私有静态字段，表示当前工作目录。
//const string defaultFileFilter：私有常量字段，表示默认的文件筛选条件。
//枚举 Dialogs：

//表示文件对话框类型，包括打开文件对话框和保存文件对话框。
//静态方法 GetFileNameDialog(Dialogs d)：

//接收一个 Dialogs 枚举参数，根据参数类型创建相应的文件对话框。
//初始化对话框的初始目录、筛选条件等属性。
//如果对话框返回不为 DialogResult.OK，则返回 null，否则返回所选文件的路径。
//静态方法 GetOpenFileName()：

//调用 GetFileNameDialog(Dialogs.Open) 方法来获取打开文件对话框选择的文件路径。
//静态方法 GetSaveFileName()：

//调用 GetFileNameDialog(Dialogs.Save) 方法来获取保存文件对话框选择的文件路径。
//静态方法 LoadList(string FileName)：

//接收一个文件名参数 FileName，从该文件中逐行读取内容并存储在列表中。
//返回一个包含文件内容的字符串列表。
//静态方法 LoadListFromFile(string FileName)：

//与上面的方法类似，但在读取时将内容转换为 double 类型并存储在 List<double> 中。
//静态方法 GetFileName(string f)：

//接收一个文件路径参数 f，返回该文件的无扩展名的文件名。
//静态方法 SaveListTo(string fileName, List<double> text)：

//接收文件名和一个 List<double> 参数，将列表中的 double 数据逐行写入到文件中。
//如果成功写入则返回 true，否则返回 false。
//静态方法 WriteTo(string file, string text)：

//接收文件名和文本内容参数，将文本内容写入指定文件。
//这段代码主要定义了一个名为 FileTools 的工具类，用于简化与文件操作相关的任务，例如打开、保存文件，读取文件内容并转换为数据列表，将数据写入文件等。它可以在C#应用程序中方便地进行文件操作，尤其适用于处理心电图(ECG)数据文件。
{
	public class FileTools
	{
		static string WorkingDir = Directory.GetCurrentDirectory();
		const string defaultFileFilter = "E:\\ECG\\心电数据\\DSY(*.txt)|*.txt";
		
		enum Dialogs {Open, Save};
		static string GetFileNameDialog(Dialogs d) 
		{
			FileDialog fd;
			switch(d) 
			{
				case Dialogs.Open: 
					fd = new OpenFileDialog();
					break;
				case Dialogs.Save: 
					fd = new SaveFileDialog();
					break;
				default:
					return null; 
			}
			fd.InitialDirectory = WorkingDir;
			fd.Filter = defaultFileFilter;
			fd.RestoreDirectory = true ;
			if(fd.ShowDialog() != DialogResult.OK) return null;
			return fd.FileName; 
		}
		static public string GetOpenFileName()
		{
			return GetFileNameDialog(Dialogs.Open);
		}
		
		static public string GetSaveFileName()
		{
			return GetFileNameDialog(Dialogs.Save);
		}
		static List<string> LoadList(string FileName)
		{
			List<string> result = new List<string>();
			StreamReader sr = new StreamReader(FileName);
			string text;
			while ((text=sr.ReadLine())!=null) result.Add(text);
			sr.Close();
			return result; 
		}
		public static List<double> LoadListFromFile(string FileName)
		{
			List<double> v = new List<double>();
			StreamReader sr = new StreamReader(FileName);
			string text;
				while ((text=sr.ReadLine())!=null)
				{
					try 
					{
						double tmp=double.Parse(text);
						v.Add(tmp);
					}
					catch
					{
						continue;
					}
				}
				sr.Close();
			return v; 
		}
		public static string GetFileName(string f)
		{
			return Path.GetFileNameWithoutExtension(f);
		}
		public static bool SaveListTo(string fileName, List<double> text)
		{
			try 
			{
				using (StreamWriter sw = File.AppendText(fileName)) 
				{
					foreach (var v in text) 
					{
						sw.WriteLine(v);
					}
				}
				return true;
			}
			catch
			{
				return false;
			}	
		}
		public static void WriteTo(string file,string text) 
		{
			File.WriteAllText(file,text);
		}
	}
}
