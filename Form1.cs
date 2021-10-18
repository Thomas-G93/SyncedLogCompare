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

        //TODO - good idea to declare this here???
        private List<LogEntry> _list;

        public Form1()
        {
            InitializeComponent();
        }

        private void onButtonClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("onButtonClick");

            PopulateDataGridView(dataGridViewMessage);
            PopulateDataGridView(dataGridViewTracer);




            AdjustColumnsToDisplay();



            InitializeDataGridView(dataGridViewMessage);
            InitializeDataGridView(dataGridViewTracer);

            

            //TODO - cleanup
            dataGridViewMessage.CellFormatting += new DataGridViewCellFormattingEventHandler(dgv_CellFormatting);


        }

        private void AdjustColumnsToDisplay()
        {

            //Hide columns
            this.dataGridViewMessage.Columns["FileName"].Visible = false;
            this.dataGridViewMessage.Columns["Device"].Visible = false;
            this.dataGridViewMessage.Columns["Component"].Visible = false;

            this.dataGridViewTracer.Columns["FileName"].Visible = false;
            this.dataGridViewTracer.Columns["From"].Visible = false;


            this.dataGridViewMessage.Columns["Severity"].DisplayIndex = 0;
            this.dataGridViewMessage.Columns["DateTime"].DisplayIndex = 1;
            this.dataGridViewMessage.Columns["From"].DisplayIndex = 2;
            this.dataGridViewMessage.Columns["Message"].DisplayIndex = 3;

            


            this.dataGridViewTracer.Columns["Severity"].DisplayIndex = 0;
            this.dataGridViewTracer.Columns["DateTime"].DisplayIndex = 1;
            this.dataGridViewTracer.Columns["Component"].DisplayIndex = 2;
            this.dataGridViewTracer.Columns["Device"].DisplayIndex = 3;
            this.dataGridViewTracer.Columns["Message"].DisplayIndex = 4;

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
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;          //TODO - change? //ori was NONE

            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //if set user Resize does not work anymre

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



        //TODO - works but only if the FileName Column is visible in the window....
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // If the column is the Artist column, check the
            // value.

            /* //DEBUG
            Console.WriteLine("ColumnName: " + this.dataGridViewMessage.Columns[e.ColumnIndex].Name +
                              "\t||\t e.ColumnIndex: " + e.ColumnIndex +
                              "\t||\t e.RowIndex: " + e.RowIndex);
            */

            //var myvalue = dataGridViewMessage.Rows[e.RowIndex].Cells[6].Value.ToString();
            //Console.WriteLine(myvalue);


            //TODO - to not allow clicking in those cells!

            //TODO - works!!!
            //TODO - must be refactored to use the FILETYPE instead of FileName "Tracer.log" and a better why to find the column
            if (dataGridViewMessage.Rows[e.RowIndex].Cells[dataGridViewMessage.Columns["FileName"].Index].Value.ToString().Equals("TBTracer.log"))
            {
                DataGridViewRow row = dataGridViewMessage.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.Black;

                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.ForeColor = Color.White;

            }



            //TODO - works but only if the FileName Column is visible in the window....
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

                        DataGridViewRow row = dataGridViewMessage.Rows[e.RowIndex];// get you required index
                        row.DefaultCellStyle.BackColor = Color.Green; // check the cell value under your specific column and then you can toggle your colors

                    }

                }
            }

        }



        // Creates the columns and loads the data.
        //TODO - Populate should not be done with a "handover parameter" // rename
        //TODO - maybe it should be done with handover paramter? if both sides are exactly the same???
        //TODO - difference is then done through hiding / showing lines
        private void PopulateDataGridView(DataGridView dataGridView)
        {

            // Add the rows to the DataGridView.
            Console.WriteLine(tbPathToLogFolder.Text);

            LogHandler logHandler = new LogHandler(tbPathToLogFolder.Text);

            //var list = logHandler.LoadLogFiles();
            _list = logHandler.LoadLogFiles();

            var bindingList = new BindingList<LogEntry>(_list);
            var source = new BindingSource(bindingList, null);
            dataGridView.DataSource = source;


            // Adjust the row heights so that all content is visible.
            dataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }




        // --------------------------------------------
        //TODO - make SEARCH its own CLASS!!!
        // --------------------------------------------
        //TODO - inital SEARCH tests
        //TODO - maybe a nicer cleaner solution with LINQ // https://stackoverflow.com/questions/10179223/find-a-row-in-datagridview-based-on-column-and-value
        //TODO - adapt Search that on Message side only elements with from message log are highlited / shown 
        //TODO - show how many elements match current "search String" and which counter value the current box has

        private int lastSearchIndex = -1; 
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(@"search string: " + tbSearch.Text);


            //DataGridViewCell cell = GetCellWhereTextExistsInGridView(tbSearch.Text, dataGridViewMessage, 2);
            DataGridViewCell cell = GetCellWhereTextExistsInGridView(tbSearch.Text, dataGridViewMessage, 2, lastSearchIndex);



            if (cell != null)
            {
                var rowIndex = cell.RowIndex;

                lastSearchIndex = cell.RowIndex;

                dataGridViewMessage.ClearSelection();
                dataGridViewMessage.Rows[rowIndex].Selected = true;
                dataGridViewMessage.FirstDisplayedScrollingRowIndex = rowIndex;
                dataGridViewMessage.Focus();
            }



        }

        private DataGridViewCell GetCellWhereTextExistsInGridView(string searchText, DataGridView dataGridView, int columnIndex)
        {
            DataGridViewCell cellWhereTextIsMet = null;

            // For every row in the grid (obviously)
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                
                // I did not test this case, but cell.Value is an object, and objects can be null
                // So check if the cell is null before using .ToString()
                if (row.Cells[columnIndex].Value != null)
                {
                    if (row.Cells[columnIndex].Value.ToString().Contains(searchText))
                    {
                        // the searchText is equals to the text in this cell.
                        cellWhereTextIsMet = row.Cells[columnIndex];
                        break;
                    }
                }
            }

            return cellWhereTextIsMet;
        }

        private DataGridViewCell GetCellWhereTextExistsInGridView(string searchText, DataGridView dataGridView, int columnIndex, int lastSearchIndex)
        {
            DataGridViewCell cellWhereTextIsMet = null;

            if (lastSearchIndex == -1)
            {
                // For every row in the grid (obviously)
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // I did not test this case, but cell.Value is an object, and objects can be null
                    // So check if the cell is null before using .ToString()
                    if (row.Cells[columnIndex].Value != null)
                    {
                        if (row.Cells[columnIndex].Value.ToString().Contains(searchText))
                        {
                            // the searchText is equals to the text in this cell.
                            cellWhereTextIsMet = row.Cells[columnIndex];
                            break;
                        }
                    }
                }


               

            }
            else
            {
                // TODO - Ignore CASE sensitivity 
                // TODO - allow WILDCARD search
                // TODO - restart search from top when bottom is reached

                Console.WriteLine("lastSearchIndex: " + lastSearchIndex);
                lastSearchIndex++;
                for (var index = lastSearchIndex; index < dataGridView.Rows.Count; index++)
                {
                    DataGridViewRow row = dataGridView.Rows[index];

                    if (row.Cells[columnIndex].Value != null)
                    {
                        if (row.Cells[columnIndex].Value.ToString().Contains(searchText))
                        {
                            // the searchText is equals to the text in this cell.
                            cellWhereTextIsMet = row.Cells[columnIndex];
                            break;
                        }
                    }

                }
            }

            return cellWhereTextIsMet;

        }




    }
}
