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
    public partial class AddCar : Form
    {
        string connectionString = @"Data Source=DESKTOP-G26Q8FF;Initial Catalog=ProAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection();

        public string typeQuery = "";

        string[] data = new string[9];
        public AddCar()
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
        private void AddCar_Load(object sender, EventArgs e)
        {
            if (typeQuery.Equals("update"))
            {
                this.Text = "Редактирование авто";
                textBoxMark.Text = data[1];
                textBoxModel.Text = data[2];
                textBoxYear.Text = data[3];
                textBoxColor.Text = data[4];
                textBoxType.Text = data[5];
                textBoxComp.Text = data[6];
                textBoxPrice.Text = data[7];
                textBoxNahod.Text = data[8];
            }
        }

        private void add()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxColor.Text) && !string.IsNullOrWhiteSpace(textBoxColor.Text) &&
                    !string.IsNullOrEmpty(textBoxMark.Text) && !string.IsNullOrWhiteSpace(textBoxMark.Text) &&
                    !string.IsNullOrEmpty(textBoxModel.Text) && !string.IsNullOrWhiteSpace(textBoxModel.Text) &&
                    !string.IsNullOrEmpty(textBoxYear.Text) && !string.IsNullOrWhiteSpace(textBoxYear.Text) &&
                    !string.IsNullOrEmpty(textBoxType.Text) && !string.IsNullOrWhiteSpace(textBoxType.Text) &&
                    !string.IsNullOrEmpty(textBoxPrice.Text) && !string.IsNullOrWhiteSpace(textBoxPrice.Text) &&
                    !string.IsNullOrEmpty(textBoxNahod.Text) && !string.IsNullOrWhiteSpace(textBoxNahod.Text) &&
                    !string.IsNullOrEmpty(textBoxComp.Text) && !string.IsNullOrWhiteSpace(textBoxComp.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Cars ([Марка],[Модель],[Год выпуска],[Цвет],[Тип коробки],[Комплектация], [Цена], [Наличие])" +
                        " VALUES (@LName, @Name, @Otche, @Phone, @Mail, @Pas, @Price, @Nahod)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("LName", textBoxMark.Text);
                    sqlCommand.Parameters.AddWithValue("Name", textBoxModel.Text);
                    sqlCommand.Parameters.AddWithValue("Otche", textBoxYear.Text);
                    sqlCommand.Parameters.AddWithValue("Phone", textBoxColor.Text);
                    sqlCommand.Parameters.AddWithValue("Mail", textBoxType.Text);
                    sqlCommand.Parameters.AddWithValue("Pas", textBoxComp.Text);
                    sqlCommand.Parameters.AddWithValue("Price", textBoxPrice.Text);
                    sqlCommand.Parameters.AddWithValue("Nahod", textBoxNahod.Text);

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
                if (!string.IsNullOrEmpty(textBoxColor.Text) && !string.IsNullOrWhiteSpace(textBoxColor.Text) &&
                    !string.IsNullOrEmpty(textBoxMark.Text) && !string.IsNullOrWhiteSpace(textBoxMark.Text) &&
                    !string.IsNullOrEmpty(textBoxModel.Text) && !string.IsNullOrWhiteSpace(textBoxModel.Text) &&
                    !string.IsNullOrEmpty(textBoxYear.Text) && !string.IsNullOrWhiteSpace(textBoxYear.Text) &&
                    !string.IsNullOrEmpty(textBoxType.Text) && !string.IsNullOrWhiteSpace(textBoxType.Text) &&
                    !string.IsNullOrEmpty(textBoxPrice.Text) && !string.IsNullOrWhiteSpace(textBoxPrice.Text) &&
                    !string.IsNullOrEmpty(textBoxNahod.Text) && !string.IsNullOrWhiteSpace(textBoxNahod.Text) &&
                    !string.IsNullOrEmpty(textBoxComp.Text) && !string.IsNullOrWhiteSpace(textBoxComp.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Cars SET " +
                        $"[Марка] = '{textBoxMark.Text}'," +
                        $"[Модель] = '{textBoxModel.Text}'," +
                        $"[Год выпуска] = '{textBoxYear.Text}'," +
                        $"[Цвет] = '{textBoxColor.Text}'," +
                        $"[Тип коробки] = '{textBoxType.Text}'," +
                        $"[Комплектация] = '{textBoxComp.Text}'," +
                        $"[Цена] = '{textBoxPrice.Text}'," +
                        $"[Наличие] = '{textBoxNahod.Text}' WHERE id = {data[0]}", sqlConnection);

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
