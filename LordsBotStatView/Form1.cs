using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using LordsBotStat.Core;
using LordsBotStat.Core.Dto;

using NLog;

namespace LordsBotStatView
{
    public partial class Form1 : Form
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private Report report;

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
            this.LoadMembersList();
        }

        private static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                //Defining type of data column gives proper data table 
                var type = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                               ? Nullable.GetUnderlyingType(prop.PropertyType)
                               : prop.PropertyType;
                //Setting column names as Property names
                // ReSharper disable once AssignNullToNotNullAttribute
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

        private void DataGridView1_DragEnter(object sender, DragEventArgs e)
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

        private void DataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // still check if the associated data from the file(s) can be used for this purpose
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Fetch the file(s) names with full path here to be processed
                var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

                // Your desired code goes here to process the file(s) being dropped
                var r = JsonLoader.LoadJson(files);
                if (r.Items.Any())
                {
                    this.Bind(r);
                }
            }
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.DoColors();
        }

        private void Bind(Report r)
        {
            try
            {
                this.report = r;
                this.LoadMembersList();

                this.SuspendLayout();

                this.dataGridView1.DataSource = null;
                this.txtPlayerName.Text = string.Empty;

                this.bindingSource1.DataSource = ToDataTable(this.report.Items);
                this.bindingSource1.Filter = null;
            
                this.dataGridView1.DataSource = this.bindingSource1;
                this.dataGridView1.Sort(this.colDebt, ListSortDirection.Descending);

                this.panel1.Visible = false;
                this.panel2.Visible = true;

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

                this.dataGridView1.Update();
            }
            finally
            {
                this.ResumeLayout();
                this.txtPlayerName.Focus();
            }
        }

        private void DoColors()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                var o = row.Cells[nameof(this.colStatus)].Value;
                row.Cells[nameof(this.colStatus)].Style.ForeColor = o.Equals("GOOD") ? Color.Green : Color.Red;

                row.Cells[nameof(this.colRequired)].Value = this.report.TotalScore;
                row.Cells[nameof(this.colRequired)].Style.ForeColor = Color.DarkOrange;
            }
        }

        private void LoadMembersList()
        {
            var applicationDirectory = new DirectoryInfo(Application.ExecutablePath).Parent;
            var membersExcelFile = Directory.EnumerateFiles(applicationDirectory?.FullName ?? ".", "*.xlsx")
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(membersExcelFile))
            {
                this.report?.Imbue(membersExcelFile);
            }
        }

        private void TxtPlayerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                var txt = (TextBox)sender;
                this.bindingSource1.Filter = string.IsNullOrEmpty(txt.Text) ? null : $@"[{nameof(RenderItem.PlayerName)}] LIKE '%{txt.Text}%'";

                this.dataGridView1.Update();
            }
            finally
            {
                this.ResumeLayout();
            }
        }
    }
}
