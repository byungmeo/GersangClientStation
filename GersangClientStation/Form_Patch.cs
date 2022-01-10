using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Patch : MetroForm {
        bool isCompleted = false;
        DirectoryInfo temp = null;
        

        public Form_Patch() {
            InitializeComponent();
        }

        private void Form_Patch_Load(object sender, EventArgs e) {
            int currentVer; //현재 지정된 경로의 거상 버전
            int latestVer; //서버에 게시된 최신 거상 버전
            string origin_path = Form_Main.config.AppSettings.Settings["gersang_original_path"].Value;

            //원본 폴더 경로가 설정되어 있는지 확인
            if (origin_path.Equals("")) {
                MessageBox.Show("거상 원본 폴더가 지정되지 않았습니다.\n자동패치 설정 -> 원본 폴더를 지정 해주세요."
                    , "자동패치 설정", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                isCompleted = true;
                this.Close();
                return;
            }

            //원본 폴더 경로가 올바른지 확인
            try {
                //Gersang.exe 파일이 없는 경우 경로를 다시 지정하라고 메시지를 출력합니다.
                if (Directory.GetFiles(origin_path, "Gersang.exe", SearchOption.TopDirectoryOnly).Length <= 0) {
                    MessageBox.Show("현재 지정된 경로에 Gersang.exe 파일이 존재하지 않습니다.\n경로를 다시 지정해주세요."
                        , "거상 경로 인식 실패", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    isCompleted = true;
                    this.Close();
                    return;
                }
            } catch (Exception ex) {
                MessageBox.Show("거상 경로가 올바른지 확인 중에 오류가 발생하였습니다.\n경로를 다시 확인 하거나 문의 바랍니다." + ex.Message
                    , "거상 경로 확인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isCompleted = true;
                this.Close();
                return; ;
            }

            //
            //1. 원본 폴더에 있는 거상의 버전을 확인
            //
            try {
                FileStream fs = File.OpenRead(origin_path + @"\Online\vsn.dat");
                BinaryReader br = new BinaryReader(fs);
                currentVer = -(br.ReadInt32() + 1);
                fs.Close();
                br.Close();
            } catch (Exception ex) {
                MessageBox.Show("현재 거상 버전을 확인 중 오류가 발생하였습니다.\n문의해주세요." + ex.Message
                    , "거상 경로 확인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isCompleted = true;
                this.Close();
                return;
            }

            //
            //2. 거상 최신 버전을 확인하고, 패치 할 필요가 있는지 확인
            //
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

                    //버전 파일 다운로드 완료
                    //아래의 DownloadFileAsync 가 완료되면 호출되는 곳입니다.
                    //숫자를 따라가세요.
                    client.DownloadFileCompleted += (object obj, AsyncCompletedEventArgs args) => {
                        if (args.Error != null) {
                            Debug.WriteLine("vsn.dat 파일 다운로드 중 오류 발생");
                            Debug.WriteLine(args.Error.Message);
                            throw (new Exception("vsn.dat 파일 다운로드 중 오류 발생"));
                        } else {
                            Debug.WriteLine("vsn.dat.gsz 파일 다운로드 완료");
                            ZipFile.ExtractToDirectory(binDirectory.FullName + @"\vsn.dat.gsz", binDirectory.FullName);
                            Debug.WriteLine("vsn.dat 파일 압축 해제 완료");

                            FileStream fs = File.OpenRead(binDirectory.FullName + @"\vsn.dat");
                            BinaryReader br = new BinaryReader(fs);
                            latestVer = -(br.ReadInt32() + 1);

                            label_patchVersion.Text = "업데이트 버전 : " + currentVer + " -> " + latestVer;
                            Debug.WriteLine("서버에 게시된 거상 최신 버전 : " + latestVer);
                            fs.Close();
                            br.Close();

                            if (latestVer - currentVer == 0) {
                                DialogResult dr = MessageBox.Show("지정된 경로의 거상이 최신 버전과 동일한 버전입니다.\n그래도 패치를 하시겠습니까?"
                                    , "동일한 버전", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                if (dr == DialogResult.No) {
                                    isCompleted = true;
                                    this.Close();
                                    return;
                                }
                            } else if (latestVer - currentVer < 0) {
                                MessageBox.Show("지정된 경로의 거상 버전이 거상 서버에 게시된 버전보다 최신입니다.\n문의 바랍니다."
                                    , "버전 오류", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                isCompleted = true;
                                this.Close();
                                return;
                            }

                            //
                            //3. patch폴더 및 내부 폴더 생성
                            //
                            DirectoryInfo patchDirectory = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\patch");
                            if (!patchDirectory.Exists) { patchDirectory.Create(); }

                            DirectoryInfo infoDirectory = new DirectoryInfo(patchDirectory + @"\info");
                            if (!infoDirectory.Exists) { infoDirectory.Create(); }

                            DirectoryInfo fileDirectory = new DirectoryInfo(patchDirectory + @"\" + currentVer + "-" + latestVer);
                            if (!fileDirectory.Exists) { fileDirectory.Create(); }
                            temp = fileDirectory;

                            //
                            //4. 현재버전-최신버전 사이에 존재하는 버전 확인 및 info파일 다운로드
                            //
                            //최종 버전까지 필요한 패치 정보 파일을 모두 다운받습니다. (구버전 배려)
                            List<string> patchList = new List<string>();

                            System.Net.WebClient webClient = new System.Net.WebClient();
                            webClient.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");

                            if(currentVer == latestVer) {
                                string downloadUrl = @"http://akgersang.xdn.kinxcdn.com/Gersang/Patch/Gersang_Server/" + @"Client_info_File/" + currentVer;
                                webClient.DownloadFile(new Uri(downloadUrl), infoDirectory + @"\" + currentVer + ".txt");
                                Debug.WriteLine(currentVer + " 버전 패치정보 파일 다운로드 성공\n");
                                patchList.Add(currentVer.ToString());
                            } else {
                                for (int i = currentVer + 1; i <= latestVer; i++) {
                                    string downloadUrl = @"http://akgersang.xdn.kinxcdn.com/Gersang/Patch/Gersang_Server/" + @"Client_info_File/" + i;
                                    try {
                                        webClient.DownloadFile(new Uri(downloadUrl), infoDirectory + @"\" + i + ".txt");
                                        Debug.WriteLine(i + " 버전 패치정보 파일 다운로드 성공\n");

                                        patchList.Add(i.ToString());
                                    } catch (Exception ex) {
                                        //다운로드 실패 시 다음 버전으로 넘어갑니다
                                        Debug.WriteLine("버전 " + i + " 이 존재하지 않아 다음 버전으로 넘어갑니다.\n");
                                        Debug.WriteLine(ex.Message);
                                    }
                                }
                            }

                            //
                            //5. info파일이 여러개인 경우 병합
                            //
                            //패치 정보 파일에서 패치 파일 리스트를 뽑아낸다
                            Dictionary<string, string> files = new Dictionary<string, string>(); //key값으로 파일이름, value값으로 경로 저장

                            //몇번의 패치가 존재하든, 한꺼번에 패치하기위해 여러 패치정보파일에서 중복없이 파일 리스트를 뽑아옵니다.
                            if (patchList.Count >= 1) {
                                using (StreamWriter wr = new StreamWriter(infoDirectory + @"\" + currentVer + "-" + latestVer + ".txt")) { //디버깅용으로 새로운 정보 파일을 생성합니다.
                                    wr.WriteLine("파일명\t경로"); //디버깅용
                                    foreach (string item in patchList) {
                                        string[] lines = System.IO.File.ReadAllLines(infoDirectory + @"\" + item + ".txt", Encoding.Default); //패치정보파일에서 모든 텍스트를 읽어옵니다.

                                        //패치정보파일의 첫 4줄은 쓸모없으므로 생략하고, 5번째 줄부터 읽습니다.
                                        for (int i = 4; i < lines.Length; i++) {
                                            string[] row = lines[i].Split('\t'); //한 줄을 탭을 간격으로 나눕니다. (디버깅용)

                                            //만약 EOF가 등장했다면 루프를 빠져나갑니다.
                                            if (row[0] == ";EOF") {
                                                break;
                                            }

                                            if (!files.ContainsKey(row[1])) {
                                                files.Add(row[1], row[3].Remove(0, 1));
                                                wr.WriteLine(row[1] + "\t" + row[3].Remove(0, 1)); //디버깅용
                                            }
                                        }
                                    }
                                }
                            }

                            Dictionary<string, string> patchFileList; //최종적으로 다운로드 해야하는 파일의 리스트 <파일명, 경로>
                            patchFileList = files;

                            //
                            //6. 현재버전-최선버전 폴더에 파일 다운로드 시작
                            //
                            //다운로드 하는 동안 폼을 비활성화 시킵니다.
                            //this.Enabled = false;

                            string errorMessageList = "";
                            int patchFileCount = patchFileList.Count;
                            int downloadCompletedCount = 0;

                            label_progress.Text = downloadCompletedCount + " / " + patchFileList.Count;
                            progressBar.Maximum = patchFileList.Count;

                            //버전이름의 폴더에 패치 파일을 다운로드합니다.
                            string fileServerUrl = @"http://akgersang.xdn.kinxcdn.com/Gersang/Patch/Gersang_Server/" + "Client_Patch_File/";
                            foreach (var item in patchFileList) {
                                Uri downloadUrl = new Uri(fileServerUrl + item.Value + item.Key);
                                string filePath = fileDirectory.FullName + @"\" + item.Value + item.Key;
                                string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1); //파일이름만 추출합니다

                                bool isDownloading = false;
                                ListViewItem lvi = new ListViewItem(fileName);
                                lvi.UseItemStyleForSubItems = false;
                                lvi.SubItems.Add(item.Value);
                                lvi.SubItems.Add("0");
                                lvi.SubItems.Add("0");
                                lvi.SubItems.Add("다운로드 대기 중");
                                listView1.Items.Add(lvi);

                                //해당 파일이 이미 다운로드 받은 파일이라면?
                                if (System.IO.File.Exists(filePath.Remove(filePath.Length - 4))) {
                                    lvi.SubItems[4].Text = "이미 존재하는 파일";
                                    lvi.SubItems[4].ForeColor = Color.Green;

                                    label_progress.Text = ++downloadCompletedCount + " / " + patchFileList.Count;
                                    progressBar.Value += 1;
                                    Debug.WriteLine(fileName + " 는 이미 존재합니다!");

                                    //이미 존재하는 파일을 끝으로 다운로드가 종료되는 상황에 대비
                                    if (downloadCompletedCount == patchFileList.Count) {
                                        if (!errorMessageList.Equals("")) {
                                            MessageBox.Show("파일 다운로드 중 오류가 발생하였습니다.\n다시 시도해주세요.", "다운로드 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            isCompleted = true;
                                            button_close.Enabled = true;
                                            return;
                                        } else {
                                            //MessageBox.Show("패치 파일을 모두 다운로드 하였습니다.", "다운로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //isCompleted = true;
                                            //button_end.Enabled = true;

                                            //
                                            //8. 원본 폴더로 패치 파일 복사
                                            //
                                            try {
                                                //Now Create all of the directories
                                                foreach (string dirPath in Directory.GetDirectories(fileDirectory.FullName, "*", System.IO.SearchOption.AllDirectories))
                                                    Directory.CreateDirectory(dirPath.Replace(fileDirectory.FullName, origin_path));

                                                //Copy all the files & Replaces any files with the same name
                                                foreach (string newPath in Directory.GetFiles(fileDirectory.FullName, "*.*", System.IO.SearchOption.AllDirectories)) {
                                                    System.IO.File.Copy(newPath, newPath.Replace(fileDirectory.FullName, origin_path), true);
                                                }

                                                MessageBox.Show("패치 다운로드 및 적용이 모두 완료되었습니다.", "패치 적용 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                isCompleted = true;
                                                button_close.Enabled = true;
                                            } catch (Exception ex) {
                                                MessageBox.Show("패치 적용 중 오류가 발생하였습니다.\n다시 시도해주세요.\n" + ex.Message, "패치적용 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                isCompleted = true;
                                                button_close.Enabled = true;
                                                return;
                                            }

                                            //
                                            //9. 체크여부에 따라 저장된 패치 파일 삭제
                                            //
                                            if (bool.Parse(Form_Main.config.AppSettings.Settings["remove_file_after_patch"].Value)) {
                                                try {
                                                    fileDirectory.Delete(true);
                                                    Debug.WriteLine("패치 파일 삭제 완료");
                                                } catch (Exception ex) {
                                                    Debug.WriteLine("패치 파일 삭제 실패\n" + ex.Message);
                                                }
                                            }

                                            //10. 체크여부에 따라 다클라 패치 적용
                                            if (bool.Parse(Form_Main.config.AppSettings.Settings["apply_creator_after_patch"].Value)) {
                                                Form_Creator.client_create(origin_path);
                                            }
                                        }
                                    }
                                    continue;
                                }

                                //내부 폴더 생성
                                DirectoryInfo fileInnerDirectory = new DirectoryInfo(new FileInfo(filePath).DirectoryName);
                                if (!fileInnerDirectory.Exists) { fileInnerDirectory.Create(); }

                                //하나의 WebClient가 하나의 파일 다운로드를 담당
                                using (WebClient client2 = new WebClient()) {
                                    client2.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");


                                    //다운로드 진행도가 변경될 때 마다
                                    client2.DownloadProgressChanged += (object obj2, DownloadProgressChangedEventArgs args2) => {
                                        if(!isDownloading) {
                                            lvi.SubItems[3].Text = args2.TotalBytesToReceive.ToString();
                                            lvi.SubItems[4].Text = "다운로드 중";
                                            isDownloading = true;
                                        }

                                        lvi.SubItems[2].Text = args2.BytesReceived.ToString();
                                    };

                                    //다운로드가 완료 되면
                                    client2.DownloadFileCompleted += (object obj2, AsyncCompletedEventArgs args2) => {
                                        label_progress.Text = ++downloadCompletedCount + " / " + patchFileList.Count;
                                        progressBar.Value += 1;

                                        if (args2.Error != null) {
                                            lvi.SubItems[4].Text = "다운로드 실패";
                                            lvi.SubItems[4].ForeColor = Color.Red;
                                            errorMessageList += args2.Error.Message + "\n";
                                        } else {
                                            lvi.SubItems[4].Text = "다운로드 완료";
                                            lvi.SubItems[4].ForeColor = Color.Green;
                                            Debug.WriteLine(fileName + "다운로드 완료");
                                            //
                                            //7. 파일 다운로드가 완료되는 대로 압축 해제 후 압축 파일은 삭제
                                            //
                                            ZipFile.ExtractToDirectory(filePath, new FileInfo(filePath).DirectoryName);
                                            System.IO.File.Delete(filePath);
                                        }

                                        //파일 다운로드가 모두 완료
                                        if(downloadCompletedCount == patchFileList.Count) {
                                            if(!errorMessageList.Equals("")) {
                                                MessageBox.Show("파일 다운로드 중 오류가 발생하였습니다.\n다시 시도해주세요.\n" + errorMessageList, "다운로드 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                isCompleted = true;
                                                button_close.Enabled = true;
                                            } else {
                                                //MessageBox.Show("패치 파일을 모두 다운로드 하였습니다.", "다운로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //isCompleted = true;
                                                //button_end.Enabled = true;

                                                //
                                                //8. 원본 폴더로 패치 파일 복사
                                                //
                                                try {
                                                    //Now Create all of the directories
                                                    foreach (string dirPath in Directory.GetDirectories(fileDirectory.FullName, "*", System.IO.SearchOption.AllDirectories))
                                                        Directory.CreateDirectory(dirPath.Replace(fileDirectory.FullName, origin_path));

                                                    //Copy all the files & Replaces any files with the same name
                                                    foreach (string newPath in Directory.GetFiles(fileDirectory.FullName, "*.*", System.IO.SearchOption.AllDirectories)) {
                                                        System.IO.File.Copy(newPath, newPath.Replace(fileDirectory.FullName, origin_path), true);
                                                    }

                                                    MessageBox.Show("패치 다운로드 및 적용이 모두 완료되었습니다.", "패치 적용 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    isCompleted = true;
                                                    button_close.Enabled = true;
                                                } catch (Exception ex) {
                                                    MessageBox.Show("패치 적용 중 오류가 발생하였습니다.\n다시 시도해주세요.\n" + ex.Message, "패치적용 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    button_close.Enabled = true;
                                                    return;
                                                }

                                                //
                                                //9. 체크여부에 따라 저장된 패치 파일 삭제
                                                //
                                                if (bool.Parse(Form_Main.config.AppSettings.Settings["remove_file_after_patch"].Value)) {
                                                    try {
                                                        fileDirectory.Delete(true);
                                                        Debug.WriteLine("패치 파일 삭제 완료");
                                                    } catch (Exception ex) {
                                                        Debug.WriteLine("패치 파일 삭제 실패\n" + ex.Message);
                                                    }
                                                }

                                                //10. 체크여부에 따라 다클라 패치 적용
                                                if (bool.Parse(Form_Main.config.AppSettings.Settings["apply_creator_after_patch"].Value)) {
                                                    Form_Creator.client_create(origin_path);
                                                }
                                            }
                                        }

                                        return;
                                    };

                                    client2.DownloadFileAsync(downloadUrl, filePath);
                                }
                            }
                        }
                    };

                    Uri vsnPath = new Uri(@"https://akgersang.xdn.kinxcdn.com/Gersang/Patch/Gersang_Server/Client_Patch_File/Online/vsn.dat.gsz");
                    client.DownloadFileAsync(vsnPath, System.Windows.Forms.Application.StartupPath + @"\bin\vsn.dat.gsz");
                    //-> DownloadFileCompleted
                }
            } catch (Exception ex) {
                MessageBox.Show("현재 최신 거상 버전이 확인되지 않았습니다.\n인터넷이 연결되었는지 확인 하거나, 프로그램을 재시작 해주세요."
                    , "최신 버전 확인 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isCompleted = true;
                this.Close();
                return;
            }
        }

        private void button_patchNote_Click(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("https://www.gersang.co.kr/news/update_normal.gs?GSbid=1004");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void button_end_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form_Patch_FormClosing(object sender, FormClosingEventArgs e) {
            if(!isCompleted) {
                DialogResult result = MessageBox.Show("다운로드가 진행 중입니다.\n창을 닫으시겠습니까?", "패치 창 닫기", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }

        private void Form_Patch_FormClosed(object sender, FormClosedEventArgs e) {
            if(!isCompleted) {
                if(temp != null) {
                    MessageBox.Show("다운로드는 계속해서 진행됩니다.\n다시 시도하시려면 다클라 스테이션 폴더 내의\n" + @"patch\" + temp.Name + " 폴더를 삭제 해주세요."
                        , "패치 창 닫음", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("다운로드는 계속해서 진행됩니다.\n다시 시도하시려면 다클라 스테이션 폴더 내의\n" + @"patch 폴더를 삭제 해주세요."
                        , "패치 창 닫음", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
