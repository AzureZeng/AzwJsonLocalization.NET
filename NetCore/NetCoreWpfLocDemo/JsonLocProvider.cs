using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using WPFLocalizeExtension.Providers;

namespace NetCoreWpfLocDemo
{
    class JsonLocProvider:ILocalizationProvider
    {
        internal class JsonLocResourceKey:FullyQualifiedResourceKeyBase
        {
            public string Key { get; set; } = string.Empty;

            public override string ToString()
            {
                //return base.ToString();
                return Key ?? string.Empty;
            }
        }
        private static JsonLocProvider _instance;

        public static JsonLocProvider Instance
        {
            get { return _instance ??= new JsonLocProvider(); }
        }

        public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
        {
            return new JsonLocResourceKey{Key = key};
        }

        public object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
        {
            var o = App.LocalizationHost.GetObject(key, culture);
            if (o == null)
            {
                ProviderError?.Invoke(this,
                    new ProviderErrorEventArgs(target, key, "Specific key not found in localization host."));
                return null;
            }

            return o;
        }

        public ObservableCollection<CultureInfo> AvailableCultures => new ObservableCollection<CultureInfo>(App.LocalizationHost.AvailableLanguages);
        public event ProviderChangedEventHandler ProviderChanged;
        public event ProviderErrorEventHandler ProviderError;
        public event ValueChangedEventHandler ValueChanged;
    }
}
