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
    public partial class Main : Form
    {
        int sX = 1500, sY = 820; // 폼 사이즈 지정.

        static ToolStripStatusLabel StripLb; //좌표체크
        StatusStrip statusStrip;

         

        public Panel panel1;

        public Button btn;
        public Button btn1;
        public Button btn2;
        public Button btn3;

        //폼 개체==========================
        public Form1 form1 = new Form1();
        public Form2 form2 = new Form2();
        public Form3 form3 = new Form3();
        public Form4 form4 = new Form4();

        public Main()
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정

            this.IsMdiContainer = true;     // MDI 설정

            Point_Print();//좌표체크 

            COMMON_Create_Ctl comm_create_ctl = new COMMON_Create_Ctl();//컨트롤 개체

            Logo_Lode();//로고

            PANELclass pn1 = new PANELclass(this, "panel1", "panel_main", 1500-220, 930, 220, 0); //판낼 개체]
            //판넬======================================================================================================
            
            panel1 = comm_create_ctl.panel(pn1);  // ex) 판넬만들기 :  create_ctl.CTL명(CTL값);
            
            Controls.Add(panel1);  // 컨트롤에 추가함.(뷰화면)

            //==========================================================================================================

            //버튼======================================================================================================
            BTNclass bt1 = new BTNclass(this, "재고 현황", "재고 현황", 220, 150, 0, 200, btn1_Click);
            BTNclass bt2 = new BTNclass(this, "로스팅", "로스팅", 220, 150, 0, 350, btn2_Click);
            BTNclass bt3 = new BTNclass(this, "상품화", "상품화", 220, 150, 0, 500, btn3_Click);
            BTNclass bt4 = new BTNclass(this, "입고-출고", "입고-출고", 220, 150, 0, 650, btn4_Click);

            btn = comm_create_ctl.btn(bt1);
            ButtonConfig(btn, "재고현황");
            btn1 = comm_create_ctl.btn(bt2);
            ButtonConfig(btn1, "로스팅");
            btn2 = comm_create_ctl.btn(bt3);
            ButtonConfig(btn2, "상품화");
            btn3 = comm_create_ctl.btn(bt4);
            ButtonConfig(btn3, "입고-출고");

            Controls.Add(btn);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            //============================================================================================================

            form1.Show();

            //form1 추가==================================================================================================
            form1.TopLevel = false;
            form1.TopMost = true;
            form1.MdiParent = this;
            form1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(form1);

            form2.TopLevel = false;
            form2.TopMost = true;
            form2.MdiParent = this;
            form2.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(form2);

            form3.TopLevel = false;
            form3.TopMost = true;
            form3.MdiParent = this;
            form3.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(form3);

            form4.TopLevel = false;
            form4.TopMost = true;
            form4.MdiParent = this;
            form4.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(form4);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("1클릭");
            form1.Show();
            form2.Hide();
            form3.Hide();
            form4.Hide();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("2클릭");
            form1.Hide();
            form2.Show();
            form3.Hide();
            form4.Hide();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("3클릭");
            form1.Hide();
            form2.Hide();
            form3.Show();
            form4.Hide();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("4클릭");
            form1.Hide();
            form2.Hide();
            form3.Hide();
            form4.Show();
        }

        private void ButtonConfig(Button btn,string btnTxt) // 버튼 설정
        {
            btn.Font = new Font("신명조", 30.0F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Text = btnTxt;
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(237, 220, 152);
        }


        private void Point_Print()//좌표체크 함수
        {
            MouseMove += new MouseEventHandler(this.Current_FORM_MouseMove);
            statusStrip = new StatusStrip();
            StripLb = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripLb });
            statusStrip.Location = new Point(0, sY);
            statusStrip.Name = "statusStrip1";
            statusStrip.Size = new Size(sX, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // toolStripStatusLabel1
            StripLb.Name = "StripLb1";
            StripLb.Size = new Size(121, 17);
            StripLb.Text = "StripLb1";
            Controls.Add(statusStrip);
        }


        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        public void Logo_Lode() // 로고 이미지
        {
            PictureBox PictureBox;

            PictureBox = new PictureBox();

            PictureBox.Image = (Bitmap)HLC_Module.Properties.Resources.ResourceManager.GetObject("Bean");
            PictureBox.Location = new Point(0, 0);
            PictureBox.Size = new Size(220, 200);
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.BackColor = Color.FromArgb(230, 194, 81);
            Controls.Add(PictureBox);
        }
    }


}
