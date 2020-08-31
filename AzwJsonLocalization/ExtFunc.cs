// File: ExtFunc.cs
// Project: AzwJsonLocalization\AzwJsonLocalization
// Creation Time: 2020/08/16 3:54 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#region Imports

using System;
using Newtonsoft.Json.Linq;

#endregion

namespace AzureZeng.JsonLocalization
{
    internal static class ExtFunc
    {
        public static object JObjectTryToGetValue(this JObject target, string name,
            StringComparison comparisonMode = StringComparison.Ordinal)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (string.IsNullOrWhiteSpace(name)) return null;
            if (!target.TryGetValue(name, comparisonMode, out var valItem)) return null;
            return (valItem as JValue)?.Value; // if value is empty, return empty
        }
    }
}