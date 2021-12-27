using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_License : MetroForm {
        public Form_License() {
            InitializeComponent();
        }

        private void Form_License_Load(object sender, EventArgs e) {

        }

        private void link_station_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://github.com/byungmeo/GersangClientStation");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_gersangLauncher_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://github.com/LOONACIA/GersangLauncher");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_octokit_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://github.com/octokit/octokit.net");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_costura_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://github.com/Fody/Costura");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
    }
}
