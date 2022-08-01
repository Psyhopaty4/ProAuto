using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProAuto
{
    public partial class AuthForm : Form
    {
        MainForm authForm = new MainForm();
        public AuthForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Equals("1234") && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text) &&
            //    textBox2.Text.Equals("Adm30") && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox2.Text))
            //{
                authForm.Show();
                this.Hide();
            //} else
            //{
            //   MessageBox.Show("Неправильный логин или пароль!","Иди нахуй");
            //}
        }
    }
}
