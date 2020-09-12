using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AzureZeng.JsonLocalization;
using WPFLocalizeExtension.Engine;

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
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            LocalizationHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.zh_CN));
            LocalizationHost.AddLocalizationData(LocalizationData.ParseFromJson(AppRes.en_US));
        }

        public static event Action LocLanguageChanged;

        private static CultureInfo _selectedLanguage;

        public static CultureInfo SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value ?? throw new ArgumentNullException(nameof(value));
                LocalizeDictionary.Instance.Culture = value;
                CultureInfo.CurrentUICulture = value;
                LocalizationHost.SelectedCultureInfo = value;
                LocLanguageChanged?.Invoke();
            }
        }
    }
}
