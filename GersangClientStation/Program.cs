using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GersangClientStation {
    static class Program {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main() {
            bool flagMutex; //중복 실행 여부 확인

            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "GersangClientStation", out flagMutex);
            if(flagMutex) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_Main());
                mutex.ReleaseMutex();
            } else {
                MessageBox.Show("중복 실행은 불가능 합니다.", "중복 실행", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
