﻿namespace SirHurtAPI_Demo_App
{
    partial class MainForm
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
            this.scriptBox = new System.Windows.Forms.RichTextBox();
            this.InjectBtn = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Execute = new System.Windows.Forms.Button();
            this.EFF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scriptBox
            // 
            this.scriptBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scriptBox.Location = new System.Drawing.Point(1, 0);
            this.scriptBox.Name = "scriptBox";
            this.scriptBox.Size = new System.Drawing.Size(798, 418);
            this.scriptBox.TabIndex = 0;
            this.scriptBox.Text = "--This is an app using SirHurtAPI.\n";
            // 
            // InjectBtn
            // 
            this.InjectBtn.Location = new System.Drawing.Point(12, 424);
            this.InjectBtn.Name = "InjectBtn";
            this.InjectBtn.Size = new System.Drawing.Size(75, 23);
            this.InjectBtn.TabIndex = 1;
            this.InjectBtn.Text = "Inject";
            this.InjectBtn.UseVisualStyleBackColor = true;
            this.InjectBtn.Click += new System.EventHandler(this.InjectBtn_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(713, 424);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Execute
            // 
            this.Execute.Location = new System.Drawing.Point(93, 424);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(307, 23);
            this.Execute.TabIndex = 3;
            this.Execute.Text = "Execute";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // EFF
            // 
            this.EFF.Location = new System.Drawing.Point(406, 424);
            this.EFF.Name = "EFF";
            this.EFF.Size = new System.Drawing.Size(301, 23);
            this.EFF.TabIndex = 4;
            this.EFF.Text = "Execute from file";
            this.EFF.UseVisualStyleBackColor = true;
            this.EFF.Click += new System.EventHandler(this.EFF_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EFF);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.InjectBtn);
            this.Controls.Add(this.scriptBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SirHurtAPI Demo Application";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox scriptBox;
        private System.Windows.Forms.Button InjectBtn;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.Button EFF;
    }
}

