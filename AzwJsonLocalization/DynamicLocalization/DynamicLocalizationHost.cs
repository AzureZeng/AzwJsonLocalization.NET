﻿// File: DynamicLocalizationHost.cs
// Project: AzwJsonLocalization\AzwJsonLocalization
// Creation Time: 2020/08/16 11:32 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#region Imports

using System;
using System.Collections.ObjectModel;

#endregion

namespace AzureZeng.JsonLocalization.DynamicLocalization
{
    public class DynamicLocalizationHost : IDisposable
    {
        private readonly Collection<DynamicLocPropertyBinding> _bindings = new Collection<DynamicLocPropertyBinding>();

        private LocalizationHost _localizationProvider;

        public LocalizationHost LocalizationProvider
        {
            get => _localizationProvider;
            set
            {
                if (IsDisposed) throw new ObjectDisposedException(typeof(DynamicLocalizationHost).FullName);
                _localizationProvider = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public bool IsDisposed { get; private set; }

        /// <summary>
        ///     Determines whether exceptions thrown while updating localization should be ignored.
        ///     If the value of this property is true, exceptions will be ignored, but can still be seen in console output.
        /// </summary>
        public bool IgnoreUpdateLocException { get; set; } = true;

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                var array = new DynamicLocPropertyBinding[_bindings.Count];
                _bindings.CopyTo(array, 0);
                foreach (var a in array)
                    a.Dispose();
            }
            else
            {
                _bindings.Clear();
            }

            GC.SuppressFinalize(this);
            _localizationProvider = null;
            IsDisposed = true;
        }

        public DynamicLocPropertyBinding CreateNewBindingObject(object objKey)
        {
            if (objKey == null) throw new ArgumentNullException(nameof(objKey));
            foreach (var b in _bindings)
                if (b.ObjectKey == objKey)
                    throw new ArgumentException(
                        "Cannot create a new binding object which the key already exists in this host.",
                        nameof(objKey));
            var ret = new DynamicLocPropertyBinding(objKey);
            _bindings.Add(ret);
            ret.BindHost = this;
            return ret;
        }

        public bool RemoveObject(object objKey)
        {
            if (objKey == null) throw new ArgumentNullException(nameof(objKey));
            DynamicLocPropertyBinding b = null;
            foreach (var a in _bindings)
                if (a.ObjectKey == objKey)
                {
                    b = a;
                    break;
                }

            if (b == null) return false;
            _bindings.Remove(b);
            b.BindHost = null;
            return true;
        }

        public bool RemoveObject(DynamicLocPropertyBinding obj)
        {
            return obj != null && _bindings.Remove(obj);
        }

        public void UpdateLocalization()
        {
            foreach (var i in _bindings) i.UpdateLocalization();
        }

        ~DynamicLocalizationHost()
        {
            Dispose(false);
        }
    }
}