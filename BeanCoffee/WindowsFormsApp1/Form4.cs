using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Load += Form4_Load;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(163, 127, 74);// 폼 백컬러

            //판넬
            Panel panel1;
            Panel panel2;

            panel1 = new Panel();
            panel1.BackColor = Color.FromArgb(237, 227, 183);
            panel1.Size = new Size(580, 700);
            panel1.Location = new Point(50, 50);
            panel1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, panel1.Width, panel1.Height, 15, 15));

            panel2 = new Panel();
            panel2.BackColor = Color.FromArgb(237, 227, 183);
            panel2.Size = new Size(580, 700);
            panel2.Location = new Point(660, 50);
            panel2.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, panel1.Width, panel1.Height, 15, 15));

            this.Controls.Add(panel1);
            this.Controls.Add(panel2);
            ListView listView1 = new ListView();
            listView1.Size = new Size(530, 500);
            listView1.Location = new Point(25, 100);
            listView1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, listView1.Width, listView1.Height, 15, 15));
            listView1.BackColor = Color.FromArgb(224, 224, 224);

            ListView listView2 = new ListView();
            listView2.Size = new Size(530, 500);
            listView2.Location = new Point(25, 100);
            listView2.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, listView2.Width, listView2.Height, 15, 15));
            listView2.BackColor = Color.FromArgb(224, 224, 224);

            panel1.Controls.Add(listView1);
            panel2.Controls.Add(listView2);
        }
    }
}
