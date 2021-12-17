using MetroFramework.Forms;
using System.Configuration;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Shortcut : MetroForm {
        public Form_Shortcut() {
            InitializeComponent();
        }

        private void button_save_Click(object sender, System.EventArgs e) {
            Form1.config.AppSettings.Settings["shortcut_name_1"].Value = textBox_name_1.Text;
            Form1.config.AppSettings.Settings["shortcut_address_1"].Value = textBox_address_1.Text;

            Form1.config.AppSettings.Settings["shortcut_name_2"].Value = textBox_name_2.Text;
            Form1.config.AppSettings.Settings["shortcut_address_2"].Value = textBox_address_2.Text;

            Form1.config.AppSettings.Settings["shortcut_name_3"].Value = textBox_name_3.Text;
            Form1.config.AppSettings.Settings["shortcut_address_3"].Value = textBox_address_3.Text;

            Form1.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "바로가기 설정", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
