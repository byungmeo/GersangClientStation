
namespace GersangClientStation {
    partial class Form_Information {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Information));
            this.label_currentVersion = new MetroFramework.Controls.MetroLabel();
            this.label_latestVersion = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_release = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.button_license = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_currentVersion
            // 
            this.label_currentVersion.AutoSize = true;
            this.label_currentVersion.Location = new System.Drawing.Point(23, 205);
            this.label_currentVersion.Name = "label_currentVersion";
            this.label_currentVersion.Size = new System.Drawing.Size(113, 19);
            this.label_currentVersion.TabIndex = 0;
            this.label_currentVersion.Text = "현재 버전 : v0.0.0";
            // 
            // label_latestVersion
            // 
            this.label_latestVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_latestVersion.AutoSize = true;
            this.label_latestVersion.Location = new System.Drawing.Point(144, 205);
            this.label_latestVersion.Name = "label_latestVersion";
            this.label_latestVersion.Size = new System.Drawing.Size(113, 19);
            this.label_latestVersion.TabIndex = 1;
            this.label_latestVersion.Text = "최신 버전 : v0.0.0";
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(84, 160);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(192, 25);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "GersangClientStation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(150, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button_release
            // 
            this.button_release.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_release.Location = new System.Drawing.Point(275, 205);
            this.button_release.Name = "button_release";
            this.button_release.Size = new System.Drawing.Size(60, 23);
            this.button_release.TabIndex = 4;
            this.button_release.Text = "패치 노트";
            this.button_release.Click += new System.EventHandler(this.button_release_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 272);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(180, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Copyright © 2021 byungmeo";
            // 
            // button_license
            // 
            this.button_license.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_license.Location = new System.Drawing.Point(251, 270);
            this.button_license.Name = "button_license";
            this.button_license.Size = new System.Drawing.Size(86, 23);
            this.button_license.TabIndex = 6;
            this.button_license.Text = "오픈소스 정보";
            this.button_license.Click += new System.EventHandler(this.button_license_Click);
            // 
            // Form_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(360, 311);
            this.Controls.Add(this.button_license);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.button_release);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.label_latestVersion);
            this.Controls.Add(this.label_currentVersion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Information";
            this.Resizable = false;
            this.Text = "프로그램 정보";
            this.Load += new System.EventHandler(this.Form_Information_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label_currentVersion;
        private MetroFramework.Controls.MetroLabel label_latestVersion;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton button_release;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton button_license;
    }
}