using catwiftools.wallet;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace catwiftools
{
    public partial class CatWifTools : Form
    {
        Functions functions = new Functions();

        public CatWifTools()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            // Set the default view
            ShowOneGroupBox(null);
            tmrClock.Enabled = true;
        }
        private void ShowOneGroupBox(System.Windows.Forms.GroupBox groupBoxToShow)
        {
            var groupBoxes = new List<System.Windows.Forms.GroupBox>
            {
                gbxWalletNav, // Add other GroupBoxes here
                gbxProxies,
                gbxSettingsNav,
                gbxBundlerNav,
                gbxTasks,
            };

            HideAllExcept(groupBoxes, groupBoxToShow);
        }

        private void HandleButtonClick(Button selectedButton, System.Windows.Forms.GroupBox groupBoxToShow, params Button[] otherButtons)
        {
            functions.SelectButton(selectedButton);
            foreach (var button in otherButtons)
            {
                functions.DeselectButton(button);
            }

            ShowOneGroupBox(groupBoxToShow);
        }

        public void btnTasks_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnTasks, gbxTasks, btnBundler, btnProxies, btnWallets, btnSettings);
        }

        private void btnBundler_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnBundler, gbxBundlerNav, btnProxies, btnWallets, btnTasks, btnSettings);
        }

        private void btnWallets_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnWallets, gbxWalletNav, btnProxies, btnSettings, btnTasks, btnBundler);
        }


        private void btnProxies_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnProxies, gbxProxies, btnSettings, btnWallets, btnTasks, btnBundler);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnSettings, gbxSettingsNav, btnProxies, btnWallets, btnTasks, btnBundler);
        }

        //Draw the separator of header and buttons
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
            {
                e.Graphics.DrawLine(pen, 10, 84, 190, 84); // (X1, Y1, X2, Y2)
                e.Graphics.DrawLine(pen, 215, 43, 215, 795);
                e.Graphics.DrawLine(pen, 435, 43, 435, 785);
            }
        }

        public static void HideAllExcept(IEnumerable<System.Windows.Forms.GroupBox> groupBoxes, System.Windows.Forms.GroupBox groupBoxToShow)
        {
            foreach (var groupBox in groupBoxes)
            {
                if (groupBox != null)
                {
                    groupBox.Visible = groupBox == groupBoxToShow;
                }
            }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
