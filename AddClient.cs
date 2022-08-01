using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProAuto
{
    public partial class AddClient : Form
    {
        string connectionString = @"Data Source=DESKTOP-G26Q8FF;Initial Catalog=ProAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection();

        public string typeQuery = "";
        string[] data = new string[7];

        public AddClient()
        {
            InitializeComponent();
        }
        public string[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            if (typeQuery.Equals("add"))
                add();
            else if (typeQuery.Equals("update"))
                update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            if (typeQuery.Equals("update"))
            {
                this.Text = "Редактирование клиента";
                textBoxLName.Text = data[1];
                textBoxName.Text = data[2];
                textBoxOtche.Text = data[3];
                textBoxPhone.Text = data[4];
                textBoxMail.Text = data[5];
                textBoxPas.Text = data[6];
            }    
        }

        private void add ()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPhone.Text) && !string.IsNullOrWhiteSpace(textBoxPhone.Text) &&
                    !string.IsNullOrEmpty(textBoxLName.Text) && !string.IsNullOrWhiteSpace(textBoxLName.Text) &&
                    !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                    !string.IsNullOrEmpty(textBoxOtche.Text) && !string.IsNullOrWhiteSpace(textBoxOtche.Text) &&
                    !string.IsNullOrEmpty(textBoxMail.Text) && !string.IsNullOrWhiteSpace(textBoxMail.Text) &&
                    !string.IsNullOrEmpty(textBoxPas.Text) && !string.IsNullOrWhiteSpace(textBoxPas.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Clients ([Фамилия],[Имя],[Отчество],[Телефон],[Почта],[Паспортные данные])" +
                        " VALUES (@LName, @Name, @Otche, @Phone, @Mail, @Pas)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("LName", textBoxLName.Text);
                    sqlCommand.Parameters.AddWithValue("Name", textBoxName.Text);
                    sqlCommand.Parameters.AddWithValue("Otche", textBoxOtche.Text);
                    sqlCommand.Parameters.AddWithValue("Phone", textBoxPhone.Text);
                    sqlCommand.Parameters.AddWithValue("Mail", textBoxMail.Text);
                    sqlCommand.Parameters.AddWithValue("Pas", textBoxPas.Text);

                    sqlCommand.ExecuteNonQuery();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void update()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPhone.Text) && !string.IsNullOrWhiteSpace(textBoxPhone.Text) &&
                    !string.IsNullOrEmpty(textBoxLName.Text) && !string.IsNullOrWhiteSpace(textBoxLName.Text) &&
                    !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                    !string.IsNullOrEmpty(textBoxOtche.Text) && !string.IsNullOrWhiteSpace(textBoxOtche.Text) &&
                    !string.IsNullOrEmpty(textBoxMail.Text) && !string.IsNullOrWhiteSpace(textBoxMail.Text) &&
                    !string.IsNullOrEmpty(textBoxPas.Text) && !string.IsNullOrWhiteSpace(textBoxPas.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Clients SET " +
                        $"[Фамилия] = '{textBoxLName.Text}'," +
                        $"[Имя] = '{textBoxName.Text}'," +
                        $"[Отчество] = '{textBoxOtche.Text}'," +
                        $"[Телефон] = '{textBoxPhone.Text}'," +
                        $"[Почта] = '{textBoxMail.Text}'," +
                        $"[Паспортные данные] = '{textBoxPas.Text}' WHERE id = {data[0]}", sqlConnection);

                    sqlCommand.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Все поля обязательны к заполнению!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
