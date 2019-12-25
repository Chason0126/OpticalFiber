using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Diagnostics;

namespace OpticalFiber
{
    public partial class UCChart : UserControl
    {
        //Stopwatch stopwatch;
        public UCChart(int deviceNo,int channelNo,int partitionNo ,string title)
        {
            InitializeComponent();
            this.title = title;
            this.deviceNo = deviceNo;
            this.channelNo = channelNo;
            this.partitionNo = partitionNo;

            chart1.Series.Clear();

            series_AvgTemper.BorderColor = Color.Blue;
            series_AvgTemper.BorderWidth = 2;
            series_AvgTemper.ChartType = SeriesChartType.Line;

            series_RealTemper.BorderColor = Color.Green;
            series_RealTemper.BorderWidth = 2;
            series_RealTemper.ChartType = SeriesChartType.Line;

            series_RiseTemper.BorderColor = Color.Red;
            series_RiseTemper.BorderWidth = 2;
            series_RiseTemper.ChartType = SeriesChartType.Line;

            chart1.Series.Add(series_AvgTemper);
            chart1.Series.Add(series_RealTemper);
            chart1.Series.Add(series_RiseTemper);

            series_AvgTemper.Enabled = toolStripMenuItem1.Checked;
            series_RealTemper.Enabled = toolStripMenuItem2.Checked;
            series_RiseTemper.Enabled = toolStripMenuItem3.Checked;

            chart1.MouseWheel += MouseEventHandler;
            Init();
        }

        Series series_AvgTemper = new Series("平均温度");
        Series series_RealTemper = new Series("实时温度");
        Series series_RiseTemper = new Series("温升速率");

        string title;
        int deviceNo;
        int channelNo;
        int partitionNo;

        int startPosition;
        int endPosition;

        private int minmumX;
        private int maxmumX;
        private int intervalX;

        private int minmumY = -50;
        private int maxmumY = 200;
        private int intervalY = 20;



        public int MinmumX { get => minmumX; set => minmumX = value; }
        public int MaxmumX { get => maxmumX; set => maxmumX = value; }
        public int IntervalX { get => intervalX; set => intervalX = value; }
        public int MinmumY { get => minmumY; set => minmumY = value; }
        public int MaxmumY { get => maxmumY; set => maxmumY = value; }
        public int IntervalY { get => intervalY; set => intervalY = value; }


        private void Init()
        {
            if (partitionNo == 0)//是通道的  横轴起始位-200
            {
                startPosition = 1;
                endPosition = DataClass.list_DeviceChannelParam[deviceNo].struct_ChannelParams[channelNo].length;//通道光纤长度
                MaxmumX = endPosition;
                MinmumX = -200;
                IntervalX = 200;
            }
            else
            {
                startPosition = DataClass.list_DevicePartition[deviceNo].struct_devicePartition.struct_ChannelPartitions[channelNo].struct_Partitions[partitionNo].startPosition;
                endPosition = DataClass.list_DevicePartition[deviceNo].struct_devicePartition.struct_ChannelPartitions[channelNo].struct_Partitions[partitionNo].endPosition;
                MaxmumX = endPosition;
                MinmumX = startPosition - 1;
                IntervalX = 50;
            }
           
            timer1.Start();

          
           

            chart1.ChartAreas[0].AxisX.Maximum = MaxmumX;
            chart1.ChartAreas[0].AxisX.Minimum = MinmumX;
            chart1.ChartAreas[0].AxisX.Interval = IntervalX;


            chart1.ChartAreas[0].AxisY.Interval = IntervalY;
            chart1.ChartAreas[0].AxisY.Maximum = MaxmumY;
            chart1.ChartAreas[0].AxisY.Minimum = MinmumY;
            lblTitle.Text = title;
        }

       
        private  void timer1_Tick(object sender, EventArgs e)
        {
            //stopwatch = new Stopwatch();
            //stopwatch.Start();
            double avgMaxtemper = 0;
            int avgMaxposition = 0;
            double realMaxtemper = 0;
            int realMaxposition = 0;
            series_AvgTemper.Points.Clear();
            series_RealTemper.Points.Clear();
            series_RiseTemper.Points.Clear();
            for (int i=startPosition;i< endPosition; i++)
            {
                double avgTempTemper;
                double realTempTemper;
                if (IsBroken())//断纤 
                {
                    avgTempTemper = 0;
                    realTempTemper = 0;
                    series_AvgTemper.Points.AddXY(i, 0);
                    series_RealTemper.Points.AddXY(i, 0);
                }
                else
                {
                    avgTempTemper = (double)DataClass.list_DeviceTemper[deviceNo].channelTempers[channelNo].averageTemper[i] / 10;
                    series_AvgTemper.Points.AddXY(i, avgTempTemper);
                    realTempTemper = (double)DataClass.list_DeviceTemper[deviceNo].channelTempers[channelNo].realTemper[i] / 10;
                    series_RealTemper.Points.AddXY(i, realTempTemper);
                }
              
                if (avgTempTemper > avgMaxtemper)
                {
                    avgMaxtemper = avgTempTemper;
                    avgMaxposition = i;
                }
                if (realTempTemper > realMaxtemper)
                {
                    realMaxtemper = realTempTemper;
                    realMaxposition = i;
                }
            }
            if (toolStripMenuItem1.Checked)
            {
                lblMax.Text = "最高温度：" + avgMaxtemper + "℃ 距离：" + avgMaxposition + "米";
            }
            else if (toolStripMenuItem2.Checked)
            {
                lblMax.Text = "最高温度：" + realMaxtemper + "℃ 距离：" + realMaxposition + "米";
            }
            //stopwatch.Stop();
            //string time = stopwatch.ElapsedMilliseconds.ToString();

            //for (int i = 0; i <= length; i++)
            //{
            //    series_RiseTemper.Points.AddXY(i, ((double)DataClass.list_DeviceTemper[deviceNo].channelTempers[channelNo].riseTemper[startPosition + i] / 10));
            //}
        }

        private bool IsBroken()
        {
            bool isBroken = false;
            int alarmStatus = DataClass.list_DeviceChannelParam[deviceNo].struct_ChannelParams[channelNo].isBroken;
            if (alarmStatus == 1)
            {
                isBroken = true;
            }
            return isBroken;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = !toolStripMenuItem1.Checked;
            series_AvgTemper.Enabled = toolStripMenuItem1.Checked;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = !toolStripMenuItem2.Checked;
            series_RealTemper.Enabled = toolStripMenuItem2.Checked;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3.Checked = !toolStripMenuItem3.Checked;
            series_RiseTemper.Enabled = toolStripMenuItem3.Checked;
        }

        List<Zoom_StartAndFinish> arrayList_Zoom = new List<Zoom_StartAndFinish>();
        struct Zoom_StartAndFinish
        {
            public double posXStart;
            public double posXFinish;
        }
        private void MouseEventHandler(object sender, MouseEventArgs e)
        {
            try
            {
                Zoom_StartAndFinish zoom_StartFinish = new Zoom_StartAndFinish();
                double XMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double XMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (XMax - XMin) / 4;
                double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (XMax - XMin) / 4;
                zoom_StartFinish.posXStart = posXStart;
                zoom_StartFinish.posXFinish = posXFinish;

                if (e.Delta < 0 && arrayList_Zoom.Count >= 2)
                {
                    zoom_StartFinish = arrayList_Zoom[arrayList_Zoom.Count - 2];
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(zoom_StartFinish.posXStart, zoom_StartFinish.posXFinish);
                    arrayList_Zoom.RemoveAt(arrayList_Zoom.Count - 1);
                }
                if (arrayList_Zoom.Count == 1||arrayList_Zoom.Count==0)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                }
                if (e.Delta > 0)
                {
                    arrayList_Zoom.Add(zoom_StartFinish);
                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        ToolTip toolTip = new ToolTip();

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.ForeColor = Color.Black;
            Point point = new Point(e.X, e.Y);
            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(point, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(point, true);
            var result = chart1.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int i = result.PointIndex;
                DataPoint dataPoint = result.Series.Points[i];
                toolTip.AutoPopDelay = 1000;
                if (partitionNo != 0)
                {
                    toolTip.SetToolTip(chart1, "温度" + dataPoint.YValues[0].ToString() + "℃\r\n" + "距离" + (i + MinmumX) + "米");
                }
                else
                {
                    toolTip.SetToolTip(chart1, "温度" + dataPoint.YValues[0].ToString() + "℃\r\n" + "距离" + i + "米");
                }
            }
        }
    }
}
