using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catwiftools
{
    class AppState
    {
        public static ControlPanelForm ControlPanelForm { get; set; }

        // Helper method to write to the ControlPanelForm
        public static void WriteConsole(string message)
        {
            if (ControlPanelForm != null && !ControlPanelForm.IsDisposed)
            {
                ControlPanelForm.WriteConsole(message);
            }
        }
        public static void RecentAction(string message)
        {
            if (ControlPanelForm != null && !ControlPanelForm.IsDisposed)
            {
                ControlPanelForm.RecentAction(message);
            }
        }
    }
}
