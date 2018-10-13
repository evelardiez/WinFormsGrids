using System;
using System.Data;

namespace TelerikWinFormsAppGrid
{
    public partial class RadFormRadGrid : RadFormBase
    {
        public RadFormRadGrid()
        {
            InitializeComponent();
        }

        private void RadForm2_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = dataTable;

            this.radGridView1.DataSource = bindingSource;
            radGridView1.BestFitColumns();

            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource.DataSource);
        }
    }
}
