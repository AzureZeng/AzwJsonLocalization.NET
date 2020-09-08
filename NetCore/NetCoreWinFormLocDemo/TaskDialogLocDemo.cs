// File: TaskDialogLocDemo.cs
// Project: AzwJsonLocalization\NetCoreWinFormLocDemo
// Creation Time: 2020/09/02 10:46 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

using System;
using AzureZeng.JsonLocalization.DynamicLocalization;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace NetCoreWinFormLocDemo
{
    public static class TaskDialogLocDemo
    {
        public const string TranslateNamespace = "TaskDialogDemo";
        public static void ShowDialog(IntPtr handle)
        {
            var dlg = new TaskDialog
            {
                StandardButtons = TaskDialogStandardButtons.Close,
                Icon = TaskDialogStandardIcon.Information,
                FooterIcon = TaskDialogStandardIcon.Warning,
                Cancelable = true,
                Caption = Program.LocHost.GetObject(TranslateNamespace, "dialog.title").ToString(),
                InstructionText = Program.LocHost.GetObject(TranslateNamespace, "dialog.instruction").ToString(),
                Text = Program.LocHost.GetObject(TranslateNamespace, "dialog.text").ToString(),
                FooterText = Program.LocHost.GetObject(TranslateNamespace, "dialog.footerText").ToString()
            };

            var btnOpt1 = new TaskDialogCommandLink
            {
                Name="Option1",
                Instruction=Program.LocHost.GetObject(TranslateNamespace, "cmdLink.option1.note").ToString(),
                Text = Program.LocHost.GetObject(TranslateNamespace, "cmdLink.option1.text").ToString(),
                Enabled=true
            };
            dlg.Controls.Add(btnOpt1);
            dlg.Show();
        }
    }
}