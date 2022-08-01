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
    public partial class AddSupplies : Form
    {
        public AddSupplies()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-G26Q8FF;Initial Catalog=ProAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection();

        public string typeQuery = "";
        string[] data = new string[4];

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
                if (!string.IsNullOrEmpty(textBoxLName.Text) && !string.IsNullOrWhiteSpace(textBoxLName.Text) &&
                    !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                    !string.IsNullOrEmpty(textBoxOtche.Text) && !string.IsNullOrWhiteSpace(textBoxOtche.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Supplies ([Наименование поставщика],[id_авто],[Ожидаемая дата поставки])" +
                        " VALUES (@LName, @Name, @Otche)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("LName", textBoxLName.Text);
                    sqlCommand.Parameters.AddWithValue("Name", textBoxName.Text);
                    sqlCommand.Parameters.AddWithValue("Otche", textBoxOtche.Text);

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
                if (!string.IsNullOrEmpty(textBoxLName.Text) && !string.IsNullOrWhiteSpace(textBoxLName.Text) &&
                    !string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrWhiteSpace(textBoxName.Text) &&
                    !string.IsNullOrEmpty(textBoxOtche.Text) && !string.IsNullOrWhiteSpace(textBoxOtche.Text))
                {
                    sqlConnection = new SqlConnection(@connectionString);
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Supplies SET " +
                        $"[Наименование поставщика] = '{textBoxLName.Text}'," +
                        $"[id_авто] = '{textBoxName.Text}'," +
                        $"[Ожидаемая дата поставки] = '{textBoxOtche.Text}' WHERE id = {data[0]}", sqlConnection);

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

        private void AddSupplies_Load(object sender, EventArgs e)
        {
            if (typeQuery.Equals("update"))
            {
                this.Text = "Редактирование поставки";
                textBoxLName.Text = data[1];
                textBoxName.Text = data[2];
                textBoxOtche.Text = data[3];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
