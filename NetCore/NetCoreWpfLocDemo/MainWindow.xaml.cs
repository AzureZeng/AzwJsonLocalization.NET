using System;
using System.Globalization;
using System.Windows;
using WPFLocalizeExtension.Engine;

namespace NetCoreWpfLocDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Action _onLocLangChanged;

        public MainWindow()
        {
            LocalizeDictionary.SetDefaultProvider(this, JsonLocProvider.Instance);
            InitializeComponent();
            
            _onLocLangChanged = OnLocLangChanged;
            App.LocLanguageChanged += _onLocLangChanged;

            Closed += MainWindow_Closed;

            OnLocLangChanged();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            App.LocLanguageChanged -= _onLocLangChanged;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.SelectedLanguage = CultureInfo.GetCultureInfoByIetfLanguageTag("zh-CN");
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            App.SelectedLanguage = CultureInfo.DefaultThreadCurrentUICulture;
        }

        private void OnLocLangChanged()
        {
            StatusIndicator.Text = App.LocalizationHost.GetObject("MainWindow:message.ready") as string;
        }
    }
}
