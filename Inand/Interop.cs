using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inand
{
    public static class Interop
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        private const int WS_MAXIMIZEBOX = 0x10000, WS_MINIMIZEBOX = 0x20000;

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        public static void DeleteCloseAndIcon(Window window)
        {
            var hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        public static void DeleteMaximaze(Window window)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            int currentStyle = GetWindowLong(hwnd, GWL_STYLE);

            SetWindowLong(hwnd, GWL_STYLE, currentStyle & ~WS_MAXIMIZEBOX);
        }
    }
}
