﻿namespace catwiftools
{
    partial class ControlPanelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rtbConsole = new RichTextBox();
            lvRunningTasks = new ListView();
            lblRecentAction = new Label();
            label1 = new Label();
            btnMinimise = new Button();
            btnCloseApp = new Button();
            lblConsole = new Label();
            rtbRecentAction = new RichTextBox();
            SuspendLayout();
            // 
            // rtbConsole
            // 
            rtbConsole.BackColor = Color.Black;
            rtbConsole.BorderStyle = BorderStyle.None;
            rtbConsole.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbConsole.ForeColor = Color.White;
            rtbConsole.Location = new Point(12, 44);
            rtbConsole.Name = "rtbConsole";
            rtbConsole.ReadOnly = true;
            rtbConsole.Size = new Size(382, 754);
            rtbConsole.TabIndex = 0;
            rtbConsole.Text = "";
            // 
            // lvRunningTasks
            // 
            lvRunningTasks.BackColor = Color.Black;
            lvRunningTasks.BorderStyle = BorderStyle.None;
            lvRunningTasks.ForeColor = Color.White;
            lvRunningTasks.Location = new Point(406, 44);
            lvRunningTasks.Name = "lvRunningTasks";
            lvRunningTasks.Size = new Size(382, 350);
            lvRunningTasks.TabIndex = 1;
            lvRunningTasks.UseCompatibleStateImageBehavior = false;
            // 
            // lblRecentAction
            // 
            lblRecentAction.AutoSize = true;
            lblRecentAction.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecentAction.ForeColor = Color.White;
            lblRecentAction.Location = new Point(406, 397);
            lblRecentAction.Name = "lblRecentAction";
            lblRecentAction.Size = new Size(151, 30);
            lblRecentAction.TabIndex = 3;
            lblRecentAction.Text = "Recent Actions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(406, 12);
            label1.Name = "label1";
            label1.Size = new Size(145, 30);
            label1.TabIndex = 4;
            label1.Text = "Running Tasks";
            // 
            // btnMinimise
            // 
            btnMinimise.BackColor = Color.DimGray;
            btnMinimise.FlatStyle = FlatStyle.Flat;
            btnMinimise.ImeMode = ImeMode.NoControl;
            btnMinimise.Location = new Point(738, 12);
            btnMinimise.Name = "btnMinimise";
            btnMinimise.Size = new Size(22, 22);
            btnMinimise.TabIndex = 28;
            btnMinimise.Text = "-";
            btnMinimise.UseVisualStyleBackColor = false;
            btnMinimise.Click += btnMinimise_Click;
            // 
            // btnCloseApp
            // 
            btnCloseApp.BackColor = Color.FromArgb(192, 0, 0);
            btnCloseApp.FlatStyle = FlatStyle.Flat;
            btnCloseApp.ImeMode = ImeMode.NoControl;
            btnCloseApp.Location = new Point(766, 12);
            btnCloseApp.Name = "btnCloseApp";
            btnCloseApp.Size = new Size(22, 22);
            btnCloseApp.TabIndex = 27;
            btnCloseApp.Text = "X";
            btnCloseApp.UseVisualStyleBackColor = false;
            btnCloseApp.Click += btnCloseApp_Click;
            // 
            // lblConsole
            // 
            lblConsole.AutoSize = true;
            lblConsole.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConsole.ForeColor = Color.White;
            lblConsole.Location = new Point(12, 12);
            lblConsole.Name = "lblConsole";
            lblConsole.Size = new Size(127, 30);
            lblConsole.TabIndex = 29;
            lblConsole.Text = "Console Log";
            // 
            // rtbRecentAction
            // 
            rtbRecentAction.BackColor = Color.Black;
            rtbRecentAction.BorderStyle = BorderStyle.None;
            rtbRecentAction.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbRecentAction.ForeColor = Color.White;
            rtbRecentAction.Location = new Point(406, 430);
            rtbRecentAction.Name = "rtbRecentAction";
            rtbRecentAction.ReadOnly = true;
            rtbRecentAction.Size = new Size(382, 366);
            rtbRecentAction.TabIndex = 30;
            rtbRecentAction.Text = "";
            // 
            // ControlPanelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(798, 808);
            ControlBox = false;
            Controls.Add(rtbRecentAction);
            Controls.Add(lblConsole);
            Controls.Add(btnMinimise);
            Controls.Add(btnCloseApp);
            Controls.Add(label1);
            Controls.Add(lblRecentAction);
            Controls.Add(lvRunningTasks);
            Controls.Add(rtbConsole);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ControlPanelForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbConsole;
        private ListView lvRunningTasks;
        private Label lblRecentAction;
        private Label label1;
        private Button btnMinimise;
        private Button btnCloseApp;
        private Label lblConsole;
        private RichTextBox rtbRecentAction;
    }
}