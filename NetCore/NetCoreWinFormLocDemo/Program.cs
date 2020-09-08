// File: Program.cs
// Project: AzwJsonLocalization\NetCoreWinFormLocDemo
// Creation Time: 2020/09/01 7:08 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

using System;
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
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LocHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.en_US));
            LocHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.zh_CN));
            DynLocHost.LocalizationProvider = LocHost;
            LocHost.UseCurrentUiCulture = true;
            Application.Run(new WelcomeForm());
            DynLocHost.Dispose(true);
        }

        public static bool IsRunningInNetCoreMode
        {
            get
            {
#if NETCOREAPP
                return true;
#else
                return false;
#endif
            }
        }
    }
}
