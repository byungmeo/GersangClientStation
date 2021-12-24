
namespace GersangClientStation {
    partial class Form_Main {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuItem_client = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_shortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_lab = new System.Windows.Forms.ToolStripMenuItem();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.check_nickname2 = new MetroFramework.Controls.MetroCheckBox();
            this.button_start_2 = new System.Windows.Forms.Button();
            this.button_search_naver2 = new System.Windows.Forms.Button();
            this.toggle_client_2 = new MetroFramework.Controls.MetroToggle();
            this.label_client_2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.check_nickname3 = new MetroFramework.Controls.MetroCheckBox();
            this.button_start_3 = new System.Windows.Forms.Button();
            this.button_search_naver3 = new System.Windows.Forms.Button();
            this.toggle_client_3 = new MetroFramework.Controls.MetroToggle();
            this.label_client_3 = new MetroFramework.Controls.MetroLabel();
            this.label_client_1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.check_nickname1 = new MetroFramework.Controls.MetroCheckBox();
            this.button_start_1 = new System.Windows.Forms.Button();
            this.button_search_naver_1 = new System.Windows.Forms.Button();
            this.toggle_client_1 = new MetroFramework.Controls.MetroToggle();
            this.radio_setting_1 = new MetroFramework.Controls.MetroRadioButton();
            this.radio_setting_2 = new MetroFramework.Controls.MetroRadioButton();
            this.radio_setting_3 = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox_setting = new System.Windows.Forms.GroupBox();
            this.radio_setting_4 = new MetroFramework.Controls.MetroRadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.link_blog = new MetroFramework.Controls.MetroLink();
            this.pic_naver = new System.Windows.Forms.PictureBox();
            this.pic_github = new System.Windows.Forms.PictureBox();
            this.link_github = new MetroFramework.Controls.MetroLink();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.link_shortcut_5 = new MetroFramework.Controls.MetroLink();
            this.link_shortcut_4 = new MetroFramework.Controls.MetroLink();
            this.link_shortcut_3 = new MetroFramework.Controls.MetroLink();
            this.link_shortcut_2 = new MetroFramework.Controls.MetroLink();
            this.link_shortcut_1 = new MetroFramework.Controls.MetroLink();
            this.link_qa1 = new MetroFramework.Controls.MetroLink();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.link_qa2 = new MetroFramework.Controls.MetroLink();
            this.link_icon_license = new MetroFramework.Controls.MetroLink();
            this.menuItem_info = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.groupBox_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_naver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_github)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_client,
            this.menuItem_shortcut,
            this.menuItem_lab,
            this.menuItem_info});
            this.menuStrip2.Location = new System.Drawing.Point(488, 60);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip2.Size = new System.Drawing.Size(197, 471);
            this.menuStrip2.TabIndex = 13;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // menuItem_client
            // 
            this.menuItem_client.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_client.Image")));
            this.menuItem_client.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_client.Name = "menuItem_client";
            this.menuItem_client.Size = new System.Drawing.Size(190, 28);
            this.menuItem_client.Text = "클라이언트 설정         ";
            this.menuItem_client.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuItem_client.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuItem_shortcut
            // 
            this.menuItem_shortcut.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_shortcut.Image")));
            this.menuItem_shortcut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_shortcut.Name = "menuItem_shortcut";
            this.menuItem_shortcut.Size = new System.Drawing.Size(190, 28);
            this.menuItem_shortcut.Text = "바로가기 경로 설정    ";
            this.menuItem_shortcut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuItem_shortcut.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // menuItem_lab
            // 
            this.menuItem_lab.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_lab.Image")));
            this.menuItem_lab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_lab.Name = "menuItem_lab";
            this.menuItem_lab.Size = new System.Drawing.Size(190, 28);
            this.menuItem_lab.Text = "실험실                     ";
            this.menuItem_lab.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuItem_lab.Click += new System.EventHandler(this.menuItem_lab_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.check_nickname2);
            this.metroPanel2.Controls.Add(this.button_start_2);
            this.metroPanel2.Controls.Add(this.button_search_naver2);
            this.metroPanel2.Controls.Add(this.toggle_client_2);
            this.metroPanel2.Controls.Add(this.label_client_2);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(23, 230);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(290, 130);
            this.metroPanel2.TabIndex = 15;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // check_nickname2
            // 
            this.check_nickname2.AutoSize = true;
            this.check_nickname2.Checked = true;
            this.check_nickname2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_nickname2.Location = new System.Drawing.Point(186, 20);
            this.check_nickname2.Name = "check_nickname2";
            this.check_nickname2.Size = new System.Drawing.Size(74, 15);
            this.check_nickname2.TabIndex = 29;
            this.check_nickname2.Text = "별명 표시";
            this.check_nickname2.UseVisualStyleBackColor = true;
            this.check_nickname2.CheckedChanged += new System.EventHandler(this.check_nickname_CheckedChanged);
            // 
            // button_start_2
            // 
            this.button_start_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start_2.AutoSize = true;
            this.button_start_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_start_2.FlatAppearance.BorderSize = 0;
            this.button_start_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start_2.Image = ((System.Drawing.Image)(resources.GetObject("button_start_2.Image")));
            this.button_start_2.Location = new System.Drawing.Point(200, 50);
            this.button_start_2.Name = "button_start_2";
            this.button_start_2.Size = new System.Drawing.Size(70, 70);
            this.button_start_2.TabIndex = 28;
            this.button_start_2.TabStop = false;
            this.button_start_2.Text = "게임실행";
            this.button_start_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_start_2.UseVisualStyleBackColor = true;
            this.button_start_2.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_search_naver2
            // 
            this.button_search_naver2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_search_naver2.AutoSize = true;
            this.button_search_naver2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_search_naver2.FlatAppearance.BorderSize = 0;
            this.button_search_naver2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_search_naver2.Image = ((System.Drawing.Image)(resources.GetObject("button_search_naver2.Image")));
            this.button_search_naver2.Location = new System.Drawing.Point(110, 50);
            this.button_search_naver2.Name = "button_search_naver2";
            this.button_search_naver2.Size = new System.Drawing.Size(70, 70);
            this.button_search_naver2.TabIndex = 27;
            this.button_search_naver2.TabStop = false;
            this.button_search_naver2.Text = "검색보상";
            this.button_search_naver2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_search_naver2.UseVisualStyleBackColor = true;
            this.button_search_naver2.Click += new System.EventHandler(this.button_search_naver_Click);
            // 
            // toggle_client_2
            // 
            this.toggle_client_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggle_client_2.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.toggle_client_2.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.toggle_client_2.Location = new System.Drawing.Point(20, 65);
            this.toggle_client_2.Name = "toggle_client_2";
            this.toggle_client_2.Size = new System.Drawing.Size(70, 40);
            this.toggle_client_2.TabIndex = 25;
            this.toggle_client_2.Text = "Off";
            this.toggle_client_2.UseVisualStyleBackColor = true;
            this.toggle_client_2.Click += new System.EventHandler(this.toggle_client_2_Click);
            // 
            // label_client_2
            // 
            this.label_client_2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label_client_2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.label_client_2.Location = new System.Drawing.Point(10, 10);
            this.label_client_2.Name = "label_client_2";
            this.label_client_2.Size = new System.Drawing.Size(165, 25);
            this.label_client_2.TabIndex = 7;
            this.label_client_2.Text = "Client2";
            this.label_client_2.UseStyleColors = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.check_nickname3);
            this.metroPanel3.Controls.Add(this.button_start_3);
            this.metroPanel3.Controls.Add(this.button_search_naver3);
            this.metroPanel3.Controls.Add(this.toggle_client_3);
            this.metroPanel3.Controls.Add(this.label_client_3);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(23, 401);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(290, 130);
            this.metroPanel3.TabIndex = 16;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // check_nickname3
            // 
            this.check_nickname3.AutoSize = true;
            this.check_nickname3.Checked = true;
            this.check_nickname3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_nickname3.Location = new System.Drawing.Point(186, 20);
            this.check_nickname3.Name = "check_nickname3";
            this.check_nickname3.Size = new System.Drawing.Size(74, 15);
            this.check_nickname3.TabIndex = 31;
            this.check_nickname3.Text = "별명 표시";
            this.check_nickname3.UseVisualStyleBackColor = true;
            this.check_nickname3.CheckedChanged += new System.EventHandler(this.check_nickname_CheckedChanged);
            // 
            // button_start_3
            // 
            this.button_start_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start_3.AutoSize = true;
            this.button_start_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_start_3.FlatAppearance.BorderSize = 0;
            this.button_start_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start_3.Image = ((System.Drawing.Image)(resources.GetObject("button_start_3.Image")));
            this.button_start_3.Location = new System.Drawing.Point(200, 50);
            this.button_start_3.Name = "button_start_3";
            this.button_start_3.Size = new System.Drawing.Size(70, 70);
            this.button_start_3.TabIndex = 30;
            this.button_start_3.TabStop = false;
            this.button_start_3.Text = "게임실행";
            this.button_start_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_start_3.UseVisualStyleBackColor = true;
            this.button_start_3.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_search_naver3
            // 
            this.button_search_naver3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_search_naver3.AutoSize = true;
            this.button_search_naver3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_search_naver3.FlatAppearance.BorderSize = 0;
            this.button_search_naver3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_search_naver3.Image = ((System.Drawing.Image)(resources.GetObject("button_search_naver3.Image")));
            this.button_search_naver3.Location = new System.Drawing.Point(110, 50);
            this.button_search_naver3.Name = "button_search_naver3";
            this.button_search_naver3.Size = new System.Drawing.Size(70, 70);
            this.button_search_naver3.TabIndex = 29;
            this.button_search_naver3.TabStop = false;
            this.button_search_naver3.Text = "검색보상";
            this.button_search_naver3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_search_naver3.UseVisualStyleBackColor = true;
            this.button_search_naver3.Click += new System.EventHandler(this.button_search_naver_Click);
            // 
            // toggle_client_3
            // 
            this.toggle_client_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggle_client_3.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.toggle_client_3.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.toggle_client_3.Location = new System.Drawing.Point(20, 65);
            this.toggle_client_3.Name = "toggle_client_3";
            this.toggle_client_3.Size = new System.Drawing.Size(70, 40);
            this.toggle_client_3.TabIndex = 26;
            this.toggle_client_3.Text = "Off";
            this.toggle_client_3.UseVisualStyleBackColor = true;
            this.toggle_client_3.Click += new System.EventHandler(this.toggle_client_3_Click);
            // 
            // label_client_3
            // 
            this.label_client_3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label_client_3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.label_client_3.Location = new System.Drawing.Point(10, 10);
            this.label_client_3.Name = "label_client_3";
            this.label_client_3.Size = new System.Drawing.Size(165, 25);
            this.label_client_3.TabIndex = 10;
            this.label_client_3.Text = "Client3";
            this.label_client_3.UseStyleColors = true;
            // 
            // label_client_1
            // 
            this.label_client_1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label_client_1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.label_client_1.Location = new System.Drawing.Point(10, 10);
            this.label_client_1.Name = "label_client_1";
            this.label_client_1.Size = new System.Drawing.Size(165, 25);
            this.label_client_1.TabIndex = 6;
            this.label_client_1.Text = "MainClient";
            this.label_client_1.UseStyleColors = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.check_nickname1);
            this.metroPanel1.Controls.Add(this.button_start_1);
            this.metroPanel1.Controls.Add(this.button_search_naver_1);
            this.metroPanel1.Controls.Add(this.toggle_client_1);
            this.metroPanel1.Controls.Add(this.label_client_1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(290, 130);
            this.metroPanel1.TabIndex = 14;
            this.metroPanel1.VerticalScrollbarBarColor = false;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // check_nickname1
            // 
            this.check_nickname1.AutoSize = true;
            this.check_nickname1.Checked = true;
            this.check_nickname1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_nickname1.Location = new System.Drawing.Point(186, 20);
            this.check_nickname1.Name = "check_nickname1";
            this.check_nickname1.Size = new System.Drawing.Size(74, 15);
            this.check_nickname1.TabIndex = 27;
            this.check_nickname1.Text = "별명 표시";
            this.check_nickname1.UseVisualStyleBackColor = true;
            this.check_nickname1.CheckedChanged += new System.EventHandler(this.check_nickname_CheckedChanged);
            // 
            // button_start_1
            // 
            this.button_start_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start_1.AutoSize = true;
            this.button_start_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_start_1.FlatAppearance.BorderSize = 0;
            this.button_start_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start_1.Image = ((System.Drawing.Image)(resources.GetObject("button_start_1.Image")));
            this.button_start_1.Location = new System.Drawing.Point(200, 50);
            this.button_start_1.Name = "button_start_1";
            this.button_start_1.Size = new System.Drawing.Size(70, 70);
            this.button_start_1.TabIndex = 26;
            this.button_start_1.TabStop = false;
            this.button_start_1.Text = "게임실행";
            this.button_start_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_start_1.UseVisualStyleBackColor = true;
            this.button_start_1.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_search_naver_1
            // 
            this.button_search_naver_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_search_naver_1.AutoSize = true;
            this.button_search_naver_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_search_naver_1.FlatAppearance.BorderSize = 0;
            this.button_search_naver_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_search_naver_1.Image = ((System.Drawing.Image)(resources.GetObject("button_search_naver_1.Image")));
            this.button_search_naver_1.Location = new System.Drawing.Point(110, 50);
            this.button_search_naver_1.Name = "button_search_naver_1";
            this.button_search_naver_1.Size = new System.Drawing.Size(70, 70);
            this.button_search_naver_1.TabIndex = 25;
            this.button_search_naver_1.TabStop = false;
            this.button_search_naver_1.Text = "검색보상";
            this.button_search_naver_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_search_naver_1.UseVisualStyleBackColor = true;
            this.button_search_naver_1.Click += new System.EventHandler(this.button_search_naver_Click);
            // 
            // toggle_client_1
            // 
            this.toggle_client_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggle_client_1.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.toggle_client_1.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.toggle_client_1.Location = new System.Drawing.Point(20, 65);
            this.toggle_client_1.Name = "toggle_client_1";
            this.toggle_client_1.Size = new System.Drawing.Size(70, 40);
            this.toggle_client_1.TabIndex = 24;
            this.toggle_client_1.Text = "Off";
            this.toggle_client_1.UseVisualStyleBackColor = true;
            this.toggle_client_1.Click += new System.EventHandler(this.toggle_client_1_Click);
            // 
            // radio_setting_1
            // 
            this.radio_setting_1.AutoSize = true;
            this.radio_setting_1.Location = new System.Drawing.Point(26, 27);
            this.radio_setting_1.Name = "radio_setting_1";
            this.radio_setting_1.Size = new System.Drawing.Size(68, 15);
            this.radio_setting_1.TabIndex = 19;
            this.radio_setting_1.TabStop = true;
            this.radio_setting_1.Text = "1번 설정";
            this.radio_setting_1.UseVisualStyleBackColor = true;
            this.radio_setting_1.CheckedChanged += new System.EventHandler(this.radio_setting_CheckedChanged);
            // 
            // radio_setting_2
            // 
            this.radio_setting_2.AutoSize = true;
            this.radio_setting_2.Location = new System.Drawing.Point(26, 58);
            this.radio_setting_2.Name = "radio_setting_2";
            this.radio_setting_2.Size = new System.Drawing.Size(68, 15);
            this.radio_setting_2.TabIndex = 20;
            this.radio_setting_2.TabStop = true;
            this.radio_setting_2.Text = "2번 설정";
            this.radio_setting_2.UseVisualStyleBackColor = true;
            this.radio_setting_2.CheckedChanged += new System.EventHandler(this.radio_setting_CheckedChanged);
            // 
            // radio_setting_3
            // 
            this.radio_setting_3.AutoSize = true;
            this.radio_setting_3.Location = new System.Drawing.Point(26, 88);
            this.radio_setting_3.Name = "radio_setting_3";
            this.radio_setting_3.Size = new System.Drawing.Size(68, 15);
            this.radio_setting_3.TabIndex = 21;
            this.radio_setting_3.TabStop = true;
            this.radio_setting_3.Text = "3번 설정";
            this.radio_setting_3.UseVisualStyleBackColor = true;
            this.radio_setting_3.CheckedChanged += new System.EventHandler(this.radio_setting_CheckedChanged);
            // 
            // groupBox_setting
            // 
            this.groupBox_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_setting.Controls.Add(this.radio_setting_4);
            this.groupBox_setting.Controls.Add(this.radio_setting_3);
            this.groupBox_setting.Controls.Add(this.radio_setting_1);
            this.groupBox_setting.Controls.Add(this.radio_setting_2);
            this.groupBox_setting.Location = new System.Drawing.Point(335, 60);
            this.groupBox_setting.Name = "groupBox_setting";
            this.groupBox_setting.Size = new System.Drawing.Size(129, 160);
            this.groupBox_setting.TabIndex = 22;
            this.groupBox_setting.TabStop = false;
            this.groupBox_setting.Text = "클라이언트 설정";
            // 
            // radio_setting_4
            // 
            this.radio_setting_4.AutoSize = true;
            this.radio_setting_4.Location = new System.Drawing.Point(26, 118);
            this.radio_setting_4.Name = "radio_setting_4";
            this.radio_setting_4.Size = new System.Drawing.Size(68, 15);
            this.radio_setting_4.TabIndex = 22;
            this.radio_setting_4.TabStop = true;
            this.radio_setting_4.Text = "4번 설정";
            this.radio_setting_4.UseVisualStyleBackColor = true;
            this.radio_setting_4.CheckedChanged += new System.EventHandler(this.radio_setting_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(268, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // link_blog
            // 
            this.link_blog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_blog.AutoSize = true;
            this.link_blog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.link_blog.Location = new System.Drawing.Point(504, 27);
            this.link_blog.Name = "link_blog";
            this.link_blog.Size = new System.Drawing.Size(40, 22);
            this.link_blog.TabIndex = 24;
            this.link_blog.Text = "Blog";
            this.link_blog.Click += new System.EventHandler(this.link_blog_Click);
            // 
            // pic_naver
            // 
            this.pic_naver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_naver.Image = ((System.Drawing.Image)(resources.GetObject("pic_naver.Image")));
            this.pic_naver.Location = new System.Drawing.Point(490, 32);
            this.pic_naver.Name = "pic_naver";
            this.pic_naver.Size = new System.Drawing.Size(14, 14);
            this.pic_naver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_naver.TabIndex = 25;
            this.pic_naver.TabStop = false;
            // 
            // pic_github
            // 
            this.pic_github.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_github.Image = ((System.Drawing.Image)(resources.GetObject("pic_github.Image")));
            this.pic_github.Location = new System.Drawing.Point(552, 32);
            this.pic_github.Name = "pic_github";
            this.pic_github.Size = new System.Drawing.Size(14, 14);
            this.pic_github.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_github.TabIndex = 26;
            this.pic_github.TabStop = false;
            // 
            // link_github
            // 
            this.link_github.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_github.AutoSize = true;
            this.link_github.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.link_github.Location = new System.Drawing.Point(566, 27);
            this.link_github.Name = "link_github";
            this.link_github.Size = new System.Drawing.Size(51, 22);
            this.link_github.TabIndex = 27;
            this.link_github.Text = "Github";
            this.link_github.Click += new System.EventHandler(this.link_github_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.link_shortcut_5);
            this.groupBox1.Controls.Add(this.link_shortcut_4);
            this.groupBox1.Controls.Add(this.link_shortcut_3);
            this.groupBox1.Controls.Add(this.link_shortcut_2);
            this.groupBox1.Controls.Add(this.link_shortcut_1);
            this.groupBox1.Location = new System.Drawing.Point(335, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 160);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "바로가기";
            // 
            // link_shortcut_5
            // 
            this.link_shortcut_5.Location = new System.Drawing.Point(27, 125);
            this.link_shortcut_5.Name = "link_shortcut_5";
            this.link_shortcut_5.Size = new System.Drawing.Size(75, 23);
            this.link_shortcut_5.TabIndex = 4;
            this.link_shortcut_5.Text = "바로가기5";
            this.link_shortcut_5.Click += new System.EventHandler(this.link_shortcut_5_Click);
            // 
            // link_shortcut_4
            // 
            this.link_shortcut_4.Location = new System.Drawing.Point(27, 100);
            this.link_shortcut_4.Name = "link_shortcut_4";
            this.link_shortcut_4.Size = new System.Drawing.Size(75, 23);
            this.link_shortcut_4.TabIndex = 3;
            this.link_shortcut_4.Text = "바로가기4";
            this.link_shortcut_4.Click += new System.EventHandler(this.link_shortcut_4_Click);
            // 
            // link_shortcut_3
            // 
            this.link_shortcut_3.Location = new System.Drawing.Point(27, 75);
            this.link_shortcut_3.Name = "link_shortcut_3";
            this.link_shortcut_3.Size = new System.Drawing.Size(75, 23);
            this.link_shortcut_3.TabIndex = 2;
            this.link_shortcut_3.Text = "바로가기3";
            this.link_shortcut_3.Click += new System.EventHandler(this.link_shortcut_3_Click);
            // 
            // link_shortcut_2
            // 
            this.link_shortcut_2.Location = new System.Drawing.Point(27, 50);
            this.link_shortcut_2.Name = "link_shortcut_2";
            this.link_shortcut_2.Size = new System.Drawing.Size(75, 23);
            this.link_shortcut_2.TabIndex = 1;
            this.link_shortcut_2.Text = "바로가기2";
            this.link_shortcut_2.Click += new System.EventHandler(this.link_shortcut_2_Click);
            // 
            // link_shortcut_1
            // 
            this.link_shortcut_1.Location = new System.Drawing.Point(27, 25);
            this.link_shortcut_1.Name = "link_shortcut_1";
            this.link_shortcut_1.Size = new System.Drawing.Size(75, 23);
            this.link_shortcut_1.TabIndex = 0;
            this.link_shortcut_1.Text = "바로가기1";
            this.link_shortcut_1.Click += new System.EventHandler(this.link_shortcut_1_Click);
            // 
            // link_qa1
            // 
            this.link_qa1.Location = new System.Drawing.Point(19, 25);
            this.link_qa1.Name = "link_qa1";
            this.link_qa1.Size = new System.Drawing.Size(91, 23);
            this.link_qa1.Style = MetroFramework.MetroColorStyle.Red;
            this.link_qa1.TabIndex = 28;
            this.link_qa1.Text = "실행이 안돼요";
            this.link_qa1.UseStyleColors = true;
            this.link_qa1.Click += new System.EventHandler(this.link_qa1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.link_qa2);
            this.groupBox2.Controls.Add(this.link_qa1);
            this.groupBox2.Location = new System.Drawing.Point(335, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 121);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "자주 하는 질문";
            // 
            // link_qa2
            // 
            this.link_qa2.Location = new System.Drawing.Point(19, 57);
            this.link_qa2.Name = "link_qa2";
            this.link_qa2.Size = new System.Drawing.Size(91, 51);
            this.link_qa2.Style = MetroFramework.MetroColorStyle.Red;
            this.link_qa2.TabIndex = 29;
            this.link_qa2.Text = "업데이트 때마다 \r\n계정설정을 다시\r\n해야하나요?";
            this.link_qa2.UseStyleColors = true;
            this.link_qa2.Click += new System.EventHandler(this.link_qa2_Click);
            // 
            // link_icon_license
            // 
            this.link_icon_license.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.link_icon_license.AutoSize = true;
            this.link_icon_license.BackColor = System.Drawing.SystemColors.Control;
            this.link_icon_license.CustomBackground = true;
            this.link_icon_license.Location = new System.Drawing.Point(521, 498);
            this.link_icon_license.Name = "link_icon_license";
            this.link_icon_license.Size = new System.Drawing.Size(134, 23);
            this.link_icon_license.TabIndex = 28;
            this.link_icon_license.Text = "Icons by Icons8,com";
            this.link_icon_license.Click += new System.EventHandler(this.link_icon_license_Click);
            // 
            // menuItem_info
            // 
            this.menuItem_info.Image = ((System.Drawing.Image)(resources.GetObject("menuItem_info.Image")));
            this.menuItem_info.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuItem_info.Name = "menuItem_info";
            this.menuItem_info.Size = new System.Drawing.Size(190, 28);
            this.menuItem_info.Text = "프로그램 정보           ";
            this.menuItem_info.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuItem_info.Click += new System.EventHandler(this.menuItem_info_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(705, 551);
            this.Controls.Add(this.link_icon_license);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.link_github);
            this.Controls.Add(this.pic_github);
            this.Controls.Add(this.pic_naver);
            this.Controls.Add(this.link_blog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_setting);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form_Main";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "거상 다클라 스테이션";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.groupBox_setting.ResumeLayout(false);
            this.groupBox_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_naver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_github)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuItem_client;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.ToolStripMenuItem menuItem_lab;
        private MetroFramework.Controls.MetroLabel label_client_2;
        private MetroFramework.Controls.MetroLabel label_client_3;
        private MetroFramework.Controls.MetroLabel label_client_1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroRadioButton radio_setting_1;
        private MetroFramework.Controls.MetroRadioButton radio_setting_2;
        private MetroFramework.Controls.MetroRadioButton radio_setting_3;
        private System.Windows.Forms.GroupBox groupBox_setting;
        private MetroFramework.Controls.MetroToggle toggle_client_1;
        private MetroFramework.Controls.MetroToggle toggle_client_2;
        private MetroFramework.Controls.MetroToggle toggle_client_3;
        private System.Windows.Forms.Button button_search_naver_1;
        private System.Windows.Forms.Button button_start_2;
        private System.Windows.Forms.Button button_search_naver2;
        private System.Windows.Forms.Button button_start_3;
        private System.Windows.Forms.Button button_search_naver3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLink link_blog;
        private System.Windows.Forms.PictureBox pic_naver;
        private System.Windows.Forms.PictureBox pic_github;
        private MetroFramework.Controls.MetroLink link_github;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLink link_shortcut_3;
        private MetroFramework.Controls.MetroLink link_shortcut_2;
        private MetroFramework.Controls.MetroLink link_shortcut_1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_shortcut;
        private MetroFramework.Controls.MetroLink link_qa1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLink link_qa2;
        private System.Windows.Forms.Button button_start_1;
        private MetroFramework.Controls.MetroRadioButton radio_setting_4;
        private MetroFramework.Controls.MetroLink link_shortcut_5;
        private MetroFramework.Controls.MetroLink link_shortcut_4;
        private MetroFramework.Controls.MetroCheckBox check_nickname1;
        private MetroFramework.Controls.MetroCheckBox check_nickname2;
        private MetroFramework.Controls.MetroCheckBox check_nickname3;
        private MetroFramework.Controls.MetroLink link_icon_license;
        private System.Windows.Forms.ToolStripMenuItem menuItem_info;
    }
}

