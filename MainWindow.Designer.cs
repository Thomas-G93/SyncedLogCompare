
namespace SyncedLogCompare
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.scCompare = new System.Windows.Forms.SplitContainer();
            this.tlpMsg = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewMsg = new System.Windows.Forms.DataGridView();
            this.tlpMsgFilter = new System.Windows.Forms.TableLayoutPanel();
            this.tbMsgFilterSeverity = new System.Windows.Forms.TextBox();
            this.tbMsgFilterDateTime = new System.Windows.Forms.TextBox();
            this.tbMsgFilterFrom = new System.Windows.Forms.TextBox();
            this.tbMsgFilterMessage = new System.Windows.Forms.TextBox();
            this.tlpTbt = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTbtFilter = new System.Windows.Forms.TableLayoutPanel();
            this.tbTbtFilterSeverity = new System.Windows.Forms.TextBox();
            this.tbTbtFilterDateTime = new System.Windows.Forms.TextBox();
            this.tbTbtFilterComponent = new System.Windows.Forms.TextBox();
            this.tbTbtFilterDevice = new System.Windows.Forms.TextBox();
            this.tbTbtFilterMessage = new System.Windows.Forms.TextBox();
            this.dataGridViewTbt = new System.Windows.Forms.DataGridView();
            this.tlpMainStructure = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbShowFilter = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPathToLogFolder = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scCompare)).BeginInit();
            this.scCompare.Panel1.SuspendLayout();
            this.scCompare.Panel2.SuspendLayout();
            this.scCompare.SuspendLayout();
            this.tlpMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMsg)).BeginInit();
            this.tlpMsgFilter.SuspendLayout();
            this.tlpTbt.SuspendLayout();
            this.tlpTbtFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTbt)).BeginInit();
            this.tlpMainStructure.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1459, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(348, 71);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onButtonClick);
            // 
            // scCompare
            // 
            this.tlpMainStructure.SetColumnSpan(this.scCompare, 2);
            this.scCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scCompare.Location = new System.Drawing.Point(5, 226);
            this.scCompare.Margin = new System.Windows.Forms.Padding(5);
            this.scCompare.Name = "scCompare";
            // 
            // scCompare.Panel1
            // 
            this.scCompare.Panel1.Controls.Add(this.tlpMsg);
            this.scCompare.Panel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // scCompare.Panel2
            // 
            this.scCompare.Panel2.Controls.Add(this.tlpTbt);
            this.scCompare.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.scCompare.Size = new System.Drawing.Size(1806, 613);
            this.scCompare.SplitterDistance = 901;
            this.scCompare.SplitterWidth = 5;
            this.scCompare.TabIndex = 3;
            // 
            // tlpMsg
            // 
            this.tlpMsg.ColumnCount = 1;
            this.tlpMsg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMsg.Controls.Add(this.dataGridViewMsg, 0, 1);
            this.tlpMsg.Controls.Add(this.tlpMsgFilter, 0, 0);
            this.tlpMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMsg.Location = new System.Drawing.Point(20, 0);
            this.tlpMsg.Name = "tlpMsg";
            this.tlpMsg.RowCount = 2;
            this.tlpMsg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMsg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMsg.Size = new System.Drawing.Size(881, 613);
            this.tlpMsg.TabIndex = 0;
            // 
            // dataGridViewMsg
            // 
            this.dataGridViewMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMsg.Location = new System.Drawing.Point(3, 52);
            this.dataGridViewMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewMsg.Name = "dataGridViewMsg";
            this.dataGridViewMsg.RowHeadersWidth = 102;
            this.dataGridViewMsg.RowTemplate.Height = 40;
            this.dataGridViewMsg.Size = new System.Drawing.Size(875, 559);
            this.dataGridViewMsg.TabIndex = 0;
            this.dataGridViewMsg.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewMessage_ColumnWidthChanged);
            // 
            // tlpMsgFilter
            // 
            this.tlpMsgFilter.ColumnCount = 4;
            this.tlpMsgFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMsgFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMsgFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMsgFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMsgFilter.Controls.Add(this.tbMsgFilterSeverity, 0, 0);
            this.tlpMsgFilter.Controls.Add(this.tbMsgFilterDateTime, 1, 0);
            this.tlpMsgFilter.Controls.Add(this.tbMsgFilterFrom, 2, 0);
            this.tlpMsgFilter.Controls.Add(this.tbMsgFilterMessage, 3, 0);
            this.tlpMsgFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMsgFilter.Location = new System.Drawing.Point(3, 3);
            this.tlpMsgFilter.Name = "tlpMsgFilter";
            this.tlpMsgFilter.Padding = new System.Windows.Forms.Padding(2);
            this.tlpMsgFilter.RowCount = 1;
            this.tlpMsgFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMsgFilter.Size = new System.Drawing.Size(875, 44);
            this.tlpMsgFilter.TabIndex = 12;
            // 
            // tbMsgFilterSeverity
            // 
            this.tbMsgFilterSeverity.Location = new System.Drawing.Point(4, 2);
            this.tbMsgFilterSeverity.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.tbMsgFilterSeverity.Multiline = true;
            this.tbMsgFilterSeverity.Name = "tbMsgFilterSeverity";
            this.tbMsgFilterSeverity.Size = new System.Drawing.Size(100, 38);
            this.tbMsgFilterSeverity.TabIndex = 0;
            // 
            // tbMsgFilterDateTime
            // 
            this.tbMsgFilterDateTime.Location = new System.Drawing.Point(104, 2);
            this.tbMsgFilterDateTime.Margin = new System.Windows.Forms.Padding(0);
            this.tbMsgFilterDateTime.Multiline = true;
            this.tbMsgFilterDateTime.Name = "tbMsgFilterDateTime";
            this.tbMsgFilterDateTime.Size = new System.Drawing.Size(100, 34);
            this.tbMsgFilterDateTime.TabIndex = 1;
            // 
            // tbMsgFilterFrom
            // 
            this.tbMsgFilterFrom.Location = new System.Drawing.Point(204, 2);
            this.tbMsgFilterFrom.Margin = new System.Windows.Forms.Padding(0);
            this.tbMsgFilterFrom.Multiline = true;
            this.tbMsgFilterFrom.Name = "tbMsgFilterFrom";
            this.tbMsgFilterFrom.Size = new System.Drawing.Size(100, 34);
            this.tbMsgFilterFrom.TabIndex = 2;
            // 
            // tbMsgFilterMessage
            // 
            this.tbMsgFilterMessage.Location = new System.Drawing.Point(304, 2);
            this.tbMsgFilterMessage.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbMsgFilterMessage.Multiline = true;
            this.tbMsgFilterMessage.Name = "tbMsgFilterMessage";
            this.tbMsgFilterMessage.Size = new System.Drawing.Size(100, 38);
            this.tbMsgFilterMessage.TabIndex = 3;
            // 
            // tlpTbt
            // 
            this.tlpTbt.ColumnCount = 1;
            this.tlpTbt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTbt.Controls.Add(this.tlpTbtFilter, 0, 0);
            this.tlpTbt.Controls.Add(this.dataGridViewTbt, 0, 1);
            this.tlpTbt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTbt.Location = new System.Drawing.Point(0, 0);
            this.tlpTbt.Name = "tlpTbt";
            this.tlpTbt.RowCount = 2;
            this.tlpTbt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTbt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTbt.Size = new System.Drawing.Size(880, 613);
            this.tlpTbt.TabIndex = 0;
            // 
            // tlpTbtFilter
            // 
            this.tlpTbtFilter.ColumnCount = 5;
            this.tlpTbtFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTbtFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTbtFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTbtFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTbtFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTbtFilter.Controls.Add(this.tbTbtFilterSeverity, 0, 0);
            this.tlpTbtFilter.Controls.Add(this.tbTbtFilterDateTime, 1, 0);
            this.tlpTbtFilter.Controls.Add(this.tbTbtFilterComponent, 2, 0);
            this.tlpTbtFilter.Controls.Add(this.tbTbtFilterDevice, 3, 0);
            this.tlpTbtFilter.Controls.Add(this.tbTbtFilterMessage, 4, 0);
            this.tlpTbtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTbtFilter.Location = new System.Drawing.Point(3, 3);
            this.tlpTbtFilter.Name = "tlpTbtFilter";
            this.tlpTbtFilter.Padding = new System.Windows.Forms.Padding(2);
            this.tlpTbtFilter.RowCount = 1;
            this.tlpTbtFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTbtFilter.Size = new System.Drawing.Size(874, 44);
            this.tlpTbtFilter.TabIndex = 14;
            // 
            // tbTbtFilterSeverity
            // 
            this.tbTbtFilterSeverity.Location = new System.Drawing.Point(2, 2);
            this.tbTbtFilterSeverity.Margin = new System.Windows.Forms.Padding(0);
            this.tbTbtFilterSeverity.Multiline = true;
            this.tbTbtFilterSeverity.Name = "tbTbtFilterSeverity";
            this.tbTbtFilterSeverity.Size = new System.Drawing.Size(100, 38);
            this.tbTbtFilterSeverity.TabIndex = 0;
            // 
            // tbTbtFilterDateTime
            // 
            this.tbTbtFilterDateTime.Location = new System.Drawing.Point(102, 2);
            this.tbTbtFilterDateTime.Margin = new System.Windows.Forms.Padding(0);
            this.tbTbtFilterDateTime.Multiline = true;
            this.tbTbtFilterDateTime.Name = "tbTbtFilterDateTime";
            this.tbTbtFilterDateTime.Size = new System.Drawing.Size(100, 34);
            this.tbTbtFilterDateTime.TabIndex = 1;
            // 
            // tbTbtFilterComponent
            // 
            this.tbTbtFilterComponent.Location = new System.Drawing.Point(202, 2);
            this.tbTbtFilterComponent.Margin = new System.Windows.Forms.Padding(0);
            this.tbTbtFilterComponent.Multiline = true;
            this.tbTbtFilterComponent.Name = "tbTbtFilterComponent";
            this.tbTbtFilterComponent.Size = new System.Drawing.Size(100, 34);
            this.tbTbtFilterComponent.TabIndex = 2;
            // 
            // tbTbtFilterDevice
            // 
            this.tbTbtFilterDevice.Location = new System.Drawing.Point(302, 2);
            this.tbTbtFilterDevice.Margin = new System.Windows.Forms.Padding(0);
            this.tbTbtFilterDevice.Multiline = true;
            this.tbTbtFilterDevice.Name = "tbTbtFilterDevice";
            this.tbTbtFilterDevice.Size = new System.Drawing.Size(100, 38);
            this.tbTbtFilterDevice.TabIndex = 3;
            // 
            // tbTbtFilterMessage
            // 
            this.tbTbtFilterMessage.Location = new System.Drawing.Point(402, 2);
            this.tbTbtFilterMessage.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tbTbtFilterMessage.Multiline = true;
            this.tbTbtFilterMessage.Name = "tbTbtFilterMessage";
            this.tbTbtFilterMessage.Size = new System.Drawing.Size(100, 34);
            this.tbTbtFilterMessage.TabIndex = 4;
            // 
            // dataGridViewTbt
            // 
            this.dataGridViewTbt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTbt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTbt.Location = new System.Drawing.Point(3, 52);
            this.dataGridViewTbt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewTbt.Name = "dataGridViewTbt";
            this.dataGridViewTbt.RowHeadersWidth = 102;
            this.dataGridViewTbt.RowTemplate.Height = 40;
            this.dataGridViewTbt.Size = new System.Drawing.Size(874, 559);
            this.dataGridViewTbt.TabIndex = 0;
            this.dataGridViewTbt.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewTracer_ColumnWidthChanged);
            // 
            // tlpMainStructure
            // 
            this.tlpMainStructure.ColumnCount = 2;
            this.tlpMainStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainStructure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMainStructure.Controls.Add(this.label1, 0, 1);
            this.tlpMainStructure.Controls.Add(this.button3, 1, 4);
            this.tlpMainStructure.Controls.Add(this.flowLayoutPanel1, 1, 5);
            this.tlpMainStructure.Controls.Add(this.scCompare, 0, 3);
            this.tlpMainStructure.Controls.Add(this.tlpSearch, 1, 1);
            this.tlpMainStructure.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tlpMainStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainStructure.Location = new System.Drawing.Point(0, 49);
            this.tlpMainStructure.Margin = new System.Windows.Forms.Padding(20);
            this.tlpMainStructure.Name = "tlpMainStructure";
            this.tlpMainStructure.RowCount = 6;
            this.tlpMainStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainStructure.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMainStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMainStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainStructure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMainStructure.Size = new System.Drawing.Size(1816, 1044);
            this.tlpMainStructure.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(163, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "test label 1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(911, 847);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(354, 55);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbShowFilter);
            this.flowLayoutPanel1.Controls.Add(this.checkBox2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(911, 947);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(551, 70);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // cbShowFilter
            // 
            this.cbShowFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowFilter.AutoSize = true;
            this.cbShowFilter.Location = new System.Drawing.Point(3, 3);
            this.cbShowFilter.Name = "cbShowFilter";
            this.cbShowFilter.Size = new System.Drawing.Size(276, 36);
            this.cbShowFilter.TabIndex = 8;
            this.cbShowFilter.Text = "Hide / Show Filter\r\n";
            this.cbShowFilter.UseVisualStyleBackColor = true;
            this.cbShowFilter.CheckedChanged += new System.EventHandler(this.cbShowFilter_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(285, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(192, 36);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 2;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpSearch.Controls.Add(this.btnSearch, 1, 0);
            this.tlpSearch.Controls.Add(this.tbSearch, 0, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(911, 103);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.Size = new System.Drawing.Size(902, 65);
            this.tlpSearch.TabIndex = 16;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(612, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(287, 59);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Location = new System.Drawing.Point(3, 3);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(603, 59);
            this.tbSearch.TabIndex = 9;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tlpMainStructure.SetColumnSpan(this.tableLayoutPanel7, 2);
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.tbPathToLogFolder, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1810, 94);
            this.tableLayoutPanel7.TabIndex = 17;
            // 
            // tbPathToLogFolder
            // 
            this.tbPathToLogFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPathToLogFolder.Location = new System.Drawing.Point(5, 5);
            this.tbPathToLogFolder.Margin = new System.Windows.Forms.Padding(5);
            this.tbPathToLogFolder.Name = "tbPathToLogFolder";
            this.tbPathToLogFolder.Size = new System.Drawing.Size(1446, 38);
            this.tbPathToLogFolder.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1816, 49);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(148, 45);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(224, 45);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1816, 1093);
            this.Controls.Add(this.tlpMainStructure);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Synced Log Compare";
            this.Load += new System.EventHandler(this.MainCompareWindowForm_Load);
            this.scCompare.Panel1.ResumeLayout(false);
            this.scCompare.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scCompare)).EndInit();
            this.scCompare.ResumeLayout(false);
            this.tlpMsg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMsg)).EndInit();
            this.tlpMsgFilter.ResumeLayout(false);
            this.tlpMsgFilter.PerformLayout();
            this.tlpTbt.ResumeLayout(false);
            this.tlpTbtFilter.ResumeLayout(false);
            this.tlpTbtFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTbt)).EndInit();
            this.tlpMainStructure.ResumeLayout(false);
            this.tlpMainStructure.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer scCompare;
        private System.Windows.Forms.DataGridView dataGridViewTbt;
        private System.Windows.Forms.DataGridView dataGridViewMsg;
        private System.Windows.Forms.TableLayoutPanel tlpMainStructure;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbPathToLogFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox cbShowFilter;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.TableLayoutPanel tlpMsgFilter;
        private System.Windows.Forms.TextBox tbMsgFilterSeverity;
        private System.Windows.Forms.TextBox tbMsgFilterDateTime;
        private System.Windows.Forms.TextBox tbMsgFilterFrom;
        private System.Windows.Forms.TextBox tbMsgFilterMessage;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tlpTbtFilter;
        private System.Windows.Forms.TextBox tbTbtFilterSeverity;
        private System.Windows.Forms.TextBox tbTbtFilterDateTime;
        private System.Windows.Forms.TextBox tbTbtFilterComponent;
        private System.Windows.Forms.TextBox tbTbtFilterDevice;
        private System.Windows.Forms.TextBox tbTbtFilterMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TableLayoutPanel tlpMsg;
        private System.Windows.Forms.TableLayoutPanel tlpTbt;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
    }
}

