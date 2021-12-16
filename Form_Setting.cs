using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Configuration;
using System.Diagnostics;

namespace GersangClientStation {
    public partial class Form_Setting : MetroForm {
        public Form_Setting() {
            InitializeComponent();
        }

        private void Form_Setting_Load(object sender, System.EventArgs e) {
            textBox_client_path_1_tab_1.Text = ConfigurationManager.AppSettings["client_path_1_tab_1"];
            textBox_client_id_1_tab_1.Text = ConfigurationManager.AppSettings["client_id_1_tab_1"];
            textBox_client_pw_1_tab_1.Text = ConfigurationManager.AppSettings["client_pw_1_tab_1"];

            textBox_client_path_2_tab_1.Text = ConfigurationManager.AppSettings["client_path_2_tab_1"];
            textBox_client_id_2_tab_1.Text = ConfigurationManager.AppSettings["client_id_2_tab_1"];
            textBox_client_pw_2_tab_1.Text = ConfigurationManager.AppSettings["client_pw_2_tab_1"];

            textBox_client_path_3_tab_1.Text = ConfigurationManager.AppSettings["client_path_3_tab_1"];
            textBox_client_id_3_tab_1.Text = ConfigurationManager.AppSettings["client_id_3_tab_1"];
            textBox_client_pw_3_tab_1.Text = ConfigurationManager.AppSettings["client_pw_3_tab_1"];
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

        private void button_save_tab_1_Click(object sender, System.EventArgs e) {
            ConfigurationManager.AppSettings["client_path_1_tab_1"] = textBox_client_path_1_tab_1.Text;
            ConfigurationManager.AppSettings["client_id_1_tab_1"] = textBox_client_id_1_tab_1.Text;
            ConfigurationManager.AppSettings["client_pw_1_tab_1"] = textBox_client_pw_1_tab_1.Text;

            ConfigurationManager.AppSettings["client_path_2_tab_1"] = textBox_client_path_2_tab_1.Text;
            ConfigurationManager.AppSettings["client_id_2_tab_1"] = textBox_client_id_2_tab_1.Text;
            ConfigurationManager.AppSettings["client_pw_2_tab_1"] = textBox_client_pw_2_tab_1.Text;

            ConfigurationManager.AppSettings["client_path_3_tab_1"] = textBox_client_path_2_tab_1.Text;
            ConfigurationManager.AppSettings["client_id_3_tab_1"] = textBox_client_id_2_tab_1.Text;
            ConfigurationManager.AppSettings["client_pw_3_tab_1"] = textBox_client_pw_2_tab_1.Text;
        }

        private void metroButton3_Click(object sender, System.EventArgs e) {
            Debug.WriteLine(ConfigurationManager.AppSettings["client_path_1_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_id_1_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_pw_1_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_path_2_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_id_2_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_pw_2_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_path_3_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_id_3_tab_1"]);
            Debug.WriteLine(ConfigurationManager.AppSettings["client_pw_3_tab_1"]);
        }
    }
}
