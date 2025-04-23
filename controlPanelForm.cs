using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catwiftools
{
    public partial class ControlPanelForm: Form
    {
        public static ControlPanelForm Instance { get; private set; }
        public ControlPanelForm()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
            Instance = this;
        }

        public void WriteConsole(string message)
        {
            rtbConsole.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            rtbConsole.ScrollToCaret();
        }

        public void RecentAction(string message)
        {
            rtbRecentAction.AppendText($"[ {DateTime.Now.ToString("HH:mm:ss")} ] {message}\n");
            rtbConsole.ScrollToCaret();
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
