
namespace GersangClientStation {
    partial class Form_Patch {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Patch));
            this.listView1 = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currentProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_patchNote = new MetroFramework.Controls.MetroButton();
            this.label_patchVersion = new MetroFramework.Controls.MetroLabel();
            this.button_end = new MetroFramework.Controls.MetroButton();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.label_progress = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.filePath,
            this.currentProgress,
            this.fileSize,
            this.status});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(23, 110);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(603, 244);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // fileName
            // 
            this.fileName.Text = "파일명";
            this.fileName.Width = 140;
            // 
            // filePath
            // 
            this.filePath.Text = "경로";
            this.filePath.Width = 140;
            // 
            // currentProgress
            // 
            this.currentProgress.Text = "다운로드";
            this.currentProgress.Width = 80;
            // 
            // fileSize
            // 
            this.fileSize.Text = "파일크기";
            this.fileSize.Width = 80;
            // 
            // status
            // 
            this.status.Text = "상태";
            this.status.Width = 139;
            // 
            // button_patchNote
            // 
            this.button_patchNote.Location = new System.Drawing.Point(230, 66);
            this.button_patchNote.Name = "button_patchNote";
            this.button_patchNote.Size = new System.Drawing.Size(68, 23);
            this.button_patchNote.TabIndex = 3;
            this.button_patchNote.Text = "패치노트";
            this.button_patchNote.Click += new System.EventHandler(this.button_patchNote_Click);
            // 
            // label_patchVersion
            // 
            this.label_patchVersion.AutoSize = true;
            this.label_patchVersion.Location = new System.Drawing.Point(23, 68);
            this.label_patchVersion.Name = "label_patchVersion";
            this.label_patchVersion.Size = new System.Drawing.Size(201, 19);
            this.label_patchVersion.TabIndex = 4;
            this.label_patchVersion.Text = "업데이트 버전 : 00000 -> 00000";
            // 
            // button_end
            // 
            this.button_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_end.Enabled = false;
            this.button_end.Location = new System.Drawing.Point(284, 375);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(81, 23);
            this.button_end.TabIndex = 5;
            this.button_end.Text = "업데이트 종료";
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(336, 66);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(192, 23);
            this.progressBar.TabIndex = 6;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(534, 68);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(36, 19);
            this.label_progress.TabIndex = 7;
            this.label_progress.Text = "0 / 0";
            // 
            // Form_Patch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(649, 418);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.label_patchVersion);
            this.Controls.Add(this.button_patchNote);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Patch";
            this.Resizable = false;
            this.Text = "거상 패치";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Patch_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Patch_FormClosed);
            this.Load += new System.EventHandler(this.Form_Patch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader filePath;
        private System.Windows.Forms.ColumnHeader currentProgress;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.ColumnHeader status;
        private MetroFramework.Controls.MetroButton button_patchNote;
        private MetroFramework.Controls.MetroLabel label_patchVersion;
        private MetroFramework.Controls.MetroButton button_end;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel label_progress;
    }
}