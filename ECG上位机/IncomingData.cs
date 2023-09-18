using System;
using System.Collections.Generic;
using System.Linq;
namespace EcgChart
//    这段代码是使用C#编写的，它定义了一个名为 IncomingData 的类，用于处理接收到的字节数据并将其解析为双精度浮点数。以下是对每个部分的详细解释：

//导入命名空间：

//using System：引入了基本的C#系统命名空间。
//using System.Collections.Generic：引入了集合类的命名空间，用于操作和管理数据集合。
//using System.Linq：引入了LINQ（Language Integrated Query）命名空间，用于在集合中进行查询和操作。
//定义 IncomingData 类：

//构造函数 IncomingData()：一个空的构造函数，不执行任何操作。
//静态方法 parseBytes(byte[] data)：

//接收一个字节数组参数 data，用于解析其中的字节数据。
//通过特定的标识字节（170）将数据分割成多个部分，每个部分的长度为 6 字节。
//使用一个字符串列表 cByte 来暂时存储解析出的字节。
//使用 yield return 将解析后的双精度浮点数逐个返回，允许延迟枚举。
//静态方法 parseByte(List<string> cByte)：

//接收一个字符串列表参数 cByte，其中存储了要解析的字节数据。
//将第4和第5个字节合并为一个双精度浮点数值，并进行一些转换操作。
//返回解析后的双精度浮点数。
//私有方法 testCheckSum()：

//用于测试校验和的方法，不在代码中被直接调用。
//私有方法 checkSum(List<int> arr)：

//接收一个整数列表参数 arr，用于进行校验和的计算。
//通过一系列计算步骤计算并验证校验和的正确性。
//静态方法 hexToSigned(double vd)：

//将一个浮点数值转换为有符号整数并返回。
//这段代码主要定义了一个名为 IncomingData 的类，用于处理接收到的字节数据，并根据特定规则解析为双精度浮点数。它的主要功能是将字节数据转换为实际的数据值，适用于在与外部设备进行通信时处理传输数据。
{
	public class IncomingData
	{
		public IncomingData()
		{
		}
		public static IEnumerable<double> parseBytes(byte[] data)
		{
			int ByteLength = 6 ;
			List<string> cByte = new List<string>();
			for (int i=0, length=data.Length; i<length; i++) 
			{
				if(data[i]==170) {
					if(i<=length-ByteLength && data[i+1]==170) {							
						if (cByte.Count==ByteLength) {
							yield return parseByte(cByte);
						}
						cByte.Clear();
					}
				}
				else 
				{
					cByte.Add(data[i].ToString());
				}
			}
		}
		static double parseByte(List<string> cByte)
		{
			double v1 = double.Parse(cByte[3]);
			double v2 = double.Parse(cByte[4]);
			double v = v1*16*16+v2;
			v = hexToSigned(v);
			return v;
		}
		void testCheckSum()
		{
			List<int> foo = new List<int>();
			foo.Add(128);
			foo.Add(2);
			foo.Add(9);
			foo.Add(82);
			foo.Add(34);
			string msg = checkSum(foo)?"ok":"nope";
//			MessageBox.Show(msg);
		}
		bool checkSum(List<int> arr)
		{
			int length, checkValue, checksum;
			length = arr.Count;
			if(length<2) return false;
			checkValue = arr[length-1]; arr.RemoveAt(length-1); //Array.pop();
			checksum = arr.Sum(); 
			checksum &= 0xFF;
			checksum = ~checksum & 0xFF;
			return checksum==checkValue;
		}
		static double hexToSigned(double vd) {
			int v = (int)vd;
			if ((v & 0x8000) > 0) {
				v = v - 0x10000;
			}
			return v;
		}
	}
}
