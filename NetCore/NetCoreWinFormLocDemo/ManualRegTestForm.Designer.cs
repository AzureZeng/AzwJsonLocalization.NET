namespace NetCoreWinFormLocDemo
{
    partial class ManualRegTestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualRegTestForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_print = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_printPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_file_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit_undo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit_redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_edit_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_edit_selectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools_customize = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools_options = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools_contents = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools_index = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_tools_search = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_tools_about = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbar_new = new System.Windows.Forms.ToolStripButton();
            this.toolbar_open = new System.Windows.Forms.ToolStripButton();
            this.toolbar_save = new System.Windows.Forms.ToolStripButton();
            this.toolbar_print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_cut = new System.Windows.Forms.ToolStripButton();
            this.toolbar_copy = new System.Windows.Forms.ToolStripButton();
            this.toolbar_paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar_help = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file,
            this.menu_edit,
            this.menu_tools,
            this.menu_help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file_new,
            this.menu_file_open,
            this.toolStripSeparator,
            this.menu_file_save,
            this.menu_file_saveAs,
            this.toolStripSeparator1,
            this.menu_file_print,
            this.menu_file_printPreview,
            this.toolStripSeparator2,
            this.menu_file_exit});
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(37, 20);
            this.menu_file.Text = "&File";
            // 
            // menu_file_new
            // 
            this.menu_file_new.Image = ((System.Drawing.Image)(resources.GetObject("menu_file_new.Image")));
            this.menu_file_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_file_new.Name = "menu_file_new";
            this.menu_file_new.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menu_file_new.Size = new System.Drawing.Size(146, 22);
            this.menu_file_new.Text = "&New";
            // 
            // menu_file_open
            // 
            this.menu_file_open.Image = ((System.Drawing.Image)(resources.GetObject("menu_file_open.Image")));
            this.menu_file_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_file_open.Name = "menu_file_open";
            this.menu_file_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menu_file_open.Size = new System.Drawing.Size(146, 22);
            this.menu_file_open.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // menu_file_save
            // 
            this.menu_file_save.Image = ((System.Drawing.Image)(resources.GetObject("menu_file_save.Image")));
            this.menu_file_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_file_save.Name = "menu_file_save";
            this.menu_file_save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menu_file_save.Size = new System.Drawing.Size(146, 22);
            this.menu_file_save.Text = "&Save";
            // 
            // menu_file_saveAs
            // 
            this.menu_file_saveAs.Name = "menu_file_saveAs";
            this.menu_file_saveAs.Size = new System.Drawing.Size(146, 22);
            this.menu_file_saveAs.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // menu_file_print
            // 
            this.menu_file_print.Image = ((System.Drawing.Image)(resources.GetObject("menu_file_print.Image")));
            this.menu_file_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_file_print.Name = "menu_file_print";
            this.menu_file_print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menu_file_print.Size = new System.Drawing.Size(146, 22);
            this.menu_file_print.Text = "&Print";
            // 
            // menu_file_printPreview
            // 
            this.menu_file_printPreview.Image = ((System.Drawing.Image)(resources.GetObject("menu_file_printPreview.Image")));
            this.menu_file_printPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_file_printPreview.Name = "menu_file_printPreview";
            this.menu_file_printPreview.Size = new System.Drawing.Size(146, 22);
            this.menu_file_printPreview.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // menu_file_exit
            // 
            this.menu_file_exit.Name = "menu_file_exit";
            this.menu_file_exit.Size = new System.Drawing.Size(146, 22);
            this.menu_file_exit.Text = "E&xit";
            // 
            // menu_edit
            // 
            this.menu_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_edit_undo,
            this.menu_edit_redo,
            this.toolStripSeparator3,
            this.menu_edit_cut,
            this.menu_edit_copy,
            this.menu_edit_paste,
            this.toolStripSeparator4,
            this.menu_edit_selectAll});
            this.menu_edit.Name = "menu_edit";
            this.menu_edit.Size = new System.Drawing.Size(39, 20);
            this.menu_edit.Text = "&Edit";
            // 
            // menu_edit_undo
            // 
            this.menu_edit_undo.Name = "menu_edit_undo";
            this.menu_edit_undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menu_edit_undo.Size = new System.Drawing.Size(144, 22);
            this.menu_edit_undo.Text = "&Undo";
            // 
            // menu_edit_redo
            // 
            this.menu_edit_redo.Name = "menu_edit_redo";
            this.menu_edit_redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.menu_edit_redo.Size = new System.Drawing.Size(144, 22);
            this.menu_edit_redo.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // menu_edit_cut
            // 
            this.menu_edit_cut.Image = ((System.Drawing.Image)(resources.GetObject("menu_edit_cut.Image")));
            this.menu_edit_cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_edit_cut.Name = "menu_edit_cut";
            this.menu_edit_cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menu_edit_cut.Size = new System.Drawing.Size(144, 22);
            this.menu_edit_cut.Text = "Cu&t";
            // 
            // menu_edit_copy
            // 
            this.menu_edit_copy.Image = ((System.Drawing.Image)(resources.GetObject("menu_edit_copy.Image")));
            this.menu_edit_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_edit_copy.Name = "menu_edit_copy";
            this.menu_edit_copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menu_edit_copy.Size = new System.Drawing.Size(144, 22);
            this.menu_edit_copy.Text = "&Copy";
            // 
            // menu_edit_paste
            // 
            this.menu_edit_paste.Image = ((System.Drawing.Image)(resources.GetObject("menu_edit_paste.Image")));
            this.menu_edit_paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_edit_paste.Name = "menu_edit_paste";
            this.menu_edit_paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menu_edit_paste.Size = new System.Drawing.Size(144, 22);
            this.menu_edit_paste.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // menu_edit_selectAll
            // 
            this.menu_edit_selectAll.Name = "menu_edit_selectAll";
            this.menu_edit_selectAll.Size = new System.Drawing.Size(144, 22);
            this.menu_edit_selectAll.Text = "Select &All";
            // 
            // menu_tools
            // 
            this.menu_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_tools_customize,
            this.menu_tools_options});
            this.menu_tools.Name = "menu_tools";
            this.menu_tools.Size = new System.Drawing.Size(46, 20);
            this.menu_tools.Text = "&Tools";
            // 
            // menu_tools_customize
            // 
            this.menu_tools_customize.Name = "menu_tools_customize";
            this.menu_tools_customize.Size = new System.Drawing.Size(130, 22);
            this.menu_tools_customize.Text = "&Customize";
            // 
            // menu_tools_options
            // 
            this.menu_tools_options.Name = "menu_tools_options";
            this.menu_tools_options.Size = new System.Drawing.Size(130, 22);
            this.menu_tools_options.Text = "&Options";
            // 
            // menu_help
            // 
            this.menu_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_tools_contents,
            this.menu_tools_index,
            this.menu_tools_search,
            this.toolStripSeparator5,
            this.menu_tools_about});
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(44, 20);
            this.menu_help.Text = "&Help";
            // 
            // menu_tools_contents
            // 
            this.menu_tools_contents.Name = "menu_tools_contents";
            this.menu_tools_contents.Size = new System.Drawing.Size(122, 22);
            this.menu_tools_contents.Text = "&Contents";
            // 
            // menu_tools_index
            // 
            this.menu_tools_index.Name = "menu_tools_index";
            this.menu_tools_index.Size = new System.Drawing.Size(122, 22);
            this.menu_tools_index.Text = "&Index";
            // 
            // menu_tools_search
            // 
            this.menu_tools_search.Name = "menu_tools_search";
            this.menu_tools_search.Size = new System.Drawing.Size(122, 22);
            this.menu_tools_search.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // menu_tools_about
            // 
            this.menu_tools_about.Name = "menu_tools_about";
            this.menu_tools_about.Size = new System.Drawing.Size(122, 22);
            this.menu_tools_about.Text = "&About...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbar_new,
            this.toolbar_open,
            this.toolbar_save,
            this.toolbar_print,
            this.toolStripSeparator6,
            this.toolbar_cut,
            this.toolbar_copy,
            this.toolbar_paste,
            this.toolStripSeparator7,
            this.toolbar_help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbar_new
            // 
            this.toolbar_new.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_new.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_new.Image")));
            this.toolbar_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_new.Name = "toolbar_new";
            this.toolbar_new.Size = new System.Drawing.Size(23, 22);
            this.toolbar_new.Text = "&New";
            // 
            // toolbar_open
            // 
            this.toolbar_open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_open.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_open.Image")));
            this.toolbar_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_open.Name = "toolbar_open";
            this.toolbar_open.Size = new System.Drawing.Size(23, 22);
            this.toolbar_open.Text = "&Open";
            // 
            // toolbar_save
            // 
            this.toolbar_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_save.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_save.Image")));
            this.toolbar_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_save.Name = "toolbar_save";
            this.toolbar_save.Size = new System.Drawing.Size(23, 22);
            this.toolbar_save.Text = "&Save";
            // 
            // toolbar_print
            // 
            this.toolbar_print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_print.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_print.Image")));
            this.toolbar_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_print.Name = "toolbar_print";
            this.toolbar_print.Size = new System.Drawing.Size(23, 22);
            this.toolbar_print.Text = "&Print";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbar_cut
            // 
            this.toolbar_cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_cut.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_cut.Image")));
            this.toolbar_cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_cut.Name = "toolbar_cut";
            this.toolbar_cut.Size = new System.Drawing.Size(23, 22);
            this.toolbar_cut.Text = "C&ut";
            // 
            // toolbar_copy
            // 
            this.toolbar_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_copy.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_copy.Image")));
            this.toolbar_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_copy.Name = "toolbar_copy";
            this.toolbar_copy.Size = new System.Drawing.Size(23, 22);
            this.toolbar_copy.Text = "&Copy";
            // 
            // toolbar_paste
            // 
            this.toolbar_paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_paste.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_paste.Image")));
            this.toolbar_paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_paste.Name = "toolbar_paste";
            this.toolbar_paste.Size = new System.Drawing.Size(23, 22);
            this.toolbar_paste.Text = "&Paste";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbar_help
            // 
            this.toolbar_help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbar_help.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_help.Image")));
            this.toolbar_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_help.Name = "toolbar_help";
            this.toolbar_help.Size = new System.Drawing.Size(23, 22);
            this.toolbar_help.Text = "He&lp";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(655, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 20);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(33, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(805, 393);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(265, 393);
            this.treeView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(536, 393);
            this.textBox1.TabIndex = 0;
            // 
            // ManualRegTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 468);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManualRegTestForm";
            this.Text = "TestForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_file;
        private System.Windows.Forms.ToolStripMenuItem menu_file_new;
        private System.Windows.Forms.ToolStripMenuItem menu_file_open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem menu_file_save;
        private System.Windows.Forms.ToolStripMenuItem menu_file_saveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_file_print;
        private System.Windows.Forms.ToolStripMenuItem menu_file_printPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menu_file_exit;
        private System.Windows.Forms.ToolStripMenuItem menu_edit_undo;
        private System.Windows.Forms.ToolStripMenuItem menu_edit_redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menu_edit_cut;
        private System.Windows.Forms.ToolStripMenuItem menu_edit_copy;
        private System.Windows.Forms.ToolStripMenuItem menu_edit_paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menu_edit_selectAll;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_customize;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_options;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_contents;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_index;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_search;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menu_tools_about;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbar_new;
        private System.Windows.Forms.ToolStripButton toolbar_open;
        private System.Windows.Forms.ToolStripButton toolbar_save;
        private System.Windows.Forms.ToolStripButton toolbar_print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolbar_cut;
        private System.Windows.Forms.ToolStripButton toolbar_copy;
        private System.Windows.Forms.ToolStripButton toolbar_paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolbar_help;
        private System.Windows.Forms.ToolStripMenuItem menu_edit;
        private System.Windows.Forms.ToolStripMenuItem menu_tools;
        private System.Windows.Forms.ToolStripMenuItem menu_help;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

