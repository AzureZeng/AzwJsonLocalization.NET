// File: LocalizationData.cs
// Project: AzwJsonLocalization\AzwJsonLocalization
// Creation Time: 2020/08/16 3:52 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#region Imports

using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Linq;

// ReSharper disable InconsistentNaming

#endregion

namespace AzureZeng.JsonLocalization
{
    public class LocalizationData
    {
        private readonly Dictionary<string, Dictionary<string, object>> _translateData;

        private string m_author = string.Empty;

        private string m_desc = string.Empty;

        private LocalizationData()
        {
            LanguageInfo = CultureInfo.CurrentUICulture;
            _translateData = new Dictionary<string, Dictionary<string, object>>();
            CreateNewNamespace("default");
        }

        /// <summary>
        ///     Initializes an empty <seealso cref="LocalizationData" /> instance.
        /// </summary>
        /// <param name="targetCultureInfo">The target language of this data instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="targetCultureInfo" /> is null</exception>
        public LocalizationData(CultureInfo targetCultureInfo)
        {
            if (targetCultureInfo == null) throw new ArgumentNullException(nameof(targetCultureInfo));
            LanguageInfo = CultureInfo.CurrentUICulture;
            _translateData = new Dictionary<string, Dictionary<string, object>>();
            CreateNewNamespace("default");
        }

        /// <summary>
        ///     The target language of this data.
        /// </summary>
        public CultureInfo LanguageInfo { get; private set; }

        /// <summary>
        ///     The author of this localization data. This property is usually defined in data JSON file.
        /// </summary>
        public string Author
        {
            get => m_author;
            set
            {
                if (value == null) value = string.Empty;
                m_author = value;
            }
        }

        /// <summary>
        ///     The description of this localization data. This property is usually defined in data JSON file.
        /// </summary>
        public string Description
        {
            get => m_desc;
            set
            {
                if (value == null) value = string.Empty;
                m_desc = value;
            }
        }

        /// <summary>
        ///     Get the names of data namespaces defined in this <seealso cref="LocalizationData" /> instance.
        /// </summary>
        public string[] DataNamespaceNames
        {
            get
            {
                var copy = new string[_translateData.Count];
                _translateData.Keys.CopyTo(copy, 0);
                return copy;
            }
        }

        /// <summary>
        ///     Get the specified data object in this <seealso cref="LocalizationData" /> instance.
        /// </summary>
        /// <param name="namespaceName">
        ///     The namespace name which contains the required object.
        ///     Will attempt to search in default namespace if this parameter set to null/empty/"default".
        /// </param>
        /// <param name="key">The key of this object. If this parameter is null or empty string, this property will return null.</param>
        /// <returns>The specified object. Or return null if this object is not found.</returns>
        public object this[string namespaceName, string key]
        {
            get
            {
                if (string.IsNullOrEmpty(key)) return null;
                if (string.IsNullOrEmpty(namespaceName) ||
                    string.Equals(namespaceName, "default", StringComparison.OrdinalIgnoreCase))
                    namespaceName = "default";
                if (_translateData.ContainsKey(namespaceName) && _translateData[namespaceName].ContainsKey(key))
                    return _translateData[namespaceName][key];
                return null;
            }
        }

        /// <summary>
        ///     Get the specified data object in this <seealso cref="LocalizationData" /> instance.
        /// </summary>
        /// <param name="key">The key of the object. This parameter can be also a path to a specified object.</param>
        /// <returns>The specified object. Return null if this object is not found, or the path given is invalid.</returns>
        public object this[string key] =>
            ParsePathString(key, out var namespaceName, out var _key)
                ? this[namespaceName, _key]
                : null;

        /// <summary>
        ///     Attempt to create a data namespace with specified name.
        /// </summary>
        /// <param name="namespaceName">The name of the namespace.</param>
        /// <returns>If created successfully, return true; otherwise return false.</returns>
        /// <exception cref="ArgumentException">The provided namespace name is invalid.</exception>
        public Dictionary<string, object> CreateNewNamespace(string namespaceName)
        {
            if (!ValidateName(namespaceName, true)) throw new ArgumentException("Invalid name.", nameof(namespaceName));
            if (string.IsNullOrEmpty(namespaceName) ||
                "default".Equals(namespaceName, StringComparison.OrdinalIgnoreCase)) namespaceName = "default";
            if (_translateData.ContainsKey(namespaceName)) return _translateData[namespaceName];
            var newNmsp = new Dictionary<string, object>();
            _translateData.Add(namespaceName, newNmsp);
            return newNmsp;
        }

        /// <summary>
        ///     Get the specified namespace dictionary.
        /// </summary>
        /// <param name="namespaceName">The name of required namespace.</param>
        /// <returns>The required namespace dictionary. Return null if this namespace is not defined.</returns>
        public Dictionary<string, object> GetDataNamespace(string namespaceName)
        {
            return _translateData.ContainsKey(namespaceName) ? _translateData[namespaceName] : null;
        }

        /// <summary>
        ///     Remove a specific namespace from this <seealso cref="LocalizationData" /> instance.
        /// </summary>
        /// <param name="namespaceName">The name of the specific namespace.</param>
        /// <returns>If removed successfully, return true. Otherwise, return false.</returns>
        public bool RemoveNamespace(string namespaceName)
        {
            if (string.IsNullOrEmpty(namespaceName) || namespaceName == "default" ||
                !_translateData.ContainsKey(namespaceName)) return false;
            return _translateData.Remove(namespaceName);
        }

        /// <summary>
        ///     Parse specific localization data and append these data to this instance.
        ///     Usually used to migrate multiple data to one instance.
        /// </summary>
        /// <param name="json">Target JSON string to be parsed and appended.</param>
        public void AppendFromJson(string json)
        {
            InternalParse(json, false);
        }

        /// <summary>
        ///     Create an <seealso cref="LocalizationData" /> instance and load data from a specified JSON string.
        /// </summary>
        /// <param name="json">The data JSON string.</param>
        /// <returns>The instance created.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="json" /> is empty string or null.</exception>
        public static LocalizationData ParseFromJson(string json)
        {
            var instance = new LocalizationData();
            instance.InternalParse(json, true);
            return instance;
        }

        private void InternalParse(string json, bool readDescFromJson)
        {
            if (string.IsNullOrEmpty(json)) throw new ArgumentException("Value cannot be null or empty.", nameof(json));
            var document = JObject.Parse(json);

            if (!(document["objects"] is JObject objects)) return;
            foreach (var i in objects) // Namespace loop
                if (!string.IsNullOrEmpty(i.Key) && ValidateName(i.Key, true) && i.Value is JObject j)
                {
                    var dict = CreateNewNamespace(i.Key);
                    foreach (var data in j) // Data loop
                        if (data.Value is JValue record && ValidateName(data.Key, false))
                            dict.Add(data.Key, record.Value);
                }

            if (readDescFromJson)
            {
                var targetCultureName = document.JObjectTryToGetValue("targetLanguage")?.ToString();
                if (!string.IsNullOrWhiteSpace(targetCultureName))
                    try
                    {
                        LanguageInfo = CultureInfo.GetCultureInfoByIetfLanguageTag(targetCultureName);
                    }
                    catch (CultureNotFoundException)
                    {
                        // Do not change anything.
                    }

                Author = document.JObjectTryToGetValue("author") as string;
                Description = document.JObjectTryToGetValue("description") as string;
            }
        }

        /// <summary>
        ///     Check whether a specific name is valid.
        /// </summary>
        /// <param name="n">The name string which required to be check.</param>
        /// <param name="isNamespaceName">If this parameter is true, the function will perform a namespace name check.</param>
        /// <returns>If the name is valid, return true; otherwise, false.</returns>
        public static bool ValidateName(string n, bool isNamespaceName)
        {
            if (string.IsNullOrEmpty(n))
                return isNamespaceName; // Default namespace

            if (n.Length == 1 && n[0] == '_') return false; // '_' string
            for (var i = 0; i < n.Length; i++)
            {
                var c = n[i];
                if (char.IsNumber(c) && i != 0) continue;
                if (char.IsLetter(c) || c == '_') continue;
                if (c == '.' && !isNamespaceName && i != 0 && i != n.Length - 1) continue;
                return false;
            }

            return true;
        }

        public static bool ParsePathString(string s, out string namespaceName, out string key)
        {
            if (string.IsNullOrWhiteSpace(s) || s[s.Length - 1] == ':') goto InvalidPathReturn;
            if (s.Contains(":"))
            {
                if (s[0] == ':')
                {
                    namespaceName = string.Empty;
                    key = s.Substring(1, s.Length - 1);
                    return true;
                }

                var idx = s.IndexOf(':');
                namespaceName = s.Substring(0, idx);
                key = s.Substring(idx + 1, s.Length - namespaceName.Length - 1);
                if (ValidateName(namespaceName, true) && ValidateName(key, false)) return true;
            }
            else
            {
                if (ValidateName(s, false))
                {
                    namespaceName = string.Empty;
                    key = s;
                    return true;
                }
            }

            InvalidPathReturn:
            namespaceName = null;
            key = null;
            return false;
        }
    }
}