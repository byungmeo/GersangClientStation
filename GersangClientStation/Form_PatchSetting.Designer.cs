
namespace GersangClientStation {
    partial class Form_PatchSetting {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PatchSetting));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBox_original_path = new MetroFramework.Controls.MetroTextBox();
            this.button_find = new MetroFramework.Controls.MetroButton();
            this.button_save = new MetroFramework.Controls.MetroButton();
            this.check_removeFile = new MetroFramework.Controls.MetroCheckBox();
            this.pathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.check_creator = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(71, 123);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(298, 38);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "거상 원본 폴더를 지정 해주세요.\r\n다클라 생성기로 만든 폴더는 지정하지 마세요.";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseStyleColors = true;
            // 
            // textBox_original_path
            // 
            this.textBox_original_path.Location = new System.Drawing.Point(23, 75);
            this.textBox_original_path.Name = "textBox_original_path";
            this.textBox_original_path.Size = new System.Drawing.Size(314, 23);
            this.textBox_original_path.TabIndex = 1;
            // 
            // button_find
            // 
            this.button_find.Location = new System.Drawing.Point(343, 75);
            this.button_find.Name = "button_find";
            this.button_find.Size = new System.Drawing.Size(75, 23);
            this.button_find.TabIndex = 2;
            this.button_find.Text = "찾기";
            this.button_find.Click += new System.EventHandler(this.button_find_Click);
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(183, 229);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "저장";
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // check_removeFile
            // 
            this.check_removeFile.AutoSize = true;
            this.check_removeFile.Checked = true;
            this.check_removeFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_removeFile.Location = new System.Drawing.Point(23, 187);
            this.check_removeFile.Name = "check_removeFile";
            this.check_removeFile.Size = new System.Drawing.Size(191, 15);
            this.check_removeFile.TabIndex = 4;
            this.check_removeFile.Text = "패치 완료 후 패치파일 삭제하기";
            this.check_removeFile.UseVisualStyleBackColor = true;
            this.check_removeFile.CheckedChanged += new System.EventHandler(this.check_removeFile_CheckedChanged);
            // 
            // pathBrowserDialog
            // 
            this.pathBrowserDialog.Description = "예시 : \"C:\\AKInteractive\\Gersang\"";
            this.pathBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.pathBrowserDialog.ShowNewFolderButton = false;
            // 
            // check_creator
            // 
            this.check_creator.AutoSize = true;
            this.check_creator.Checked = true;
            this.check_creator.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_creator.Location = new System.Drawing.Point(281, 187);
            this.check_creator.Name = "check_creator";
            this.check_creator.Size = new System.Drawing.Size(137, 15);
            this.check_creator.TabIndex = 5;
            this.check_creator.Text = "다클라 패치 적용하기";
            this.check_creator.UseVisualStyleBackColor = true;
            this.check_creator.CheckedChanged += new System.EventHandler(this.check_creator_CheckedChanged);
            // 
            // Form_PatchSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(441, 273);
            this.Controls.Add(this.check_creator);
            this.Controls.Add(this.check_removeFile);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_find);
            this.Controls.Add(this.textBox_original_path);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_PatchSetting";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "거상 패치 설정";
            this.Load += new System.EventHandler(this.Form_Patch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox textBox_original_path;
        private MetroFramework.Controls.MetroButton button_find;
        private MetroFramework.Controls.MetroButton button_save;
        private MetroFramework.Controls.MetroCheckBox check_removeFile;
        private System.Windows.Forms.FolderBrowserDialog pathBrowserDialog;
        private MetroFramework.Controls.MetroCheckBox check_creator;
    }
}