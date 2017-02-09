using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Timers;

namespace testDraw1
{
    public partial class Form1 : Form
    {
        #region 变量
        Dictionary<int, string> nameDic = new Dictionary<int, string>();     //姓名字典1
        List<string> nameList = new List<string>();                          //姓名列表1

        private int delete = 0;
        static int third = 0;
        static int second = 0;
        static int first = 0;
        static int special = 0;
        bool ss = false;
        bool s = false;
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pic\fu1.jpg");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "开始";
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;                                                                  
            groupBox5.Visible = false;
            person1.Visible = false;
            person2.Visible = false;
            person3.Visible = false;
            label1.Visible = false;

            //获取抽奖人员txt文件
            StreamReader reader = new StreamReader(Application.StartupPath + @"\list.txt",Encoding.Default);
            if (reader == null)
            {
                MessageBox.Show("获取列表失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string line = reader.ReadLine();
            while (line != "" && line != null)
            {
                string x = line;
                nameList.Add(x);
                line = reader.ReadLine();
            }                     
            for (int i = 0; i < nameList.Count; i++)
            {
                nameDic.Add(i+1, nameList[i]);
            }
            reader.Close();


        }

        private void button1_Click(object sender, EventArgs e)//抽奖按钮
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择抽奖类别", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (timer1.Enabled == false)
                {
                    timer1.Enabled = !timer1.Enabled;
                    comboBox1.Enabled = false;
                    button1.Text = "停止";
                    label1.Visible = true;
                }
                else
                {
                    timer1.Enabled = !timer1.Enabled;
                    label1.Visible = true;
                    comboBox1.Enabled = true;
                    button1.Text = "开始";
                    getName(comboBox1.SelectedIndex);
                }            
            }            
        }

        private void getName(int a)//获取中奖人姓名
        {
            switch(a)
            {
                case 0:
                    third++;
                    if (third >= 4)       //三等奖3人
                    {
                        //comboBox1.SelectedIndex++;
                        MessageBox.Show("三等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else 
                    {
                        nameDic.Remove(delete);
                        if (third == 1)
                        {
                            person1.Text = label1.Text;
                            label4.Text = person1.Text;
                        }
                        else if (third == 2)
                        {
                            person2.Text = label1.Text;
                            label5.Text = person2.Text;
                        }
                        else if (third == 3)
                        {
                            person3.Text = label1.Text;
                            label6.Text = person3.Text;
                            MessageBox.Show("三等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupBox2.Visible = true;
                        }
                        break; 
                    }              
                case 1:
                    second++;
                    if (second >= 3)          //二等奖2人
                    {
                        //comboBox1.SelectedIndex++;
                        MessageBox.Show("二等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else
                    {
                        nameDic.Remove(delete);
                        if (second == 1)
                        {
                            person1.Text = label1.Text;
                            label7.Text = person1.Text;
                        }
                        else if (second == 2)
                        {
                            person2.Text = label1.Text;
                            label8.Text = person2.Text;
                            MessageBox.Show("二等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupBox3.Visible = true;
                        }
                        break;
                    }
                case 2:
                    first++;
                    if (first >= 2)             //一等奖1人
                    {
                        //comboBox1.SelectedIndex++;
                        MessageBox.Show("一等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else
                    {
                        person1.Text = label1.Text;
                        label9.Text = person1.Text;
                        nameDic.Remove(delete);
                        MessageBox.Show("一等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox4.Visible = true;
                        break;
                    }
                case 3:
                    special++;
                    if (special >= 2)             //特等奖1人
                    {
                        //comboBox1.Text = " ";
                        MessageBox.Show("特等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else
                    {
                        person1.Text = label1.Text;
                        label10.Text = person1.Text;
                        nameDic.Remove(delete);
                        MessageBox.Show("特等奖抽奖完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        groupBox5.Visible = true;
                        break;
                    }                    
            }
                
        }

        private void timer1_Tick(object sender, EventArgs e)//定时器设置 定时输出随机数，作为字典索引获取中奖人姓名
        {
                if (comboBox1.SelectedIndex == 2)
                    timer1.Interval = 15;
                int[] arrPerson = new int[nameDic.Count];
                nameDic.Keys.CopyTo(arrPerson, 0);
                int nRdId = new Random().Next(0, arrPerson.Length);
                int nPerson = arrPerson[nRdId];
                label1.Text = nameDic[nPerson];
                delete = nPerson; 
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)//抽奖类别选择框
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox1.Visible = true;
                person1.Visible = true;
                person2.Visible = true;
                person3.Visible = true;
                person1.Text = "获奖者1";
                person2.Text = "获奖者2";
                person3.Text = "获奖者3";
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\pic\3.png");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                groupBox1.Visible = true;
                person1.Visible = true;
                person2.Visible = true;
                person3.Visible = false;
                person1.Text = "获奖者1";
                person2.Text = "获奖者2";
                person3.Text = "获奖者3";
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\pic\2.png");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Visible = true;
                person1.Visible = true;
                person2.Visible = false;
                person3.Visible = false;
                person1.Text = "获奖者1";
                person2.Text = "获奖者2";
                person3.Text = "获奖者3";
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\pic\1.png");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                groupBox1.Visible = true;
                person1.Visible = true;
                person2.Visible = false;
                person3.Visible = false;
                person1.Text = "获奖者1";
                person2.Text = "获奖者2";
                person3.Text = "获奖者3";
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\pic\s.jpg");
            }
        }

        private void 进入特别纪念奖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ss == false)
            {
                if (third >= 3 && second >= 2 && first >= 1 && special >= 1)
                {
                    //this.Visible = false;
                    Form2 f2 = new Form2();

                    f2.P1 = label4.Text;
                    f2.P2 = label5.Text;
                    f2.P3 = label6.Text;
                    f2.P4 = label7.Text;
                    f2.P5 = label8.Text;
                    f2.P6 = label9.Text;
                    f2.P7 = label10.Text;

                    ss = true;
                    f2.ShowDialog();
                    f2.TopMost = true;

                }
                else
                {
                    MessageBox.Show("没有完成今年抽奖", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("抽奖结束", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
