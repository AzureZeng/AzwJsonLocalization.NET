// File: DynamicBindObject.cs
// Project: AzwJsonLocalization\AzwJsonLocalization
// Creation Time: 2020/08/17 11:14 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#region Imports

using System;
using System.Collections.ObjectModel;
using System.Reflection;

#endregion

namespace AzureZeng.JsonLocalization.DynamicLocalization
{
    public class DynamicBindObject
    {
        // object array format
        // propertyInfo, namespace, key
        internal readonly Collection<object[]> _bindProps = new Collection<object[]>();

        public DynamicBindObject(object targetObject)
        {
            TargetObject = targetObject ?? throw new ArgumentNullException(nameof(targetObject));
        }

        public object TargetObject { get; }

        public void RegisterNewProperty(string property, string namespaceName, string key)
        {
            if (!LocalizationData.ValidateName(namespaceName, true))
                throw new ArgumentException("Invalid namespace name.", nameof(namespaceName));
            if (!LocalizationData.ValidateName(key, false))
                throw new ArgumentException("Invalid key name.", nameof(key));
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Value cannot be null or empty.", nameof(key));
            var p = TargetObject.GetType().GetProperty(property);
            if (p == null)
                throw new ArgumentException(
                    $"Cannot find property {property} in type {TargetObject.GetType().FullName}");
            _bindProps.Add(new object[] {p, namespaceName, key});
        }

        public void RegisterNewProperty(string property, string keyOrPath)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (string.IsNullOrEmpty(keyOrPath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(keyOrPath));
            if (!LocalizationData.ParsePathString(keyOrPath, out var namespaceName, out var key))
                throw new ArgumentException("Invalid path or key.", nameof(keyOrPath));
            var p = TargetObject.GetType().GetProperty(property);
            if (p == null)
                throw new ArgumentException(
                    $"Cannot find property {property} in type {TargetObject.GetType().FullName}");
            _bindProps.Add(new object[] {p, namespaceName, key});
        }

        public void RegisterNewProperty(PropertyInfo property, string namespaceName, string key)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (!LocalizationData.ValidateName(namespaceName, true))
                throw new ArgumentException("Invalid namespace name.", nameof(namespaceName));
            if (!LocalizationData.ValidateName(key, false))
                throw new ArgumentException("Invalid key name.", nameof(key));
            // validate?
            _bindProps.Add(new object[] {property, namespaceName, key});
        }

        public void RegisterNewProperty(PropertyInfo property, string keyOrPath)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            if (string.IsNullOrEmpty(keyOrPath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(keyOrPath));
            if (!LocalizationData.ParsePathString(keyOrPath, out var namespaceName, out var key))
                throw new ArgumentException("Invalid path or key.", nameof(keyOrPath));
            // validate?
            _bindProps.Add(new object[] {property, namespaceName, key});
        }

        public void UnregisterProperty(string property)
        {
            object[] pi = null;
            foreach (var i in _bindProps)
            {
                if (!(i?[0] is PropertyInfo) || ((PropertyInfo) i[0]).Name != property) continue;
                pi = i;
                break;
            }

            if (pi != null) _bindProps.Remove(pi);
        }

        public void UnregisterProperty(PropertyInfo property)
        {
            object[] pi = null;
            foreach (var i in _bindProps)
            {
                if (!(i?[0] is PropertyInfo) || (PropertyInfo) i[0] != property) continue;
                pi = i;
                break;
            }

            if (pi != null) _bindProps.Remove(pi);
        }
    }
}