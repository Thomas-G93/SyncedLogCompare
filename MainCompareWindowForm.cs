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
    public partial class MainCompareWindowForm : Form
    {


        public MainCompareWindowForm()
        {
            InitializeComponent();
        }

        private void onButtonClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("onButtonClick");

            PopulateDataGridView(dataGridViewMessage);
            PopulateDataGridView(dataGridViewTracer);


            HideNotNeededColumnsToDisplay();

            InitializeDataGridView(dataGridViewMessage);
            InitializeDataGridView(dataGridViewTracer);

            


            dataGridViewMessage.CellFormatting += new DataGridViewCellFormattingEventHandler((s, eArgs) => dgvHideFileType_CellFormatting(s, eArgs, dataGridViewMessage, FileType.TBTracer));
            //TODO - if to decide which filetype gets hidden -> Messages or MessagesBase
            dataGridViewTracer.CellFormatting += new DataGridViewCellFormattingEventHandler((s, eArgs) => dgvHideFileType_CellFormatting(s, eArgs, dataGridViewTracer, FileType.Messages));


        }

        private void HideNotNeededColumnsToDisplay()
        {

            //Hide columns
            this.dataGridViewMessage.Columns["FileName"].Visible = false;
            this.dataGridViewMessage.Columns["Device"].Visible = false;
            this.dataGridViewMessage.Columns["Component"].Visible = false;
            this.dataGridViewMessage.Columns["FileType"].Visible = false;

            this.dataGridViewTracer.Columns["FileName"].Visible = false;
            this.dataGridViewTracer.Columns["From"].Visible = false;
            this.dataGridViewTracer.Columns["FileType"].Visible = false;


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


        private void MainCompareWindowForm_Load(object sender, EventArgs e)
        {

            InitializeTableLayoutPanel();

            // Binding Scrollbar
            this.dataGridViewMessage.Scroll += new ScrollEventHandler(dataGridViewMessage_Scroll);
            this.dataGridViewTracer.Scroll += new ScrollEventHandler(dataGridViewTracer_Scroll);

        }

        /// <summary>
        /// bind scrollbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGridViewTracer_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridViewMessage.FirstDisplayedScrollingRowIndex = this.dataGridViewTracer.FirstDisplayedScrollingRowIndex;
        }

        /// <summary>
        /// bind scrollbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


            // Set Sizing for Rows and Columns
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.Columns["Severity"].HeaderText = string.Empty;
            dataGridView.AutoResizeColumn(dataGridView.Columns["Severity"].Index);
            dataGridView.AutoResizeColumn(dataGridView.Columns["Message"].Index);
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;


            // Set the selection background color for all the cells.
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightGray;        //TODO - change?
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dataGridView.RowHeadersVisible = false;

            // Set the background color for all rows and for alternating rows. The value for alternating rows overrides the value for all rows. 
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            //dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; //TODO - maybe enable if it is easier to read

            // Set the row and column header styles.
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Black;


            #region optional larger font for severity

            /*
            // Specify a larger font for the "Severity" column. 
            using (Font font = new Font(dataGridView.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold))
            {
                dataGridView.Columns["Severity"].DefaultCellStyle.Font = font;
            }
            */

            #endregion



            //TODO - move CellFormatting handler out of Initialization ??
            // Attach a handler to the CellFormatting event.
            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvColorSeverity_CellFormatting);

        }



        /// <summary>
        /// change cell foreground from "Severity" column, based on cell value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvColorSeverity_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        /// <summary>
        /// hide row of DataGridView by changing all colors to white, based on FileType
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="dataGridView"></param>
        /// <param name="fileType"></param>
        private void dgvHideFileType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e, DataGridView dataGridView, FileType fileType)
        {
            #region DEBUG_SECTION
            /* //DEBUG
            Console.WriteLine("ColumnName: " + this.dataGridViewMessage.Columns[e.ColumnIndex].Name +
                              "\t||\t e.ColumnIndex: " + e.ColumnIndex +
                              "\t||\t e.RowIndex: " + e.RowIndex);
            */
            #endregion

            //TODO - possible to disable selection here?
            if (dataGridView.Rows[e.RowIndex].Cells[dataGridView.Columns["FileType"].Index].Value.ToString().Equals(fileType.ToString()))
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.Black;

                e.CellStyle.SelectionBackColor = Color.White;
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.ForeColor = Color.White;
            }

        }


        // TODO - access "tbPathToLogFolder" in another way and move this out???
        /// <summary>
        /// populate DataGridView with LogEntries, based on path from TextBox
        /// </summary>
        /// <param name="dataGridView"></param>
        private void PopulateDataGridView(DataGridView dataGridView)
        {
            Console.WriteLine(@"tbPathToLogFolder: " + tbPathToLogFolder.Text);

            LogHandler logHandler = new LogHandler(tbPathToLogFolder.Text);
            var list = logHandler.LoadLogFiles();

            var bindingList = new BindingList<LogEntry>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView.DataSource = source;

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

            //TODO - should search in all columns not ONLY in MESSAGE
            DataGridViewCell cell = GetCellWhereTextExistsInGridView(tbSearch.Text, dataGridViewMessage, dataGridViewMessage.Columns["Message"].Index, lastSearchIndex);



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
                        Console.WriteLine(row.Cells[columnIndex].Value.ToString());
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
                // TODO - allow WILDCARD search -> REGEX
                // TODO - restart search from top when bottom is reached
                // TODO - what if no element matches 

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
