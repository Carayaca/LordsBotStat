using System;
using System.Windows.Forms;

namespace LordsBotStatView
{
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Reflection;

    using LordsBotStat.Core;
    using LordsBotStat.Core.Dto;

    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    //inserting property values to DataTable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check DataTable
            return dataTable;
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Data format of the file(s) can be accepted
            // (we only accept file drops from Windows Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // modify the drag drop effects to Move
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                // no need for any drag drop effect
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // still check if the associated data from the file(s) can be used for this purpose
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Fetch the file(s) names with full path here to be processed
                var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

                // Your desired code goes here to process the file(s) being dropped
                var report = JsonLoader.LoadJson(files);
                if (report != null)
                {
                    this.Bind(report);
                }
            }
        }

        private void Bind(Report report)
        {
            this.bindingSource1.DataSource = ToDataTable(report.Items);
            this.dataGridView1.DataSource = this.bindingSource1;

            this.DoColors();

            for (int i = 1; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                int colw = dataGridView1.Columns[i].Width;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[i].Width = colw;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dataGridView1.Refresh();
        }

        private void DoColors()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                var o = row.Cells["colStatus"].Value;
                row.Cells["colStatus"].Style.ForeColor = o.Equals("GOOD") ? Color.Green : Color.Red;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.DoColors();
        }
    }
}
