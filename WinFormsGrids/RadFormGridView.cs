using System;
using System.Data;

namespace TelerikWinFormsAppGrid
{
    public partial class RadFormGridView : RadFormBase
    {
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
