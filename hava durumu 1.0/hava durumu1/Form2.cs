using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hava_durumu1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("please your info");

            }
            if (textBox1.Text=="root")
            {
                if (textBox2.Text=="1234")
                {
                    Form1 form1=new Form1();
                    form1.ShowDialog();
                    this.Hide();
                }

            }           
        }
    }
}
