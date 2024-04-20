using System;
using System.Drawing;
using System.Windows.Forms;

namespace Patcher.App
{
    partial class pForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.completeProgress = new System.Windows.Forms.ProgressBar();
            this.currentProgress = new System.Windows.Forms.ProgressBar();
            this.completeProgressText = new System.Windows.Forms.Label();
            this.currentProgressText = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 17);
            // 
            // completeProgress
            // 
            this.completeProgress.Location = new System.Drawing.Point(12, 64);
            this.completeProgress.Name = "completeProgress";
            this.completeProgress.Size = new System.Drawing.Size(436, 21);
            this.completeProgress.TabIndex = 1;
            // 
            // currentProgress
            // 
            this.currentProgress.Location = new System.Drawing.Point(12, 114);
            this.currentProgress.Name = "currentProgress";
            this.currentProgress.Size = new System.Drawing.Size(436, 21);
            this.currentProgress.TabIndex = 2;
            // 
            // completeProgressText
            // 
            this.completeProgressText.AutoSize = true;
            this.completeProgressText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.completeProgressText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.completeProgressText.Location = new System.Drawing.Point(9, 44);
            this.completeProgressText.Name = "completeProgressText";
            this.completeProgressText.Size = new System.Drawing.Size(106, 13);
            this.completeProgressText.TabIndex = 3;
            this.completeProgressText.Text = "Gesamtfortschritt: 0%";
            // 
            // currentProgressText
            // 
            this.currentProgressText.AutoSize = true;
            this.currentProgressText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currentProgressText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.currentProgressText.Location = new System.Drawing.Point(9, 94);
            this.currentProgressText.Name = "currentProgressText";
            this.currentProgressText.Size = new System.Drawing.Size(157, 13);
            this.currentProgressText.TabIndex = 4;
            this.currentProgressText.Text = "Dateifortschritt: 0%  |  0.00 KB/s";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Start.Enabled = false;
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Start.Location = new System.Drawing.Point(12, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(406, 23);
            this.Start.TabIndex = 5;
            this.Start.Text = "Spiel starten";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.settingsButton.Enabled = false;
            this.settingsButton.Image = global::Patcher.App.Properties.Resources.SettingsIcon;
            this.settingsButton.Location = new System.Drawing.Point(424, 11);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(24, 24);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // pForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(460, 170);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.currentProgressText);
            this.Controls.Add(this.completeProgressText);
            this.Controls.Add(this.currentProgress);
            this.Controls.Add(this.completeProgress);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(476, 209);
            this.MinimumSize = new System.Drawing.Size(476, 209);
            this.Name = "pForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invisible2 Patcher";
            this.Load += new System.EventHandler(this.pForm_Load);
            this.Shown += new System.EventHandler(this.pForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public  System.Windows.Forms.ToolStripStatusLabel   Status;
        public  System.Windows.Forms.ProgressBar            completeProgress;
        public  System.Windows.Forms.ProgressBar            currentProgress;
        public  System.Windows.Forms.Label                  completeProgressText;
        public  System.Windows.Forms.Label                  currentProgressText;
        public  System.Windows.Forms.Button                 Start;
        private Button settingsButton;
    }
}

