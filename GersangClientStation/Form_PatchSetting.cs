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
    }
}
