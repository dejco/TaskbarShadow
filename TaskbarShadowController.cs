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
                }
            }
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
            //Shadows.Default.Color1 = Color.Black;
            //Shadows.Default.Color2 = Color.Black;
            //Shadows.Default.Color1Opacity = 0;
            //Shadows.Default.Color2Opacity = 135;
            //Shadows.Default.Size = 14;
            //Shadows.Default.ShadowOpacity = 255;
            //Shadows.Default.Save();
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
            bool value = this.StartWithWindows.Checked;
            if (value)
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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTBS aboutTBS = new AboutTBS();
            aboutTBS.ShowDialog();
        }
    }
}
