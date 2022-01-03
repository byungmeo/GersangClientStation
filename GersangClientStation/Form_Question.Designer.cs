
namespace GersangClientStation {
    partial class Form_Question {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Question));
            this.link_1 = new MetroFramework.Controls.MetroLink();
            this.link_2 = new MetroFramework.Controls.MetroLink();
            this.link_3 = new MetroFramework.Controls.MetroLink();
            this.link_4 = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.link_5 = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // link_1
            // 
            this.link_1.AutoSize = true;
            this.link_1.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_1.Location = new System.Drawing.Point(23, 96);
            this.link_1.Name = "link_1";
            this.link_1.Size = new System.Drawing.Size(187, 22);
            this.link_1.Style = MetroFramework.MetroColorStyle.Red;
            this.link_1.TabIndex = 0;
            this.link_1.Text = "1. 거상 실행이 안돼요";
            this.link_1.UseStyleColors = true;
            this.link_1.Click += new System.EventHandler(this.link_1_Click);
            // 
            // link_2
            // 
            this.link_2.AutoSize = true;
            this.link_2.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_2.Location = new System.Drawing.Point(23, 136);
            this.link_2.Name = "link_2";
            this.link_2.Size = new System.Drawing.Size(346, 22);
            this.link_2.Style = MetroFramework.MetroColorStyle.Red;
            this.link_2.TabIndex = 1;
            this.link_2.Text = "2. 업데이트마다 설정을 다시 해야하나요?";
            this.link_2.UseStyleColors = true;
            this.link_2.Click += new System.EventHandler(this.link_2_Click);
            // 
            // link_3
            // 
            this.link_3.AutoSize = true;
            this.link_3.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_3.Location = new System.Drawing.Point(23, 176);
            this.link_3.Name = "link_3";
            this.link_3.Size = new System.Drawing.Size(225, 22);
            this.link_3.Style = MetroFramework.MetroColorStyle.Red;
            this.link_3.TabIndex = 2;
            this.link_3.Text = "3. 검색 보상이 안받아져요";
            this.link_3.UseStyleColors = true;
            this.link_3.Click += new System.EventHandler(this.link_3_Click);
            // 
            // link_4
            // 
            this.link_4.AutoSize = true;
            this.link_4.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_4.Location = new System.Drawing.Point(23, 216);
            this.link_4.Name = "link_4";
            this.link_4.Size = new System.Drawing.Size(240, 22);
            this.link_4.Style = MetroFramework.MetroColorStyle.Red;
            this.link_4.TabIndex = 3;
            this.link_4.Text = "4. 백신 프로그램이 차단해요";
            this.link_4.UseStyleColors = true;
            this.link_4.Click += new System.EventHandler(this.link_4_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(234, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "클릭하면 블로그 링크로 이동합니다.";
            this.metroLabel1.UseStyleColors = true;
            // 
            // link_5
            // 
            this.link_5.AutoSize = true;
            this.link_5.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.link_5.Location = new System.Drawing.Point(23, 256);
            this.link_5.Name = "link_5";
            this.link_5.Size = new System.Drawing.Size(154, 22);
            this.link_5.Style = MetroFramework.MetroColorStyle.Red;
            this.link_5.TabIndex = 5;
            this.link_5.Text = "5. e0010005 오류";
            this.link_5.UseStyleColors = true;
            this.link_5.Click += new System.EventHandler(this.link_5_Click);
            // 
            // Form_Question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(433, 309);
            this.Controls.Add(this.link_5);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.link_4);
            this.Controls.Add(this.link_3);
            this.Controls.Add(this.link_2);
            this.Controls.Add(this.link_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Question";
            this.Resizable = false;
            this.ShowInTaskbar = false;
            this.Text = "자주하는 질문";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLink link_1;
        private MetroFramework.Controls.MetroLink link_2;
        private MetroFramework.Controls.MetroLink link_3;
        private MetroFramework.Controls.MetroLink link_4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLink link_5;
    }
}