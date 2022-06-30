using System;
using System.Collections;
using System.Reflection;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            Crypt crypt = new Crypt();

            if(radioButton1.Checked)
            {
                crypt.my_md5(input);
                textBox2.Text = crypt.TakeMD5Result();
            }
            else
            {
                int res = await crypt.my_md5_for_file(input);
                if (res == 0)
                    textBox2.Text = crypt.TakeMD5Result();
                else
                    textBox2.Text = "Файл не существует";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
                textBox1.Text = OPF.FileName;
        }
    }
}
