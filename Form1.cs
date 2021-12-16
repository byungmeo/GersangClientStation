using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form1 : MetroForm {
        private const string url_main = "http://www.gersang.co.kr/main/index.gs";
        private const string url_logout = "http://www.gersang.co.kr/member/logoutProc.gs";
        private const string url_otp = "https://www.gersang.co.kr/member/otp.gs";

        //pw는 암호화를 통한 관리 필요
        private string client_path_1;
        private string client_id_1;
        private string client_pw_1;

        private string client_path_2;
        private string client_id_2;
        private string client_pw_2;

        private string client_path_3;
        private string client_id_3;
        private string client_pw_3;

        WebBrowser webBrowser = new WebBrowser();
        HtmlDocument document = null;

        private Client currentLoginClient = Client.None;
        private bool isTypingOtp = false;
        private bool isSubmitOtp = false;

        enum Status {
            Offline, //로그아웃 상태
            Online,  //로그인 완료
            Retrying //로그인 재시도중
        }

        enum Client {
            MainClient, //1클라
            Client2, //2클라
            Client3, //3클라
            None
        }

        public Form1() {
            InitializeComponent();
            webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted); //브라우저 로딩 완료 이벤트 리스너 부착
            webBrowser2.ScriptErrorsSuppressed = true; //Script Error가 뜨지 않도록 합니다.
            webBrowser2.Navigate(url_main); //홈페이지 메인 화면으로 이동합니다.
        }

        private void Form1_Load(object sender, EventArgs e) {
            //저장되어있는 세팅값 번호를 불러오고, 해당 세팅값으로 클라이언트를 세팅합니다.
            byte settingNumber = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);
            switch (settingNumber) {
                case 1:
                    radio_setting_1.PerformClick(); //라디오 버튼을 클릭하여 CheckedChanged 이벤트를 발생시킵니다.
                    break;
                case 2:
                    radio_setting_2.PerformClick();
                    break;
                case 3:
                    radio_setting_3.PerformClick();
                    break;
                default:
                    MessageBox.Show("오류 발생 : Form1_Load\nInvalid Setting Number");
                    return;
            }
        }

        //라디오 버튼의 CheckedChanged이벤트 발생 시 불러옵니다.
        //클라이언트 경로, 아이디, 비밀번호를 세팅값에 맞춰 세팅합니다.
        private void LoadSetting() {
            byte settingNumber = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);

            switch (settingNumber) {
                case 1:
                    this.client_path_1 = ConfigurationManager.AppSettings["client_path_1_tab_1"];
                    this.client_id_1 = ConfigurationManager.AppSettings["client_id_1_tab_1"];
                    this.client_pw_1 = ConfigurationManager.AppSettings["client_pw_1_tab_1"];
                    this.client_path_2 = ConfigurationManager.AppSettings["client_path_2_tab_1"];
                    this.client_id_2 = ConfigurationManager.AppSettings["client_id_2_tab_1"];
                    this.client_pw_2 = ConfigurationManager.AppSettings["client_pw_2_tab_1"];
                    this.client_path_3 = ConfigurationManager.AppSettings["client_path_3_tab_1"];
                    this.client_id_3 = ConfigurationManager.AppSettings["client_id_3_tab_1"];
                    this.client_pw_3 = ConfigurationManager.AppSettings["client_pw_3_tab_1"];
                    break;
                case 2:
                    this.client_path_1 = ConfigurationManager.AppSettings["client_path_1_tab_2"];
                    this.client_id_1 = ConfigurationManager.AppSettings["client_id_1_tab_2"];
                    this.client_pw_1 = ConfigurationManager.AppSettings["client_pw_1_tab_2"];
                    this.client_path_2 = ConfigurationManager.AppSettings["client_path_2_tab_2"];
                    this.client_id_2 = ConfigurationManager.AppSettings["client_id_2_tab_2"];
                    this.client_pw_2 = ConfigurationManager.AppSettings["client_pw_2_tab_2"];
                    this.client_path_3 = ConfigurationManager.AppSettings["client_path_3_tab_2"];
                    this.client_id_3 = ConfigurationManager.AppSettings["client_id_3_tab_2"];
                    this.client_pw_3 = ConfigurationManager.AppSettings["client_pw_3_tab_2"];
                    break;
                case 3:
                    this.client_path_1 = ConfigurationManager.AppSettings["client_path_1_tab_3"];
                    this.client_id_1 = ConfigurationManager.AppSettings["client_id_1_tab_3"];
                    this.client_pw_1 = ConfigurationManager.AppSettings["client_pw_1_tab_3"];
                    this.client_path_2 = ConfigurationManager.AppSettings["client_path_2_tab_3"];
                    this.client_id_2 = ConfigurationManager.AppSettings["client_id_2_tab_3"];
                    this.client_pw_2 = ConfigurationManager.AppSettings["client_pw_2_tab_3"];
                    this.client_path_3 = ConfigurationManager.AppSettings["client_path_3_tab_3"];
                    this.client_id_3 = ConfigurationManager.AppSettings["client_id_3_tab_3"];
                    this.client_pw_3 = ConfigurationManager.AppSettings["client_pw_3_tab_3"];
                    break;
                default:
                    Debug.WriteLine("잘못된 세팅값입니다.");
                    break;
            }
        }

        //웹 브라우저 로딩이 완료되면 호출됩니다.
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            Debug.WriteLine("Document Load Completed");
            this.document = this.webBrowser2.Document;
            Debug.WriteLine("Load URL : " + document.Url);

            HtmlElementCollection input_otp = this.document.GetElementsByTagName("input").GetElementsByName("GSotpNo"); //OTP 입력상자를 가져옵니다.
            //홈페이지 주소가 otp주소면서 OTP 입력상자가 존재할 경우 OTP 화면으로 간주합니다.
            if (document.Url.Equals(url_otp) && input_otp.Count != 0) {
                Debug.WriteLine("OTP 화면입니다.");
                if(!isTypingOtp && !isSubmitOtp) {
                    OtpLogin(input_otp[0]); //여기서 otp 입력을 함
                    return;
                }

                if(!isSubmitOtp) {
                    //opt 입력이 되었으므로, 클릭
                    HtmlElement button_otp_login = document.GetElementById("btn_Send");
                    isSubmitOtp = true;
                    button_otp_login.InvokeMember("Click");
                }
                return;
            }

            isTypingOtp = false;
            isSubmitOtp = false;

            if(currentLoginClient == Client.None) {
                return;
            }

            //웹페이지에 닉네임이 표시되고 있는지 확인하여 로그인 여부를 판단합니다.
            System.Windows.Forms.HtmlElement div_nickname = this.findElementByClassName("div", "user_name");
            if (div_nickname != null) {
                Debug.WriteLine("로그인이 되어있는 상태입니다!\n홈페이지 닉네임 : " + div_nickname.InnerText);
                SetStatus(Status.Online, currentLoginClient, div_nickname.InnerText);
                //isLogin = true;
            } else {
                Debug.WriteLine("로그인에 실패하였거나, 아직 로그인이 되지 않은 상태입니다.");
                this.label_status_1.Text = "Offline";
                this.label_status_1.BackColor = Color.IndianRed;
                //isLogin = false;
            }
        }

        private void Login(Client client) {
            Debug.WriteLine("로그인 시작");
            currentLoginClient = client;

            string id = null;
            string pw = null;
            switch (client) {
                case Client.MainClient:
                    id = client_id_1;
                    pw = client_pw_1;
                    break;
                case Client.Client2:
                    id = client_id_2;
                    pw = client_pw_2;
                    break;
                case Client.Client3:
                    id = client_id_3;
                    pw = client_pw_3;
                    break;
                case Client.None:
                    Debug.WriteLine("SetStatus: 잘못된 Client 인자 전달");
                    return;
            }

            try {
                //"GSuserID"라는 이름을 가진 input 태그 요소는 2개 있습니다. 그 중 2번째 요소에 id속성을 설정해줘야 합니다.
                //"GSuserPW"도 마찬가지
                HtmlElement input_userId = document.GetElementsByTagName("input").GetElementsByName("GSuserID")[1];
                HtmlElement input_userPwd = document.GetElementsByTagName("input").GetElementsByName("GSuserPW")[1];

                //frmLogin이라는 Name 속성을 가진 Form 태그 요소를 찾습니다.
                HtmlElement form_login = document.Forms.GetElementsByName("frmLogin")[0];
                
                if(input_userId == null || input_userPwd == null || form_login == null) {
                    return;
                }

                input_userId.SetAttribute("value", id); //아이디를 웹페이지에 입력
                input_userPwd.SetAttribute("value", pw); //패스워드를 웹페이지에 입력
                form_login.InvokeMember("submit"); //입력된 아이디와 패스워드로 로그인을 시도

            } catch(ArgumentOutOfRangeException e) {
                if(document.Url.Equals(url_main)) {
                    Debug.WriteLine(e.Message);
                    Debug.WriteLine("로그인을 다시 시도합니다.");
                    SetStatus(Status.Retrying, client);
                    Delay(1000);
                    Login(client);
                }
            }
        }

        private void Logout() {
            if(currentLoginClient != Client.None) {
                Debug.WriteLine("로그아웃 시작");
                SetStatus(Status.Offline, currentLoginClient, "");
                currentLoginClient = Client.None;
                webBrowser2.Navigate(url_logout);
            }
        }

        private void button_login_1_Click(object sender, EventArgs e) {
            Debug.WriteLine("1번 로그인 버튼 클릭");
            Logout();
            Delay(1000);
            Login(Client.MainClient);
        }

        private void button_login_2_Click(object sender, EventArgs e) {
            Debug.WriteLine("2번 로그인 버튼 클릭");
            Logout();
            Delay(1000);
            Login(Client.Client2);
        }

        private void button_login_3_Click(object sender, EventArgs e) {
            Debug.WriteLine("3번 로그인 버튼 클릭");
            Logout();
            Delay(1000);
            Login(Client.Client3);
        }

        private void GameStart(string client_path) {
            //거상의 실행 경로를 저장하는 레지스트리에 접근합니다.
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\JOYON\Gersang\Korean", RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (registryKey != null) {
                registryKey.SetValue("InstallPath", client_path);
                registryKey.Close();
            }

            //홈페이지에서 gameStart 스크립트를 실행합니다. (인자가 1이면 본섭, 2면 테섭을 실행합니다)
            this.document.InvokeScript("gameStart", new object[] { 1 });
        }

        private void button_start_1_Click(object sender, EventArgs e) {
            GameStart(client_path_1);
        }

        private void button_start_2_Click(object sender, EventArgs e) {
            GameStart(client_path_2);
        }

        
        private void button_start_3_Click(object sender, EventArgs e) {
            GameStart(client_path_3);
        }
        
        private void OtpLogin(HtmlElement input_otp) {
            Form otpDialogForm = new MetroForm() {
                Width = 300,
                Height = 100,
                Text = "OTP를 입력해주세요.",
                StartPosition = FormStartPosition.CenterScreen,
                Resizable = false,
                MaximizeBox = false,
                MinimizeBox = false
            };
            MetroTextBox textBox_otp = new MetroTextBox() { Left=30, Top=60, Width=180 };
            MetroButton button_otpConfirm = new MetroButton() { Left = 220, Top = 60, Width = 50, Text = "로그인", DialogResult=DialogResult.OK };
            button_otpConfirm.Click += (sender, e) => { otpDialogForm.Close(); };
            otpDialogForm.Controls.Add(textBox_otp);
            otpDialogForm.Controls.Add(button_otpConfirm);
            otpDialogForm.AcceptButton = button_otpConfirm;

            string otpCode = otpDialogForm.ShowDialog() == DialogResult.OK ? textBox_otp.Text : string.Empty;
            isTypingOtp = true;
            Debug.WriteLine(otpCode);
            input_otp.SetAttribute("value", otpCode);
        }

        //Document에서 해당 태그와 클래스명을 가진 요소를 반환합니다.
        //여러 개가 있을 경우 가장 첫 번째에 있는 요소를 가져옴에 유의
        private HtmlElement findElementByClassName(string tagName, string className) {
            foreach (HtmlElement element in document.GetElementsByTagName(tagName)) {
                if (element.GetAttribute("className") == className) {
                    return element;
                }
            }
            return null;
        }

        private void SetStatus(Status status, Client client) {
            string status_msg = status.ToString();
            Color color = Color.White;

            switch (status) {
                case Status.Offline:
                    color = Color.IndianRed;
                    break;
                case Status.Online:
                    color = Color.Green;
                    break;
            }

            switch (client) {
                case Client.MainClient:
                    label_status_1.Text = status_msg;
                    label_status_1.BackColor = color;
                    break;
                case Client.Client2:
                    label_status_2.Text = status_msg;
                    label_status_2.BackColor = color;
                    break;
                case Client.Client3:
                    label_status_3.Text = status_msg;
                    label_status_3.BackColor = color;
                    break;
                case Client.None:
                    Debug.WriteLine("SetStatus: 잘못된 Client 인자 전달");
                    return;
            }
        }

        private void SetStatus(Status status, Client client, string nickname) {
            SetStatus(status, client);

            switch (client) {
                case Client.MainClient:
                    label_nickname_1.Text = nickname;
                    break;
                case Client.Client2:
                    label_nickname_2.Text = nickname;
                    break;
                case Client.Client3:
                    label_nickname_3.Text = nickname;
                    break;
                case Client.None:
                    Debug.WriteLine("SetStatus: 잘못된 Client 인자 전달");
                    return;
            }
        }

        //ms초만큼 딜레이를 겁니다.
        private static DateTime Delay(int MS) {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment) {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            Form_Setting settingDialogForm = new Form_Setting();
            settingDialogForm.ShowDialog();
            LoadSetting(); //세팅값이 바뀌었다면 새로고침 합니다.
        }

        private void radio_setting_CheckedChanged(object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;

            if (rb == null) {
                MessageBox.Show("오류 발생 : radio_setting_CheckedChanged\nsender is null");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked) {
                if(rb.Equals(radio_setting_1)) {
                    ConfigurationManager.AppSettings["setting_num"] = "1";
                } else if(rb.Equals(radio_setting_2)) {
                    ConfigurationManager.AppSettings["setting_num"] = "2";
                } else if(rb.Equals(radio_setting_3)) {
                    ConfigurationManager.AppSettings["setting_num"] = "3";
                } else {
                    MessageBox.Show("오류 발생 : radio_setting_CheckedChanged\nUnknown RadioButton");
                    return;
                }

                LoadSetting();
            }
        }
    }
}
