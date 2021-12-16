using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Configuration;

namespace GersangClientStation {
    public partial class Form_Setting : MetroForm {
        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public Form_Setting() {
            InitializeComponent();
        }

        private void Form_Setting_Load(object sender, System.EventArgs e) {
            tabControl_setting.SelectedTab = metroTabPage1;

            //탭1
            textBox_client_path_1_tab_1.Text = ConfigurationManager.AppSettings["client_path_1_tab_1"];
            textBox_client_id_1_tab_1.Text = ConfigurationManager.AppSettings["client_id_1_tab_1"];
            textBox_client_pw_1_tab_1.Text = ConfigurationManager.AppSettings["client_pw_1_tab_1"];

            textBox_client_path_2_tab_1.Text = ConfigurationManager.AppSettings["client_path_2_tab_1"];
            textBox_client_id_2_tab_1.Text = ConfigurationManager.AppSettings["client_id_2_tab_1"];
            textBox_client_pw_2_tab_1.Text = ConfigurationManager.AppSettings["client_pw_2_tab_1"];

            textBox_client_path_3_tab_1.Text = ConfigurationManager.AppSettings["client_path_3_tab_1"];
            textBox_client_id_3_tab_1.Text = ConfigurationManager.AppSettings["client_id_3_tab_1"];
            textBox_client_pw_3_tab_1.Text = ConfigurationManager.AppSettings["client_pw_3_tab_1"];

            //탭2
            textBox_client_path_1_tab_2.Text = ConfigurationManager.AppSettings["client_path_1_tab_2"];
            textBox_client_id_1_tab_2.Text = ConfigurationManager.AppSettings["client_id_1_tab_2"];
            textBox_client_pw_1_tab_2.Text = ConfigurationManager.AppSettings["client_pw_1_tab_2"];

            textBox_client_path_2_tab_2.Text = ConfigurationManager.AppSettings["client_path_2_tab_2"];
            textBox_client_id_2_tab_2.Text = ConfigurationManager.AppSettings["client_id_2_tab_2"];
            textBox_client_pw_2_tab_2.Text = ConfigurationManager.AppSettings["client_pw_2_tab_2"];

            textBox_client_path_3_tab_2.Text = ConfigurationManager.AppSettings["client_path_3_tab_2"];
            textBox_client_id_3_tab_2.Text = ConfigurationManager.AppSettings["client_id_3_tab_2"];
            textBox_client_pw_3_tab_2.Text = ConfigurationManager.AppSettings["client_pw_3_tab_2"];

            //탭3
            textBox_client_path_1_tab_3.Text = ConfigurationManager.AppSettings["client_path_1_tab_3"];
            textBox_client_id_1_tab_3.Text = ConfigurationManager.AppSettings["client_id_1_tab_3"];
            textBox_client_pw_1_tab_3.Text = ConfigurationManager.AppSettings["client_pw_1_tab_3"];

            textBox_client_path_2_tab_3.Text = ConfigurationManager.AppSettings["client_path_2_tab_3"];
            textBox_client_id_2_tab_3.Text = ConfigurationManager.AppSettings["client_id_2_tab_3"];
            textBox_client_pw_2_tab_3.Text = ConfigurationManager.AppSettings["client_pw_2_tab_3"];

            textBox_client_path_3_tab_3.Text = ConfigurationManager.AppSettings["client_path_3_tab_3"];
            textBox_client_id_3_tab_3.Text = ConfigurationManager.AppSettings["client_id_3_tab_3"];
            textBox_client_pw_3_tab_3.Text = ConfigurationManager.AppSettings["client_pw_3_tab_3"];
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

        private void button_save_tab_1_Click(object sender, System.EventArgs e) {
            config.AppSettings.Settings["client_path_1_tab_1"].Value = textBox_client_path_1_tab_1.Text;
            config.AppSettings.Settings["client_id_1_tab_1"].Value = textBox_client_id_1_tab_1.Text;
            config.AppSettings.Settings["client_pw_1_tab_1"].Value = textBox_client_pw_1_tab_1.Text;
            
            config.AppSettings.Settings["client_path_2_tab_1"].Value = textBox_client_path_2_tab_1.Text;
            config.AppSettings.Settings["client_id_2_tab_1"].Value = textBox_client_id_2_tab_1.Text;
            config.AppSettings.Settings["client_pw_2_tab_1"].Value = textBox_client_pw_2_tab_1.Text;

            config.AppSettings.Settings["client_path_3_tab_1"].Value = textBox_client_path_3_tab_1.Text;
            config.AppSettings.Settings["client_id_3_tab_1"].Value = textBox_client_id_3_tab_1.Text;
            config.AppSettings.Settings["client_pw_3_tab_1"].Value = textBox_client_pw_3_tab_1.Text;

            config.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void button_save_tab_2_Click(object sender, System.EventArgs e) {
            config.AppSettings.Settings["client_path_1_tab_2"].Value = textBox_client_path_1_tab_2.Text;
            config.AppSettings.Settings["client_id_1_tab_2"].Value = textBox_client_id_1_tab_2.Text;
            config.AppSettings.Settings["client_pw_1_tab_2"].Value = textBox_client_pw_1_tab_2.Text;

            config.AppSettings.Settings["client_path_2_tab_2"].Value = textBox_client_path_2_tab_2.Text;
            config.AppSettings.Settings["client_id_2_tab_2"].Value = textBox_client_id_2_tab_2.Text;
            config.AppSettings.Settings["client_pw_2_tab_2"].Value = textBox_client_pw_2_tab_2.Text;

            config.AppSettings.Settings["client_path_3_tab_2"].Value = textBox_client_path_3_tab_2.Text;
            config.AppSettings.Settings["client_id_3_tab_2"].Value = textBox_client_id_3_tab_2.Text;
            config.AppSettings.Settings["client_pw_3_tab_2"].Value = textBox_client_pw_3_tab_2.Text;

            config.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void button_save_tab_3_Click(object sender, System.EventArgs e) {
            config.AppSettings.Settings["client_path_1_tab_3"].Value = textBox_client_path_1_tab_3.Text;
            config.AppSettings.Settings["client_id_1_tab_3"].Value = textBox_client_id_1_tab_3.Text;
            config.AppSettings.Settings["client_pw_1_tab_3"].Value = textBox_client_pw_1_tab_3.Text;

            config.AppSettings.Settings["client_path_2_tab_3"].Value = textBox_client_path_2_tab_3.Text;
            config.AppSettings.Settings["client_id_2_tab_3"].Value = textBox_client_id_2_tab_3.Text;
            config.AppSettings.Settings["client_pw_2_tab_3"].Value = textBox_client_pw_2_tab_3.Text;

            config.AppSettings.Settings["client_path_3_tab_3"].Value = textBox_client_path_3_tab_3.Text;
            config.AppSettings.Settings["client_id_3_tab_3"].Value = textBox_client_id_3_tab_3.Text;
            config.AppSettings.Settings["client_pw_3_tab_3"].Value = textBox_client_pw_3_tab_3.Text;

            config.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
