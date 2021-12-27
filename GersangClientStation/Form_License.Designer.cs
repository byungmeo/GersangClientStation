
namespace GersangClientStation {
    partial class Form_License {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_License));
            this.link_gersangLauncher = new MetroFramework.Controls.MetroLink();
            this.link_octokit = new MetroFramework.Controls.MetroLink();
            this.link_costura = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // link_gersangLauncher
            // 
            this.link_gersangLauncher.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.link_gersangLauncher.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_gersangLauncher.Location = new System.Drawing.Point(23, 105);
            this.link_gersangLauncher.Name = "link_gersangLauncher";
            this.link_gersangLauncher.Size = new System.Drawing.Size(162, 23);
            this.link_gersangLauncher.TabIndex = 1;
            this.link_gersangLauncher.Text = "GersangLauncher";
            this.link_gersangLauncher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_gersangLauncher.Click += new System.EventHandler(this.link_gersangLauncher_Click);
            // 
            // link_octokit
            // 
            this.link_octokit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.link_octokit.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_octokit.Location = new System.Drawing.Point(23, 155);
            this.link_octokit.Name = "link_octokit";
            this.link_octokit.Size = new System.Drawing.Size(75, 23);
            this.link_octokit.TabIndex = 2;
            this.link_octokit.Text = "Octokit";
            this.link_octokit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_octokit.Click += new System.EventHandler(this.link_octokit_Click);
            // 
            // link_costura
            // 
            this.link_costura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.link_costura.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_costura.Location = new System.Drawing.Point(23, 205);
            this.link_costura.Name = "link_costura";
            this.link_costura.Size = new System.Drawing.Size(84, 23);
            this.link_costura.TabIndex = 3;
            this.link_costura.Text = "Costura";
            this.link_costura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.link_costura.Click += new System.EventHandler(this.link_costura_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(291, 38);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "거상 다클라 스테이션은 아래의 오픈소스들을\r\n참고 또는 사용 하여 제작 되었음을 알립니다..";
            this.metroLabel1.UseStyleColors = true;
            // 
            // Form_License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(342, 255);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.link_costura);
            this.Controls.Add(this.link_octokit);
            this.Controls.Add(this.link_gersangLauncher);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_License";
            this.Resizable = false;
            this.Text = "오픈소스 정보";
            this.Load += new System.EventHandler(this.Form_License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLink link_gersangLauncher;
        private MetroFramework.Controls.MetroLink link_octokit;
        private MetroFramework.Controls.MetroLink link_costura;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}