using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }

        COMMON_Create_Ctl comm;
        Timer timer;
        Panel grap1;
        Panel grap2;
        private void Form2_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거
            
            comm = new COMMON_Create_Ctl();
            this.BackColor = Color.FromArgb(163, 127, 74);// 폼 백컬러

            //판넬
            Panel panel1;
            panel1 = new Panel();
            panel1.BackColor = Color.FromArgb(237, 227, 183);
            panel1.Size = new Size(820, 700);
            panel1.Location = new Point(400, 50);
            panel1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, panel1.Width, panel1.Height, 15, 15));

            LBclass lb1 = new LBclass(this, "label1", "label_name~", 24, 100, 100, 10, 10);
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "원두", "원두 :", 15, 100, 40, 50, 170));
            lbarray.Add(new LBclass(this, "용량", "용량(단위KG) :", 15, 250, 40, 50, 210 + 20));
            lbarray.Add(new LBclass(this, "이물질", "이물질 제거 :", 15, 250, 40, 50, 250 + 40));
            lbarray.Add(new LBclass(this, "온도", "로스팅 온도 :", 15, 250, 40, 50, 290 + 60));
            lbarray.Add(new LBclass(this, "시간", "로스팅 시간 :", 15, 250, 40, 50, 330 + 80));
            lbarray.Add(new LBclass(this, "쿨링", "실온쿨링 시간 :", 15, 250, 40, 50, 370 + 100));
            lbarray.Add(new LBclass(this, "결점두", "결점두 확인 :", 15, 250, 40, 50, 410 + 120));
            lbarray.Add(new LBclass(this, "숙성", "숙성 기간 :", 15, 250, 40, 50, 450 + 140));
            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm.lb((LBclass)lbarray[i]);

                lb.Font = new Font("견명조", 25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                

                panel1.Controls.Add(lb);
            }
            //ArrayList btn_Txt = new ArrayList();

            //btn_Txt.Add(new BTNclass(this, "로스팅", "로스팅", 100, 100, 10, 10, btn_Click));
            //for(int i = 0; i< btn_Txt.Count; i++)
            //{
            //    Button btTxt = comm.btn((BTNclass)btn_Txt[i]);
            //    if (btTxt.Name == "로스팅")
            //    {
            //        btTxt.
            //    } 
            //    panel1.Controls.Add(btTxt);
            //}

            TextBox textBox1 = new TextBox();
            textBox1.Size = new Size(160, 50);
            textBox1.Location = new Point(700, 100);
            textBox1.Multiline = true;
            textBox1.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, textBox1.Width, textBox1.Height, 15, 15));
            textBox1.Font = new Font(Font.Name, 25, FontStyle.Bold);
            textBox1.ReadOnly = true; 
            textBox1.BackColor = Color.FromArgb(224, 224, 224);

            string time = String.Format("{0}h {1}m","7","10");

            textBox1.Text = string.Format("{0}", time);

            panel1.Controls.Add(textBox1);
            // 콤보박스==========================================================
            ArrayList Muchine_list = new ArrayList();
            Muchine_list.Add("머신1");
            Muchine_list.Add("머신2");
            Muchine_list.Add("머신3");
            
            ComboBox combo1 = new ComboBox();
            combo1.Size = new Size(300, 300);
            combo1.Location = new Point(50, 80);
            combo1.Name = "콤보1";
            combo1.SelectedIndexChanged += Combo1_SelectedIndexChanged;
            Controls.Add(combo1);
            combo1.Font = new Font(combo1.Font.Name, 27, FontStyle.Regular);
            combo1.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < Muchine_list.Count; i++)
            {
                combo1.Items.Add(Muchine_list[i]);
            }
            //상태표시 텍스트 박스================================================
            TextBox textBox = new TextBox();
            textBox.Size = new Size(300,400);
            textBox.Location = new Point(50,350);
            textBox.Multiline = true;
            textBox.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, textBox.Width, textBox.Height, 15, 15));
            textBox.Font = new Font(Font.Name, 18, FontStyle.Regular);
            textBox.ReadOnly = true;
            textBox.BackColor = Color.FromArgb(237, 227, 183);

            ArrayList machine_text = new ArrayList();
            machine_text.Add("결점두 확인요망 ");
            machine_text.Add("로스팅 완료 ");
            machine_text.Add("쿨링 완료 ");

            textBox.Text = string.Format(" -{0}",Muchine_list[1].ToString() +" "+ machine_text[1].ToString());

            Controls.Add(textBox);
            //그래프 바 ===========================================================
            grap1 = new Panel();
            grap2 = new Panel();

            grap1.Height = 50;
            grap1.Width = 620;
            grap1.BackColor = Color.Silver;
            grap1.Location = new Point(50, 100);


            grap2.Height = 50;
            grap2.Width = 10;
            grap2.BackColor = Color.Silver;
            grap2.Location = new Point(50, 100);

            
            panel1.Controls.Add(grap2);
            panel1.Controls.Add(grap1);

            timer = new Timer();
            timer.Interval = 9600;
            timer.Tick += Timer_Tick;
            timer.Start();
            //버튼 =================================================================
            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "설정", "설 정", 100, 60, 680, 530, btn1_Click));
            btnArray.Add(new BTNclass(this, "결점두 확인", "결점두 확인", 150, 60, 630, 600, btn2_Click));

            for (int i = 0; i < btnArray.Count; i++)
            {
                Button btn = comm.btn((BTNclass)btnArray[i]);

                if (btn.Name == "설정")
                {
                    btn.Font = new Font("견명조", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(80, 200, 223);
                    btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
                    btn.BackColor = Color.FromArgb(52, 152, 219);  // rgb(218,234,244)
                }
                else if (btn.Name == "결점두 확인")
                {
                    btn.Font = new Font("견명조", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(80, 200, 223);
                    btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
                    btn.BackColor = Color.FromArgb(52, 152, 219);  // rgb(218,234,244)
                }
                panel1.Controls.Add(btn);
            }
            this.Controls.Add(panel1);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("설정 클릭");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("결점두 확인");
        }

        

        private void btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (grap2.Width > 620)
            {
                grap2.Width = 1;

            }
            else if (grap2.Width == 620)
            {
                timer.Stop();
                
            }
            else
            {
                grap2.Width = grap2.Width + 2;
                grap2.BackColor = Color.FromArgb(231, 76, 60);
            }

            //if (grap2.Width > 370) grap2.Width = 1;
            //else grap2.Width = grap2.Width + 1;

            timer.Start();
        }

    }
}
