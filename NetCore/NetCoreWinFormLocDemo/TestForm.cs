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
    public partial class TestForm : Form
    {
        private readonly DynamicPropertyBinding _dpd;

        public TestForm()
        {
            InitializeComponent();
            _dpd = Program.DynLocHost.CreateNewBindingObject(this);
            _dpd.RegisterNewProperty(button1, nameof(button1.Text), "TestForm:button1.text");
            _dpd.RegisterNewProperty(menu_file, nameof(menu_file.Text), "TestForm:menu.file");
            _dpd.RegisterNewProperty(menu_file_new, nameof(menu_file_new.Text), "TestForm:menu.file.new");
            _dpd.RegisterNewProperty(menu_file_open, nameof(menu_file_open.Text), "TestForm:menu.file.open");
            _dpd.RegisterNewProperty(menu_file_save, nameof(menu_file_save.Text), "TestForm:menu.file.save");
            _dpd.RegisterNewProperty(menu_file_saveAs, nameof(menu_file_saveAs.Text), "TestForm:menu.file.saveAs");
            button1.Click += Button1_Click;
            _dpd.UpdateLocalization();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _dpd.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.LocHost.SelectedCultureInfo = CultureInfo.GetCultureInfoByIetfLanguageTag("zh-CN");
            Program.DynLocHost.UpdateLocalization();
        }
    }
}
