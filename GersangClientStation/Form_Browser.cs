using System.Diagnostics;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Browser : Form {
        private WebBrowser mainBrowser;
        private const string url_main = "http://www.gersang.co.kr/main/index.gs";

        public Form_Browser() {
            InitializeComponent();
        }

        public Form_Browser(WebBrowser mainBrowser, string url) : this() {
            this.mainBrowser = mainBrowser;
            this.Controls.Add(this.mainBrowser);
            mainBrowser.Navigate(url);
        }

        private void Form_Browser_FormClosed(object sender, FormClosedEventArgs e) {
            Debug.WriteLine("폼 닫음");
            this.mainBrowser.Navigate(url_main);
            this.Controls.Clear();
        }
    }
}
