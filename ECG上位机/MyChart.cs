using System;
using System.Collections.Generic;
using System.Drawing;
using ZedGraph;
namespace EcgChart
//    这段代码是使用C#编写的，它定义了一个名为 MyChart 的类，用于在 ZedGraph 控件中实现心电图的实时显示。以下是对每个部分的详细解释：

//导入命名空间：

//using System：引入了基本的C#系统命名空间。
//using System.Collections.Generic：引入了集合类的命名空间，用于操作和管理数据集合。
//using System.Drawing：引入了绘图相关的命名空间，用于处理颜色和图形。
//using ZedGraph：引入了 ZedGraph 库的命名空间，该库用于绘制图形和曲线。
//定义 MyChart 类：

//ZedGraphControl graph：私有字段，表示 ZedGraph 控件。
//GraphPane pane：私有字段，表示图表的绘图区域。
//const string chartTitle：私有常量字段，表示图表的标题，被设置为"ECG实时显示系统"。
//int pointCount：私有字段，用于跟踪添加的数据点数量。
//构造函数 MyChart(ZedGraphControl g)：

//接收一个 ZedGraphControl 参数作为图表的绘图区域。
//初始化各字段，调用 initGraph() 进行图表初始化。
//私有方法 initGraph()：

//清除之前的曲线，设置图表标题、轴标题等。
//创建一个红色的曲线，并设置其他绘图选项，如缩放、滚动等。
//调用 Update() 方法进行更新。
//公共方法 DrawGraph(List<double> val, string label, bool append)：

//接收一个 List<double> 参数 val，表示要绘制的数据值。
//根据参数 append 的值决定是否清除之前的曲线，设置曲线颜色。
//将 val 转换为 PointPairList 对象，并根据是否追加数据绘制相应的曲线。
//调用 Update() 方法进行更新。
//私有方法 listToPointPairList(List<double> val)：

//将输入的 List<double> 转换为 PointPairList 对象，便于图表绘制。
//私有方法 Update()：

//调用 AxisChange() 方法更新轴的变化。
//调用 Invalidate() 方法触发控件的重绘。
//公共方法 AddPoint(double val, int curveIndex = 0)：

//向指定的曲线中添加一个数据点，同时更新点的数量和图表。
//这段代码主要定义了一个名为 MyChart 的类，用于在 ZedGraph 控件中实现心电图(ECG)的实时显示。它封装了图表的初始化、数据绘制和数据添加等功能，方便在C#应用程序中集成实时的心电图显示功能。
{
	public class MyChart
	{
		ZedGraphControl graph;
		GraphPane pane;
		const string chartTitle = "ECG实时显示系统";
		int pointCount;
		
		
		public MyChart(ZedGraphControl g)
		{
			graph = g; 
			pane = graph.GraphPane; 
			pointCount = 0; 
			initGraph();
		}
		void initGraph(){
			pane.CurveList.Clear();
			pane.Title.Text = chartTitle;
//			pane.YAxis.Title.IsVisible = false;
            pane.YAxis.Title.Text = "幅值/uV";
			pane.XAxis.Title.Text="Time";
//			pane.XAxis.Title.IsVisible = false;
			pane.XAxis.Scale.Min = 0;
			graph.RestoreScale(pane); // restore to default all zooming, etc.
//			pane.XAxis.AxisGap
            LineItem myCurve = pane.AddCurve("ECG", null, Color.Red, SymbolType.None);
			graph.IsEnableHZoom = true;
			graph.IsEnableVZoom = false;
			graph.IsShowHScrollBar = true;
			graph.IsAutoScrollRange = true;
			Update();
		}
		public void DrawGraph (List<double> val,string label,bool append)
		{
			label = label ?? "ECG";
            Color color = Color.Red;
			
			if(!append) pane.CurveList.Clear (); 
			else color=Color.Maroon;
			pointCount = 0;
			PointPairList list = listToPointPairList(val); 
			LineItem myCurve = pane.AddCurve (label, list, color, SymbolType.None);
			graph.RestoreScale(pane);
			Update();
		}
		PointPairList listToPointPairList(List<double> val)
		{
			PointPairList result = new PointPairList ();
			int l=val.Count;
			for(int i=0; i<l;i++) {
				result.Add(i,val[i]);
			}
			return result;
		}
		void Update() 
		{
			graph.AxisChange ();
			graph.Invalidate ();
		}
		public void AddPoint(double val,int curveIndex=0) 
		{
			pane.CurveList[curveIndex].AddPoint(pointCount++,val);
			Update();
		}
	}
}
