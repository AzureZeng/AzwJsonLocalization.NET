﻿// File: DynamicPropertyBinding.cs
// Project: AzwJsonLocalization\AzwJsonLocalization
// Creation Time: 2020/08/17 11:50 AM
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
    public class DynamicLocPropertyBinding : IDisposable
    {
        private readonly Collection<DynamicLocBindObject> _bindObjects = new Collection<DynamicLocBindObject>();

        public DynamicLocPropertyBinding(object key)
        {
            ObjectKey = key ?? throw new ArgumentNullException(nameof(key));
        }

        public object ObjectKey { get; internal set; }

        public DynamicLocalizationHost BindHost { get; internal set; }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            if (IsDisposed) return;
            _bindObjects.Clear();
            BindHost.RemoveObject(this);
            GC.SuppressFinalize(this);
            IsDisposed = true;
        }

        public void UnregisterObject(object obj)
        {
            DynamicLocBindObject locBind = null;
            foreach (var o in _bindObjects)
                if (o.TargetObject == obj)
                {
                    locBind = o;
                    break;
                }

            if (locBind != null) _bindObjects.Remove(locBind);
        }

        public void UnregisterObject(DynamicLocBindObject obj)
        {
            DynamicLocBindObject locBind = null;
            foreach (var o in _bindObjects)
                if (o == obj)
                {
                    locBind = o;
                    break;
                }

            if (locBind != null) _bindObjects.Remove(locBind);
        }

        public DynamicLocBindObject RegisterNewObject(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            foreach (var o in _bindObjects)
                if (o.TargetObject == obj)
                    return o;
            var awsl = new DynamicLocBindObject(obj);
            _bindObjects.Add(awsl);
            return awsl;
        }

        public void RegisterNewObject(DynamicLocBindObject obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            foreach (var a in _bindObjects)
                if (a == obj || a.TargetObject == obj.TargetObject)
                    throw new ArgumentException("Cannot register a object which is already registered.");
            _bindObjects.Add(obj);
        }

        public void RegisterNewProperty(object obj, string property, string namespaceName, string key)
        {
            var o = RegisterNewObject(obj);
            o.RegisterNewProperty(property, namespaceName, key);
        }

        public void RegisterNewProperty(object obj, PropertyInfo property, string namespaceName, string key)
        {
            var o = RegisterNewObject(obj);
            o.RegisterNewProperty(property, namespaceName, key);
        }

        public void RegisterNewProperty(object obj, string property, string keyOrPath)
        {
            var o = RegisterNewObject(obj);
            o.RegisterNewProperty(property, keyOrPath);
        }

        public void RegisterNewProperty(object obj, PropertyInfo property, string keyOrPath)
        {
            var o = RegisterNewObject(obj);
            o.RegisterNewProperty(property, keyOrPath);
        }

        public void UpdateLocalization()
        {
            if (IsDisposed) throw new ObjectDisposedException(typeof(DynamicLocPropertyBinding).FullName);
            if (BindHost == null)
                throw new InvalidOperationException(
                    $"Before calling this function, a {typeof(DynamicLocalizationHost).FullName} instance must be assigned to property {BindHost}.");
            if (BindHost.LocalizationProvider == null)
                throw new InvalidOperationException(
                    $"The assigned {typeof(DynamicLocalizationHost).FullName} must be assigned a {typeof(LocalizationHost).FullName}");
            foreach (var a in _bindObjects)
            foreach (var b in a._bindProps)
            {
                var pi = b[0] as PropertyInfo;
                if (pi != null)
                {
                    void PerformLoc()
                    {
                        var val = BindHost.LocalizationProvider.GetObject(b[1] as string, b[2] as string) ??
                                  $"Key: {(string.IsNullOrEmpty(b[1] as string) ? string.Empty : b[1] + ":")}{b[2]}";
                        pi.SetValue(a.TargetObject, val);
                    }

                    if (BindHost.IgnoreUpdateLocException)
                        try
                        {
                            PerformLoc();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Localization Error:" + e);
                        }
                    else
                        PerformLoc();
                }
            }

            UpdateLocalizationRequired?.Invoke(this, new EventArgs());
        }

        ~DynamicLocPropertyBinding()
        {
            Dispose();
        }

        public event EventHandler UpdateLocalizationRequired;
    }
}