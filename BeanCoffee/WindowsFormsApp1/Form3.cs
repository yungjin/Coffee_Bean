using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private List<int> _valueList1;
        Chart chart1;
        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(163, 127, 74);// 폼 백컬러

            //판넬
            Panel panel1;
            panel1 = new Panel();
            panel1.BackColor = Color.FromArgb(237, 227, 183);
            panel1.Size = new Size(1170, 700);
            panel1.Location = new Point(50, 50);
            panel1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, panel1.Width, panel1.Height, 15, 15));

            // 객체 선언 및 생성
            chart1 = new Chart();


            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();


            // 기본 설정
            chartArea1.Name = "ChartArea1";
            legend1.Name = "Legend1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartArea1.BackColor = Color.FromArgb(237, 227, 183);// 배경색상
            legend1.BackColor = Color.FromArgb(237, 227, 183);// 배경색상

            // 차트 기본 설정
            chart1.Name = "chart1";
            chart1.Size = new Size(310, 310);
            chart1.Location = new Point(500, 0);
            chart1.Text = "chart1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Legends.Add(legend1);
            chart1.Series.Add(series1);
            chart1.BackColor = Color.FromArgb(237, 227, 183);
            _valueList1 = new List<int>();

            // 컨트롤 등록
            panel1.Controls.Add(chart1);
            this.Controls.Add(panel1);
            start();
        }
        private void AddData()
        {
            //_valueList1.Add(System.DateTime.Now.Second);
            _valueList1.Add(new Random().Next(0, 100));
            DateTime now = DateTime.Now;
            if (chart1.Series[0].Points.Count > 0)
            {
                while (chart1.Series[0].Points[0].XValue < now.AddSeconds(-60).ToOADate())
                {
                    chart1.Series[0].Points.RemoveAt(0);
                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(0).ToOADate();
                }
            }
            chart1.Series[0].Points.AddXY(now.ToOADate(), _valueList1[_valueList1.Count - 1]);
            chart1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AddData();
        }
        private void start()
        {
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}
