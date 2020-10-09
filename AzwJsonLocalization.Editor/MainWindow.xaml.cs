// File: MainWindow.xaml.cs
// Project: AzwJsonLocalization\AzwJsonLocalization.Editor
// Creation Time: 2020/09/21 3:13 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

#region Imports

using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using ControlzEx.Theming;
using Fluent;
using MahApps.Metro.Controls;

#endregion

namespace AzwJsonLocalization.Editor
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private Binding textContentBinding = new Binding(){ Path = new PropertyPath("TargetString")};

        public MainWindow()
        {
            InitializeComponent();
            foreach (var a in RibbonHost.Tabs)
                foreach (var b in a.Groups) 
                    b.CanAddToQuickAccessToolBar = false;
            
            
        }


    }
}