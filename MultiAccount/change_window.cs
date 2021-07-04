using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiAccount
{
    class change_window
    {
        public List<Process> procs;
        int currrent;
        public change_window()
        {
            procs = new List<Process>();
            Process[] allProcesses = Process.GetProcesses();
            foreach (Process workingProcess in allProcesses)
            {
                if (workingProcess.MainWindowTitle.Length > 0)
                {
                    if (workingProcess.MainWindowTitle == "WAKFU")
                        procs.Add(workingProcess);
                }
            }
            currrent = 0;
        }

        private void swap_window()
        {
            if (procs.Count > 0)
            {
                if (procs[currrent].MainWindowHandle != IntPtr.Zero)
                    SetForegroundWindow(procs[currrent].MainWindowHandle);
                Console.WriteLine("swapped !" + currrent);
            }
        }

        public void change_to_index(int index)
        {
            currrent = index;
            swap_window();
        }

        public void change_window_forward()
        {
            currrent = currrent == procs.Count - 1 ? 0 : currrent += 1;
            swap_window();
        }
        public void change_window_backward()
        {
            currrent = currrent == 0 ? procs.Count - 1 : currrent -= 1;
            swap_window();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
