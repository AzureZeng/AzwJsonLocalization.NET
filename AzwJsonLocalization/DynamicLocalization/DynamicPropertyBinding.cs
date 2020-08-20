// File: DynamicPropertyBinder.cs
// Project: AzwJsonLocalization\AzwJsonLocalization
// Creation Time: 2020/08/17 11:50 AM
// ------------------------------
// If you want to use this file for commercial, you should
// ask the permission of this file's original author.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

using System;
using System.Collections.ObjectModel;
using System.Reflection;

namespace AzureZeng.JsonLocalization.DynamicLocalization
{
    public class DynamicPropertyBinding : IDisposable
    {
        private readonly Collection<DynamicBindObject> _bindObjects = new Collection<DynamicBindObject>();

        public DynamicPropertyBinding(object key)
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
            DynamicBindObject bind = null;
            foreach (var o in _bindObjects)
                if (o.TargetObject == obj)
                {
                    bind = o;
                    break;
                }

            if (bind != null) _bindObjects.Remove(bind);
        }

        public void UnregisterObject(DynamicBindObject obj)
        {
            DynamicBindObject bind = null;
            foreach (var o in _bindObjects)
                if (o == obj)
                {
                    bind = o;
                    break;
                }

            if (bind != null) _bindObjects.Remove(bind);
        }

        public DynamicBindObject RegisterNewObject(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            foreach (var o in _bindObjects)
                if (o.TargetObject == obj)
                    return o;
            var awsl = new DynamicBindObject(obj);
            _bindObjects.Add(awsl);
            return awsl;
        }

        public void RegisterNewObject(DynamicBindObject obj)
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
            if (IsDisposed) throw new ObjectDisposedException(typeof(DynamicPropertyBinding).FullName);
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
                    Action performLoc = delegate
                    {
                        var val = BindHost.LocalizationProvider.GetObject(b[1] as string, b[2] as string) ??
                                  $"Key: {b[1]}:{b[2]}";
                        pi.SetValue(a.TargetObject, val);
                    };
                    if (BindHost.IgnoreUpdateLocException)
                        try
                        {
                            performLoc.Invoke();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Localization Error:" + e);
                        }
                    else
                        performLoc.Invoke();
                }
            }
        }

        ~DynamicPropertyBinding()
        {
            Dispose();
        }
    }
}