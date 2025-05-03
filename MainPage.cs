using catwiftools.settings;
using catwiftools.wallet;
using Microsoft.Data.Sqlite;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
namespace catwiftools
{
    public partial class CatWifTools : Form
    {
        UiHelper functions = new UiHelper();
        private Dictionary<Button, Control> buttonControlMap = new Dictionary<Button, Control>();
        public string fundWallet = "";
        private walletGroup walletGroup;

        public CatWifTools()
        {
            InitializeComponent();
            DraggingHelper.EnableDragging(this);
            this.Paint += Form_Paint;
            InitializeButtonControlMap();
        }

        private void CatWifTools_Load(object sender, EventArgs e)
        {
            ShowControls(new List<Control>());
            tmrClock.Enabled = true;
            pnlBackground.Visible = true;
            fundWallet = walletHelper.CheckForFundWallet();
            if (fundWallet == "")
            {
                walletGroup.DisableCreation();
            }
            settingsGeneral settingsGeneral = new settingsGeneral();
            settingsGeneral.fundWalletSetup();
        }

        private void InitializeButtonControlMap()
        {
            buttonControlMap = new Dictionary<Button, Control>
                {
                    { btnSettings, pnlSettingsNav },
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
                return new List<Control> { pnlSettingsNav };
            }
            if (button == btnSettingsGeneral)
            {
                return new List<Control> { pnlSettingsNav, settingsGeneral1 };
            }
            if (button == btnSettingsVolume)
            {
                return new List<Control> { pnlSettingsNav, settingsVolume1 };
            }
            if (button == btnSettingsBundler)
            {
                return new List<Control> { pnlSettingsNav, settingsBundler1 };
            }
            if (button == btnSettingsBumpIt)
            {
                return new List<Control> { pnlSettingsNav, settingsBumpIt1 };
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
                    pnlSettingsNav,
                    bundlerMainPage1,
                    tasksMainPage1,
                    proxiesMainPage1,
                    pnlBackground,
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
            if (pnlSettingsNav.Visible || tasksMainPage1.Visible)
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

        private void pnlSettingsNav_VisibleChanged(object sender, EventArgs e)
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

        private void CatWifTools_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Define the bounds of the gradient (same size as form)
            Rectangle bounds = new Rectangle(0, 0, Width, Height);

            // Define a circle in the center of the form
            Point center = new Point(bounds.Width / 2, bounds.Height / 2);
            int radius = Math.Max(bounds.Width, bounds.Height);

            // Create a circular path
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(center.X - radius, center.Y - radius, radius * 2, radius * 2);

                // Create a PathGradientBrush with that path
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterPoint = center;
                    brush.CenterColor = Color.FromArgb(37, 37, 53);
                    brush.SurroundColors = new Color[] { Color.Black };

                    graphics.FillRectangle(brush, bounds);
                }
            }
        }
    }
}