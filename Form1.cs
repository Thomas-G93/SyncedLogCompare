using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyncedLogCompare.log;

namespace SyncedLogCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void onButtonClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("onButtonClick");

            PopulateDataGridView(dataGridViewMessage);
            PopulateDataGridView(dataGridViewTracer);


            //Hide columns
         //   this.dataGridViewMessage.Columns["FileName"].Visible = false;
         //   this.dataGridViewMessage.Columns["Device"].Visible = false;
         //   this.dataGridViewMessage.Columns["Component"].Visible = false;

         //   this.dataGridViewTracer.Columns["FileName"].Visible = false;
         //   this.dataGridViewTracer.Columns["From"].Visible = false;





            InitializeDataGridView(dataGridViewMessage);
            InitializeDataGridView(dataGridViewTracer);


            //TODO - not working.... 
            dataGridViewMessage.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitializeTableLayoutPanel();

            // Binding Scrollbar
            this.dataGridViewMessage.Scroll += new ScrollEventHandler(dataGridViewMessage_Scroll);
            this.dataGridViewTracer.Scroll += new ScrollEventHandler(dataGridViewTracer_Scroll);

        }

        // Binding Scrollbar
        void dataGridViewTracer_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridViewMessage.FirstDisplayedScrollingRowIndex = this.dataGridViewTracer.FirstDisplayedScrollingRowIndex;
        }
        void dataGridViewMessage_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridViewTracer.FirstDisplayedScrollingRowIndex = this.dataGridViewMessage.FirstDisplayedScrollingRowIndex;
        }


        private void InitializeTableLayoutPanel()
        {
            this.tableLayoutPanel1.Dock = DockStyle.Fill;

            //TODO - Initialize more?

        }

        // Configures the appearance and behavior of a DataGridView control.
        private void InitializeDataGridView(DataGridView dataGridView)
        {

            // Initialize basic DataGridView properties.
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.BorderStyle = BorderStyle.None;

            // Set property values appropriate for read-only display and limited interactivity. 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = true;                                            //TODO - change?
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;          //TODO - change?
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Set the selection background color for all the cells.
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;        //TODO - change?
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dataGridView.RowHeadersVisible = false; //TODO - make it visible and smaller? Any purpose?

            // Set the background color for all rows and for alternating rows. The value for alternating rows overrides the value for all rows. 
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            //dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; //TODO - maybe enable if it is easier to read

            // Set the row and column header styles.
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Black;


            // Specify a larger font for the "Severity" column. 
            using (Font font = new Font(dataGridView.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold))
            {
                dataGridView.Columns["Severity"].DefaultCellStyle.Font = font;
            }

            // Attach a handler to the CellFormatting event.
            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);


            

        }


        //TODO - works but only if the FileName Column is visible in the window....
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // If the column is the Artist column, check the
            // value.

            Console.WriteLine("TEST: " + this.dataGridViewMessage.Columns[e.ColumnIndex].Name);


            if (this.dataGridViewMessage.Columns[e.ColumnIndex].Name == "FileName")
            {
     
                if (e.Value != null)
                {
                    string stringValue = (string)e.Value;
                    
                    Console.WriteLine(stringValue);

                    stringValue = stringValue.ToLower();

                    if (stringValue.Equals("tbtracer.log"))
                    {
                        e.CellStyle.SelectionBackColor = Color.Green;
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.SelectionForeColor = Color.DarkGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                    }

                }
            }
        }



        // Changes the foreground color of cells in the "Ratings" column 
        // depending on the number of stars. 
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTracer.Columns["Severity"].Index && e.Value != null)
            {

                switch (e.Value.ToString())
                {
                    case "(A)":
                        e.CellStyle.SelectionBackColor = Color.DarkRed;
                        e.CellStyle.BackColor = Color.DarkRed;
                        e.CellStyle.SelectionForeColor = Color.OrangeRed;
                        e.CellStyle.ForeColor = Color.OrangeRed;
                        break;
                    case "(E)":
                        e.CellStyle.SelectionBackColor = Color.Red;
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "(W)":
                        e.CellStyle.SelectionBackColor = Color.Yellow;
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "(I)":
                        e.CellStyle.SelectionBackColor = Color.White;
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.SelectionForeColor = Color.Black;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }



        // Creates the columns and loads the data.
        //TODO - Populate should not be done with a "handover parameter" // rename
        private void PopulateDataGridView(DataGridView dataGridView)
        {

            // Add the rows to the DataGridView.
            Console.WriteLine(tbPathToLogFolder.Text);

            LogHandler logHandler = new LogHandler(tbPathToLogFolder.Text);


            var list = logHandler.LoadLogFiles();




            var bindingList = new BindingList<LogEntry>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView.DataSource = source;


            // Adjust the row heights so that all content is visible.
            dataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
