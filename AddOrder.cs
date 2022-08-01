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
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=DESKTOP-G26Q8FF;Initial Catalog=ProAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection();

        public string typeQuery = "";

        string[] data = new string[9];

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
        private void AddOrder_Load(object sender, EventArgs e)
        {
            if (typeQuery.Equals("update"))
            {
                this.Text = "Редактирование заказа";
                textBoxMark.Text = data[1];
                textBoxModel.Text = data[2];
                textBoxYear.Text = data[3];
                textBoxColor.Text = data[8];
                textBoxType.Text = data[7];
                textBoxComp.Text = data[6];
            }
        }

        private void add()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxMark.Text) && !string.IsNullOrWhiteSpace(textBoxMark.Text) &&
                    !string.IsNullOrEmpty(textBoxModel.Text) && !string.IsNullOrWhiteSpace(textBoxModel.Text) &&
                    !string.IsNullOrEmpty(textBoxYear.Text) && !string.IsNullOrWhiteSpace(textBoxYear.Text) &&
                    !string.IsNullOrEmpty(textBoxType.Text) && !string.IsNullOrWhiteSpace(textBoxType.Text) &&
                    !string.IsNullOrEmpty(textBoxComp.Text) && !string.IsNullOrWhiteSpace(textBoxComp.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Orders ([id_клиента],[id_менеджера],[id_авто],[id_поставки],[Статус заказа],[Цена])" +
                        " VALUES (@LName, @Name, @Otche, @Phone, @Mail, @Pas)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("LName", textBoxMark.Text);
                    sqlCommand.Parameters.AddWithValue("Name", textBoxModel.Text);
                    sqlCommand.Parameters.AddWithValue("Otche", textBoxYear.Text);
                    sqlCommand.Parameters.AddWithValue("Phone", textBoxColor.Text);
                    sqlCommand.Parameters.AddWithValue("Mail", textBoxType.Text);
                    sqlCommand.Parameters.AddWithValue("Pas", textBoxComp.Text);

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
                if (!string.IsNullOrEmpty(textBoxMark.Text) && !string.IsNullOrWhiteSpace(textBoxMark.Text) &&
                    !string.IsNullOrEmpty(textBoxModel.Text) && !string.IsNullOrWhiteSpace(textBoxModel.Text) &&
                    !string.IsNullOrEmpty(textBoxYear.Text) && !string.IsNullOrWhiteSpace(textBoxYear.Text) &&
                    !string.IsNullOrEmpty(textBoxType.Text) && !string.IsNullOrWhiteSpace(textBoxType.Text) &&
                    !string.IsNullOrEmpty(textBoxComp.Text) && !string.IsNullOrWhiteSpace(textBoxComp.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Orders SET " +
                        $"[id_клиента] = '{textBoxMark.Text}'," +
                        $"[id_менеджера] = '{textBoxModel.Text}'," +
                        $"[id_авто] = '{textBoxYear.Text}'," +
                        $"[id_поставки] = '{textBoxColor.Text}'," +
                        $"[Статус заказа] = '{textBoxType.Text}'," +
                        $"[Цена] = '{textBoxComp.Text}' WHERE id = {data[0]}", sqlConnection);

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
