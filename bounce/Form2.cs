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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(label1);
             int x = 0;
            int y = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 29; j++)
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
                y +=22;
            }
           
      
          

         


          
        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Remove(button4);
        }


    }
}
