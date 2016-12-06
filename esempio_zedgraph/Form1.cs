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
        private Timer timer;
        private PointPairList pointPl = new PointPairList();
        private double X, Y;
        public List<double> Lx = new List<double>();
        public List<double> Ly = new List<double>();

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Accelerometer";
            myPane.XAxis.Title.Text = "Time(ms)";
            myPane.YAxis.Title.Text = "g(m/sec^2)";
            // myPane.YAxis.Scale.MagAuto = false;
            // PointPairList holds the data for plotting, X and Y arrays

            // RollingPointPairList aaa = new RollingPointPairList(i);
            // Add curves to myPane object
            LineItem myCurve = myPane.AddCurve("ADC", pointPl, Color.Red, SymbolType.None);
            //myCurve.Line.IsVisible = false;
            myCurve.Line.Width = 1.0F;
            // LineItem myCurve = myPane.AddCurve("ADC", aaa, Color.Blue, SymbolType.None);
            // BarItem mybar = myPane.AddBar("plotting", x , y, Color.Red);
            // I add all three functions just to be sure it refeshes the plot. 
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();
        }

    void timer_Tick(object sender, EventArgs e)
    {
        Y = Math.Cos(X);
        Lx.Add(X); Ly.Add(Y);

        X += 1;
        // pointPl.Add(x,y);
        pointPl.Add(X, Y);
        zedGraphControl1.AxisChange();
        //zedGraphControl1.Refresh(); 
        zedGraphControl1.Invalidate();

    }

    public Form1()
        {
            InitializeComponent();
            EventArgs e = new EventArgs();
            zedGraphControl1_Load(this, e);

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
    }
}
