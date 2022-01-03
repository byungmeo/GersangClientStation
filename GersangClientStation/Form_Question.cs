using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GersangClientStation {
    public partial class Form_Question : MetroForm {
        public Form_Question() {
            InitializeComponent();
        }

        private void link_1_Click(object sender, EventArgs e) {
            //거상 실행이 안돼요
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222598459133");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_2_Click(object sender, EventArgs e) {
            //업데이트마다 설정을 다시 해야하나요?
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222599326032");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_3_Click(object sender, EventArgs e) {
            //검색 보상이 안받아져요
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222611787980");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_4_Click(object sender, EventArgs e) {
            //백신 프로그램이 차단해요
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222611788318");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }
        }

        private void link_5_Click(object sender, EventArgs e) {
            //e0010005 오류
            try {
                System.Diagnostics.Process.Start("https://blog.naver.com/kog5071/222598647561");
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("링크 접속 에러");
            }

        }
    }
}
