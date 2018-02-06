namespace TaskbarShadow
{
    partial class TaskbarShadowController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskbarShadowController));
            this.sizeBar = new System.Windows.Forms.TrackBar();
            this.color1OpacityLbl = new System.Windows.Forms.Label();
            this.color1Opacity = new System.Windows.Forms.TrackBar();
            this.sizelbl = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.color1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.color2 = new System.Windows.Forms.PictureBox();
            this.color2Opacity = new System.Windows.Forms.TrackBar();
            this.color2OpacityLbl = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.ShadowOpacityLbl = new System.Windows.Forms.GroupBox();
            this.ShadowOpacity = new System.Windows.Forms.TrackBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.InvertColors = new System.Windows.Forms.Button();
            this.SwapColors = new System.Windows.Forms.Button();
            this.StartWithWindows = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowControllerItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToggleShadowsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateShadowsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeOnStart = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color1Opacity)).BeginInit();
            this.sizelbl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color2Opacity)).BeginInit();
            this.ShadowOpacityLbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShadowOpacity)).BeginInit();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // sizeBar
            // 
            this.sizeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeBar.Location = new System.Drawing.Point(6, 19);
            this.sizeBar.Maximum = 1080;
            this.sizeBar.Minimum = 2;
            this.sizeBar.Name = "sizeBar";
            this.sizeBar.Size = new System.Drawing.Size(159, 45);
            this.sizeBar.TabIndex = 1;
            this.sizeBar.Value = 14;
            this.sizeBar.Scroll += new System.EventHandler(this.SetValues);
            // 
            // color1OpacityLbl
            // 
            this.color1OpacityLbl.AutoSize = true;
            this.color1OpacityLbl.Location = new System.Drawing.Point(52, 16);
            this.color1OpacityLbl.Name = "color1OpacityLbl";
            this.color1OpacityLbl.Size = new System.Drawing.Size(43, 13);
            this.color1OpacityLbl.TabIndex = 3;
            this.color1OpacityLbl.Text = "Opacity";
            // 
            // color1Opacity
            // 
            this.color1Opacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.color1Opacity.Location = new System.Drawing.Point(52, 34);
            this.color1Opacity.Maximum = 255;
            this.color1Opacity.Name = "color1Opacity";
            this.color1Opacity.Size = new System.Drawing.Size(366, 45);
            this.color1Opacity.TabIndex = 4;
            this.color1Opacity.Scroll += new System.EventHandler(this.SetValues);
            // 
            // sizelbl
            // 
            this.sizelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizelbl.Controls.Add(this.sizeBar);
            this.sizelbl.Location = new System.Drawing.Point(301, 194);
            this.sizelbl.Name = "sizelbl";
            this.sizelbl.Size = new System.Drawing.Size(171, 79);
            this.sizelbl.TabIndex = 5;
            this.sizelbl.TabStop = false;
            this.sizelbl.Text = "Shadow size";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.color1);
            this.groupBox2.Controls.Add(this.color1Opacity);
            this.groupBox2.Controls.Add(this.color1OpacityLbl);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 85);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color 1";
            this.toolTip.SetToolTip(this.groupBox2, "Color away from taskbar");
            // 
            // color1
            // 
            this.color1.BackColor = System.Drawing.Color.Black;
            this.color1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.color1.Location = new System.Drawing.Point(6, 19);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(40, 60);
            this.color1.TabIndex = 2;
            this.color1.TabStop = false;
            this.toolTip.SetToolTip(this.color1, "Click to change color 1");
            this.color1.Click += new System.EventHandler(this.SetColor);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.color2);
            this.groupBox3.Controls.Add(this.color2Opacity);
            this.groupBox3.Controls.Add(this.color2OpacityLbl);
            this.groupBox3.Location = new System.Drawing.Point(12, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 85);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color 2";
            this.toolTip.SetToolTip(this.groupBox3, "Color at taskbar");
            // 
            // color2
            // 
            this.color2.BackColor = System.Drawing.Color.Black;
            this.color2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.color2.Location = new System.Drawing.Point(6, 19);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(40, 58);
            this.color2.TabIndex = 2;
            this.color2.TabStop = false;
            this.toolTip.SetToolTip(this.color2, "Click to change color 2");
            this.color2.Click += new System.EventHandler(this.SetColor);
            // 
            // color2Opacity
            // 
            this.color2Opacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.color2Opacity.Location = new System.Drawing.Point(52, 32);
            this.color2Opacity.Maximum = 255;
            this.color2Opacity.Name = "color2Opacity";
            this.color2Opacity.Size = new System.Drawing.Size(366, 45);
            this.color2Opacity.TabIndex = 4;
            this.color2Opacity.Value = 200;
            this.color2Opacity.Scroll += new System.EventHandler(this.SetValues);
            // 
            // color2OpacityLbl
            // 
            this.color2OpacityLbl.AutoSize = true;
            this.color2OpacityLbl.Location = new System.Drawing.Point(52, 16);
            this.color2OpacityLbl.Name = "color2OpacityLbl";
            this.color2OpacityLbl.Size = new System.Drawing.Size(43, 13);
            this.color2OpacityLbl.TabIndex = 3;
            this.color2OpacityLbl.Text = "Opacity";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetBtn.Location = new System.Drawing.Point(397, 279);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 8;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // ShadowOpacityLbl
            // 
            this.ShadowOpacityLbl.Controls.Add(this.ShadowOpacity);
            this.ShadowOpacityLbl.Location = new System.Drawing.Point(12, 194);
            this.ShadowOpacityLbl.Name = "ShadowOpacityLbl";
            this.ShadowOpacityLbl.Size = new System.Drawing.Size(283, 79);
            this.ShadowOpacityLbl.TabIndex = 9;
            this.ShadowOpacityLbl.TabStop = false;
            this.ShadowOpacityLbl.Text = "Shadow opacity";
            // 
            // ShadowOpacity
            // 
            this.ShadowOpacity.Location = new System.Drawing.Point(6, 19);
            this.ShadowOpacity.Maximum = 255;
            this.ShadowOpacity.Minimum = 1;
            this.ShadowOpacity.Name = "ShadowOpacity";
            this.ShadowOpacity.Size = new System.Drawing.Size(271, 45);
            this.ShadowOpacity.TabIndex = 1;
            this.ShadowOpacity.Value = 255;
            this.ShadowOpacity.ValueChanged += new System.EventHandler(this.SetValues);
            // 
            // InvertColors
            // 
            this.InvertColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InvertColors.Image = global::TaskbarShadow.Properties.Resources.Invert;
            this.InvertColors.Location = new System.Drawing.Point(442, 46);
            this.InvertColors.Name = "InvertColors";
            this.InvertColors.Size = new System.Drawing.Size(30, 30);
            this.InvertColors.TabIndex = 11;
            this.toolTip.SetToolTip(this.InvertColors, "Invert color\r\nLeft click for Color 1 \r\nRight click for Color 2\r\nMiddle click for " +
        "both");
            this.InvertColors.UseVisualStyleBackColor = true;
            this.InvertColors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InvertColors_MouseUp);
            // 
            // SwapColors
            // 
            this.SwapColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SwapColors.Image = ((System.Drawing.Image)(resources.GetObject("SwapColors.Image")));
            this.SwapColors.Location = new System.Drawing.Point(442, 12);
            this.SwapColors.Name = "SwapColors";
            this.SwapColors.Size = new System.Drawing.Size(30, 30);
            this.SwapColors.TabIndex = 10;
            this.toolTip.SetToolTip(this.SwapColors, "Swap colors");
            this.SwapColors.UseVisualStyleBackColor = true;
            this.SwapColors.Click += new System.EventHandler(this.SwapColors_Click);
            // 
            // StartWithWindows
            // 
            this.StartWithWindows.AutoSize = true;
            this.StartWithWindows.Location = new System.Drawing.Point(12, 285);
            this.StartWithWindows.Name = "StartWithWindows";
            this.StartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.StartWithWindows.TabIndex = 12;
            this.StartWithWindows.Text = "Start with Windows";
            this.StartWithWindows.UseVisualStyleBackColor = true;
            this.StartWithWindows.Click += new System.EventHandler(this.StartWithWindows_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Taskbar Shadow";
            this.notifyIcon.Visible = true;
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowControllerItem,
            this.ToggleShadowsItem,
            this.UpdateShadowsItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyMenu.Name = "contextMenuStrip1";
            this.notifyMenu.Size = new System.Drawing.Size(162, 120);
            // 
            // ShowControllerItem
            // 
            this.ShowControllerItem.Name = "ShowControllerItem";
            this.ShowControllerItem.Size = new System.Drawing.Size(161, 22);
            this.ShowControllerItem.Text = "Hide controller";
            this.ShowControllerItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // ToggleShadowsItem
            // 
            this.ToggleShadowsItem.Name = "ToggleShadowsItem";
            this.ToggleShadowsItem.Size = new System.Drawing.Size(161, 22);
            this.ToggleShadowsItem.Text = "Toggle shadows";
            this.ToggleShadowsItem.ToolTipText = "Toggle shadows on all displays";
            this.ToggleShadowsItem.Click += new System.EventHandler(this.ToggleShadowsItem_Click);
            // 
            // UpdateShadowsItem
            // 
            this.UpdateShadowsItem.Name = "UpdateShadowsItem";
            this.UpdateShadowsItem.Size = new System.Drawing.Size(161, 22);
            this.UpdateShadowsItem.Text = "Update shadows";
            this.UpdateShadowsItem.ToolTipText = "Update shadows on all displays";
            this.UpdateShadowsItem.Click += new System.EventHandler(this.UpdateShadowsItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MinimizeOnStart
            // 
            this.MinimizeOnStart.AutoSize = true;
            this.MinimizeOnStart.Location = new System.Drawing.Point(135, 285);
            this.MinimizeOnStart.Name = "MinimizeOnStart";
            this.MinimizeOnStart.Size = new System.Drawing.Size(150, 17);
            this.MinimizeOnStart.TabIndex = 13;
            this.MinimizeOnStart.Text = "Minimize controller on start";
            this.MinimizeOnStart.UseVisualStyleBackColor = true;
            this.MinimizeOnStart.Click += new System.EventHandler(this.MinimizeOnStart_Click);
            // 
            // TaskbarShadowController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 314);
            this.Controls.Add(this.MinimizeOnStart);
            this.Controls.Add(this.StartWithWindows);
            this.Controls.Add(this.InvertColors);
            this.Controls.Add(this.SwapColors);
            this.Controls.Add(this.ShadowOpacityLbl);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sizelbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 353);
            this.Name = "TaskbarShadowController";
            this.Opacity = 0.99D;
            this.Text = "Taskbar Shadow Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskbarShadowController_FormClosing);
            this.Load += new System.EventHandler(this.TaskbarShadowController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color1Opacity)).EndInit();
            this.sizelbl.ResumeLayout(false);
            this.sizelbl.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color2Opacity)).EndInit();
            this.ShadowOpacityLbl.ResumeLayout(false);
            this.ShadowOpacityLbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShadowOpacity)).EndInit();
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar sizeBar;
        private System.Windows.Forms.PictureBox color1;
        private System.Windows.Forms.Label color1OpacityLbl;
        private System.Windows.Forms.TrackBar color1Opacity;
        private System.Windows.Forms.GroupBox sizelbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox color2;
        private System.Windows.Forms.TrackBar color2Opacity;
        private System.Windows.Forms.Label color2OpacityLbl;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.GroupBox ShadowOpacityLbl;
        private System.Windows.Forms.TrackBar ShadowOpacity;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button SwapColors;
        private System.Windows.Forms.Button InvertColors;
        private System.Windows.Forms.CheckBox StartWithWindows;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowControllerItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox MinimizeOnStart;
        private System.Windows.Forms.ToolStripMenuItem UpdateShadowsItem;
        private System.Windows.Forms.ToolStripMenuItem ToggleShadowsItem;
    }
}