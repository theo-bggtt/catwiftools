namespace catwiftools
{
    public partial class CatWifTools : Form
    {
        Functions functions = new Functions();
        private Dictionary<Button, Control> buttonControlMap = new Dictionary<Button, Control>();

        public CatWifTools()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
            this.Paint += Form_Paint;
            InitializeButtonControlMap();
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            // Set the default view
            ShowControls(new List<Control>());
            tmrClock.Enabled = true;
        }



        // Main button events


        private void InitializeButtonControlMap()
        {
            buttonControlMap = new Dictionary<Button, Control>
            {
                { btnTasks, tasksMainPage1 },
                { btnBundler, bundlerMainPage1 },
                { btnWallets, gbxWalletNav },
                { btnProxies, proxiesMainPage1 },
                { btnSettings, gbxSettingsNav },
                { btnWalletsVolume, walletVolume1}
            };
        }

        private List<Control> GetControlsForButton(Button button)
        {
            if (button == btnTasks)
            {
                return new List<Control> { tasksMainPage1 };
            }
            if (button == btnBundler)
            {
                return new List<Control> { bundlerMainPage1 };
            }
            if (button == btnWallets)
            {
                return new List<Control> { gbxWalletNav };
            }
            if (button == btnWalletsVolume)
            {
                return new List<Control> { gbxWalletNav, walletVolume1 };
            }
            if (button == btnProxies)
            {
                return new List<Control> { proxiesMainPage1 };
            }
            if (button == btnSettings)
            {
                return new List<Control> { gbxSettingsNav };
            }

            return new List<Control>();
        }

        private void ShowControls(List<Control> controlsToShow)
        {
            if (controlsToShow == null)
            {
                controlsToShow = new List<Control>();
            }

            var allControls = new List<Control>
            {
                gbxWalletNav,
                gbxSettingsNav,
                bundlerMainPage1,
                tasksMainPage1,
                proxiesMainPage1,
                walletVolume1,
                gbxBackground,
            };

            foreach (var control in allControls)
            {
                control.Visible = controlsToShow.Contains(control);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton && buttonControlMap.ContainsKey(clickedButton))
            {
                // List of controls to show when the button is clicked
                List<Control> controlsToShow = GetControlsForButton(clickedButton);

                // Pass the list of controls to handle showing them
                HandleButtonClick(clickedButton, controlsToShow);
            }
        }


        private void HandleButtonClick(Button selectedButton, List<Control> controlsToShow)
        {
            functions.SelectButton(selectedButton);

            foreach (var button in buttonControlMap.Keys)
            {
                if (button != selectedButton)
                {
                    functions.DeselectButton(button);
                }
            }

            ShowControls(controlsToShow);
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
        private void Form_Paint(object? sender, PaintEventArgs e)
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
            if (walletVolume1.Visible)
            {
                using (Pen pen = new Pen(Color.Gray, 2)) // Color.Gray and thickness 2
                {
                    e.Graphics.DrawLine(pen, 460, 148, 1300, 148);
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
