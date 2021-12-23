using MetroFramework.Forms;
using System.Configuration;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Shortcut : MetroForm {
        public Form_Shortcut() {
            InitializeComponent();
        }

        private void Form_Shortcut_Load(object sender, System.EventArgs e) {
            textBox_name_1.Text = ConfigurationManager.AppSettings["shortcut_name_1"];
            textBox_address_1.Text = ConfigurationManager.AppSettings["shortcut_address_1"];

            textBox_name_2.Text = ConfigurationManager.AppSettings["shortcut_name_2"];
            textBox_address_2.Text = ConfigurationManager.AppSettings["shortcut_address_2"];

            textBox_name_3.Text = ConfigurationManager.AppSettings["shortcut_name_3"];
            textBox_address_3.Text = ConfigurationManager.AppSettings["shortcut_address_3"];

            textBox_name_4.Text = ConfigurationManager.AppSettings["shortcut_name_4"];
            textBox_address_4.Text = ConfigurationManager.AppSettings["shortcut_address_4"];

            textBox_name_5.Text = ConfigurationManager.AppSettings["shortcut_name_5"];
            textBox_address_5.Text = ConfigurationManager.AppSettings["shortcut_address_5"];
        }

        private void button_save_Click(object sender, System.EventArgs e) {
            Form_Main.config.AppSettings.Settings["shortcut_name_1"].Value = textBox_name_1.Text;
            Form_Main.config.AppSettings.Settings["shortcut_address_1"].Value = textBox_address_1.Text;

            Form_Main.config.AppSettings.Settings["shortcut_name_2"].Value = textBox_name_2.Text;
            Form_Main.config.AppSettings.Settings["shortcut_address_2"].Value = textBox_address_2.Text;

            Form_Main.config.AppSettings.Settings["shortcut_name_3"].Value = textBox_name_3.Text;
            Form_Main.config.AppSettings.Settings["shortcut_address_3"].Value = textBox_address_3.Text;

            Form_Main.config.AppSettings.Settings["shortcut_name_4"].Value = textBox_name_4.Text;
            Form_Main.config.AppSettings.Settings["shortcut_address_4"].Value = textBox_address_4.Text;

            Form_Main.config.AppSettings.Settings["shortcut_name_5"].Value = textBox_name_5.Text;
            Form_Main.config.AppSettings.Settings["shortcut_address_5"].Value = textBox_address_5.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "바로가기 설정", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
