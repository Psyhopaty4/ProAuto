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
    public partial class AddManager : Form
    {
        public AddManager()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-G26Q8FF;Initial Catalog=ProAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection();

        public string typeQuery = "";
        string[] data = new string[5];

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
        private void add()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPhone.Text) && !string.IsNullOrWhiteSpace(textBoxPhone.Text) &&
                    !string.IsNullOrEmpty(textBoxLName.Text) && !string.IsNullOrWhiteSpace(textBoxLName.Text) &&
                    !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                    !string.IsNullOrEmpty(textBoxOtche.Text) && !string.IsNullOrWhiteSpace(textBoxOtche.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Managers ([Фамилия],[Имя],[Отчество],[Телефон])" +
                        " VALUES (@LName, @Name, @Otche, @Phone)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("LName", textBoxLName.Text);
                    sqlCommand.Parameters.AddWithValue("Name", textBoxName.Text);
                    sqlCommand.Parameters.AddWithValue("Otche", textBoxOtche.Text);
                    sqlCommand.Parameters.AddWithValue("Phone", textBoxPhone.Text);

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
                    !string.IsNullOrEmpty(textBoxOtche.Text) && !string.IsNullOrWhiteSpace(textBoxOtche.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Managers SET " +
                        $"[Фамилия] = '{textBoxLName.Text}'," +
                        $"[Имя] = '{textBoxName.Text}'," +
                        $"[Отчество] = '{textBoxOtche.Text}'," +
                        $"[Телефон] = '{textBoxPhone.Text}' WHERE id = {data[0]}", sqlConnection);

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
        private void button1_Click(object sender, EventArgs e)
        {
            if (typeQuery.Equals("add"))
                add();
            else if (typeQuery.Equals("update"))
                update();
        }

        private void AddManager_Load(object sender, EventArgs e)
        {
            if (typeQuery.Equals("update"))
            {
                this.Text = "Редактирование менеджера";
                textBoxLName.Text = data[1];
                textBoxName.Text = data[2];
                textBoxOtche.Text = data[3];
                textBoxPhone.Text = data[4];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
