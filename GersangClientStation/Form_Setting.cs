using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Setting : MetroForm {
        private bool isTextChanged = false;

        public Form_Setting() {
            InitializeComponent();
        }

        private void Form_Setting_Load(object sender, System.EventArgs e) {
            tabControl_setting.SelectedTab = metroTabPage1;

            //탭1
            textBox_client_name_1_tab_1.Text = ConfigurationManager.AppSettings["client_name_1_tab_1"];
            textBox_client_path_1_tab_1.Text = ConfigurationManager.AppSettings["client_path_1_tab_1"];
            textBox_client_id_1_tab_1.Text = ConfigurationManager.AppSettings["client_id_1_tab_1"];
            textBox_client_pw_1_tab_1.Text = ConfigurationManager.AppSettings["client_pw_1_tab_1"];

            textBox_client_name_2_tab_1.Text = ConfigurationManager.AppSettings["client_name_2_tab_1"];
            textBox_client_path_2_tab_1.Text = ConfigurationManager.AppSettings["client_path_2_tab_1"];
            textBox_client_id_2_tab_1.Text = ConfigurationManager.AppSettings["client_id_2_tab_1"];
            textBox_client_pw_2_tab_1.Text = ConfigurationManager.AppSettings["client_pw_2_tab_1"];

            textBox_client_name_3_tab_1.Text = ConfigurationManager.AppSettings["client_name_3_tab_1"];
            textBox_client_path_3_tab_1.Text = ConfigurationManager.AppSettings["client_path_3_tab_1"];
            textBox_client_id_3_tab_1.Text = ConfigurationManager.AppSettings["client_id_3_tab_1"];
            textBox_client_pw_3_tab_1.Text = ConfigurationManager.AppSettings["client_pw_3_tab_1"];

            //탭2
            textBox_client_name_1_tab_2.Text = ConfigurationManager.AppSettings["client_name_1_tab_2"];
            textBox_client_path_1_tab_2.Text = ConfigurationManager.AppSettings["client_path_1_tab_2"];
            textBox_client_id_1_tab_2.Text = ConfigurationManager.AppSettings["client_id_1_tab_2"];
            textBox_client_pw_1_tab_2.Text = ConfigurationManager.AppSettings["client_pw_1_tab_2"];

            textBox_client_name_2_tab_2.Text = ConfigurationManager.AppSettings["client_name_2_tab_2"];
            textBox_client_path_2_tab_2.Text = ConfigurationManager.AppSettings["client_path_2_tab_2"];
            textBox_client_id_2_tab_2.Text = ConfigurationManager.AppSettings["client_id_2_tab_2"];
            textBox_client_pw_2_tab_2.Text = ConfigurationManager.AppSettings["client_pw_2_tab_2"];

            textBox_client_name_3_tab_2.Text = ConfigurationManager.AppSettings["client_name_3_tab_2"];
            textBox_client_path_3_tab_2.Text = ConfigurationManager.AppSettings["client_path_3_tab_2"];
            textBox_client_id_3_tab_2.Text = ConfigurationManager.AppSettings["client_id_3_tab_2"];
            textBox_client_pw_3_tab_2.Text = ConfigurationManager.AppSettings["client_pw_3_tab_2"];

            //탭3
            textBox_client_name_1_tab_3.Text = ConfigurationManager.AppSettings["client_name_1_tab_3"];
            textBox_client_path_1_tab_3.Text = ConfigurationManager.AppSettings["client_path_1_tab_3"];
            textBox_client_id_1_tab_3.Text = ConfigurationManager.AppSettings["client_id_1_tab_3"];
            textBox_client_pw_1_tab_3.Text = ConfigurationManager.AppSettings["client_pw_1_tab_3"];

            textBox_client_name_2_tab_3.Text = ConfigurationManager.AppSettings["client_name_2_tab_3"];
            textBox_client_path_2_tab_3.Text = ConfigurationManager.AppSettings["client_path_2_tab_3"];
            textBox_client_id_2_tab_3.Text = ConfigurationManager.AppSettings["client_id_2_tab_3"];
            textBox_client_pw_2_tab_3.Text = ConfigurationManager.AppSettings["client_pw_2_tab_3"];

            textBox_client_name_3_tab_3.Text = ConfigurationManager.AppSettings["client_name_3_tab_3"];
            textBox_client_path_3_tab_3.Text = ConfigurationManager.AppSettings["client_path_3_tab_3"];
            textBox_client_id_3_tab_3.Text = ConfigurationManager.AppSettings["client_id_3_tab_3"];
            textBox_client_pw_3_tab_3.Text = ConfigurationManager.AppSettings["client_pw_3_tab_3"];

            //탭4
            textBox_client_name_1_tab_4.Text = ConfigurationManager.AppSettings["client_name_1_tab_4"];
            textBox_client_path_1_tab_4.Text = ConfigurationManager.AppSettings["client_path_1_tab_4"];
            textBox_client_id_1_tab_4.Text = ConfigurationManager.AppSettings["client_id_1_tab_4"];
            textBox_client_pw_1_tab_4.Text = ConfigurationManager.AppSettings["client_pw_1_tab_4"];

            textBox_client_name_2_tab_4.Text = ConfigurationManager.AppSettings["client_name_2_tab_4"];
            textBox_client_path_2_tab_4.Text = ConfigurationManager.AppSettings["client_path_2_tab_4"];
            textBox_client_id_2_tab_4.Text = ConfigurationManager.AppSettings["client_id_2_tab_4"];
            textBox_client_pw_2_tab_4.Text = ConfigurationManager.AppSettings["client_pw_2_tab_4"];

            textBox_client_name_3_tab_4.Text = ConfigurationManager.AppSettings["client_name_3_tab_4"];
            textBox_client_path_3_tab_4.Text = ConfigurationManager.AppSettings["client_path_3_tab_4"];
            textBox_client_id_3_tab_4.Text = ConfigurationManager.AppSettings["client_id_3_tab_4"];
            textBox_client_pw_3_tab_4.Text = ConfigurationManager.AppSettings["client_pw_3_tab_4"];
        }

        //폴더 탐색기를 띄워서 선택한 경로를 텍스트박스에 넣습니다.
        private void FindPath(MetroTextBox textBox_path) {
            //pathBrowserDialog.SelectedPath = null;
            pathBrowserDialog.ShowDialog();
            if (pathBrowserDialog.SelectedPath.Length != 0) {
                textBox_path.Text = pathBrowserDialog.SelectedPath;
            }
        }

        private void button_path_finder_1_tab_1_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_1_tab_1); }
        private void button_path_finder_2_tab_1_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_2_tab_1); }
        private void button_path_finder_3_tab_1_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_3_tab_1); }
        private void button_path_finder_1_tab_2_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_1_tab_2); }
        private void button_path_finder_2_tab_2_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_2_tab_2); }
        private void button_path_finder_3_tab_2_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_3_tab_2); }
        private void button_path_finder_1_tab_3_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_1_tab_3); }
        private void button_path_finder_2_tab_3_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_2_tab_3); }
        private void button_path_finder_3_tab_3_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_3_tab_3); }
        private void button_path_finder_1_tab_4_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_1_tab_4); }
        private void button_path_finder_2_tab_4_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_2_tab_4); }
        private void button_path_finder_3_tab_4_Click(object sender, System.EventArgs e) { FindPath(textBox_client_path_3_tab_4); }

        private void button_save_tab_1_Click(object sender, System.EventArgs e) {
            Form_Main.config.AppSettings.Settings["client_name_1_tab_1"].Value = textBox_client_name_1_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_path_1_tab_1"].Value = textBox_client_path_1_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_id_1_tab_1"].Value = textBox_client_id_1_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_1"].Value = textBox_client_pw_1_tab_1.Text;

            Form_Main.config.AppSettings.Settings["client_name_2_tab_1"].Value = textBox_client_name_2_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_path_2_tab_1"].Value = textBox_client_path_2_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_id_2_tab_1"].Value = textBox_client_id_2_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_1"].Value = textBox_client_pw_2_tab_1.Text;

            Form_Main.config.AppSettings.Settings["client_name_3_tab_1"].Value = textBox_client_name_3_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_path_3_tab_1"].Value = textBox_client_path_3_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_id_3_tab_1"].Value = textBox_client_id_3_tab_1.Text;
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_1"].Value = textBox_client_pw_3_tab_1.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_save_tab_2_Click(object sender, System.EventArgs e) {
            Form_Main.config.AppSettings.Settings["client_name_1_tab_2"].Value = textBox_client_name_1_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_path_1_tab_2"].Value = textBox_client_path_1_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_id_1_tab_2"].Value = textBox_client_id_1_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_2"].Value = textBox_client_pw_1_tab_2.Text;

            Form_Main.config.AppSettings.Settings["client_name_2_tab_2"].Value = textBox_client_name_2_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_path_2_tab_2"].Value = textBox_client_path_2_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_id_2_tab_2"].Value = textBox_client_id_2_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_2"].Value = textBox_client_pw_2_tab_2.Text;

            Form_Main.config.AppSettings.Settings["client_name_3_tab_2"].Value = textBox_client_name_3_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_path_3_tab_2"].Value = textBox_client_path_3_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_id_3_tab_2"].Value = textBox_client_id_3_tab_2.Text;
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_2"].Value = textBox_client_pw_3_tab_2.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_save_tab_3_Click(object sender, System.EventArgs e) {
            Form_Main.config.AppSettings.Settings["client_name_1_tab_3"].Value = textBox_client_name_1_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_path_1_tab_3"].Value = textBox_client_path_1_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_id_1_tab_3"].Value = textBox_client_id_1_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_3"].Value = textBox_client_pw_1_tab_3.Text;

            Form_Main.config.AppSettings.Settings["client_name_2_tab_3"].Value = textBox_client_name_2_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_path_2_tab_3"].Value = textBox_client_path_2_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_id_2_tab_3"].Value = textBox_client_id_2_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_3"].Value = textBox_client_pw_2_tab_3.Text;

            Form_Main.config.AppSettings.Settings["client_name_3_tab_3"].Value = textBox_client_name_3_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_path_3_tab_3"].Value = textBox_client_path_3_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_id_3_tab_3"].Value = textBox_client_id_3_tab_3.Text;
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_3"].Value = textBox_client_pw_3_tab_3.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_save_tab_4_Click(object sender, System.EventArgs e) {
            Form_Main.config.AppSettings.Settings["client_name_1_tab_4"].Value = textBox_client_name_1_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_path_1_tab_4"].Value = textBox_client_path_1_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_id_1_tab_4"].Value = textBox_client_id_1_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_4"].Value = textBox_client_pw_1_tab_4.Text;

            Form_Main.config.AppSettings.Settings["client_name_2_tab_4"].Value = textBox_client_name_2_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_path_2_tab_4"].Value = textBox_client_path_2_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_id_2_tab_4"].Value = textBox_client_id_2_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_4"].Value = textBox_client_pw_2_tab_4.Text;

            Form_Main.config.AppSettings.Settings["client_name_3_tab_4"].Value = textBox_client_name_3_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_path_3_tab_4"].Value = textBox_client_path_3_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_id_3_tab_4"].Value = textBox_client_id_3_tab_4.Text;
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_4"].Value = textBox_client_pw_3_tab_4.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_client_pw_TextChanged(object sender, System.EventArgs e) { isTextChanged = true; }

        //tab_1 패스워드 암호화
        private void textBox_client_pw_1_tab_1_Leave(object sender, System.EventArgs e) {
            if(isTextChanged) {
                if(textBox_client_pw_1_tab_1.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_1_tab_1.Text = EncryptionSupporter.Protect(textBox_client_pw_1_tab_1.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_2_tab_1_Leave(object sender, System.EventArgs e) {
            if(isTextChanged) {
                if (textBox_client_pw_2_tab_1.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_2_tab_1.Text = EncryptionSupporter.Protect(textBox_client_pw_2_tab_1.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_3_tab_1_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_3_tab_1.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_3_tab_1.Text = EncryptionSupporter.Protect(textBox_client_pw_3_tab_1.Text);
                isTextChanged = false;
            }
        }

        //tab_2 패스워드 암호화
        private void textBox_client_pw_1_tab_2_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_1_tab_2.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_1_tab_2.Text = EncryptionSupporter.Protect(textBox_client_pw_1_tab_2.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_2_tab_2_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_2_tab_2.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_2_tab_2.Text = EncryptionSupporter.Protect(textBox_client_pw_2_tab_2.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_3_tab_2_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_3_tab_2.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_3_tab_2.Text = EncryptionSupporter.Protect(textBox_client_pw_3_tab_2.Text);
                isTextChanged = false;
            }
        }

        //tab_3 패스워드 암호화
        private void textBox_client_pw_1_tab_3_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_1_tab_3.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_1_tab_3.Text = EncryptionSupporter.Protect(textBox_client_pw_1_tab_3.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_2_tab_3_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_2_tab_3.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_2_tab_3.Text = EncryptionSupporter.Protect(textBox_client_pw_2_tab_3.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_3_tab_3_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_3_tab_3.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_3_tab_3.Text = EncryptionSupporter.Protect(textBox_client_pw_3_tab_3.Text);
                isTextChanged = false;
            }
        }

        //tab_4 패스워드 암호화
        private void textBox_client_pw_1_tab_4_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_1_tab_4.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_1_tab_4.Text = EncryptionSupporter.Protect(textBox_client_pw_1_tab_4.Text);
                isTextChanged = false;
            }
        }
        private void textBox_client_pw_2_tab_4_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_2_tab_4.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_2_tab_4.Text = EncryptionSupporter.Protect(textBox_client_pw_2_tab_4.Text);
                isTextChanged = false;
            }
        }
        
        private void textBox_client_pw_3_tab_4_Leave(object sender, System.EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_pw_3_tab_4.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_pw_3_tab_4.Text = EncryptionSupporter.Protect(textBox_client_pw_3_tab_4.Text);
                isTextChanged = false;
            }
        }

        //패스워드 텍스트박스 초기화
        private void button_clear_pw_1_tab_1_Click(object sender, System.EventArgs e) { textBox_client_pw_1_tab_1.Clear(); }
        private void button_clear_pw_2_tab_1_Click(object sender, System.EventArgs e) { textBox_client_pw_2_tab_1.Clear(); }
        private void button_clear_pw_3_tab_1_Click(object sender, System.EventArgs e) { textBox_client_pw_3_tab_1.Clear(); }
        private void button_clear_pw_1_tab_2_Click(object sender, System.EventArgs e) { textBox_client_pw_1_tab_2.Clear(); }
        private void button_clear_pw_2_tab_2_Click(object sender, System.EventArgs e) { textBox_client_pw_2_tab_2.Clear(); }
        private void button_clear_pw_3_tab_2_Click(object sender, System.EventArgs e) { textBox_client_pw_3_tab_2.Clear(); }
        private void button_clear_pw_1_tab_3_Click(object sender, System.EventArgs e) { textBox_client_pw_1_tab_3.Clear(); }
        private void button_clear_pw_2_tab_3_Click(object sender, System.EventArgs e) { textBox_client_pw_2_tab_3.Clear(); }
        private void button_clear_pw_3_tab_3_Click(object sender, System.EventArgs e) { textBox_client_pw_3_tab_3.Clear(); }
        private void button_clear_pw_1_tab_4_Click(object sender, System.EventArgs e) { textBox_client_pw_1_tab_4.Clear(); }
        private void button_clear_pw_2_tab_4_Click(object sender, System.EventArgs e) { textBox_client_pw_2_tab_4.Clear(); }
        private void button_clear_pw_3_tab_4_Click(object sender, System.EventArgs e) { textBox_client_pw_3_tab_4.Clear(); }
    }
}
