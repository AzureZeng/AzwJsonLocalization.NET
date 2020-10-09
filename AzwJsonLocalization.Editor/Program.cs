// File: Program.cs
// Project: AzwJsonLocalization\AzwJsonLocalization.Editor
// Creation Time: 2020/09/27 2:54 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

using System;
using System.Windows;

namespace AzwJsonLocalization.Editor
{
    public static class Program
    {
        public static App CurrentAppInstance { get; private set; }

        [STAThread]
        private static int Main()
        {
            CurrentAppInstance = new App();
            return CurrentAppInstance.Run();
        }
    }
}