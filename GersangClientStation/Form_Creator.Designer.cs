
namespace GersangClientStation {
    partial class Form_Creator {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Creator));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBox_mainPath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.button_create = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.button_findPath = new MetroFramework.Controls.MetroButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 73);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(123, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "거상 경로 (본클라)";
            // 
            // textBox_mainPath
            // 
            this.textBox_mainPath.Location = new System.Drawing.Point(152, 73);
            this.textBox_mainPath.Name = "textBox_mainPath";
            this.textBox_mainPath.Size = new System.Drawing.Size(314, 23);
            this.textBox_mainPath.TabIndex = 1;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(215, 99);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(193, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "예시 : C:\\AKInteractive\\Gersang";
            this.metroLabel2.UseStyleColors = true;
            // 
            // button_create
            // 
            this.button_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_create.Location = new System.Drawing.Point(229, 240);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 3;
            this.button_create.Text = "생성하기";
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(29, 156);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(475, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "자동으로 같은 위치에 Gersang2, Gersang3라는 이름으로 폴더가 생성됩니다.";
            this.metroLabel3.UseStyleColors = true;
            // 
            // button_findPath
            // 
            this.button_findPath.Location = new System.Drawing.Point(472, 73);
            this.button_findPath.Name = "button_findPath";
            this.button_findPath.Size = new System.Drawing.Size(37, 23);
            this.button_findPath.TabIndex = 5;
            this.button_findPath.Text = "...";
            this.button_findPath.Click += new System.EventHandler(this.button_findPath_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "예시 : C:\\AKInteractive\\Gersang";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(109, 187);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(313, 38);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "아직 다클생성기의 기능을 완전히 이식하지 않아 \r\n단축키가 초기화될 수 있습니다.";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel4.UseStyleColors = true;
            // 
            // Form_Creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(532, 282);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.button_findPath);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.textBox_mainPath);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Creator";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "다클라 생성기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox textBox_mainPath;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton button_create;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton button_findPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}