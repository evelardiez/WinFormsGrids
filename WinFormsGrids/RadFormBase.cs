using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TelerikWinFormsAppGrid
{
    public class RadFormBase : Telerik.WinControls.UI.RadForm
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["NwindConnectionString"].ConnectionString;
        protected string tableName = "Customers";

        protected OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        protected DataTable dataTable = new DataTable();
        protected BindingSource bindingSource = new BindingSource();

        protected void GetData()
        {
            var queryString = $"SELECT * from {tableName}";

            var connection = new OleDbConnection(connectionString);

            dataAdapter = new OleDbDataAdapter(queryString, connectionString);

            var commandBuilder = new OleDbCommandBuilder(dataAdapter);

            dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;
        }
    }
}
