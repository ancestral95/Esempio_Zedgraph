using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace esempio_zedgraph
{
    public partial class Form1 : Form
    {
        public double[] x = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        public double[] y = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 7, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };

        public Form1()
        {
            InitializeComponent();
            EventArgs e = new EventArgs();
            zedGraphControl1_Load(this, e);
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Accelerometer";
            myPane.XAxis.Title.Text = "Time(10^-2sec)";
            myPane.YAxis.Title.Text = "Dati(#)";
            // myPane.YAxis.Scale.MagAuto = false;
            // PointPairList holds the data for plotting, X and Y arrays 
            PointPairList spl1 = new PointPairList(x, y);
            // RollingPointPairList aaa = new RollingPointPairList(i);
            // Add curves to myPane object
            LineItem myCurve = myPane.AddCurve("ADC", spl1, Color.Red, SymbolType.None);
            //myCurve.Line.IsVisible = false;
            myCurve.Line.Width = 1.0F;
            // LineItem myCurve = myPane.AddCurve("ADC", aaa, Color.Blue, SymbolType.None);
            // BarItem mybar = myPane.AddBar("plotting", x , y, Color.Red);
            // I add all three functions just to be sure it refeshes the plot. 
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();

        }
    }
}
