using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using SyncedLogCompare.log;

namespace SyncedLogCompare
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public MainWindow(string pathToLogFolder)
        {
            InitializeComponent();

            tbPathToLogFolder.Text = pathToLogFolder;

            
        }


        private BindingList<LogEntry> _entries = new BindingList<LogEntry>();


        // populate DataGridView with LogEntries, based on path from TextBox
        private void PopulateDataGridView(DataGridView dataGridView)
        {
            // Console.WriteLine(@"tbPathToLogFolder: " + tbPathToLogFolder.Text);


            LogHandler logHandler = new LogHandler(tbPathToLogFolder.Text);
            var list = logHandler.LoadLogFiles();

            //var bindingList = new BindingList<LogEntry>(list);
            _entries= new BindingList<LogEntry>(list);

            dataGridView.RowCount = _entries.Count;

            dataGridView.DataSource = _entries;

            //dataGridView.RowCount = 1000;


            Console.WriteLine(_entries.Count);

            //var source = new BindingSource(bindingList, null);
            //dataGridView.DataSource = source;


            // https://sourceforge.net/projects/blw/
            //BindingListView<LogEntry> view = new BindingListView<LogEntry>(list); // ############################## check if really the way to go !!!!!!!!! 
            //dataGridView.DataSource = view;

            //Console.WriteLine(view.Count);

        }


        // needed for BindingListView ?????
        //private List<LogEntry> list;
        //private BindingListView<LogEntry> view;


        private void dataGridViewMsg_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex == dataGridViewMsg.RowCount - 1) return;

            LogEntry tmpLogEntry = null;

            tmpLogEntry = (LogEntry) this._entries[e.RowIndex];



            //Console.WriteLine("e.RowIndex: " + e.RowIndex + " dataGridViewMsg.RowCount: " + dataGridViewMsg.RowCount);

            switch (this.dataGridViewMsg.Columns[e.ColumnIndex].Name)
            {
                case "Severity":
                    e.Value = tmpLogEntry.Severity;
                    break;

                case "DateTime":
                    e.Value = tmpLogEntry.DateTime;
                    break;

                case "From":
                    e.Value = tmpLogEntry.From;
                    break;

                case "Message":
                    e.Value = tmpLogEntry.Message;
                    break;

                case "Component":
                    e.Value = tmpLogEntry.Component;
                    break;

                case "Device":
                    e.Value = tmpLogEntry.Device;
                    break;

                case "FileName":
                    e.Value = tmpLogEntry.FileName;
                    break;

                case "FileType":
                    e.Value = tmpLogEntry.FileType;
                    break;
            }

        }


        // configures the appearance and behavior of a DataGridView control.
        private void InitializeDataGridView(DataGridView dataGridView)
        {
            // VIRTUAL MODE ------------------------
            dataGridView.VirtualMode = true;

            dataGridViewMsg.CellValueNeeded += new DataGridViewCellValueEventHandler(dataGridViewMsg_CellValueNeeded);
            // -------------------------------------

            // Add columns to the DataGridView.
            DataGridViewTextBoxColumn msgSeverityColumn = new DataGridViewTextBoxColumn();
            msgSeverityColumn.HeaderText = "Severity";
            msgSeverityColumn.Name = "Severity";

            DataGridViewTextBoxColumn msgDateTimeColumn = new DataGridViewTextBoxColumn();
            msgDateTimeColumn.HeaderText = "DateTime";
            msgDateTimeColumn.Name = "DateTime";

            DataGridViewTextBoxColumn msgFromColumn = new DataGridViewTextBoxColumn();
            msgFromColumn.HeaderText = "From";
            msgFromColumn.Name = "From";

            DataGridViewTextBoxColumn msgMessageColumn = new DataGridViewTextBoxColumn();
            msgMessageColumn.HeaderText = "Message";
            msgMessageColumn.Name = "Message";

            DataGridViewTextBoxColumn msgComponentColumn = new DataGridViewTextBoxColumn();
            msgComponentColumn.HeaderText = "Component";
            msgComponentColumn.Name = "Component";

            DataGridViewTextBoxColumn msgDeviceColumn = new DataGridViewTextBoxColumn();
            msgDeviceColumn.HeaderText = "Device";
            msgDeviceColumn.Name = "Device";


            DataGridViewTextBoxColumn msgFileNameColumn = new DataGridViewTextBoxColumn();
            msgFileNameColumn.HeaderText = "FileName";
            msgFileNameColumn.Name = "FileName";

            DataGridViewTextBoxColumn msgFileTypeColumn = new DataGridViewTextBoxColumn();
            msgFileTypeColumn.HeaderText = "FileType";
            msgFileTypeColumn.Name = "FileType";


            dataGridView.Columns.Add(msgSeverityColumn);
            dataGridView.Columns.Add(msgDateTimeColumn);
            dataGridView.Columns.Add(msgFromColumn);
            dataGridView.Columns.Add(msgMessageColumn);
            dataGridView.Columns.Add(msgComponentColumn);
            dataGridView.Columns.Add(msgDeviceColumn);
            dataGridView.Columns.Add(msgFileNameColumn);
            dataGridView.Columns.Add(msgFileTypeColumn);



            // Initialize basic DataGridView properties.
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.BorderStyle = BorderStyle.None;

            // Set property values appropriate for read-only display and limited interactivity. 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;

            dataGridView.AllowUserToOrderColumns = false; //TODO - change? 
            dataGridView.ReadOnly = true;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = true;                                            //TODO - change?


            // Set Sizing for Rows and Columns
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.Columns["Severity"].HeaderText = string.Empty;
            dataGridView.AutoResizeColumn(dataGridView.Columns["Severity"].Index); // AutoSize to minimum of Severity text
            dataGridView.AutoResizeColumn(dataGridView.Columns["Message"].Index); // AutoSize Message field
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









        private void onButtonClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("onButtonClick");

            PopulateDataGridView(dataGridViewMsg);
            PopulateDataGridView(dataGridViewTbt);


            dataGridViewMsg.Refresh();
            dataGridViewTbt.Refresh();

            InitializeDataGridView(dataGridViewMsg);
            InitializeDataGridView(dataGridViewTbt);

            InitializeColumnOrder();


            dataGridViewMsg.CellFormatting += new DataGridViewCellFormattingEventHandler((s, eArgs) => dgvHideFileType_CellFormatting(s, eArgs, dataGridViewMsg, FileType.TBTracer));
            //TODO - if to decide which filetype gets hidden -> Messages or MessagesBase
            dataGridViewTbt.CellFormatting += new DataGridViewCellFormattingEventHandler((s, eArgs) => dgvHideFileType_CellFormatting(s, eArgs, dataGridViewTbt, FileType.Messages));


        }


        private void MainCompareWindowForm_Load(object sender, EventArgs e)
        {
            // Binding Scrollbar
            this.dataGridViewMsg.Scroll += new ScrollEventHandler(dataGridViewMessage_Scroll);
            this.dataGridViewTbt.Scroll += new ScrollEventHandler(dataGridViewTracer_Scroll);
        }


        private void InitializeColumnOrder()
        {

            //Hide columns
            /*

            this.dataGridViewMsg.Columns["FileName"].Visible = false;
            this.dataGridViewMsg.Columns["Device"].Visible = false;
            this.dataGridViewMsg.Columns["Component"].Visible = false;
            this.dataGridViewMsg.Columns["FileType"].Visible = false;

            this.dataGridViewTbt.Columns["FileName"].Visible = false;
            this.dataGridViewTbt.Columns["From"].Visible = false;
            this.dataGridViewTbt.Columns["FileType"].Visible = false;

            this.dataGridViewMsg.Columns["Severity"].DisplayIndex = 0;
            this.dataGridViewMsg.Columns["DateTime"].DisplayIndex = 1;
            this.dataGridViewMsg.Columns["From"].DisplayIndex = 2;
            this.dataGridViewMsg.Columns["Message"].DisplayIndex = 3;

            this.dataGridViewTbt.Columns["Severity"].DisplayIndex = 0;
            this.dataGridViewTbt.Columns["DateTime"].DisplayIndex = 1;
            this.dataGridViewTbt.Columns["Component"].DisplayIndex = 2;
            this.dataGridViewTbt.Columns["Device"].DisplayIndex = 3;
            this.dataGridViewTbt.Columns["Message"].DisplayIndex = 4;

            */

        }


        // bind scrollbar
        private void dataGridViewMessage_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridViewTbt.FirstDisplayedScrollingRowIndex = this.dataGridViewMsg.FirstDisplayedScrollingRowIndex;
        }

        // bind scrollbar
        private void dataGridViewTracer_Scroll(object sender, ScrollEventArgs e)
        {
            this.dataGridViewMsg.FirstDisplayedScrollingRowIndex = this.dataGridViewTbt.FirstDisplayedScrollingRowIndex;
        }


        private void dataGridViewMessage_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbMsgFilterSeverity.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["Severity"].Index].Width;
            tbMsgFilterDateTime.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["DateTime"].Index].Width;
            tbMsgFilterFrom.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["From"].Index].Width;
            tbMsgFilterMessage.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["Message"].Index].Width;
        }

        private void dataGridViewTracer_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            tbTbtFilterSeverity.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["Severity"].Index].Width;
            tbTbtFilterDateTime.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["DateTime"].Index].Width;
            tbTbtFilterComponent.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["Component"].Index].Width;
            tbTbtFilterDevice.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["Device"].Index].Width;
            tbTbtFilterMessage.Width = dataGridViewMsg.Columns[dataGridViewMsg.Columns["Message"].Index].Width;
        }





        // change cell foreground from "Severity" column, based on cell value
        private void dgvColorSeverity_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTbt.Columns["Severity"].Index && e.Value != null)
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


        // hide row of DataGridView by changing all colors to white, based on FileType
        private void dgvHideFileType_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e, DataGridView dataGridView, FileType fileType)
        {
            #region DEBUG_SECTION
            /* //DEBUG
            Console.WriteLine("ColumnName: " + this.dataGridViewMessage.Columns[e.ColumnIndex].Name +
                              "\t||\t e.ColumnIndex: " + e.ColumnIndex +
                              "\t||\t e.RowIndex: " + e.RowIndex);
            */
            #endregion

            /*
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
            */

        }





        // --------------------------------------------
        //TODO - FILTER
        // --------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
         
            /*
            view.ApplyFilter(delegate(LogEntry logEntry)
            {
                return logEntry.Message.Contains("####");
            });
            */
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
            DataGridViewCell cell = GetCellWhereTextExistsInGridView(tbSearch.Text, dataGridViewMsg, dataGridViewMsg.Columns["Message"].Index, lastSearchIndex);



            if (cell != null)
            {
                var rowIndex = cell.RowIndex;

                lastSearchIndex = cell.RowIndex;

                dataGridViewMsg.ClearSelection();
                dataGridViewMsg.Rows[rowIndex].Selected = true;
                dataGridViewMsg.FirstDisplayedScrollingRowIndex = rowIndex;
                dataGridViewMsg.Focus();
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




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cbShowFilter_CheckedChanged(object sender, EventArgs e)
        {

            if (cbShowFilter.Checked)
            {
                tbMsgFilterSeverity.Visible = true;
                tbMsgFilterDateTime.Visible = true;
                tbMsgFilterFrom.Visible = true;
                tbMsgFilterMessage.Visible = true;

                tbTbtFilterSeverity.Visible = true;
                tbTbtFilterDateTime.Visible = true;
                tbTbtFilterComponent.Visible = true;
                tbTbtFilterDevice.Visible = true;
                tbTbtFilterMessage.Visible = true;
            }
            else
            {
                tbMsgFilterSeverity.Clear();
                tbMsgFilterDateTime.Clear();
                tbMsgFilterFrom.Clear();
                tbMsgFilterMessage.Clear();

                tbTbtFilterSeverity.Clear();
                tbTbtFilterDateTime.Clear();
                tbTbtFilterComponent.Clear();
                tbTbtFilterDevice.Clear();
                tbTbtFilterMessage.Clear();


                tbMsgFilterSeverity.Visible = false;
                tbMsgFilterDateTime.Visible = false;
                tbMsgFilterFrom.Visible = false;
                tbMsgFilterMessage.Visible = false;

                tbTbtFilterSeverity.Visible = false;
                tbTbtFilterDateTime.Visible = false;
                tbTbtFilterComponent.Visible = false;
                tbTbtFilterDevice.Visible = false;
                tbTbtFilterMessage.Visible = false;

            }

        }
    }
}
