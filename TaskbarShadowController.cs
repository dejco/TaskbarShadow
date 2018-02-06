using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskbarShadow
{
    public partial class TaskbarShadowController : Form
    {
        public TaskbarShadowController()
        {
            InitializeComponent();
        }

        List<PerPixelAlphaForm> ShadowWindows = new List<PerPixelAlphaForm>();
        ColorDialog colorDialog = new ColorDialog();
               
        private void TaskbarShadowController_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
                UpdateLabels();
            }            
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Do you wish to reset settings?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Shadows.Default.Reset();
                }
            }
            StartWithWindows.Checked = IsStartupItem();
            List<IntPtr> allWindows = Win32.GetAllChildrenWindowHandles(Win32.GetDesktopWindow(), 1024);

            // MessageBox.Show(allWindows.Count.ToString());
            foreach (IntPtr wnd in allWindows)
            {
                if (Win32.GetClassNameOfWindow(wnd) == "Shell_TrayWnd" || Win32.GetClassNameOfWindow(wnd) == "Shell_SecondaryTrayWnd")
                {
                    PerPixelAlphaForm ppa = new PerPixelAlphaForm();
                    ShadowWindows.Add(ppa);
                    ppa.Show();
                    ppa.SetShadow(wnd);

                    ToolStripMenuItem ShadowToggleItem = new ToolStripMenuItem
                    {
                        Tag = ppa,
                        Text = "Shadow " + ShadowWindows.Count.ToString(),
                        Checked = ppa.IsVisible                        
                    };
                    ShadowToggleItem.Click += ShadowToggleItem_Click;
                    ShadowToggleItem.ToolTipText = "Toggle shadow " + ShadowWindows.Count.ToString();
                    ToggleShadowsItem.DropDownItems.Add(ShadowToggleItem);                    
                }
            }

            if (Shadows.Default.MinimizeOnStart == true)
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                ShowControllerItem.Text = "Show controller";
            }
        }
        
        private void ShadowToggleItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                try
                {
                    ToggleShadow((ToolStripMenuItem)sender);
                }
                catch { }
            }
        }

        private void ToggleShadow(ToolStripMenuItem item)
        {
            PerPixelAlphaForm ppa = (PerPixelAlphaForm)item.Tag;
            ppa.ToggleShadow();
            item.Checked = ppa.IsVisible;
        }
        
        private void UpdateShadows()
        {
            if (ShadowWindows.Count > 0)
            {
                Shadows.Default.Color1 = color1.BackColor;
                Shadows.Default.Color2 = color2.BackColor;
                Shadows.Default.Color1Opacity = color1Opacity.Value;
                Shadows.Default.Color2Opacity = color2Opacity.Value;
                Shadows.Default.Size = sizeBar.Value;
                Shadows.Default.ShadowOpacity = ShadowOpacity.Value;
                Shadows.Default.Save();                
                foreach (PerPixelAlphaForm ppa in ShadowWindows)
                {
                    ppa.UpdateShadow();
                }                
            }
        }

        private void LoadSettings()
        {
            color1.BackColor = Shadows.Default.Color1;
            color1Opacity.Value = Shadows.Default.Color1Opacity;
            color2.BackColor = Shadows.Default.Color2;
            color2Opacity.Value = Shadows.Default.Color2Opacity;
            sizeBar.Value = Shadows.Default.Size;
            ShadowOpacity.Value = Shadows.Default.ShadowOpacity;
            MinimizeOnStart.Checked = Shadows.Default.MinimizeOnStart;            
        }

        private void UpdateLabels()
        {
            color1OpacityLbl.Text = "Opacity: " + color1Opacity.Value.ToString();
            color2OpacityLbl.Text = "Opacity: " + color2Opacity.Value.ToString();
            sizelbl.Text = "Shadow size: " + sizeBar.Value.ToString();
            ShadowOpacityLbl.Text = "Shadow opacity: " + ShadowOpacity.Value.ToString();
        }

        private void ResetShadows()
        {
            Shadows.Default.Reset();
            LoadSettings();
            UpdateLabels();

            if (ShadowWindows.Count > 0)
            {
                foreach (PerPixelAlphaForm ppa in ShadowWindows)
                {
                    ppa.UpdateShadow();
                }                
            }
        }

        private void SetColor(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                colorDialog.Color = (sender as PictureBox).BackColor;                
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    (sender as PictureBox).BackColor = colorDialog.Color;
                }                
                UpdateShadows();
            }
        }

        private void SetValues(object sender, EventArgs e)
        {
            if (sender is TrackBar)
            {
                UpdateLabels();
                UpdateShadows();
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetShadows();            
        }

        private void InvertColors_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                color1.BackColor = Color.FromArgb(255 - color1.BackColor.R, 255 - color1.BackColor.G, 255 - color1.BackColor.B);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                color1.BackColor = Color.FromArgb(255 - color1.BackColor.R, 255 - color1.BackColor.G, 255 - color1.BackColor.B);
                color2.BackColor = Color.FromArgb(255 - color2.BackColor.R, 255 - color2.BackColor.G, 255 - color2.BackColor.B);
            }
            else if (e.Button == MouseButtons.Right)
            {
                color2.BackColor = Color.FromArgb(255 - color2.BackColor.R, 255 - color2.BackColor.G, 255 - color2.BackColor.B);
            }
            UpdateShadows();
        }

        private void SwapColors_Click(object sender, EventArgs e)
        {
            color1.BackColor = Shadows.Default.Color2;
            color2.BackColor = Shadows.Default.Color1;
            UpdateShadows();
        }

        private void StartWithWindows_Click(object sender, EventArgs e)
        {
            if (this.StartWithWindows.Checked)
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                bool flag = !this.IsStartupItem();
                if (flag)
                {
                    rkApp.SetValue("TaskbarShadow", System.Windows.Forms.Application.ExecutablePath.ToString());
                }
            }
            else
            {
                RegistryKey rkApp2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                bool flag2 = this.IsStartupItem();
                if (flag2)
                {
                    rkApp2.DeleteValue("TaskbarShadow", false);
                }
            }
        }

        private bool IsStartupItem()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            bool flag = rkApp.GetValue("TaskbarShadow") == null;
            return !flag;
        }

        /// <summary>
        /// Get or set app as startup item
        /// </summary>
        /// <param name="enable">use null to check only</param>
        /// <returns></returns>
        private bool IsStartupitem(bool? enable)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            return false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTBS aboutTBS = new AboutTBS();
            aboutTBS.ShowDialog();
        }

        private void MinimizeOnStart_Click(object sender, EventArgs e)
        {
            Shadows.Default.MinimizeOnStart = MinimizeOnStart.Checked;
            Shadows.Default.Save();
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (this.Opacity >=0.5D)
            {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                ShowControllerItem.Text = "Show controller";
            }
            else if(this.Opacity <0.5D)
            {
                this.Opacity = 1;
                this.ShowInTaskbar = true;
                ShowControllerItem.Text = "Hide controller";
            }
        }        

        private void ToggleShadowsItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in ToggleShadowsItem.DropDownItems)
            {
                ToggleShadow(item);
            }
        }

        private void UpdateShadowsItem_Click(object sender, EventArgs e)
        {
            UpdateShadows();
        }

        private void TaskbarShadowController_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
        }
    }
}
