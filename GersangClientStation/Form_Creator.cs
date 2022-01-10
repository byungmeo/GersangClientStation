using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Creator : MetroForm {
        public Form_Creator() {
            InitializeComponent();
        }

        private void button_create_Click(object sender, EventArgs e) {
            if(textBox_mainPath.Text == "") {
                MessageBox.Show("거상 경로를 먼저 지정해주세요.", "다클라 생성", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            client_create(textBox_mainPath.Text);
        }

        public static void client_create(string original_path) {
            try {
                // 파일 복사 시 제외할 확장자명이 담긴 txt파일을 생성합니다.
                string excludeList = ".tmp\n.bmp";
                System.IO.File.WriteAllText("exclude.txt", excludeList);

                //다클생성기 bat파일의 초안을 불러옵니다.
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "GersangClientStation.ClientCreatorCommand.txt";
                string command = "";
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream)) {
                    command = reader.ReadToEnd();
                }

                //bat파일 초안의 경로 부분을 사용자가 설정한 경로로 바꿉니다.
                command = command.Replace("#PATH1#", original_path);
                string[] splitString = original_path.Split('\\');
                string previousPath = "";
                for (int i = 0; i < splitString.Length - 1; i++) {
                    previousPath += splitString[i] + '\\';
                }
                command = command.Replace("#PATH2#", previousPath + "Gersang2");
                command = command.Replace("#PATH3#", previousPath + "Gersang3");

                //다클생성기 bat파일을 생성합니다.
                string batchFileName = "ClientCreator.bat";
                System.IO.File.WriteAllText(batchFileName, command, System.Text.Encoding.Default);

                ProcessStartInfo psInfo = new ProcessStartInfo(batchFileName); //다클생성기 bat파일 실행 준비
                psInfo.Verb = "runas"; //관리자 권한 실행
                psInfo.CreateNoWindow = false; //cmd창이 보이도록 합니다.
                psInfo.UseShellExecute = false; //

                Process process = new Process();
                process.StartInfo = psInfo;
                process.Start(); //다클생성기 실행
                process.WaitForExit();

                MessageBox.Show("다클라 생성을 완료하였습니다.\n다클라 폴더의 이름은 Gersang2, Gersang3입니다.", "다클라 생성", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //다클라가 생성된 폴더를 열어준다
                System.Diagnostics.Process.Start(original_path + "/..");
            } catch (Exception exception) {
                MessageBox.Show("다클라 생성중 오류가 발생한 것 같습니다. 문의해주세요.\n" + exception.StackTrace, "다클라 생성", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_findPath_Click(object sender, EventArgs e) {
            folderBrowserDialog.ShowDialog();
            textBox_mainPath.Text = folderBrowserDialog.SelectedPath;
        }
    }
}
