using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bounce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int x = 0;          //红色方块x轴坐标
        public int y = 0;          //红色方块x轴坐标
        public int s = 0;          //时间
        public int sum = 0;        //数组索引
        public string str = "";    //方向
        public int lab3 = 0;       //绿色方块x轴坐标
        public List<string> list;
        public int ass = 0;
        private void Form1_Load_1(object sender, EventArgs e)
        {   
            timer1.Enabled = false;
            bounce.Visible = false;
            list = new List<string>();
            lab3 = 250;                   //绿色方块初始位置
            this.label3.Location = new System.Drawing.Point(lab3, 350);
        }
        private int aaa = 0;
        private void button1_Click_1(object sender, EventArgs e)//暂停/继续
        {

                aaa++;
                if (aaa % 2 == 1)
                { timer1.Enabled = false; button1.Text = "继续/Space"; }
                else
                { timer1.Enabled = true; button1.Text = "暂停/Space"; }
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            textBox1.Focus(); 
            s++;
            label1.Text = x + ":" + y + "  time:" + s;
            if (eswn(x, y, list[sum],ass) != "xy") str = eswn(x, y, list[sum],ass);//在十二项可能中则执行
            if (str == "es") { es(); }
            if (str == "en") { en(); }
            if (str == "ws") { ws(); }
            if (str == "wn") { wn(); }
            if (x == 0 || x == 551 || y == 0 || y == 330) { sum++; list.Add(str); }//timer1.Enabled = false; 
            this.bounce.Location = new System.Drawing.Point(x, y);//红色方块位置
            if (y == 330)//判断绿色方块与红色方块的X轴位置是否重合
            {
                if (x >= lab3 - 20 && x < lab3 + 80)
                    label2.Text = x + "";
                else { timer1.Enabled = false; over.Visible = true; }
            }
           
            label4.Text = "剩余数量:" + (panel1.Controls.Count - 3);
            foreach (Control a in panel1.Controls)//消除轨迹中的方块
            {
                if (a is Button)
                {
                    if (a.Location.Y == y && a.Location.X < x + 10 && a.Location.X + 22 > x + 10)
                    {
                        ass = a.Location.Y + 22; label2.Text = ass + "";
                        panel1.Controls.Remove(a); 
                        
                    }

                }
            }
            if (panel1.Controls.Count == 3) { over.Visible = true; end.Visible = true; timer1.Enabled = false; }//消除所有方块赢得胜利
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)//获取用户输入的键值
        {
            if (e.KeyCode == Keys.Left)
            {
                if(lab3>0)
                lab3 -= 5;
                this.label3.Location = new System.Drawing.Point(lab3, 350);
            }
            if (e.KeyCode == Keys.Right)
            {
                if (lab3 < 512)
                lab3 += 5;
                this.label3.Location = new System.Drawing.Point(lab3, 350);
            }
            if (e.KeyCode == Keys.Down) { if (y < 310) y += 20;}
            if (e.KeyCode == Keys.Space) { button1_Click_1(null, null);}
            if (e.KeyCode == Keys.F5) button3_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)//开始F5
        {
            if (leftorright() == "ws") x = 0;
            else x = 551;
             y = 80;
             s = 0;
            aaa = 0;
            button1.Text = "暂停/Space"; 
            list.Clear();
            list.Add(leftorright());
            sum = 0;
            removebut();
            newbut();
            lab3 = 250;
            this.label3.Location = new System.Drawing.Point(lab3, 350);
            timer1.Enabled = true;
            panel1.Visible = true;
            over.Visible = false;
            end.Visible = false;
            bounce.Visible = true;
            button3.Text = "重新开始/F5";
        }
        public string eswn(int a, int b,string str,int top)//根据上一个轨迹返回下一个轨迹
        {
            if (a == 0 && b == 0 ) return "es";
            if (a == 551 && b == 330) return "wn";
            if (a == 0 && b == 330) return "en";
            if (a == 551 && b == 0) return "ws";
            if ( b == 330 && str == "es") return "en";
            if (b == top && str == "en") return "es";
            if (a == 551 && str == "es") return "ws";
            if (b == 330 && str == "ws") return "wn";
            if (b == top && str == "wn") return "ws";
            if (a == 0 && str == "wn") return "en";
            if (a == 551 && str == "en") return "wn";
            if (a == top && str == "ws") return "es";
            else return "xy";
        }
        public void es()//东南
        {
            x++;
            y++;
        }
        public void en()//东北
        {
            x++;
            y--;
        }
        public void wn()//西北
        {
            x--;
            y--;
        }
        public void ws()//西南
        {
            x--;
            y++;
        }
        public void newbut()//创建panel1中的所有方块
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    Button a = new Button();
                    a.Location = new System.Drawing.Point(x, y);
                    a.Size = new System.Drawing.Size(22, 22);
                    a.UseVisualStyleBackColor = true;
                    a.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    panel1.Controls.Add(a);
                    x += 22;
                }
                x = 0;
                y += 22;
            }
        }
        private void removebut()//删除panel1中的所有方块
        {
            foreach (Control a in panel1.Controls)
            {
                if (a is Button)
                {
                    panel1.Controls.Remove(a);
                    removebut();
                }
            }
        }
        public string leftorright() //随机初始位置
        {
            Random r = new Random();
            int ran = r.Next(0, 9);
            if (ran % 2 == 0) { return "ws"; }
            else return "es";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode==Keys.A)
            MessageBox.Show("");
        }

    }
}
