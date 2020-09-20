using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WPFLocalizeExtension.Engine;

namespace NetCoreWpfLocDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            LocalizeDictionary.SetDefaultProvider(this, JsonLocProvider.Instance);
            InitializeComponent();
            
            App.LocLanguageChanged += OnLocLangChanged;
            Closed += MainWindow_Closed;

            OnLocLangChanged();
            UpdateLanguageMenu(true);
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            App.LocLanguageChanged -= OnLocLangChanged;
        }

        private void OnLocLangChanged()
        {
            StatusIndicator.Text = App.LocalizationHost.GetObject("MainWindow:message.ready") as string;
        }

        public void UpdateLanguageMenu(bool refreshLanguageList)
        {
            if (refreshLanguageList)
            {
                foreach (FrameworkElement e in menu_selectLanguage.Items)
                {
                    if (e is MenuItem item) item.Click -= LanguageSelectMenu_Clicked;
                }
                menu_selectLanguage.Items.Clear();
                foreach (var i in App.LocalizationHost.AvailableLanguages)
                {
                    MenuItem menu = new MenuItem{Header = i.EnglishName, Tag = i};
                    menu.Click += LanguageSelectMenu_Clicked;
                    menu.IsChecked = i.Equals(App.SelectedLanguage); 
                    menu_selectLanguage.Items.Add(menu);
                }
            }
            else
            {
                foreach (FrameworkElement e in menu_selectLanguage.Items)
                {
                    if (e is MenuItem m) m.IsChecked = App.SelectedLanguage.Equals(e.Tag);
                }
            }
        }

        public void LanguageSelectMenu_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem castItem && castItem.Tag is CultureInfo castCultureInfo)
            {
                App.SelectedLanguage = castCultureInfo;
                UpdateLanguageMenu(false);
            }
        }
    }
}
