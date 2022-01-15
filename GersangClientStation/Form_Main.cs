using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Main : MetroForm {
        /// <summary>
        /// 셋업
        /// </summary>

        //app.config 관련
        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //각종 url 정의
        private const string url_main = "http://www.gersang.co.kr/main/index.gs"; //거상 홈페이지
        private const string url_logout = "http://www.gersang.co.kr/member/logoutProc.gs"; //로그아웃 링크
        //private const string url_otp = "https://www.gersang.co.kr/member/otp.gs"; //OTP 링크
        private const string url_search_gersang = "https://search.naver.com/search.naver?&query=거상"; //네이버 검색 링크
        private string url_event = ""; //프로그램 실행 시 mainBrowser에서 출석체크 이벤트 url을 찾음

        //사용자 계정 정보 (LoadSetting으로 초기화)
        //패스워드는 DPAPI로 암호화되어 다른 사용자 컴퓨터에서 복호화 불가
        //복호화 된 패스워드가 변수에 할당되는 일이 없도록 유의
        private string client_path_1;//
        private string client_id_1;
        private string client_pw_1;
        private string client_path_2;//
        private string client_id_2;
        private string client_pw_2;
        private string client_path_3;//
        private string client_id_3;
        private string client_pw_3;

        //바로가기 경로 (LoadSetting으로 초기화)
        private string shortcut_name_1;//
        private string shortcut_address_1;
        private string shortcut_name_2;//
        private string shortcut_address_2;
        private string shortcut_name_3;//
        private string shortcut_address_3;
        private string shortcut_name_4;//
        private string shortcut_address_4;
        private string shortcut_name_5;//
        private string shortcut_address_5;

        //브라우저 객체
        WebBrowser mainBrowser = new WebBrowser(); //로그인, 실행, 바로가기 기능을 수행하는 메인 브라우저
        WebBrowser eventBrowser = new WebBrowser(); //검색 이벤트 보상 수령을 위한 브라우저

        //mainBrowser의 Document 속성
        HtmlDocument document_main = null;

        //프로그램 버전 정보
        public static string currentVersion;
        public static string latestVersion;

        //서버에 업로드된 거상 최신버전
        private int gersangLatestVersion;

        //클라이언트 열거체
        enum Client {
            MainClient, //1클라
            Client2, //2클라
            Client3, //3클라
            None
        }

        //현재 로그인 되어있는 클라이언트
        private Client currentLoginClient = Client.None;

        //실험실 기능 체크여부
        private bool isActiveX;
        private bool isDebuggingMode = false;
        private bool isDebuggingSearchMode = false;

        //ID/PW 바로입력 기능을 위한 패스워드 관련 bool
        private bool isTextChanged = false;

        //프로그램의 현재 진행 상태를 나타내는 bool
        private bool isProcessing = false; //현재 작업이 진행중인가? (true라면 버튼 클릭 불가)
        private bool isLogin = false; //방금 Login 메서드를 실행한 상태
        private bool isChangeLogin = false; //이미 로그인 된 상태에서, 다른 클라로 로그인 하려고 Logout 메서드를 실행한 상태
        private bool isGameStart_Login = false; //로그아웃된 상태에서 게임실행 버튼을 눌러 Login 메서드를 실행한 상태
        private bool isGameStart_Logout = false; //로그인 된 상태에서, 다른 클라의 게임실행 버튼을 눌러 Logout 메서드를 실행한 상태
        private bool isSearch_Login = false; //로그아웃 된 상태에서 검색보상 버튼을 눌러 Login 메서드를 실행한 상태
        private bool isSearch_Logout = false; //로그인 된 상태에서, 다른 클라의 검색보상 버튼을 눌러 Logout 메서드를 실행한 상태
        public static bool isShortcut = false; //바로가기 링크를 접속한 상태인가? (true라면 로그인 검사를 하지 않음)

        //임시로 사용할 변수들
        private string current_client_path = ""; //현재 게임실행 버튼을 누른 클라이언트의 거상 경로를 임시로 저장
        private Client current_change_client = Client.None; //로그인 된 상태에서, 다른 클라로 로그인 할 때, 다른 클라의 정보를 임시로 저장

        //폼 생성자
        public Form_Main() {
            checkUpdate(); //업데이트 확인
            initWebBrowser(); //웹브라우저 초기세팅
            InitializeComponent();
        }

        //폼 로딩
        private void Form_Main_Load(object sender, EventArgs e) {
            LoadSetting();
            initTextBox(); //ID/PW 바로입력 기능 관련 초기화
            initRadioButton(); //저장되어있는 세팅값 번호를 불러오고, 해당 세팅값으로 클라이언트를 세팅합니다.
            initCheckBox();
            initLabFunction(); //실험실 기능 세팅값 초기화

            checkGersangUpdate();
        }

        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 메인 브라우저 로딩 이벤트
        /// </summary>
        //메인 브라우저 로딩이 완료되면 호출됩니다.
        private void mainBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            //절대경로가 같은지 체크하여 이 이벤트가 3번 실행되는 것을 방지합니다.
            if (e.Url.AbsoluteUri != mainBrowser.Url.AbsoluteUri) {
                metroLabel5.Text = "로딩 중...";
                return;
            }
            metroLabel5.Text = "로딩 완료";
            test_url.Text = e.Url.ToString();

            this.document_main = mainBrowser.Document;
            if (document_main == null) {
                MessageBox.Show("mainBrowser_DocumentCompleted 에서 예외가 발생하였습니다.\n개발자에게 문의 해주세요.\ndocument_main이 null입니다.");
                return;
            }

            Debug.WriteLine("<< 현재 메인 브라우저 접속 URL : " + document_main.Url + " >>");

            //비밀번호 변경 경로라면, 다음에 변경하기 버튼을 누르기
            if (document_main.Url.ToString().Contains("pw_reset.gs")) {
                test_status.Text = "pw_reset";
                Debug.WriteLine("비밀번호 변경 주기 홉페이지입니다.");
                foreach (HtmlElement element in mainBrowser.Document.GetElementsByTagName("a")) {
                    string innerText = element.InnerText;
                    if (innerText == "다음에 변경하기") {
                        Debug.WriteLine("정상적인 게임 실행을 위해 다음에 변경하기를 클릭합니다.");
                        element.InvokeMember("Click");
                        return;
                    }
                }
            }

            //게임실행 버튼을 누르고 로그인 버튼을 누른 상태
            if (isGameStart_Login) {
                test_status.Text = "isGameStart_Login";
                if (document_main.Url.ToString().Contains("otp.gs")) {
                    Debug.WriteLine("OTP화면 입니다.");
                    if (OtpLogin()) {
                        Debug.WriteLine("OTP 확인 버튼 클릭");
                        return;
                    }
                }

                GameStart(current_client_path);
                isGameStart_Login = false;
                isLogin = false; //로그인 처리 완료 후 false로 변경
                current_client_path = "";
            }
            //게임실행 버튼을 누르고 로그아웃 버튼을 누른 상태
            else if (isGameStart_Logout) {
                test_status.Text = "isGameStart_Logout";
                Debug.WriteLine(currentLoginClient);
                Debug.WriteLine(isLogin);
                if (!isLogin) {
                    Login(current_change_client);
                    return;
                } else {
                    if (document_main.Url.ToString().Contains("otp.gs")) {
                        Debug.WriteLine("OTP화면 입니다.");
                        if (OtpLogin()) {
                            Debug.WriteLine("OTP 확인 버튼 클릭");
                            return;
                        }
                    }
                    GameStart(current_client_path);
                    isGameStart_Logout = false;
                    isLogin = false;
                    current_change_client = Client.None;
                }
            }
            //로그인 되어 있는데, 다른 계정에 로그인 하기 위해 로그아웃 한 상태
            else if (isChangeLogin) {
                test_status.Text = "isChangeLogin";
                if (!isLogin) {
                    Login(current_change_client);
                    return;
                } else {
                    if (document_main.Url.ToString().Contains("otp.gs")) {
                        Debug.WriteLine("OTP화면 입니다.");
                        if (OtpLogin()) {
                            Debug.WriteLine("OTP 확인 버튼 클릭");
                            return;
                        }
                    }
                    isChangeLogin = false;
                    isLogin = false;
                    current_change_client = Client.None;
                }
            }
            //로그아웃 상태에서 검색보상 버튼을 누른 후 브라우저에서 로그인 버튼을 누른 상태
            else if (isSearch_Login) {
                test_status.Text = "isSearch_Login";
                if (document_main.Url.ToString().Contains("otp.gs")) {
                    Debug.WriteLine("OTP화면 입니다.");
                    if (OtpLogin()) {
                        Debug.WriteLine("OTP 확인 버튼 클릭");
                        return;
                    }
                }

                navigateSearchPage(); //네이버 검색창에 접속한다.
                isSearch_Login = false;
                isLogin = false;
            }
            //로그인 상태에서 다른 클라의 검색보상 버튼을 눌러 Logout메서드를 실행 한 상태
            else if (isSearch_Logout) {
                test_status.Text = "isSearch_Logout";
                Debug.WriteLine(currentLoginClient);
                Debug.WriteLine(isLogin);
                if (!isLogin) {
                    Login(current_change_client);
                    return;
                } else {
                    if (document_main.Url.ToString().Contains("otp.gs")) {
                        Debug.WriteLine("OTP화면 입니다.");
                        if (OtpLogin()) {
                            Debug.WriteLine("OTP 확인 버튼 클릭");
                            return;
                        }
                    }

                    navigateSearchPage();
                    isSearch_Logout = false;
                    isLogin = false;
                    current_change_client = Client.None;
                }
            }
            //Login메서드에서 아이디와 비밀번호를 입력하고 로그인 버튼을 누른 상태
            else if(isLogin) {
                test_status.Text = "isLogin";
                //OTP 화면인지 판단
                if (document_main.Url.ToString().Contains("otp.gs")) {
                    Debug.WriteLine("OTP화면 입니다.");
                    if(OtpLogin()) {
                        Debug.WriteLine("OTP 확인 버튼 클릭");
                        return;
                    }
                }

                isLogin = false; //로그인 처리 완료 후 false로 변경
            } 

            //로그인 상태가 아니라면 로그인 여부를 판단하지 않습니다.
            if (currentLoginClient == Client.None) {
                metroLabel5.Text = "로그아웃";
                isProcessing = false;
                return;
            }

            //바로가기 접속 시에는 로그인 여부를 판단하지 않습니다.
            if(!isShortcut) {
                setStatus();
            }
            isProcessing = false;
        }

        private void setStatus() {
            //웹페이지에 닉네임이 표시되고 있는지 확인하여 로그인 여부를 판단합니다.
            HtmlElement div_nickname = this.findElementByClassName("div", "user_name");
            if (div_nickname != null) {
                Debug.WriteLine("로그인이 되어있는 상태입니다!\n홈페이지 닉네임 : " + div_nickname.InnerText);
                switch (currentLoginClient) {
                    case Client.MainClient:
                        toggle_client_1.Checked = true;
                        break;
                    case Client.Client2:
                        toggle_client_2.Checked = true;
                        break;
                    case Client.Client3:
                        toggle_client_3.Checked = true;
                        break;
                    case Client.None:
                        Debug.WriteLine("SetStatus: 잘못된 Client 인자 전달");
                        return;
                }
                metroLabel5.Text = "로그인 완료";
            } else {
                Debug.WriteLine("로그인에 실패하였습니다.");
                metroLabel5.Text = "로그인 실패";
                currentLoginClient = Client.None;
                toggle_client_1.Checked = false;
                toggle_client_2.Checked = false;
                toggle_client_3.Checked = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 로그인
        /// </summary>
        private void Login(Client client) {
            if(client == Client.None) {
                MessageBox.Show("Login메서드에 잘못된 클라이언트 매개변수가 입력되었습니다.");
            }

            document_main = mainBrowser.Document;
            if(document_main == null) {
                MessageBox.Show("Login 메서드 실행 오류 : document_main이 null 입니다.\n개발자에게 문의 해주세요.");
                return;
            }

            Debug.WriteLine("로그인 시작");

            string id = null;
            string pw = null;

            //아이디와 비밀번호를 불러옵니다.
            if (check_direct.Checked) {
                switch (client) {
                    case Client.MainClient:
                        id = textBox_client_1_id.Text;
                        pw = textBox_client_1_pw.Text;
                        break;
                    case Client.Client2:
                        id = textBox_client_2_id.Text;
                        pw = textBox_client_2_pw.Text;
                        break;
                    case Client.Client3:
                        id = textBox_client_3_id.Text;
                        pw = textBox_client_3_pw.Text;
                        break;
                }
            } else {
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
                }
            }

            try {
                //"GSuserID"라는 이름을 가진 input 태그 요소는 2개 있습니다. 그 중 2번째 요소에 id속성을 설정해줘야 합니다.
                //"GSuserPW"도 마찬가지
                HtmlElementCollection temp = document_main.GetElementsByTagName("input").GetElementsByName("GSuserID");
                if(temp == null) {
                    MessageBox.Show("Login메서드 실행 실패지점 1\n개발자에게 문의해주세요.");
                    return;
                }
                HtmlElement input_userId = temp[1];

                temp = document_main.GetElementsByTagName("input").GetElementsByName("GSuserPW");
                if (temp == null) {
                    MessageBox.Show("Login메서드 실행 실패지점 2\n개발자에게 문의해주세요.");
                    return;
                }
                HtmlElement input_userPwd = temp[1];

                //frmLogin이라는 Name 속성을 가진 Form 태그 요소를 찾습니다.
                temp = document_main.Forms.GetElementsByName("frmLogin");
                if(temp == null) {
                    MessageBox.Show("Login메서드 실행 실패지점 3\n개발자에게 문의해주세요.");
                    return;
                }

                HtmlElement form_login = temp[0];
                if (input_userId == null || input_userPwd == null || form_login == null) {
                    MessageBox.Show("Login메서드 실행 실패지점 4\n개발자에게 문의해주세요.");
                    return;
                }

                input_userId.SetAttribute("value", id); //아이디를 웹페이지에 입력

                try {
                    input_userPwd.SetAttribute("value", EncryptionSupporter.Unprotect(pw)); //복호화된 패스워드를 웹페이지에 입력
                } catch (CryptographicException e) {
                    //사용자가 암호화된 패스워드가 포함된 설정파일을 타 PC로 복사 후 사용 시 발생하는 오류
                    Debug.WriteLine(e.Message);
                    MessageBox.Show("암호화된 패스워드를 복호화하는데 실패하였습니다.\n설정 파일을 타 PC로 복사하지 말아주세요.\n모든 패스워드가 초기화 됩니다.", "패스워드 복호화 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearPassword();
                    return;
                }

                isLogin = true;
                form_login.InvokeMember("submit"); //입력된 아이디와 패스워드로 로그인을 시도
                currentLoginClient = client; //여기까지 무사히 왔다면 로그인을 하였다고 간주 (단, 로딩 이벤트에서 로그인 완료하였는지 체크하여 안되었을 시 None으로 변경)
            } catch (ArgumentOutOfRangeException e) {
                isLogin = false;
                MessageBox.Show(e.StackTrace);
            }
        }

        private void clearPassword() {
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_1"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_1"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_1"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_2"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_2"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_2"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_3"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_3"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_3"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_4"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_4"].Value = "";
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_4"].Value = "";

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
            LoadSetting();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// OTP 로그인
        /// </summary>
        private bool OtpLogin() {
            try {
                HtmlElementCollection input_otp = this.document_main.GetElementsByTagName("input").GetElementsByName("GSotpNo"); //OTP 입력상자를 가져옵니다.
                if (input_otp.Count == 0) {
                    MessageBox.Show("OtpLogin 메서드 실행 오류 : OTP 입력 창을 찾을 수 없습니다.");
                    return false;
                }

                string otpCode = string.Empty;

                Form otpDialogForm = new MetroForm() {
                    Width = 300,
                    Height = 100,
                    Text = "OTP를 입력해주세요.",
                    StartPosition = FormStartPosition.Manual, //CenterParent 설정 및 Owner설정 시 otp 입력이 정상적으로 되지 않음..
                    Resizable = false,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle
                };

                otpDialogForm.Left = this.Left + (this.Width - otpDialogForm.Width) / 2;
                otpDialogForm.Top = this.Top + (this.Height - otpDialogForm.Height) / 2;
                MetroTextBox textBox_otp = new MetroTextBox() { Left = 30, Top = 60, Width = 180, MaxLength = 8 };
                MetroButton button_otpConfirm = new MetroButton() { Left = 220, Top = 60, Width = 50, Text = "로그인", DialogResult = DialogResult.OK };
                otpDialogForm.AcceptButton = button_otpConfirm;
                button_otpConfirm.DialogResult = DialogResult.OK;

                otpDialogForm.FormClosed += (sender, e) => {
                    Delay(500);
                    this.Activate(); //OTP 로그인 후 버튼 두 번 클릭해야하는 현상 방지
                };

                bool isCancle = false;
                otpDialogForm.FormClosing += (sender, e) => {
                    if(otpDialogForm.DialogResult == DialogResult.OK) {
                        if (textBox_otp.Text.Length < 8) {
                            MessageBox.Show("OTP 코드를 다시 확인해주세요.\nOTP 코드는 8자리 입니다.", "OTP 코드 입력", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                        } else {
                            otpCode = textBox_otp.Text;

                            Debug.WriteLine(otpCode);
                            input_otp[0].SetAttribute("value", otpCode);

                            //opt 입력이 되었으므로, 클릭
                            HtmlElement button_otp_login = document_main.GetElementById("btn_Send");
                            object result = button_otp_login.InvokeMember("Click");
                            mainBrowser.Url = new Uri(url_main); //로그인 실패 여부를 판단하기 위해 메인 홈페이지로 이동
                        }
                    } else {
                        //X버튼으로 닫았을 때 (Cancle)
                        mainBrowser.Navigate(url_main);
                        isCancle = true;
                    }
                };

                otpDialogForm.Controls.Add(textBox_otp);
                otpDialogForm.Controls.Add(button_otpConfirm);
                otpDialogForm.ShowDialog();

                if (isCancle) {
                    Debug.WriteLine("OTP 로그인 취소");
                    return false;
                }

                return true;
            } catch(Exception ex) {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 로그아웃
        /// </summary>
        private void Logout() {
            if (currentLoginClient != Client.None) {
                Debug.WriteLine("로그아웃 시작");
                switch (currentLoginClient) {
                    case Client.MainClient:
                        toggle_client_1.Checked = false;
                        break;
                    case Client.Client2:
                        toggle_client_2.Checked = false;
                        break;
                    case Client.Client3:
                        toggle_client_3.Checked = false;
                        break;
                    default:
                        Debug.WriteLine("SetStatus: 잘못된 Client 인자 전달");
                        break;
                }

                currentLoginClient = Client.None;
                mainBrowser.Navigate(url_logout);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 게임 시작
        /// </summary>
        private void GameStart(string client_path) {
            document_main = mainBrowser.Document;
            if(document_main == null) {
                MessageBox.Show("GameStart에서 document_main이 null입니다.\n관리자에게 문의해주세요.");
                return;
            }

            if (currentLoginClient == Client.None) {
                MessageBox.Show("로그인을 먼저 해주세요.");
                return;
            }

            //거상의 실행 경로를 저장하는 레지스트리에 접근합니다.
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\JOYON\Gersang\Korean", RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (registryKey != null) {
                registryKey.SetValue("InstallPath", client_path);
                registryKey.Close();
            }

            if (this.isActiveX) {
                //홈페이지에서 gameStart 스크립트를 실행합니다. (인자가 1이면 본섭, 2면 테섭을 실행합니다)
                this.document_main.InvokeScript("gameStart", new object[] { 1 });
            } else {
                //ActiveX가 아닌 GersangStarter로 실행하도록 합니다.
                //참고 : https://github.com/LOONACIA/GersangLauncher

                string script = "function myStart() {\n self.location.href='Gersang:';\n startRetry = setTimeout(\"socketStart('main')\", 2000);" + "\n}";
                HtmlElement script_start = this.document_main.CreateElement("script"); //새로운 스크립트 요소를 추가합니다
                script_start.SetAttribute("language", "JavaScript");
                script_start.InnerHtml = script;
                this.document_main.GetElementsByTagName("head")[0].AppendChild(script_start);
                this.document_main.InvokeScript("myStart");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 검색 보상 수령용 이벤트 브라우저 로딩 이벤트
        /// </summary>
        //하드코딩한 임시 bool 변수
        bool isFind = false; //이벤트 페이지 링크를 찾았는지 여부
        bool isNaver = false; //현재 네이버 검색창인지
        bool isMainPage = false; //거상 홈페이지인지
        bool isEventPage = false; //출석체크 이벤트 페이지인지
        private void eventBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            //절대경로가 같은지 체크하여 이 이벤트가 3번 실행되는 것을 방지합니다.
            if (e.Url.AbsoluteUri != eventBrowser.Url.AbsoluteUri) {
                return;
            }

            Debug.WriteLine("<< 현재 이벤트 브라우저 접속 URL : " + e.Url + " >>");

            //프로그램을 시작하자마자 출석체크 이벤트 페이지를 찾고, 리턴합니다.
            //찾은 뒤에는 진입하지 않습니다.
            if (!isFind) {
                foreach (HtmlElement element in eventBrowser.Document.GetElementsByTagName("a")) {
                    string href = element.GetAttribute("href");
                    if (href.Contains("attendance")) {
                        url_event = href;
                        Debug.WriteLine("이벤트 페이지 링크 : " + url_event);
                        isFind = true;
                        return;
                    }
                }
                return;
            }

            if(url_event.Equals("")) {
                Debug.WriteLine("이벤트 페이지를 찾지 못하여 다음 과정을 진행하지 않습니다.");
                return;
            }

            //출석체크 이벤트 페이지를 성공적으로 찾았으며, 현재 네이버에 거상을 검색한 상태라면,
            //검색페이지 내의 거상 공식홈페이지 링크 버튼을 찾고 누릅니다.
            if (isNaver && e.Url.ToString().Contains(url_search_gersang)) {
                Debug.WriteLine("네이버 검색 완료 -> 거상 링크 클릭");
                clickGersangLink();
                return;
            }

            //거상 홈페이지에 들어왔다면, 바로 이벤트 페이지로 접속합니다.
            if (isMainPage && e.Url.ToString().Contains(url_main)) {
                Debug.WriteLine("거상 메인화면 -> 거상 링크 클릭");
                navigateEventPage();
                return;
            }

            //거상 출석체크 이벤트 페이지에 접속하였다면, 현재 시간 체크 후 해당 시간의 아이템 받기 버튼을 클릭합니다.
            if (isEventPage && e.Url.ToString().Contains(url_event)) {
                Debug.WriteLine("이벤트 페이지 -> 보상 수령 버튼 클릭");
                if (eventBrowser.Document.GetElementById("pop") != null) { //단순히 정말로 페이지가 다 로딩된건지 확인하기 위함입니다.
                    clickItemGet();
                }
            }

            isProcessing = false;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 네이버 검색 버튼 클릭
        /// </summary>
        private void button_search_naver_Click(object sender, EventArgs e) {
            if (isProcessing) {
                Debug.WriteLine("지금은 버튼을 누를 수 없습니다.");
                return;
            }

            document_main = mainBrowser.Document;
            if (document_main == null) {
                MessageBox.Show("button_search_naver_Click에서 document_main이 null입니다.\n관리자에게 문의해주세요.");
                return;
            }

            if (url_event == "" || !isFind) {
                MessageBox.Show("이벤트 페이지를 찾지 못하였습니다.");
                return;
            }

            if (isDebuggingSearchMode) {
                //검색 보상 수령이 안되는 경우 검색모드 디버깅모드를 체크하면
                //직접 작동하는걸 확인 가능합니다.
                Form debugSearchForm = new Form() {
                    Width = 1300,
                    Height = 1000,
                    StartPosition = FormStartPosition.CenterScreen
                };
                debugSearchForm.FormClosed += delegate (object obj, FormClosedEventArgs args) {
                    debugSearchForm.Controls.Clear();
                };

                debugSearchForm.Controls.Add(eventBrowser);
                debugSearchForm.Show();
            }

            //네이버 검색 페이지 접속 -> 거상 공홈 버튼 클릭 -> 이벤트 페이지 이동 -> 아이템 획득 순서로 진행됩니다.
            //각 과정이 메서드로 분리되어 DocumentLoading시에 실행됩니다.
            Client client;

            //클릭한 버튼에 따라 변수를 초기화
            Button button_search = sender as Button;
            if (button_search.Equals(button_search_naver_1)) { client = Client.MainClient; }
            else if (button_search.Equals(button_search_naver2)) { client = Client.Client2; } 
            else if (button_search.Equals(button_search_naver3)) { client = Client.Client3; } 
            else {
                client = Client.None;
                MessageBox.Show("잘못된 검색 버튼");
                return;
            }

            isProcessing = true;

            if (currentLoginClient != client) {
                //다른 계정에 로그인 되어있거나, 로그아웃 상태라면,

                if(currentLoginClient != Client.None) {
                    isSearch_Logout = true;
                    current_change_client = client;
                    Logout(); //로그아웃 한다.
                    //Login(client); //로그인 한다.
                    //navigateSearchPage(); //네이버 검색창에 접속한다.
                } else {
                    //로그인이 안되어있다면,
                    isSearch_Login = true;
                    Login(client);
                    //navigateSearchPage(); //네이버 검색창에 접속한다.
                }
            } else {
                //시작하려는 거상 계정에 로그인되어있다면 그냥 실행
                navigateSearchPage();
                return;
            }
        }

        //네이버에 거상을 검색
        private void navigateSearchPage() {
            isNaver = true;
            eventBrowser.Navigate(url_search_gersang);
        }

        //거상 공홈 버튼 클릭
        private void clickGersangLink() {
            foreach (HtmlElement element in eventBrowser.Document.GetElementsByTagName("a")) {
                string href = element.GetAttribute("href");
                if (href.Equals("http://www.gersang.co.kr/main.gs")) {
                    element.SetAttribute("target", "_self"); //새 창이 열리지 않도록 합니다
                    element.InvokeMember("click");
                    isNaver = false;
                    isMainPage = true;
                    return;
                }
            }

            isNaver = false;
            Debug.WriteLine("네이버 검색창에서 거상 링크를 찾지 못하였습니다.");
        }

        //출석체크 이벤트 페이지로 이동
        private void navigateEventPage() {
            isMainPage = false;
            isEventPage = true;
            eventBrowser.Navigate(url_event);
        }

        //보상 수령
        private void clickItemGet() {
            isEventPage = false;

            /* 검색보상 수령 시간대별 인자 값
            1-> 00:05 ~05:55
            2-> 06:05 ~11:55
            3-> 12:05 ~17:55
            4-> 18:05 ~23:55
            */
            int arg; //event_Search_Use 스크립트 실행 인자

            int koreaHour = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Korea Standard Time").Hour;
            if (koreaHour >= 0 && koreaHour <= 5) {
                arg = 1;
            } else if (koreaHour >= 6 && koreaHour <= 11) {
                arg = 2;
            } else if (koreaHour >= 12 && koreaHour <= 17) {
                arg = 3;
            } else {
                arg = 4;
            }

            eventBrowser.Document.InvokeScript("event_Search_Use", new object[] { arg });

            Delay(500);
            Activate(); //검색 보상 기능 실행 후 폼이 비활성화 되어 실행 버튼을 두번 눌러야 하는 현상 방지
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 로그인 토글버튼 클릭 & 별명 체크박스 클릭
        /// </summary>
        private void toggle_client_1_Click(object sender, EventArgs e) {
            MetroToggle toggle = sender as MetroToggle;

            if (isProcessing) {
                Debug.WriteLine("지금은 버튼을 누를 수 없습니다.");
                toggle.Checked = !toggle.Checked;
                return;
            }
            isProcessing = true;
           
            if (toggle.Checked) {
                if (client_id_1 == "" || client_pw_1 == "" || client_path_1 == "") {
                    toggle_client_1.Checked = false;
                    MessageBox.Show("경로 또는 아이디 또는 비밀번호가 설정되지 않았습니다.");
                    return;
                }

                if (currentLoginClient != Client.None) {
                    isChangeLogin = true;
                    current_change_client = Client.MainClient;
                    Logout();
                } else {
                    Login(Client.MainClient);
                }
            } else {
                Logout();
            }
        }

        private void toggle_client_2_Click(object sender, EventArgs e) {
            MetroToggle toggle = sender as MetroToggle;

            if (isProcessing) {
                Debug.WriteLine("지금은 버튼을 누를 수 없습니다.");
                toggle.Checked = !toggle.Checked;
                return;
            }
            isProcessing = true;

            if (toggle.Checked) {
                if (client_id_2 == "" || client_pw_2 == "" || client_path_2 == "") {
                    toggle_client_2.Checked = false;
                    MessageBox.Show("경로 또는 아이디 또는 비밀번호가 설정되지 않았습니다.");
                    return;
                }

                if (currentLoginClient != Client.None) {
                    isChangeLogin = true;
                    current_change_client = Client.Client2;
                    Logout();
                } else {
                    Login(Client.Client2);
                }
            } else {
                Logout();
            }
        }

        private void toggle_client_3_Click(object sender, EventArgs e) {
            MetroToggle toggle = sender as MetroToggle;

            if (isProcessing) {
                Debug.WriteLine("지금은 버튼을 누를 수 없습니다.");
                toggle.Checked = !toggle.Checked;
                return;
            }
            isProcessing = true;

            if (toggle.Checked) {
                if (client_id_3 == "" || client_pw_3 == "" || client_path_3 == "") {
                    toggle_client_3.Checked = false;
                    MessageBox.Show("경로 또는 아이디 또는 비밀번호가 설정되지 않았습니다.");
                    return;
                }

                if (currentLoginClient != Client.None) {
                    isChangeLogin = true;
                    current_change_client = Client.Client3;
                    Logout();
                } else {
                    Login(Client.Client3);
                }
            } else {
                Logout();
            }
        }

        //별명 표시 체크박스 클릭
        private void check_nickname_CheckedChanged(object sender, EventArgs e) {
            config.AppSettings.Settings["display_nickname"].Value = check_nickname.Checked.ToString();
            LoadSetting();
        }

        //ID/PW 바로입력 체크박스 클릭
        private void check_direct_CheckedChanged(object sender, EventArgs e) {
            config.AppSettings.Settings["input_direct"].Value = check_direct.Checked.ToString();
            LoadSetting();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 세팅 토글 버튼 클릭
        /// </summary>
        private void radio_setting_CheckedChanged(object sender, EventArgs e) {
            RadioButton rb = sender as RadioButton;

            if (rb == null) {
                MessageBox.Show("오류 발생 : radio_setting_CheckedChanged\nsender is null");
                return;
            }

            if (rb.Checked) {
                if (rb.Equals(radio_setting_1)) {
                    config.AppSettings.Settings["setting_num"].Value = "1";
                } else if (rb.Equals(radio_setting_2)) {
                    config.AppSettings.Settings["setting_num"].Value = "2";
                } else if (rb.Equals(radio_setting_3)) {
                    config.AppSettings.Settings["setting_num"].Value = "3";
                } else if (rb.Equals(radio_setting_4)) {
                    config.AppSettings.Settings["setting_num"].Value = "4";
                } else {
                    MessageBox.Show("오류 발생 : radio_setting_CheckedChanged\nUnknown RadioButton");
                    return;
                }

                config.Save(ConfigurationSaveMode.Modified, true); //Full로 하면 특정 환경에서 오류 발생
                ConfigurationManager.RefreshSection("appSettings");
                LoadSetting();
                initTextBox();
                checkClientVersion();

                //만약 로그인 되어있었다면, 로그아웃 합니다.
                if (currentLoginClient != Client.None) {
                    Logout();
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 각종 링크 클릭
        /// </summary>
        private void link_blog_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222597523325");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_github_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://github.com/byungmeo/GersangClientStation");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_shortcut_1_Click(object sender, EventArgs e) {
            if (shortcut_address_1 == "") {
                MessageBox.Show("바로가기 주소를 설정 해주세요.");
                return;
            }
            try {
                isShortcut = true;
                Form_Browser shortcutForm = new Form_Browser(mainBrowser, shortcut_address_1);
                shortcutForm.ShowDialog();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_shortcut_2_Click(object sender, EventArgs e) {
            if (shortcut_address_2 == "") {
                MessageBox.Show("바로가기 주소를 설정 해주세요.");
                return;
            }

            try {
                isShortcut = true;
                Form_Browser shortcutForm = new Form_Browser(mainBrowser, shortcut_address_2);
                shortcutForm.ShowDialog();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_shortcut_3_Click(object sender, EventArgs e) {
            if (shortcut_address_3 == "") {
                MessageBox.Show("바로가기 주소를 설정 해주세요.");
                return;
            }

            try {
                isShortcut = true;
                Form_Browser shortcutForm = new Form_Browser(mainBrowser, shortcut_address_3);
                shortcutForm.ShowDialog();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_shortcut_4_Click(object sender, EventArgs e) {
            if (shortcut_address_4 == "") {
                MessageBox.Show("바로가기 주소를 설정 해주세요.");
                return;
            }

            try {
                isShortcut = true;
                Form_Browser shortcutForm = new Form_Browser(mainBrowser, shortcut_address_4);
                shortcutForm.ShowDialog();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_shortcut_5_Click(object sender, EventArgs e) {
            if (shortcut_address_5 == "") {
                MessageBox.Show("바로가기 주소를 설정 해주세요.");
                return;
            }

            try {
                isShortcut = true;
                Form_Browser shortcutForm = new Form_Browser(mainBrowser, shortcut_address_5);
                shortcutForm.ShowDialog();
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_qa1_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222598459133");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_qa2_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222599326032");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        private void link_icon_license_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://icons8.com");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 게임 시작 버튼 클릭
        /// </summary>
        private void button_start_Click(object sender, EventArgs e) {
            if (isProcessing) {
                Debug.WriteLine("지금은 버튼을 누를 수 없습니다.");
                return;
            }
            isProcessing = true;

            Client client = Client.None;
            string client_path = "";
            int version = 0;
            string id = "";
            string pw = "";

            try {
                //클릭한 버튼에 따라 변수를 초기화
                Button button_start = sender as Button;
                if (button_start.Equals(button_start_1)) {
                    client = Client.MainClient;
                    client_path = client_path_1;
                    version = Int16.Parse(label_client_1_version.Text);
                    id = client_id_1;
                    pw = client_pw_1;
                } else if (button_start.Equals(button_start_2)) {
                    client = Client.Client2;
                    client_path = client_path_2;
                    version = Int16.Parse(label_client_2_version.Text);
                    id = client_id_2;
                    pw = client_pw_2;
                } else if (button_start.Equals(button_start_3)) {
                    client = Client.Client3;
                    client_path = client_path_3;
                    version = Int16.Parse(label_client_3_version.Text);
                    id = client_id_3;
                    pw = client_pw_3;
                } else {
                    client = Client.None;
                    client_path = string.Empty;
                    version = 0;
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                version = 0;
            }
            

            //예외 처리
            if (client == Client.None) {
                MessageBox.Show("잘못된 시작 버튼, 개발자에게 문의하세요.");
                return;
            }

            if (client_path == "") {
                MessageBox.Show("거상 경로를 지정해주세요.\n클라이언트 설정 창을 엽니다.", "경로 설정", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                menuItem_client.PerformClick();
                return;
            }

            if(version < Int16.Parse(label_gersangLatestVersion.Text) && version != 0 && !label_gersangLatestVersion.Text.Equals("00000")) {
                DialogResult dr = MessageBox.Show("거상 업데이트가 필요합니다.\n다클라 스테이션의 패치 기능으로\n훨씬 빠르게 업데이트 하시겠습니까?", "업데이트", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dr == DialogResult.Yes) {
                    string origin_path = Form_Main.config.AppSettings.Settings["gersang_original_path"].Value;

                    //원본 폴더 경로가 설정되어 있는지 확인
                    if (origin_path.Equals("")) {
                        MessageBox.Show("거상 원본 폴더가 지정되지 않았습니다.\n거상 패치 설정 창을 엽니다."
                            , "거상 패치 설정", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        menuItem_patch.PerformClick();
                        return;
                    } else {
                        Form_Patch form_patch = new Form_Patch();
                        form_patch.ShowDialog();
                        checkClientVersion();
                        return;
                    }
                }
            }

            if(id.Equals("")) {
                MessageBox.Show("아이디를 입력해주세요..\n클라이언트 설정 창을 엽니다.", "아이디 설정", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                menuItem_client.PerformClick();
                return;
            }

            if(pw.Equals("")) {
                MessageBox.Show("비밀번호를 입력해주세요..\n클라이언트 설정 창을 엽니다.", "패스워드 설정", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                menuItem_client.PerformClick();
                return;
            }

            if (isDebuggingMode) {
                //검색 보상 수령이 안되는 경우 검색모드 디버깅모드를 체크하면
                //직접 작동하는걸 확인 가능합니다.
                Form debugForm = new Form() {
                    Width = 1300,
                    Height = 1000,
                    StartPosition = FormStartPosition.CenterScreen
                };
                debugForm.FormClosed += delegate (object obj, FormClosedEventArgs args) {
                    debugForm.Controls.Clear();
                };

                debugForm.Controls.Add(mainBrowser);
                debugForm.Show();
            }

            if(currentLoginClient != client) {
                current_client_path = client_path;
                if (currentLoginClient == Client.None) {
                    isGameStart_Login = true;
                    Login(client);
                    //GameStart(client_path);
                } else {
                    isGameStart_Logout = true;
                    current_change_client = client;
                    Logout();
                    //Login(client);
                    //GameStart(client_path);
                }
            } else {
                //시작하려는 거상 계정에 로그인되어있다면 그냥 실행
                GameStart(client_path);
                isProcessing = false;
            }

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 메뉴 클릭
        /// </summary>

        //클라이언트 설정
        private void menuItem_client_Click(object sender, EventArgs e) {
            byte settingNumber = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);
            Form_Setting settingDialogForm = new Form_Setting(settingNumber);
            settingDialogForm.ShowDialog();
            LoadSetting(); //세팅값이 바뀌었다면 새로고침 합니다.
            checkClientVersion();
        }

        //바로가기 경로 설정
        private void menuItem_shortcut_Click(object sender, EventArgs e) {
            Form_Shortcut shortcutDialogForm = new Form_Shortcut();
            shortcutDialogForm.ShowDialog();
            LoadSetting(); //세팅값이 바뀌었다면 새로고침 합니다.
        }
        
        private void menuItem_create_Click(object sender, EventArgs e) {
            Form_Creator form_creator = new Form_Creator();
            form_creator.ShowDialog();
            checkClientVersion();
        }

        private void menuItem_patch_Click(object sender, EventArgs e) {
            Form_PatchSetting form_patchSetting = new Form_PatchSetting();
            form_patchSetting.ShowDialog();
        }

        //실험실
        private void menuItem_lab_Click(object sender, EventArgs e) {
            Form_Lab labForm = new Form_Lab();

            MetroCheckBox check_activeX = new MetroCheckBox() { Left = 30, Top = 120, Text = "ActiveX 사용" };
            check_activeX.CheckedChanged += delegate (object obj, EventArgs eventArgs) {
                this.isActiveX = ((MetroCheckBox)obj).Checked;
                config.AppSettings.Settings["use_activeX"].Value = isActiveX.ToString();
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
            };

            MetroCheckBox check_debug = new MetroCheckBox() { Left = 30, Top = 150, Text = "디버깅 모드" };
            check_debug.CheckedChanged += delegate (object obj, EventArgs eventArgs) {
                this.isDebuggingMode = ((MetroCheckBox)obj).Checked;
            };

            MetroCheckBox check_debugSearch = new MetroCheckBox() { Left = 30, Top = 180, Width = 140, Text = "검색보상 디버깅 모드" };
            check_debugSearch.CheckedChanged += delegate (object obj, EventArgs eventArgs) {
                this.isDebuggingSearchMode = ((MetroCheckBox)obj).Checked;
            };

            labForm.Controls.Add(check_activeX);
            labForm.Controls.Add(check_debug);
            labForm.Controls.Add(check_debugSearch);

            labForm.Load += delegate (object obj, EventArgs eventArgs) {
                check_activeX.Checked = this.isActiveX;
                check_debug.Checked = this.isDebuggingMode;
                check_debugSearch.Checked = this.isDebuggingSearchMode;
            };

            labForm.ShowDialog();
        }

        private void menuItem_question_Click(object sender, EventArgs e) {
            Form_Question questionForm = new Form_Question();
            questionForm.ShowDialog();
        }

        private void menuItem_contact_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222605986594");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        //프로그램 정보
        private void menuItem_info_Click(object sender, EventArgs e) {
            Form_Information informationForm = new Form_Information();
            informationForm.ShowDialog();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 세팅 메서드
        /// </summary>
        //깃허브 레포지토리의 최신 Release 버전을 이용하여 최신버전인지 체크하고, 구버전이라면 깃허브 링크로 안내합니다.
        private async void checkUpdate() {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //버전 업데이트 시 Properties -> AssemblyInfo.cs 의 AssemblyVersion과 AssemblyFileVersion을 바꿔주세요.
            currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, 5);

            //이전 버전의 config파일을 가져온 유저를 위해 업데이트 알림 수신과 관련한 config를 초기화 합니다.
            KeyValueConfigurationElement element_check_update = Form_Main.config.AppSettings.Settings["check_update"];
            if (element_check_update == null) { 
                Form_Main.config.AppSettings.Settings.Add("check_update", "True");
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
            }

            KeyValueConfigurationElement element_ignore_version = Form_Main.config.AppSettings.Settings["current_ignore_version"];
            if (element_ignore_version == null) { 
                Form_Main.config.AppSettings.Settings.Add("current_ignore_version", "");
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
            }

            try {
                //깃허브에서 모든 릴리즈 정보를 받아옵니다.
                GitHubClient client = new GitHubClient(new ProductHeaderValue("Byungmeo"));
                IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("byungmeo", "GersangClientStation");
                latestVersion = releases[0].TagName;

                //깃허브에 게시된 마지막 버전과 현재 버전을 초기화 합니다.
                //Version latestGitHubVersion = new Version(releases[0].TagName);
                Version latestGitHubVersion = new Version(latestVersion);
                Version localVersion = new Version(currentVersion);
                Debug.WriteLine("깃허브에 마지막으로 게시된 버전 : " + latestGitHubVersion);
                Debug.WriteLine("현재 프로젝트 버전 : " + localVersion);

                //버전 비교
                int versionComparison = localVersion.CompareTo(latestGitHubVersion);
                if (versionComparison < 0) {
                    if(!Boolean.Parse(config.AppSettings.Settings["check_update"].Value)) {
                        //업데이트 알림을 받지 않기로 체크하였음
                        Debug.WriteLine("업데이트 알림을 받지 않기로 이전에 체크 하였음.");
                        Debug.WriteLine("알림을 띄우지 않기로 한 버전 : " + config.AppSettings.Settings["current_ignore_version"].Value);
                        if (latestGitHubVersion.ToString() == config.AppSettings.Settings["current_ignore_version"].Value) {
                            //당시 알림을 받지 않기로 한 버전이 현재 업데이트 버전과 동일하면 알림을 띄우지 않습니다.
                            return;
                        } else {
                            //만약 당시 알림을 받지 않기로 한 버전보다 상위 버전이 출시되면 다시 알림을 띄우도록 합니다.
                            config.AppSettings.Settings["check_update"].Value = "True";
                            config.Save(ConfigurationSaveMode.Modified, true);
                            ConfigurationManager.RefreshSection("appSettings");
                        }
                    }
                    Debug.WriteLine("구버전입니다! 업데이트 메시지박스를 출력합니다!");

                    DialogResult dr1 = MessageBox.Show(releases[0].Body + "\n\n업데이트 하시겠습니까? (GitHub 접속)",
                        "업데이트 안내", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr1 == DialogResult.Yes) {
                        System.Diagnostics.Process.Start("https://github.com/byungmeo/GersangClientStation/releases/latest");
                    } else {
                        DialogResult dr2 = MessageBox.Show("다다음 패치가 게시될 때 까지 업데이트 알림을 받지 않으시겠습니까?",
                        "업데이트 알림", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        
                        if (dr2 == DialogResult.Yes) {
                            Debug.WriteLine("업데이트 알림을 받지 않기로 체크 하였음.");
                            Debug.WriteLine("다음부터 알림을 받지 않을 버전 : " + latestGitHubVersion.ToString());
                            config.AppSettings.Settings["check_update"].Value = "False";
                            config.AppSettings.Settings["current_ignore_version"].Value = latestGitHubVersion.ToString();
                            config.Save(ConfigurationSaveMode.Modified, true);
                            ConfigurationManager.RefreshSection("appSettings");
                        }
                    }
                } else if (versionComparison > 0) {
                    Debug.WriteLine("깃허브에 릴리즈된 버전보다 최신입니다!");
                } else {
                    Debug.WriteLine("현재 버전은 최신버전입니다!");
                }
            } catch (Exception ex) {
                MessageBox.Show("프로그램 업데이트 확인 도중 에러가 발생하였습니다.\n에러 메시지를 캡쳐하고, 문의 부탁드립니다.", "업데이트 확인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("에러 메시지1 : \n" + ex.Message);
                MessageBox.Show("에러 메시지2 : \n" + ex.ToString());
                Debug.WriteLine(ex.Message);
            }
        }

        //클라이언트 경로, 아이디, 비밀번호를 세팅값에 맞춰 세팅합니다.
        private void LoadSetting() {
            byte settingNumber = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);

            //이전 버전에서 설정 파일을 가져온 경우 세팅값을 임의로 설정합니다.
            for (int tab = 1; tab <= 4; tab++) {
                for (int num = 1; num <= 3; num++) {
                    KeyValueConfigurationElement element_name = Form_Main.config.AppSettings.Settings["client_name_" + num + "_tab_" + tab];
                    if (element_name == null) { Form_Main.config.AppSettings.Settings.Add("client_name_" + num + "_tab_" + tab, "Client" + num); }

                    KeyValueConfigurationElement element_path = Form_Main.config.AppSettings.Settings["client_path_" + num + "_tab_" + tab];
                    if (element_path == null) { Form_Main.config.AppSettings.Settings.Add("client_path_" + num + "_tab_" + tab, ""); }

                    KeyValueConfigurationElement element_id = Form_Main.config.AppSettings.Settings["client_id_" + num + "_tab_" + tab];
                    if (element_id == null) { Form_Main.config.AppSettings.Settings.Add("client_id_" + num + "_tab_" + tab, ""); }

                    KeyValueConfigurationElement element_pw = Form_Main.config.AppSettings.Settings["client_pw_" + num + "_tab_" + tab];
                    if (element_pw == null) { Form_Main.config.AppSettings.Settings.Add("client_pw_" + num + "_tab_" + tab, ""); }
                }
            }

            //이전 버전에서 설정 파일을 가져온 경우 바로가기 설정을 임의로 설정합니다.
            for (int num = 1; num <= 5; num++) {
                KeyValueConfigurationElement element_shortcut_name = Form_Main.config.AppSettings.Settings["shortcut_name_" + num];
                if (element_shortcut_name == null) { Form_Main.config.AppSettings.Settings.Add("shortcut_name_" + num, "바로가기" + num); }

                KeyValueConfigurationElement element_shortcut_address = Form_Main.config.AppSettings.Settings["shortcut_address_" + num];
                if (element_shortcut_address == null) { Form_Main.config.AppSettings.Settings.Add("shortcut_address_" + num, url_main); }
            }

            //이전 버전에서 설정 파일을 가져온 경우 별명 표시 여부 설정을 임의로 설정합니다.
            KeyValueConfigurationElement element_display_nickname = Form_Main.config.AppSettings.Settings["display_nickname"];
            if (element_display_nickname == null) { Form_Main.config.AppSettings.Settings.Add("display_nickname", "True"); }

            //이전 버전에서 설정 파일을 가져온 경우 ID/PW 바로 입력 여부 설정을 임의로 설정합니다.
            KeyValueConfigurationElement element_input_direct = Form_Main.config.AppSettings.Settings["input_direct"];
            if (element_input_direct == null) { Form_Main.config.AppSettings.Settings.Add("input_direct", "False"); }

            //이전 버전에서 설정 파일을 가져온 경우 ActiveX 사용 여부 설정을 임의로 설정합니다.
            KeyValueConfigurationElement element_use_activeX = Form_Main.config.AppSettings.Settings["use_activeX"];
            if (element_use_activeX == null) { Form_Main.config.AppSettings.Settings.Add("use_activeX", "True"); }

            //이전 버전에서 설정 파일을 가져온 경우 거상 패치 관련 설정을 초기화 합니다.
            KeyValueConfigurationElement element_original_path = Form_Main.config.AppSettings.Settings["gersang_original_path"];
            if (element_original_path == null) { Form_Main.config.AppSettings.Settings.Add("gersang_original_path", ""); }
            KeyValueConfigurationElement element_removeFile = Form_Main.config.AppSettings.Settings["remove_file_after_patch"];
            if (element_removeFile == null) { Form_Main.config.AppSettings.Settings.Add("remove_file_after_patch", "True"); }
            KeyValueConfigurationElement element_creator = Form_Main.config.AppSettings.Settings["apply_creator_after_patch"];
            if (element_creator == null) { Form_Main.config.AppSettings.Settings.Add("apply_creator_after_patch", "True"); }

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            this.client_path_1 = ConfigurationManager.AppSettings["client_path_1_tab_" + settingNumber];
            this.client_id_1 = ConfigurationManager.AppSettings["client_id_1_tab_" + settingNumber];
            this.client_pw_1 = ConfigurationManager.AppSettings["client_pw_1_tab_" + settingNumber];

            this.client_path_2 = ConfigurationManager.AppSettings["client_path_2_tab_" + settingNumber];
            this.client_id_2 = ConfigurationManager.AppSettings["client_id_2_tab_" + settingNumber];
            this.client_pw_2 = ConfigurationManager.AppSettings["client_pw_2_tab_" + settingNumber];

            this.client_path_3 = ConfigurationManager.AppSettings["client_path_3_tab_" + settingNumber];
            this.client_id_3 = ConfigurationManager.AppSettings["client_id_3_tab_" + settingNumber];
            this.client_pw_3 = ConfigurationManager.AppSettings["client_pw_3_tab_" + settingNumber];

            if (check_nickname.Checked) { 
                this.label_client_1.Text = ConfigurationManager.AppSettings["client_name_1_tab_" + settingNumber];
                this.label_client_2.Text = ConfigurationManager.AppSettings["client_name_2_tab_" + settingNumber];
                this.label_client_3.Text = ConfigurationManager.AppSettings["client_name_3_tab_" + settingNumber];
            } else { 
                this.label_client_1.Text = client_id_1;
                this.label_client_2.Text = client_id_2;
                this.label_client_3.Text = client_id_3;
            }

            if (check_direct.Checked) {
                changeInputDirectMode(true);
            } else {
                changeInputDirectMode(false);
            }

            this.shortcut_name_1 = ConfigurationManager.AppSettings["shortcut_name_1"];
            link_shortcut_1.Text = this.shortcut_name_1;
            this.shortcut_address_1 = ConfigurationManager.AppSettings["shortcut_address_1"];
            this.shortcut_name_2 = ConfigurationManager.AppSettings["shortcut_name_2"];
            link_shortcut_2.Text = this.shortcut_name_2;
            this.shortcut_address_2 = ConfigurationManager.AppSettings["shortcut_address_2"];
            this.shortcut_name_3 = ConfigurationManager.AppSettings["shortcut_name_3"];
            link_shortcut_3.Text = this.shortcut_name_3;
            this.shortcut_address_3 = ConfigurationManager.AppSettings["shortcut_address_3"];
            this.shortcut_name_4 = ConfigurationManager.AppSettings["shortcut_name_4"];
            link_shortcut_4.Text = this.shortcut_name_4;
            this.shortcut_address_4 = ConfigurationManager.AppSettings["shortcut_address_4"];
            this.shortcut_name_5 = ConfigurationManager.AppSettings["shortcut_name_5"];
            link_shortcut_5.Text = this.shortcut_name_5;
            this.shortcut_address_5 = ConfigurationManager.AppSettings["shortcut_address_5"];
        }

        private void changeInputDirectMode(bool flag) {
            this.label_client_1.Visible = !flag;
            this.label_client_2.Visible = !flag;
            this.label_client_3.Visible = !flag;

            textBox_client_1_id.Enabled = flag;
            textBox_client_1_id.Visible = flag;
            textBox_client_1_pw.Enabled = flag;
            textBox_client_1_pw.Visible = flag;
            button_save_1.Enabled = flag;
            button_save_1.Visible = flag;

            textBox_client_2_id.Enabled = flag;
            textBox_client_2_id.Visible = flag;
            textBox_client_2_pw.Enabled = flag;
            textBox_client_2_pw.Visible = flag;
            button_save_2.Enabled = flag;
            button_save_2.Visible = flag;

            textBox_client_3_id.Enabled = flag;
            textBox_client_3_id.Visible = flag;
            textBox_client_3_pw.Enabled = flag;
            textBox_client_3_pw.Visible = flag;
            button_save_3.Enabled = flag;
            button_save_3.Visible = flag;
        }

        //저장되어있는 세팅값 번호를 불러오고, 해당 세팅값으로 클라이언트를 세팅합니다.
        private void initRadioButton() {
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
                case 4:
                    radio_setting_4.PerformClick();
                    break;
                default:
                    MessageBox.Show("오류 발생 : Form1_Load\nInvalid Setting Number");
                    return;
            }
        }

        private void initCheckBox() {
            bool display_nickname = bool.Parse(ConfigurationManager.AppSettings["display_nickname"]);
            bool input_direct = bool.Parse(ConfigurationManager.AppSettings["input_direct"]);

            this.check_nickname.Checked = display_nickname;
            this.check_direct.Checked = input_direct;
        }

        private void initWebBrowser() {
            mainBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.mainBrowser_DocumentCompleted); //브라우저 로딩 완료 이벤트 리스너 부착
            mainBrowser.ScriptErrorsSuppressed = true; //Script Error가 뜨지 않도록 합니다.
            mainBrowser.Dock = DockStyle.Fill;
            mainBrowser.Navigate(url_main); //홈페이지 메인 화면으로 이동합니다.

            eventBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.eventBrowser_DocumentCompleted); //브라우저 로딩 완료 이벤트 리스너 부착
            eventBrowser.ScriptErrorsSuppressed = true; //Script Error가 뜨지 않도록 합니다.
            eventBrowser.Dock = DockStyle.Fill;
            eventBrowser.Url = new Uri(url_main, UriKind.Absolute); //홈페이지 메인 화면으로 이동합니다.
        }

        private void initLabFunction() {
            isActiveX = bool.Parse(ConfigurationManager.AppSettings["use_activeX"]);
        }

        //ID/PW 바로입력 기능을 위해 텍스트박스 초기화
        private void initTextBox() {
            byte settingNumber = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);

            textBox_client_1_id.Text = ConfigurationManager.AppSettings["client_id_1_tab_" + settingNumber];
            textBox_client_1_pw.Text = ConfigurationManager.AppSettings["client_pw_1_tab_" + settingNumber];

            textBox_client_2_id.Text = ConfigurationManager.AppSettings["client_id_2_tab_" + settingNumber];
            textBox_client_2_pw.Text = ConfigurationManager.AppSettings["client_pw_2_tab_" + settingNumber];

            textBox_client_3_id.Text = ConfigurationManager.AppSettings["client_id_3_tab_" + settingNumber];
            textBox_client_3_pw.Text = ConfigurationManager.AppSettings["client_pw_3_tab_" + settingNumber];
        }

        private void textBox_pw_TextChanged(object sender, System.EventArgs e) { isTextChanged = true; }

        private void textBox_client_1_pw_Leave(object sender, EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_1_pw.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_1_pw.Text = EncryptionSupporter.Protect(textBox_client_1_pw.Text);
                isTextChanged = false;
            }
        }

        private void textBox_client_2_pw_Leave(object sender, EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_2_pw.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_2_pw.Text = EncryptionSupporter.Protect(textBox_client_2_pw.Text);
                isTextChanged = false;
            }
        }

        private void textBox_client_3_pw_Leave(object sender, EventArgs e) {
            if (isTextChanged) {
                if (textBox_client_3_pw.Text == "") { return; }
                Debug.WriteLine("패스워드가 암호화 되었습니다.");
                textBox_client_3_pw.Text = EncryptionSupporter.Protect(textBox_client_3_pw.Text);
                isTextChanged = false;
            }
        }

        private void button_save_1_Click(object sender, EventArgs e) {
            byte setting_num = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);
            Form_Main.config.AppSettings.Settings["client_id_1_tab_" + setting_num].Value = textBox_client_1_id.Text;
            Form_Main.config.AppSettings.Settings["client_pw_1_tab_" + setting_num].Value = textBox_client_1_pw.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_save_2_Click(object sender, EventArgs e) {
            byte setting_num = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);
            Form_Main.config.AppSettings.Settings["client_id_2_tab_" + setting_num].Value = textBox_client_2_id.Text;
            Form_Main.config.AppSettings.Settings["client_pw_2_tab_" + setting_num].Value = textBox_client_2_pw.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_save_3_Click(object sender, EventArgs e) {
            byte setting_num = Byte.Parse(ConfigurationManager.AppSettings["setting_num"]);
            Form_Main.config.AppSettings.Settings["client_id_3_tab_" + setting_num].Value = textBox_client_3_id.Text;
            Form_Main.config.AppSettings.Settings["client_pw_3_tab_" + setting_num].Value = textBox_client_3_pw.Text;

            Form_Main.config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("저장이 완료되었습니다.", "경로 및 계정정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //거상 서버에서 vsn.dat 파일을 다운로드 받아 현재 거상 최신버전을 확인
        private void checkGersangUpdate() {
            try {
                //현재 거상 최신 버전을 확인합니다
                using (WebClient client = new WebClient()) {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                    client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");

                    DirectoryInfo binDirectory = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\bin");
                    if (!binDirectory.Exists) { binDirectory.Create(); } else {
                        foreach (FileInfo file in binDirectory.GetFiles()) {
                            if (file.Name.Equals("vsn.dat")) {
                                file.Delete();
                            }
                        }
                    }

                    client.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) => {
                        if (e.Error != null) {
                            Debug.WriteLine("vsn.dat 파일 다운로드 중 오류 발생");
                            Debug.WriteLine(e.Error.Message);
                        } else {
                            Debug.WriteLine("vsn.dat.gsz 파일 다운로드 완료");
                            ZipFile.ExtractToDirectory(binDirectory.FullName + @"\vsn.dat.gsz", binDirectory.FullName);
                            Debug.WriteLine("vsn.dat 파일 압축 해제 완료");

                            FileStream fs = File.OpenRead(binDirectory.FullName + @"\vsn.dat");
                            BinaryReader br = new BinaryReader(fs);
                            gersangLatestVersion = -(br.ReadInt32() + 1);
                            label_gersangLatestVersion.Text = gersangLatestVersion.ToString();
                            Debug.WriteLine("서버에 게시된 거상 최신 버전 : " + gersangLatestVersion);
                            fs.Close();
                            br.Close();

                            checkClientVersion();
                        }
                    };

                    Uri vsnPath = new Uri(@"https://akgersang.xdn.kinxcdn.com/Gersang/Patch/Gersang_Server/Client_Patch_File/Online/vsn.dat.gsz");
                    client.DownloadFileAsync(vsnPath, System.Windows.Forms.Application.StartupPath + @"\bin\vsn.dat.gsz");
                }
            } catch (Exception e) {
                MessageBox.Show("거상 최신 버전 확인 중 오류 발생\n" + e.Message);
            }

        }

        //클라이언트 경로에서 vsn.dat를 추출하여 현재 거상 클라버전을 확인
        private void checkClientVersion() {
            try {
                string[] client_path = new string[3] { client_path_1, client_path_2, client_path_3 };
                MetroLabel[] labels_clinet_version = new MetroLabel[3] { label_client_1_version, label_client_2_version, label_client_3_version };
                for (int i = 0; i < 3; i++) {
                    if (client_path[i].Equals("")) {
                        labels_clinet_version[i].Style = MetroFramework.MetroColorStyle.Silver;
                        labels_clinet_version[i].Text = "확인불가";
                        continue;
                    }
                    FileStream fs = File.OpenRead(client_path[i] + @"\Online\vsn.dat");
                    BinaryReader br = new BinaryReader(fs);
                    int currentVer = -(br.ReadInt32() + 1);
                    labels_clinet_version[i].Text = currentVer.ToString();
                    Debug.WriteLine("클라 " + i + "  버전 :" + currentVer);

                    if (currentVer < gersangLatestVersion) {
                        labels_clinet_version[i].Style = MetroFramework.MetroColorStyle.Red;
                    } else {
                        labels_clinet_version[i].Style = MetroFramework.MetroColorStyle.Black;
                    }
                    fs.Close();
                    br.Close();
                }
            } catch (Exception e) {
                Debug.WriteLine("클라이언트 버전 확인 중 오류 발생\n" + e.Message);
            }
        }

        //태스크바의 아이콘을 클릭 시 최소화, 최대화가 되도록 설정 (호출 필요 X)
        //원래 안되었던 이유 : MetroForm은 BorderStyle이 None이라서
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000;
                cp.ClassStyle |= 0x8;
                return cp;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 수동패치
        /// </summary>

        private void button_patch_Click(object sender, EventArgs e) {
            string origin_path = Form_Main.config.AppSettings.Settings["gersang_original_path"].Value;

            //원본 폴더 경로가 설정되어 있는지 확인
            if (origin_path.Equals("")) {
                MessageBox.Show("거상 원본 폴더가 지정되지 않았습니다.\n거상 패치 설정 창을 엽니다."
                    , "거상 패치 설정", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                menuItem_patch.PerformClick();
                return;
            } else {
                Form_Patch form_patch = new Form_Patch();
                form_patch.ShowDialog();
                checkClientVersion();
                return;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 유틸 메서드
        /// </summary>

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

        //Document에서 해당 태그와 클래스명을 가진 요소를 반환합니다.
        //여러 개가 있을 경우 가장 첫 번째에 있는 요소를 가져옴에 유의
        private HtmlElement findElementByClassName(string tagName, string className) {
            document_main = mainBrowser.Document;
            if(document_main == null) {
                return null;
            }

            foreach (HtmlElement element in document_main.GetElementsByTagName(tagName)) {
                if(element == null) {
                    continue;
                } else {
                    if (element.GetAttribute("className") == className) {
                        return element;
                    }
                }
            }

            return null;
        }
    }
}
