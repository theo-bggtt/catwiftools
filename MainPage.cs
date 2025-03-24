using catwiftools.settings;
using catwiftools.wallet;
using Microsoft.Data.Sqlite;
using System.Net.NetworkInformation;
namespace catwiftools
{
    public partial class CatWifTools : Form
    {
        Functions functions = new Functions();
        private Dictionary<Button, Control> buttonControlMap = new Dictionary<Button, Control>();
        public string fundWallet = "";
        private walletGroup walletGroup; // Add this line

        public CatWifTools()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
            this.Paint += Form_Paint;
            InitializeButtonControlMap();
            fundWallet = Functions.CheckForFundWallet();
            walletGroup = new walletGroup(); // Add this line
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            ShowControls(new List<Control>());
            tmrClock.Enabled = true;
            gbxBackground.Visible = true;
            fundWallet = Functions.CheckForFundWallet();
            settingsGeneral settingsGeneral = new settingsGeneral();
            settingsGeneral.fundWalletSetup();
        }

        private void InitializeButtonControlMap()
        {
            buttonControlMap = new Dictionary<Button, Control>
                {
                    { btnSettings, gbxSettingsNav },
                    { btnWallets, walletVolume1 },
                    { btnTasks, tasksMainPage1 },
                    { btnBundler, bundlerMainPage1 },
                    { btnProxies, proxiesMainPage1 },

                    { btnSettingsGeneral, settingsGeneral1 },
                    { btnSettingsVolume, settingsVolume1 },
                    { btnSettingsBundler, settingsBundler1 },
                    { btnSettingsBumpIt, settingsBumpIt1 }

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
            if (button == btnProxies)
            {
                return new List<Control> { proxiesMainPage1 };
            }
            if (button == btnWallets)
            {
                return new List<Control> { walletVolume1 };
            }
            // Settings sub buttons
            if (button == btnSettings)
            {
                return new List<Control> { gbxSettingsNav };
            }
            if (button == btnSettingsGeneral)
            {
                return new List<Control> { gbxSettingsNav, settingsGeneral1 };
            }
            if (button == btnSettingsVolume)
            {
                return new List<Control> { gbxSettingsNav, settingsVolume1 };
            }
            if (button == btnSettingsBundler)
            {
                return new List<Control> { gbxSettingsNav, settingsBundler1 };
            }
            if (button == btnSettingsBumpIt)
            {
                return new List<Control> { gbxSettingsNav, settingsBumpIt1 };
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
                    gbxSettingsNav,
                    bundlerMainPage1,
                    tasksMainPage1,
                    proxiesMainPage1,
                    gbxBackground,
                    walletVolume1,
                    settingsGeneral1,
                    settingsVolume1,
                    settingsBundler1,
                    settingsBumpIt1,
                };

            foreach (var control in allControls)
            {
                if (control != null)
                {
                    control.Visible = controlsToShow.Contains(control);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton && buttonControlMap.ContainsKey(clickedButton))
            {
                List<Control> controlsToShow = GetControlsForButton(clickedButton);
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
                    if (button == btnSettings &&
                        (selectedButton == btnSettingsGeneral || selectedButton == btnSettingsVolume || selectedButton == btnSettingsBundler || selectedButton == btnSettingsBumpIt))
                    {
                        functions.SelectButton(button);
                        continue;
                    }

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

        private void Form_Paint(object? sender, PaintEventArgs e)
        {
            if (gbxSettingsNav.Visible)
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

        private void gbxSettingsNav_VisibleChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void btnControlPanel_Click(object sender, EventArgs e)
        {
            if (AppState.ControlPanelForm == null || AppState.ControlPanelForm.IsDisposed)
            {
                AppState.ControlPanelForm = new ControlPanelForm();
                AppState.ControlPanelForm.Show();
                AppState.WriteConsole("Control Panel opened");
            }
            else
            {
                AppState.ControlPanelForm.BringToFront();
                AppState.ControlPanelForm.Location = new Point(this.Location.X + (this.Width / 4), this.Location.Y);
                AppState.ControlPanelForm.Visible = true;
            }
        }
    }
}