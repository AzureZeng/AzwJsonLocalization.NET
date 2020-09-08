// File: WelcomeForm.cs
// Project: AzwJsonLocalization\NetCoreWinFormLocDemo
// Creation Time: 2020/09/01 7:08 PM
// ------------------------------
// If you want to use this file for commercial purpose, you should
// ask this file's original author for the permission of use.
// ------------------------------
// Copyright(C) 2014-2020, Azure Zeng(Individual).
// All rights reversed.

using System.Globalization;
using System.Windows.Forms;
using AzureZeng.JsonLocalization.DynamicLocalization;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace NetCoreWinFormLocDemo
{
    public class WelcomeForm:Form
    {

        #region WinForm Designer Generated Code

        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink commandLink1;
        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink commandLink2;
        private Label label2;
        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink commandLink3;
        private Label label3;
        private ComboBox comboBox1;
        private Button button1;
        private Label label1;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.commandLink1 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.commandLink2 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.label2 = new System.Windows.Forms.Label();
            this.commandLink3 = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.CommandLink();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 40);
            this.label1.TabIndex = 0;
            this.label1.Tag = "label.intro";
            this.label1.Text = "Welcome to AzwJsonLocalization demo!\r\nThis demo supports both .NET Core and .NET " +
    "Framework.";
            // 
            // commandLink1
            // 
            this.commandLink1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commandLink1.Location = new System.Drawing.Point(15, 60);
            this.commandLink1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commandLink1.Name = "commandLink1";
            this.commandLink1.NoteText = "Register all properties by code to implement localization.";
            this.commandLink1.Size = new System.Drawing.Size(539, 75);
            this.commandLink1.TabIndex = 1;
            this.commandLink1.Tag = "cmdLink.manualRegDemo";
            this.commandLink1.Text = "Manual Register Style Localization";
            this.commandLink1.UseVisualStyleBackColor = true;
            // 
            // commandLink2
            // 
            this.commandLink2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commandLink2.Location = new System.Drawing.Point(15, 142);
            this.commandLink2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commandLink2.Name = "commandLink2";
            this.commandLink2.NoteText = "Use specific function loop and foreach to apply property registering.";
            this.commandLink2.Size = new System.Drawing.Size(539, 75);
            this.commandLink2.TabIndex = 2;
            this.commandLink2.Tag = "cmdLink.autoRegDemo";
            this.commandLink2.Text = "Automatic Register Style Localization";
            this.commandLink2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 349);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "You are running in * mode";
            // 
            // commandLink3
            // 
            this.commandLink3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commandLink3.Location = new System.Drawing.Point(15, 225);
            this.commandLink3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commandLink3.Name = "commandLink3";
            this.commandLink3.NoteText = "Shows the dynamic TaskDialog localization dialog.";
            this.commandLink3.Size = new System.Drawing.Size(539, 75);
            this.commandLink3.TabIndex = 4;
            this.commandLink3.Tag = "cmdLink.taskDlgDemo";
            this.commandLink3.Text = "TaskDialog Dynamic Localization";
            this.commandLink3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 311);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 5;
            this.label3.Tag = "label.selectTargetLang";
            this.label3.Text = "Select target language:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(248, 308);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(305, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 344);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 29);
            this.button1.TabIndex = 8;
            this.button1.Tag = "button.shutdown";
            this.button1.Text = "&Shutdown";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(569, 386);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commandLink3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandLink2);
            this.Controls.Add(this.commandLink1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForms Localization Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private const string TranslateNamespace = "WelcomeForm";

        private DynamicLocPropertyBinding _propBind;

        public WelcomeForm()
        {
            InitializeComponent();

            // do localization
            _propBind = Program.DynLocHost.CreateNewBindingObject(this);
            AutoRegisterLoc(this);
            _propBind.UpdateLocalizationRequired += delegate
            {
                label2.Text = string.Format(Program.LocHost.GetObject(TranslateNamespace, "label.runningFrameworkMode") as string, Program.IsRunningInNetCoreMode?"Core":"Framework");
            };
            _propBind.UpdateLocalization();
            // end localization

            commandLink1.Click += CmdLink_ManualRegForm_Click;
            commandLink3.Click += CmdLink_TaskDlgLoc_Click;

            foreach (var i in Program.LocHost.AvailableLanguages)
            {
                comboBox1.Items.Add(i);
                if (i.Equals(CultureInfo.CurrentUICulture)) comboBox1.SelectedItem = i;
            }
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            button1.Click += delegate { Close(); };
            Closing += WelcomeForm_Closing;
        }

        private void CmdLink_TaskDlgLoc_Click(object sender, System.EventArgs e)
        {
            TaskDialogLocDemo.ShowDialog(Handle);
        }

        private void WelcomeForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(Program.LocHost.GetObject(TranslateNamespace, "message.sureToShutdown") as string, "Demo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) e.Cancel=true;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CultureInfo.CurrentUICulture = comboBox1.SelectedItem as CultureInfo;
            Program.DynLocHost.UpdateLocalization();
        }

        private void CmdLink_ManualRegForm_Click(object sender, System.EventArgs e)
        {
            new ManualRegTestForm().Show();
        }

        private void AutoRegisterLoc(Control ctl)
        {
            if (ctl is Form || ctl is GroupBox)
            {
                if(ctl.Tag != null) _propBind.RegisterNewProperty(ctl, "Text", TranslateNamespace, ctl.Tag.ToString());
                foreach (Control a in ctl.Controls) AutoRegisterLoc(a);
                
            }
            if ((ctl is Button || ctl is Label) && ctl.Tag !=null)
                _propBind.RegisterNewProperty(ctl, "Text", TranslateNamespace, ctl.Tag.ToString());
            if (ctl is CommandLink)
            {
                _propBind.RegisterNewProperty(ctl, nameof(CommandLink.Text), TranslateNamespace, ctl.Tag + ".text");
                _propBind.RegisterNewProperty(ctl, nameof(CommandLink.NoteText), TranslateNamespace, ctl.Tag + ".note");
            }
        }
    }
}