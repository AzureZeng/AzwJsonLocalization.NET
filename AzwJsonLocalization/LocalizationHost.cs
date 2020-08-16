﻿#region File License

// File: LocalizationHost.cs
// Project: AzwJsonLocalizationTemplate\AzwLocalization
// Creation Time: 2020/08/10 3:13 PM
// ------------------------------
// If you want to use this file for commercial, you should
// ask the permission of this file's original author.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#endregion

using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace AzureZeng.JsonLocalization
{
    public class LocalizationHost
    {
        private readonly Collection<LocalizationData> _dataSet;

        private readonly ObservableCollection<CultureInfo> _availableLanguages;

        public ObservableCollection<CultureInfo> AvailableLanguages => _availableLanguages;

        /// <summary>
        /// Create an empty <seealso cref="LocalizationHost"/> instance.
        /// </summary>
        public LocalizationHost()
        {
            _dataSet = new Collection<LocalizationData>();
            _availableLanguages=new ObservableCollection<CultureInfo>();
        }
        
        private CultureInfo _defaultCultureInfo = CultureInfo.CurrentUICulture;

        /// <summary>
        /// Determines which language will be used if the specified localization data cannot be found.
        /// </summary>
        /// <exception cref="ArgumentNullException">Occurs when attempting to set this property to null.</exception>
        public CultureInfo DefaultCultureInfo
        {
            get => _defaultCultureInfo;
            set => _defaultCultureInfo = value ?? throw new ArgumentNullException(nameof(value));
        }

        private CultureInfo _selectedCultureInfo = CultureInfo.CurrentUICulture;

        /// <summary>
        /// Determines which language should be used in <seealso cref="GetObject(string,string)"/> and <seealso cref="GetObject(string)"/> overload(aka. default target language).
        /// This property will be ignored if the value of <seealso cref="UseCurrentUiCulture"/> is true.
        /// </summary>
        /// <exception cref="ArgumentNullException">Occurs when attempting to set this property to null.</exception>
        public CultureInfo SelectedCultureInfo
        {
            get => _selectedCultureInfo;
            set => _selectedCultureInfo = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Determines whether the default target language should use <seealso cref="CultureInfo.CurrentUICulture"/>.
        /// If the value of this property is false, the value of default target language will be <seealso cref="SelectedCultureInfo"/>.
        /// </summary>
        public bool UseCurrentUiCulture { get; set; }

        #region GetObject Methods

        /// <summary>
        /// Get a specified object from this <seealso cref="LocalizationHost"/> instance.
        /// </summary>
        /// <param name="key">The key or the path of the required object.</param>
        /// <param name="lang">The required target language.</param>
        /// <returns>The specified object. If this object is not found, or the path given is invalid, this function will return null.</returns>
        public object GetObject(string key, CultureInfo lang)
        {
            if (lang == null) throw new ArgumentNullException(nameof(lang));
            if (string.IsNullOrEmpty(key)) throw new ArgumentException(@"Value cannot be null or empty.", nameof(key));
            RefGetDataInstance(out var defaultData, out var targetData);
            var o = targetData?[key];
            return o ?? defaultData?[key];
        }

        /// <summary>
        /// Get a specified object from this <seealso cref="LocalizationHost"/> instance.
        /// </summary>
        /// <param name="namespaceName">The name of the namespace which contains the required object.</param>
        /// <param name="key">The key of the required object.</param>
        /// <param name="lang"></param>
        /// <returns>The specified object. If this object is not found, this function will return null.</returns>
        public object GetObject(string namespaceName, string key, CultureInfo lang)
        {
            if (lang == null) throw new ArgumentNullException(nameof(lang));
            if (string.IsNullOrEmpty(namespaceName)) namespaceName = "default";
            if (string.IsNullOrEmpty(key)) throw new ArgumentException(@"Value cannot be null or empty.", nameof(key));
            RefGetDataInstance(out var defaultData, out var targetData);
            var o = targetData?[namespaceName, key];
            return o ?? defaultData?[namespaceName, key];
        }

        /// <summary>
        /// Get a specified object from this <seealso cref="LocalizationHost"/> instance.
        /// </summary>
        /// <param name="key">The key or the path of the required object.</param>
        /// <returns>The specified object. If this object is not found, or the path given is invalid, this function will return null.</returns>
        public object GetObject(string key) => GetObject(key, GetSelectedCultureInfo());

        /// <summary>
        /// Get a specified object from this <seealso cref="LocalizationHost"/> instance.
        /// </summary>
        /// <param name="namespaceName">The name of the namespace which contains the required object.</param>
        /// <param name="key">The key of the required object.</param>
        /// <returns>The specified object. If this object is not found, this function will return null.</returns>
        public object GetObject(string namespaceName, string key) => GetObject(namespaceName, key, GetSelectedCultureInfo());

        private void RefGetDataInstance(out LocalizationData defaultData, out LocalizationData targetData)
        {
            defaultData = null;
            targetData = null;
            var target = GetSelectedCultureInfo();
            foreach (var c in _dataSet)
            {
                if (c.LanguageInfo.Equals(_defaultCultureInfo)) defaultData = c;
                if (c.LanguageInfo.Equals(target)) targetData = c;
            }
        }
        
        #endregion

        /// <summary>
        /// Get whether a specific language data is existed in this <seealso cref="LocalizationHost"/> instance.
        /// </summary>
        /// <param name="lang">The specific language.</param>
        /// <returns>If the specific language data is existed in this instance, this function will return true; otherwise, false.</returns>
        public bool ContainsLanguageData(CultureInfo lang)
        {
            if (lang == null) throw new ArgumentNullException(nameof(lang));
            foreach (var l in _dataSet)
            {
                if (lang.Equals(l.LanguageInfo)) return true;
            }
            return false;
        }

        /// <summary>
        /// Get the specified <seealso cref="LocalizationData"/> instance.
        /// </summary>
        /// <param name="lang">The target language of the specified instance.</param>
        /// <returns>If the specified instance can be found, return true; otherwise false.</returns>
        public LocalizationData GetLocalizationData(CultureInfo lang)
        {
            if (lang == null) return null;
            foreach (var i in _dataSet)
            {
                if (lang.Equals(i.LanguageInfo)) return i;
            }

            return null;
        }

        private CultureInfo GetSelectedCultureInfo()
        {
            if (UseCurrentUiCulture) return CultureInfo.CurrentUICulture;
            return _selectedCultureInfo;
        }

        #region Add/Remove Method

        /// <summary>
        /// Add a new <seealso cref="LocalizationData"/> instance to this localization host.
        /// </summary>
        /// <param name="data">The required instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Occurs when attempt to add a <seealso cref="LocalizationData"/> which this host already contains a <seealso cref="LocalizationData"/> that have the same target language.</exception>
        public void AddLocalizationData(LocalizationData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (ContainsLanguageData(data.LanguageInfo))
                throw new InvalidOperationException(
                    $"Cannot add a {nameof(LocalizationData)} instance that the target language already loaded in this {nameof(LocalizationHost)}. " +
                    $"If you want to add this {nameof(LocalizationData)} instance, you must remove the {nameof(LocalizationData)} which the target language is same in this host.");
            _dataSet.Add(data);
            _availableLanguages.Add(data.LanguageInfo);
        }

        /// <summary>
        /// Remove specific localization data from this <seealso cref="LocalizationHost"/>.
        /// </summary>
        /// <param name="data">The required <seealso cref="LocalizationData"/> instance.</param>
        /// <returns>If the required data is removed, return true; otherwise, false</returns>
        public bool RemoveLocalizationData(LocalizationData data)
        {
            if (data == null) return false;
            for (var index = 0; index < _dataSet.Count; index++)
            {
                var i = _dataSet[index];
                if (i == data)
                {
                    _dataSet.Remove(data);
                    _availableLanguages.Remove(data.LanguageInfo);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Remove specific localization data from this <seealso cref="LocalizationHost"/>.
        /// </summary>
        /// <param name="targetLang">The <seealso cref="CultureInfo"/> of target language.</param>
        /// <returns>If the required data is removed, return true; otherwise, false</returns>
        public bool RemoveLocalizationData(CultureInfo targetLang)
        {
            if (targetLang == null) return false;
            for (var index = 0; index < _dataSet.Count; index++)
            {
                var i = _dataSet[index];
                if (i.LanguageInfo.Equals(targetLang))
                {
                    _dataSet.Remove(i);
                    _availableLanguages.Remove(i.LanguageInfo);
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}