using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProAuto
{
    public partial class MainForm : Form
    {

        BindingSource bind = new BindingSource();
        DataSet dataSet = new DataSet();
        SqlDataAdapter sqlData = new SqlDataAdapter();
        
        string connectionString = @"Data Source=DESKTOP-G26Q8FF;Initial Catalog=ProAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string query = "";
        public string typeQuery = ""; // инкапсулировать потом на основной форме
        string action = "";
        bool f = true;

        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            action = "Clients";
            toolStripButton6.Visible = false;
            query = "SELECT * FROM Clients";
            connect();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                action = "Clients";
                bind.RemoveFilter();
                toolStripButton6.Visible = false;
                toolStripButton5.Enabled = true;
                query = "SELECT * FROM Clients";
                connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void connect ()
        {
            SqlConnection sqlConnection = new SqlConnection(@connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = query;
            sqlData = new SqlDataAdapter(sqlCommand);
            dataSet.Tables.Clear();
            sqlData.Fill(dataSet);
            bind.DataSource = dataSet.Tables[0];
            dataGridView1.DataSource = bind;
            sqlConnection.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                bind.RemoveFilter();
                action = "Orders";
                toolStripButton6.Visible = false;
                toolStripButton5.Enabled = false;
                query = "SELECT Orders.id, Clients.Фамилия AS Клиент, " +
                    "Managers.Фамилия AS Менеджер, Cars.Марка, " +
                    "Cars.Модель, Cars.[Год выпуска], Orders.Цена, Orders.[Статус заказа], " +
                    "Supplies.[Наименование поставщика] AS Поставщик " +
                    "FROM Orders JOIN Clients ON Orders.[id_клиента] = Clients.id JOIN Managers ON " +
                    "Orders.[id_менеджера] = Managers.id JOIN Cars ON Orders.[id_авто] = Cars.id " +
                    "JOIN Supplies ON Orders.[id_поставки] = Supplies.id";
                connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                bind.RemoveFilter();
                action = "Supplies";
                toolStripButton5.Enabled = false;
                toolStripButton6.Visible = false;
                query = "SELECT Supplies.[Наименование поставщика], Cars.Марка, Cars.Модель, Cars.[Год выпуска], " +
                    "Supplies.[Ожидаемая дата поставки] FROM Supplies JOIN Cars ON Supplies.id_авто = Cars.id";
                connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            try
            {
                bind.RemoveFilter();
                action = "Managers";
                toolStripButton6.Visible = false;
                toolStripButton5.Enabled = true;
                query = "SELECT * FROM Managers";
                connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                bind.RemoveFilter();
                action = "Cars";
                toolStripButton6.Visible = true;
                toolStripButton5.Enabled = true;
                query = "SELECT * FROM Cars";
                connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            /*switch (action)
            {
                case "Supplies":
                    if (!string.IsNullOrEmpty(toolStripTextBox1.Text) && !string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                        bind.Filter = $"[имя] LIKE '{toolStripTextBox1.Text}%' OR [фамилия] LIKE '{toolStripTextBox1.Text}%' OR [отчество] LIKE '{toolStripTextBox1.Text}%'";
                    else
                        bind.RemoveFilter();
                    break;
                case "Clients":
                    if (!string.IsNullOrEmpty(toolStripTextBox1.Text) && !string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                        bind.Filter = $"[имя] LIKE '{toolStripTextBox1.Text}%' OR [фамилия] LIKE '{toolStripTextBox1.Text}%' OR [отчество] LIKE '{toolStripTextBox1.Text}%'";
                    else
                        bind.RemoveFilter();
                    break;
                case "Orders":
                    if (!string.IsNullOrEmpty(toolStripTextBox1.Text) && !string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                        bind.Filter = $"[имя] LIKE '{toolStripTextBox1.Text}%' OR [фамилия] LIKE '{toolStripTextBox1.Text}%' OR [отчество] LIKE '{toolStripTextBox1.Text}%'";
                    else
                        bind.RemoveFilter();
                    break;
                case "Managers":
                    if (!string.IsNullOrEmpty(toolStripTextBox1.Text) && !string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                        bind.Filter = $"[имя] LIKE '{toolStripTextBox1.Text}%' OR [фамилия] LIKE '{toolStripTextBox1.Text}%' OR [отчество] LIKE '{toolStripTextBox1.Text}%'";
                    else
                        bind.RemoveFilter();
                    break;
                case "Cars":
                    if (!string.IsNullOrEmpty(toolStripTextBox1.Text) && !string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                        bind.Filter = $"[имя] LIKE '{toolStripTextBox1.Text}%' OR [фамилия] LIKE '{toolStripTextBox1.Text}%' OR [отчество] LIKE '{toolStripTextBox1.Text}%'";
                    else
                        bind.RemoveFilter();
                    break;
            }*/
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case "Supplies":
                    AddSupplies addSupplies = new AddSupplies();
                    addSupplies.typeQuery = "add";
                    addSupplies.Show();
                    break;
                case "Clients":
                    AddClient addClient = new AddClient();
                    addClient.typeQuery = "add";
                    addClient.Show();
                    break;
                case "Orders":
                    AddOrder addOrder = new AddOrder();
                    addOrder.typeQuery = "add";
                    addOrder.Show();    
                    break;
                case "Managers":
                    AddManager addManager = new AddManager();
                    addManager.typeQuery = "add";
                    addManager.Show();
                    break;
                case "Cars":
                    AddCar addCar = new AddCar();
                    addCar.typeQuery = "add";
                    addCar.Show();
                    break;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection = new SqlConnection(@connectionString);
                sqlConnection.Open();
                string queryDelete = "";
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    switch (action)
                    {
                        case "Supplies":
                            queryDelete = $"DELETE FROM Supplies WHERE id = {dataGridView1.Rows[selectedrowindex].Cells[0].Value}";
                            break;
                        case "Clients":
                            queryDelete = $"DELETE FROM Clients WHERE id = {dataGridView1.Rows[selectedrowindex].Cells[0].Value}";
                            break;
                        case "Orders":
                            queryDelete = $"DELETE FROM Orders WHERE id = {dataGridView1.Rows[selectedrowindex].Cells[0].Value}";
                            break;
                        case "Managers":
                            queryDelete = $"DELETE FROM Managers WHERE id = {dataGridView1.Rows[selectedrowindex].Cells[0].Value}";
                            break;
                        case "Cars":
                            queryDelete = $"DELETE FROM Cars WHERE id = {dataGridView1.Rows[selectedrowindex].Cells[0].Value}";
                            break;
                    }
                    SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
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

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            connect();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                switch (action)
                {
                    case "Supplies":
                        AddSupplies addSupplies = new AddSupplies();
                        addSupplies.typeQuery = "update";
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            addSupplies.Data[i] = dataGridView1.Rows[selectedrowindex].Cells[i].Value.ToString();
                        addSupplies.Show();
                        break;
                    case "Clients":
                        AddClient addClient = new AddClient();
                        addClient.typeQuery = "update";
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            addClient.Data[i] = dataGridView1.Rows[selectedrowindex].Cells[i].Value.ToString();
                        addClient.Show();
                        break;
                    case "Orders":
                        AddOrder addOrder = new AddOrder();
                        addOrder.typeQuery = "update";
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            addOrder.Data[i] = dataGridView1.Rows[selectedrowindex].Cells[i].Value.ToString();
                        addOrder.Show();
                        break;
                    case "Managers":
                        AddManager addManager = new AddManager();
                        addManager.typeQuery = "update";
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            addManager.Data[i] = dataGridView1.Rows[selectedrowindex].Cells[i].Value.ToString();
                        addManager.Show();
                        break;
                    case "Cars":
                        AddCar addCar = new AddCar();
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            addCar.Data[i] = dataGridView1.Rows[selectedrowindex].Cells[i].Value.ToString();
                        addCar.typeQuery = "update";
                        addCar.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Клиент не выбран!");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (f)
            {
                bind.Filter = "[Наличие] LIKE 'есть'";
                f = false;
            }
            else
            {
                bind.RemoveFilter();
                f = true;
            }
        }
    }
}
