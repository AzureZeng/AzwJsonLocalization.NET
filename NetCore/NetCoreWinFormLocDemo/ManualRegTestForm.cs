using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureZeng.JsonLocalization.DynamicLocalization;


namespace NetCoreWinFormLocDemo
{
    public partial class ManualRegTestForm : Form
    {
        private readonly DynamicLocPropertyBinding _dpd;

        private const string TranslateNamespace = "TestForm";

        public ManualRegTestForm()
        {
            InitializeComponent();
            _dpd = Program.DynLocHost.CreateNewBindingObject(this);
            //_dpd.RegisterNewProperty(button1, nameof(button1.Text), "TestForm:button1.text");

            RegisterTranslation();
            CreateTreeViewItem();

            _dpd.UpdateLocalization();
        }

        public void CreateTreeViewItem()
        {
            var fav = new TreeNode("Favorite");
            _dpd.RegisterNewProperty(fav, "Text", TranslateNamespace, "fileTree.favorite");
            fav.Nodes.Add("Pardon.txt");
            fav.Nodes.Add("ManageWorks.txt");
            fav.Nodes.Add("DocOfWeedy.txt");

            var recentOpen = new TreeNode("Recent"); 
            _dpd.RegisterNewProperty(recentOpen, "Text", TranslateNamespace, "fileTree.recentOpened");

            var recent_none = new TreeNode("None");
            _dpd.RegisterNewProperty(recent_none, "Text", TranslateNamespace,"fileTree.recentOpened.none");

            recentOpen.Nodes.Add(recent_none);

            treeView1.Nodes.AddRange(new TreeNode[]{fav, recentOpen});
        }

        public void RegisterTranslation()
        {
            #region Menu Translation

            _dpd.RegisterNewProperty(menu_file, "Text", "TestForm:menu.file");
            _dpd.RegisterNewProperty(menu_file_new, "Text", "TestForm:menu.file.new");
            _dpd.RegisterNewProperty(menu_file_open, "Text", "TestForm:menu.file.open");
            _dpd.RegisterNewProperty(menu_file_save, "Text", "TestForm:menu.file.save");
            _dpd.RegisterNewProperty(menu_file_saveAs, "Text", "TestForm:menu.file.saveAs");
            _dpd.RegisterNewProperty(menu_file_print, "Text", "TestForm:menu.file.print");
            _dpd.RegisterNewProperty(menu_file_printPreview, "Text", "TestForm:menu.file.printPreview");
            _dpd.RegisterNewProperty(menu_file_exit, "Text", "TestForm:menu.file.exit");

            _dpd.RegisterNewProperty(menu_edit, "Text", TranslateNamespace, "menu.edit");
            _dpd.RegisterNewProperty(menu_edit_redo, "Text", TranslateNamespace, "menu.edit.redo");
            _dpd.RegisterNewProperty(menu_edit_undo, "Text", TranslateNamespace, "menu.edit.undo");
            _dpd.RegisterNewProperty(menu_edit_cut, "Text", TranslateNamespace, "menu.edit.cut");
            _dpd.RegisterNewProperty(menu_edit_copy, "Text", TranslateNamespace, "menu.edit.copy");
            _dpd.RegisterNewProperty(menu_edit_paste, "Text", TranslateNamespace, "menu.edit.paste");
            _dpd.RegisterNewProperty(menu_edit_selectAll, "Text", TranslateNamespace, "menu.edit.selectAll");

            _dpd.RegisterNewProperty(menu_tools,"Text","TestForm", "menu.tools");
            _dpd.RegisterNewProperty(menu_tools_customize, "Text", TranslateNamespace, "menu.tools.customize");
            _dpd.RegisterNewProperty(menu_tools_options, "Text", TranslateNamespace, "menu.tools.options");

            _dpd.RegisterNewProperty(menu_help,"Text", TranslateNamespace, "menu.help");
            _dpd.RegisterNewProperty(menu_tools_contents, "Text", TranslateNamespace, "menu.help.contents");
            _dpd.RegisterNewProperty(menu_tools_index, "Text", TranslateNamespace, "menu.help.index");
            _dpd.RegisterNewProperty(menu_tools_search, "Text", TranslateNamespace, "menu.help.search");
            _dpd.RegisterNewProperty(menu_tools_about, "Text", TranslateNamespace, "menu.help.about");

            #endregion

            #region Toolbar Translation

            _dpd.RegisterNewProperty(toolbar_new, "Text", "TestForm:menu.file.new");
            _dpd.RegisterNewProperty(toolbar_open, "Text", "TestForm:menu.file.open");
            _dpd.RegisterNewProperty(toolbar_save, "Text", "TestForm:menu.file.save");
            _dpd.RegisterNewProperty(toolbar_print, "Text", "TestForm:menu.file.print");
            _dpd.RegisterNewProperty(toolbar_cut, "Text", TranslateNamespace, "menu.edit.cut");
            _dpd.RegisterNewProperty(toolbar_copy, "Text", TranslateNamespace, "menu.edit.copy");
            _dpd.RegisterNewProperty(toolbar_paste, "Text", TranslateNamespace, "menu.edit.paste");
            _dpd.RegisterNewProperty(toolbar_help, "Text", TranslateNamespace, "menu.help");

            #endregion

            
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dpd.Dispose();
        }

        private void TranslateTreeNodeItem(TreeNode node)
        {
            if (!string.IsNullOrEmpty(node.Tag as string))_dpd.RegisterNewProperty(node, "Text", node.Tag as string);
            foreach (var a in node.Nodes)
            {
                if (a is TreeNode treeNode) TranslateTreeNodeItem(treeNode);
            }
        }

    }
}
