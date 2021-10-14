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


            InitializeResizingListView();
            InitializeDataGridView();

            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);

            


            //DEBUG ################################################
            #region ListViewTest_DEBUG_ONLY 

            LogHandler logHandler = new LogHandler("C:\\Users\\Thomas\\localgit\\work\\logcompare\\data.test\\logfiles_debug\\");

            List<LogEntry> list = new List<LogEntry>();

            list = logHandler.LoadLogFileEntries("messages.prn");

            listView1.Columns.Add("Severity", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Time", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("From", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Message", -2, HorizontalAlignment.Left);

            var item1 = new ListViewItem(new[] {"severity1", "dateTime1", "form1", "message1"});
            var item2 = new ListViewItem(new[] { "severity2", "dateTime2", "form2", "message2" });
            var item3 = new ListViewItem(new[] { "severity3", "dateTime3", "form3", "message3" });

            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            listView1.Items.Add(item3);


            dataGridView1.Columns.Add("columnName", "headerText");
            dataGridView1.Columns.Add("columnName2", "headerText2");
            dataGridView1.Columns.Add("columnName3", "headerText3");
            dataGridView1.Columns.Add("columnName4", "headerText4");

            



            /*
             * var item1 = new ListViewItem(new[] {"id123", "Tom", "24"});
                var item2 = new ListViewItem(new[] {person.Id, person.Name, person.Age});
                lvRegAnimals.Items.Add(item1);
                lvRegAnimals.Items.Add(item2);
             */



            foreach (var entry in list)
            {
             //   Console.WriteLine(entry.ToString());
             //   listView1.Items.Add(entry.ToString());
            }
            

            

            #endregion


        }


        private void InitializeResizingListView()
        {

            // Set the ListView to details view.
            listView1.View = View.Details;

            //Set size, location and populate the ListView.
            listView1.Size = new Size(200, 100);
            listView1.Location = new Point(40, 40);
            listView1.Columns.Add("HeaderSize");
            listView1.Columns.Add("ColumnContent");
            ListViewItem listItem1 = new ListViewItem("Short");
            ListViewItem listItem2 = new ListViewItem("Tiny");
            listItem1.SubItems.Add(new ListViewItem.ListViewSubItem(listItem1, "Something longer"));
            listItem2.SubItems.Add(new ListViewItem.ListViewSubItem(listItem2, "Something even longer"));
            listView1.Items.Add(listItem1);
            listView1.Items.Add(listItem2);

            listView1.GridLines = true;
            listView1.AllowColumnReorder = true;
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;



        }

        private void InitializeDataGridView()
        {

            dataGridView1.BackgroundColor = Color.BlueViolet;
            dataGridView1.BackColor = Color.Aqua;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.GridColor = Color.Blue;


            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview?view=windowsdesktop-5.0



        }



    }
}
