#region File License

// File: ExtFunc.cs
// Project: AzwJsonLocalizationTemplate\AzwLocalization
// Creation Time: 2020/08/10 6:15 PM
// ------------------------------
// If you want to use this file for commercial, you should
// ask the permission of this file's original author.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#endregion

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