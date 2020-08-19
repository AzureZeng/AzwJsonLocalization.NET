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
            _dpd.RegisterNewProperty(fileToolStripMenuItem, nameof(fileToolStripMenuItem.Text), "TestForm:menu.file.text");
            button1.Click += Button1_Click;
            _dpd.UpdateLocalization();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Program.DynLocHost.RemoveObject(_dpd);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.LocHost.SelectedCultureInfo = CultureInfo.GetCultureInfoByIetfLanguageTag("zh-CN");
            _dpd.UpdateLocalization();
        }
    }
}
