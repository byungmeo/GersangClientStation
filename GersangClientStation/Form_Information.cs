using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Information : MetroForm {
        public Form_Information() {
            InitializeComponent();
        }

        private void Form_Information_Load(object sender, EventArgs e) {
            label_currentVersion.Text = "현재 버전 : v" + Form_Main.currentVersion;
            label_latestVersion.Text = "최신 버전 : v" + Form_Main.latestVersion;
        }

        private void button_release_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://github.com/byungmeo/GersangClientStation/releases/latest");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void button_license_Click(object sender, EventArgs e) {
            Form_License licenseForm = new Form_License();
            licenseForm.ShowDialog();
        }
    }
}
