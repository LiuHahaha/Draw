using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Threading;

namespace testDraw1
{
    public partial class Form2 : Form
    {
        Dictionary<int, string> pastNameDic = new Dictionary<int, string>();  //姓名字典
        List<string> pastNameList = new List<string>();                       //姓名列表
        string p1;
        string p2;
        string p3;
        string p4;
        string p5;
        string p6;
        string p7;

        public string P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        public string P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public string P3
        {
            get { return p3; }
            set { p3 = value; }
        }

        public string P4
        {
            get { return p4; }
            set { p4 = value; }
        }

        public string P5
        {
            get { return p5; }
            set { p5 = value; }
        }

        public string P6
        {
            get { return p6; }
            set { p6 = value; }
        }

        public string P7
        {
            get { return p7; }
            set { p7 = value; }
        }

        public Form2()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\fu2.jpg");
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label7.Text = "";
            button1.Text = "开始";

            StreamReader reader = new StreamReader(Application.StartupPath + @"\list2.txt", Encoding.Default);
            if (reader == null)
            {
                MessageBox.Show("获取列表失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string line = reader.ReadLine();
            while (line != "" && line != null)
            {
                string x = line;
                pastNameList.Add(x);
                line = reader.ReadLine();
            }
            reader.Close();

            pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\pic\ss.png");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (pastNameList.Contains(p1))
                pastNameList.Remove(p1);
            if (pastNameList.Contains(p2))
                pastNameList.Remove(p2);
            if (pastNameList.Contains(p3))
                pastNameList.Remove(p3);
            if (pastNameList.Contains(p4))
                pastNameList.Remove(p4);
            if (pastNameList.Contains(p5))
                pastNameList.Remove(p5);
            if (pastNameList.Contains(p6))
                pastNameList.Remove(p6);
            if (pastNameList.Contains(p7))
                pastNameList.Remove(p7);

            if (pastNameList.Count != 0)
            {
                for (int i = 0; i < pastNameList.Count; i++)
                {
                    pastNameDic.Add(i + 1, pastNameList[i]);
                }
                showlabels(pastNameList.Count);
            }
            else
            {
                label1.Text = "无";
                label1.Visible = true;
            }
        }

        public void showlabels(int a)
        {
            switch(a)
            {
                case 1:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    break;
                case 2:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    break;
                case 3:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    break;
                case 4:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    break;
                case 5:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    break;
                case 6:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    break;
                case 7:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    break;
                case 8:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    break;
                case 9:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    label10.Text = pastNameList[8];
                    label10.Visible = true;
                    break;
                case 10:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    label10.Text = pastNameList[8];
                    label10.Visible = true;
                    label11.Text = pastNameList[9];
                    label11.Visible = true;
                    break;
                case 11:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    label10.Text = pastNameList[8];
                    label10.Visible = true;
                    label11.Text = pastNameList[9];
                    label11.Visible = true;
                    label12.Text = pastNameList[10];
                    label12.Visible = true;
                    break;
                case 12:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    label10.Text = pastNameList[8];
                    label10.Visible = true;
                    label11.Text = pastNameList[9];
                    label11.Visible = true;
                    label12.Text = pastNameList[10];
                    label12.Visible = true;
                    label13.Text = pastNameList[11];
                    label13.Visible = true;
                    break;
                case 13:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    label10.Text = pastNameList[8];
                    label10.Visible = true;
                    label11.Text = pastNameList[9];
                    label11.Visible = true;
                    label12.Text = pastNameList[10];
                    label12.Visible = true;
                    label13.Text = pastNameList[11];
                    label13.Visible = true;
                    label14.Text = pastNameList[12];
                    label14.Visible = true;
                    break;
                case 14:
                    label1.Text = pastNameList[0];
                    label1.Visible = true;
                    label2.Text = pastNameList[1];
                    label2.Visible = true;
                    label3.Text = pastNameList[2];
                    label3.Visible = true;
                    label4.Text = pastNameList[3];
                    label4.Visible = true;
                    label5.Text = pastNameList[4];
                    label5.Visible = true;
                    label6.Text = pastNameList[5];
                    label6.Visible = true;
                    label8.Text = pastNameList[6];
                    label8.Visible = true;
                    label9.Text = pastNameList[7];
                    label9.Visible = true;
                    label10.Text = pastNameList[8];
                    label10.Visible = true;
                    label11.Text = pastNameList[9];
                    label11.Visible = true;
                    label12.Text = pastNameList[10];
                    label12.Visible = true;
                    label13.Text = pastNameList[11];
                    label13.Visible = true;
                    label14.Text = pastNameList[12];
                    label14.Visible = true;
                    label15.Text = pastNameList[13];
                    label15.Visible = true;
                    break;
            }
                 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            int[] arrPerson = new int[pastNameDic.Count];
            pastNameDic.Keys.CopyTo(arrPerson, 0);
            int nRdId = new Random().Next(0, arrPerson.Length);
            int nPerson = arrPerson[nRdId];
            label7.Text = pastNameDic[nPerson];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = !timer1.Enabled;
                button1.Text = "停止";
                label7.Visible = true;
            }
            else
            {
                timer1.Enabled = !timer1.Enabled;
                button1.Text = "结束";
                button1.Enabled = false;
            }            
        }
    }
}
