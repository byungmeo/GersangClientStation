using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_PatchSetting : MetroForm {
        public Form_PatchSetting() {
            InitializeComponent();
        }

        private void Form_Patch_Load(object sender, EventArgs e) {
            textBox_original_path.Text = Form_Main.config.AppSettings.Settings["gersang_original_path"].Value;

            check_removeFile.Checked = bool.Parse(Form_Main.config.AppSettings.Settings["remove_file_after_patch"].Value);
            check_creator.Checked = bool.Parse(Form_Main.config.AppSettings.Settings["apply_creator_after_patch"].Value);
        }

        private void button_save_Click(object sender, EventArgs e) {
            if(textBox_original_path.Text.Equals("")) {
                MessageBox.Show("거상 원본 폴더 경로를 지정 해주세요.");
                return;
            }

            Form_Main.config.AppSettings.Settings["gersang_original_path"].Value = textBox_original_path.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "거상 패치 설정", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_find_Click(object sender, EventArgs e) {
            pathBrowserDialog.ShowDialog();
            if (pathBrowserDialog.SelectedPath.Length != 0) {
                textBox_original_path.Text = pathBrowserDialog.SelectedPath;
            }
        }

        private void check_removeFile_CheckedChanged(object sender, EventArgs e) {
            MetroCheckBox check = sender as MetroCheckBox;
            Form_Main.config.AppSettings.Settings["remove_file_after_patch"].Value = check.Checked.ToString();
            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void check_creator_CheckedChanged(object sender, EventArgs e) {
            MetroCheckBox check = sender as MetroCheckBox;
            Form_Main.config.AppSettings.Settings["apply_creator_after_patch"].Value = check.Checked.ToString();
            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
