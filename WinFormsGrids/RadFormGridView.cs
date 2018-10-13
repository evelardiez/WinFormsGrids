using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TelerikWinFormsAppGrid
{
    public partial class RadFormGridView : Telerik.WinControls.UI.RadForm
    {
        public RadFormGridView()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
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

            this.dataGridView1.DataSource = bindingSource;

            using (new OleDbCommandBuilder(adapter))
            {
                adapter.Fill(dtAccess);
            }

            this.dataGridView1.AutoResizeColumns();
        }
    }
}
