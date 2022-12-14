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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string username = "root";
        string password = "1234";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == username && textBox2.Text==password)
            {
                Form3 frm3 = new Form3();
                frm3.Show();
                this.Hide();
            }
            if (textBox1.Text != username && textBox2.Text != password)
            {
                MessageBox.Show("invalid all info");
            }
            if (textBox1.Text != username)
            {
                MessageBox.Show("invalid username");  
            }
            if (textBox2.Text != password)
            {
                MessageBox.Show("invalid password");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

     