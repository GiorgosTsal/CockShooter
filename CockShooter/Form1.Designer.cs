﻿namespace CockShooter
{
    partial class CockShooter
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
            this.components = new System.ComponentModel.Container();
            this.timerLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerLoop
            // 
            this.timerLoop.Tick += new System.EventHandler(this.timerLoop_Tick);
            // 
            // CockShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CockShooter.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(796, 586);
            this.Name = "CockShooter";
            this.Text = "Cock Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLoop;
    }
}
