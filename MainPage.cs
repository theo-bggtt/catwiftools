namespace catwiftools
{
    public partial class CatWifTools : Form
    {
        Functions functions = new Functions();

        public CatWifTools()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
            this.Paint += Form_Paint;
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            // Set the default view
            ShowOneControl(null);
            tmrClock.Enabled = true;
        }

        // Main buttons
        public void btnTasks_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnTasks, tasksMainPage1, btnBundler, btnProxies, btnWallets, btnSettings);
        }

        private void btnBundler_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnBundler, bundlerMainPage1, btnProxies, btnWallets, btnTasks, btnSettings);
        }

        private void btnWallets_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnWallets, gbxWalletNav, btnProxies, btnSettings, btnTasks, btnBundler);
        }

        private void btnProxies_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnProxies, proxiesMainPage1, btnSettings, btnWallets, btnTasks, btnBundler);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HandleButtonClick(btnSettings, gbxSettingsNav, btnProxies, btnWallets, btnTasks, btnBundler);
        }

        // Main button events
        private void HandleButtonClick(Button selectedButton, Control controlToShow, params Button[] otherButtons)
        {
            functions.SelectButton(selectedButton);
            foreach (var button in otherButtons)
            {
                functions.DeselectButton(button);
            }

            ShowOneControl(controlToShow);
        }

        private void ShowOneControl(Control controlToShow)
        {
            // Combine GroupBoxes and UserControls into a single list
            var controls = new List<Control>
    {
        gbxWalletNav,     // Replace with actual GroupBoxes
        gbxSettingsNav,
        bundlerMainPage1,
        tasksMainPage1,
        proxiesMainPage1,
    };

            HideAllExcept(controls, controlToShow);
        }

        public static void HideAllExcept(IEnumerable<Control> controls, Control controlToShow)
        {
            foreach (var control in controls)
            {
                if (control != null)
                {
                    control.Visible = control == controlToShow;
                }
            }
        }




        // Draw the separators
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
            {
                e.Graphics.DrawLine(pen, 15, 91, 200, 91);
                e.Graphics.DrawLine(pen, 215, 20, 215, 790);
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

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        // Draw the separator for wallet and settings
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            // Check if the GroupBox is visible
            if (gbxWalletNav.Visible || gbxSettingsNav.Visible)
            {
                using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
                {
                    e.Graphics.DrawLine(pen, 435, 50, 435, 790);
                }
            }
            if (bundlerMainPage1.Visible)
            {
                using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
                {
                    e.Graphics.DrawLine(pen, 225, 91, 1000, 91);
                }
            }
        }

        private void gbxWalletNav_VisibleChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void gbxSettingsNav_VisibleChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
