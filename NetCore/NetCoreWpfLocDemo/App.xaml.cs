using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AzureZeng.JsonLocalization;

namespace NetCoreWpfLocDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LocalizationHost LocalizationHost { get; } = new LocalizationHost();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LocalizationHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.zh_CN));
            LocalizationHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.en_US));
        }
    }
}
