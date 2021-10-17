using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            PopulateDataGridView(dataGridView1);
            PopulateDataGridView(dataGridView2);

            InitializeDataGridView(dataGridView1);
            InitializeDataGridView(dataGridView2);

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
            dataGridView.MultiSelect = true; //TODO - change?
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None; //TODO - change?
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Set the selection background color for all the cells.
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightCoral; //TODO - change?
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


            // Specify a larger font for the "Ratings" column. 
            using (Font font = new Font(dataGridView.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold))
            {
                dataGridView.Columns["Rating"].DefaultCellStyle.Font = font;
            }

            // Attach a handler to the CellFormatting event.
            dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView_CellFormatting);


        }


        // Changes the foreground color of cells in the "Ratings" column 
        // depending on the number of stars. 
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Rating"].Index && e.Value != null)
            {
                switch (e.Value.ToString().Length)
                {
                    case 1:
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.SelectionBackColor = Color.LightGray;

                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case 2:
                        e.CellStyle.SelectionForeColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Yellow;
                        break;
                    case 3:
                        e.CellStyle.SelectionForeColor = Color.Green;
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case 4:
                        e.CellStyle.SelectionForeColor = Color.Blue;
                        e.CellStyle.ForeColor = Color.Blue;
                        break;
                }
            }
        }


        // Creates the columns and loads the data.
        //TODO - Populate should not be done with a "handover parameter"
        private void PopulateDataGridView(DataGridView dataGridView)
        {
            // Set the column header names.
            dataGridView.ColumnCount = 5;
            dataGridView.Columns[0].Name = "Recipe";
            dataGridView.Columns[1].Name = "Category";
            dataGridView.Columns[2].Name = "Main Ingredients";
            dataGridView.Columns[3].Name = "Last Prepared";
            dataGridView.Columns[4].Name = "Rating";

            // Populate the rows.
            object[] row1 = new object[]{"Meatloaf", "Main Dish", "ground beef", new DateTime(2000, 3, 23), "*"};
            object[] row2 = new object[]{"Key Lime Pie", "Dessert", "lime juice, evaporated milk", new DateTime(2002, 4, 12), "****"};
            object[] row3 = new object[]{"Orange-Salsa Pork Chops", "Main Dish", "pork chops, salsa, orange juice", new DateTime(2000, 8, 9), "****"};
            object[] row4 = new object[]{"Black Bean and Rice Salad", "Salad", "black beans, brown rice", new DateTime(1999, 5, 7), "****"};
            object[] row5 = new object[]{"Chocolate Cheesecake", "Dessert", "cream cheese", new DateTime(2003, 3, 12), "***"};
            object[] row6 = new object[]{"Black Bean Dip", "Appetizer", "black beans, sour cream", new DateTime(2003, 12, 23), "***"};

            // Add the rows to the DataGridView.
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };
            foreach (object[] rowArray in rows)
            {
                dataGridView.Rows.Add(rowArray);
            }

            // Adjust the row heights so that all content is visible.
            dataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
