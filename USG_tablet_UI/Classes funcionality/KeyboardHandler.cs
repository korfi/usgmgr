using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace USG_tablet_UI
{
    public static class KeyboardHandler
    {

        [DllImport("user32.dll")]
        private static extern int FindWindow(string sClass, string sWindow);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);

        public static void showKeyboard()
        {

            Version win8version = new Version(6, 2, 9200, 0);

            if (Environment.OSVersion.Version >= win8version)
            {
                string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
                string keyboardPath = Path.Combine(progFiles, "TabTip.exe");

            Process.Start(keyboardPath);
            }
        }

        //Close keyboard
        public static void hideKeyboard()
        {
            Version win8version = new Version(6, 2, 9200, 0);

                if (Environment.OSVersion.Version >= win8version)
                {
                    uint WM_SYSCOMMAND = 274;
                    uint SC_CLOSE = 61536;
                    IntPtr KeyboardWnd = (System.IntPtr)FindWindow("IPTip_Main_Window", null);
                    PostMessage(KeyboardWnd.ToInt32(), WM_SYSCOMMAND, (int)SC_CLOSE, 0);
                }
        }


    }
}
