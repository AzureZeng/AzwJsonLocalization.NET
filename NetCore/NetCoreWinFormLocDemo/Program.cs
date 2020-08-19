using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureZeng.JsonLocalization;
using AzureZeng.JsonLocalization.DynamicLocalization;

namespace NetCoreWinFormLocDemo
{
    static class Program
    {
        public static DynamicLocalizationHost DynLocHost { get; } = new DynamicLocalizationHost();

        public static LocalizationHost LocHost { get; } = new LocalizationHost();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LocHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.en_US));
            LocHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.zh_CN));
            DynLocHost.LocalizationProvider = LocHost;
            Application.Run(new TestForm());
        }
    }
}
