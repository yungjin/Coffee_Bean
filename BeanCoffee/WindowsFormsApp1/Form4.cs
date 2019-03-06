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
            panel1 = new Panel();
            panel1.BackColor = Color.FromArgb(237, 227, 183);
            panel1.Size = new Size(1170, 700);
            panel1.Location = new Point(50, 50);
            panel1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, panel1.Width, panel1.Height, 15, 15));

            this.Controls.Add(panel1);
        }
    }
}
