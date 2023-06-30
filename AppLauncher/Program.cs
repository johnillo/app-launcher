using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AppLauncher
{
    static class Program
    {
        const int CSIDL_COMMON_STARTMENU = 0x16; // All Users\Start Menu

        [DllImport("shell32.dll")]
        public static extern bool SHGetSpecialFolderPath(IntPtr hwnd, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);

        public static string GetAllUsersStartMenuDirectory()
        {
            StringBuilder path = new StringBuilder(512);
            SHGetSpecialFolderPath(IntPtr.Zero, path, CSIDL_COMMON_STARTMENU, false);
            return path.ToString();
        }

        [STAThread]
        static void Main()
        {
            bool isNewInstance;
            Mutex mutex = new Mutex(true, "AppLauncher", out isNewInstance);
            if (!isNewInstance) {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            mutex.ReleaseMutex();
        }
    }
}