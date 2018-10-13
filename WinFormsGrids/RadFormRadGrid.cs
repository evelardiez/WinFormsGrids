using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TelerikWinFormsAppGrid
{
    public partial class RadFormRadGrid : Telerik.WinControls.UI.RadForm
    {
        public RadFormRadGrid()
        {
            InitializeComponent();
        }

        private void RadForm2_Load(object sender, EventArgs e)
        {
            var connectionString =
                System.Configuration.ConfigurationManager.
                ConnectionStrings["NwindConnectionString"].ConnectionString;

            var connection = new OleDbConnection(connectionString);

            connection.Open();

            string queryString = "SELECT * from Employees";

            var adapter = new OleDbDataAdapter(queryString, connection);

            var dtAccess = new DataTable();
            var bindingSource = new BindingSource();
            bindingSource.DataMember = "Employees";
            bindingSource.DataSource = dtAccess;

            this.radGridView1.DataSource = bindingSource;

            using (new OleDbCommandBuilder(adapter))
            {
                adapter.Fill(dtAccess);
            }

            radGridView1.BestFitColumns();
        }
    }
}
