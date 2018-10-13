using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TelerikWinFormsAppGrid
{
    public partial class RadFormGridView : Telerik.WinControls.UI.RadForm
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["NwindConnectionString"].ConnectionString;
        private string tableName = "Customers";

        private OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        private DataTable dataTable = new DataTable();
        private BindingSource bindingSource = new BindingSource();


        public RadFormGridView()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = dataTable;

            this.dataGridView1.DataSource = bindingSource;
            this.dataGridView1.AutoResizeColumns();

            GetData();
        }

        private void GetData()
        {
            var queryString = $"SELECT * from {tableName}";

            var connection = new OleDbConnection(connectionString);

            dataAdapter = new OleDbDataAdapter(queryString, connectionString);

            var commandBuilder = new OleDbCommandBuilder(dataAdapter);

            dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataAdapter.Update((DataTable)bindingSource.DataSource);

            //var builder = new OleDbCommandBuilder(adapter);
            //var updateCommand = builder.GetUpdateCommand();

            //adapter.Update(dataTable);
        }
    }
}
