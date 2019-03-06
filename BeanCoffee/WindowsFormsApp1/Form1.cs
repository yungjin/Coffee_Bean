using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        COMMON_Create_Ctl comm;
        Panel panel1;

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(163, 127, 74);
            //판넬
            panel1 = new Panel();
            panel1.BackColor = Color.FromArgb(237, 227, 183);
            panel1.Size = new Size(1170, 700);
            panel1.Location = new Point(50, 50);
            panel1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, panel1.Width, panel1.Height, 15, 15));
            // 객체 선언 및 생성
            Chart chart1 = new Chart();
            Chart chart2 = new Chart();
            Chart chart3 = new Chart();
            Chart chart4 = new Chart();

            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();

            ChartArea chartArea3 = new ChartArea();
            Legend legend3 = new Legend();
            Series series3 = new Series();

            ChartArea chartArea4 = new ChartArea();
            Legend legend4 = new Legend();
            Series series4 = new Series();


            // 기본 설정
            chartArea1.Name = "ChartArea1";
            legend1.Name = "Legend1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartArea1.BackColor = Color.FromArgb(237, 227, 183);// 배경색상
            legend1.BackColor = Color.FromArgb(237, 227, 183);// 배경색상

            chartArea2.Name = "ChartArea2";
            legend2.Name = "Legend2";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = SeriesChartType.Doughnut;
            series2.Legend = "Legend2";
            series2.Name = "Series2";
            chartArea2.BackColor = Color.FromArgb(237, 227, 183);// 배경색상
            legend2.BackColor = Color.FromArgb(237, 227, 183);// 배경색상

            chartArea3.Name = "ChartArea3";
            legend3.Name = "Legend3";
            series3.ChartArea = "ChartArea3";
            series3.ChartType = SeriesChartType.Doughnut;
            series3.Legend = "Legend3";
            series3.Name = "Series3";
            chartArea3.BackColor = Color.FromArgb(237, 227, 183);// 배경색상
            legend3.BackColor = Color.FromArgb(237, 227, 183);// 배경색상

            chartArea4.Name = "ChartArea4";
            legend4.Name = "Legend4";
            series4.ChartArea = "ChartArea4";
            series4.ChartType = SeriesChartType.Doughnut;
            series4.Legend = "Legend4";
            series4.Name = "Series4";
            chartArea4.BackColor = Color.FromArgb(237, 227, 183);// 배경색상
            legend4.BackColor = Color.FromArgb(237, 227, 183);// 배경색상
            // 차트 기본 설정
            chart1.Name = "chart1";
            chart1.Size = new Size(310, 310);
            chart1.Location = new Point(30, 0);
            chart1.Text = "chart1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Legends.Add(legend1);
            chart1.Series.Add(series1);
            chart1.BackColor = Color.FromArgb(237, 227, 183);

            chart2.Name = "chart2";
            chart2.Size = new Size(310, 310);
            chart2.Location = new Point(400, 0);
            chart2.Text = "chart2";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Legends.Add(legend2);
            chart2.Series.Add(series2);
            chart2.BackColor = Color.FromArgb(237, 227, 183);

            chart3.Name = "chart3";
            chart3.Size = new Size(310, 310);
            chart3.Location = new Point(400 + 400, 0);
            chart3.Text = "chart3";
            chart3.ChartAreas.Add(chartArea3);
            chart3.Legends.Add(legend3);
            chart3.Series.Add(series3);
            chart3.BackColor = Color.FromArgb(237, 227, 183);

            chart4.Name = "chart4";
            chart4.Size = new Size(310, 310);
            chart4.Location = new Point(30, 340);
            chart4.Text = "chart4";
            chart4.ChartAreas.Add(chartArea4);
            chart4.Legends.Add(legend4);
            chart4.Series.Add(series4);
            chart4.BackColor = Color.FromArgb(237, 227, 183);

            // 데이터 부분

            ArrayList arry = Select_Webapi("Form1_Chart_all_Select");
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            foreach (Hashtable ht in arry) // 이름 , 그램 차트그래프 데이터 삽입 
            {
                chart1.Series["Series1"].Points.AddXY(ht["Bean_Name"].ToString(), ht["Gram"].ToString());
                
            }

            ArrayList arry1 = Select_Webapi("Form1_Chart_Roasting_select");
            chart2.Series["Series2"].IsValueShownAsLabel = true;
            foreach (Hashtable ht in arry1) // 이름 , 그램 차트그래프 데이터 삽입 
            {
                chart2.Series["Series2"].Points.AddXY(ht["Bean_Name"].ToString(), ht["SUM(Roasting_Gram)"].ToString());

            }
            

            ArrayList arry2 = Select_Webapi("Form1_Chart_Product_select");
            chart3.Series["Series3"].IsValueShownAsLabel = true;
            foreach (Hashtable ht in arry2) // 이름 , 그램 차트그래프 데이터 삽입 
            {
                chart3.Series["Series3"].Points.AddXY(ht["Bean_Name"].ToString(), ht["SUM(Product_Gram)"].ToString());

            }

            ArrayList arry3 = Select_Webapi("Form1_Chart_Bean_select");
            chart4.Series["Series4"].IsValueShownAsLabel = true;
            foreach (Hashtable ht in arry3) // 이름 , 그램 차트그래프 데이터 삽입 
            {
                chart4.Series["Series4"].Points.AddXY(ht["Bean_Name"].ToString(), ht["Bean"].ToString());

            }
            


            // 컨트롤 등록
            panel1.Controls.Add(chart1);
            panel1.Controls.Add(chart2);
            panel1.Controls.Add(chart3);
            panel1.Controls.Add(chart4);
            this.Controls.Add(panel1);
            comm = new COMMON_Create_Ctl();
            //라벨
            LBclass lb1 = new LBclass(this, "label1", "label_name~", 24, 100, 100, 10, 10);
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "전체 원두", "전체 원두", 20, 200, 40, 60, 310));
            lbarray.Add(new LBclass(this, "로스팅", "로스팅", 20, 200, 40, 440, 310));
            lbarray.Add(new LBclass(this, "상품화", "상품화", 20, 200, 40, 860, 310));
            lbarray.Add(new LBclass(this, "생 두", "생 두", 20, 200, 40, 90, 650));
            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm.lb((LBclass)lbarray[i]);

                lb.Font = new Font("견명조", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));


                panel1.Controls.Add(lb);
            }
        }

        

        public ArrayList Select_Webapi(string controll_name)
        {
            WebClient client = new WebClient();
            //NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://192.168.3.18:5000/" + controll_name;
            Stream result = client.OpenRead(url);

            StreamReader sr = new StreamReader(result);
            string str = sr.ReadToEnd();

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(str);
            ArrayList list = new ArrayList();
            foreach (JObject row in jList)
            {
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                list.Add(ht);
            }

            return list;
        }
    }
}
