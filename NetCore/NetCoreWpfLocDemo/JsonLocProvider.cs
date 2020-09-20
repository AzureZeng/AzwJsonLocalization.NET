using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using WPFLocalizeExtension.Providers;

namespace NetCoreWpfLocDemo
{
    class JsonLocProvider : ILocalizationProvider
    {
        internal class JsonLocResourceKey : FullyQualifiedResourceKeyBase
        {
            public string Key { get; set; } = string.Empty;

            public override string ToString()
            {
                //return base.ToString();
                return Key ?? string.Empty;
            }
        }

        private static JsonLocProvider _instance;

        // ReSharper disable once ConvertToNullCoalescingCompoundAssignment
        public static JsonLocProvider Instance
        {
            get
            {
                var instance = _instance;
                if (instance != null)
                {
                    return instance;
                }

                return (_instance = new JsonLocProvider());
            }
        }

        public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
        {
            return new JsonLocResourceKey {Key = key};
        }

        public object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
        {
            var o = App.LocalizationHost.GetObject(key, culture);
            if (o == null)
            {
                ProviderError?.Invoke(this,
                    new ProviderErrorEventArgs(target, key, "Specific key cannot be found in the localization host."));
                return null;
            }

            return o;
        }

        public ObservableCollection<CultureInfo> AvailableCultures => App.LocalizationHost.AvailableLanguages;

        public event ProviderErrorEventHandler ProviderError;

        // Unsupported event
        event ProviderChangedEventHandler ILocalizationProvider.ProviderChanged
        {
            add {}
            remove {}
        }

        // Unsupported event
        event ValueChangedEventHandler ILocalizationProvider.ValueChanged
        {
            add{}
            remove {}
        }
    }
}
