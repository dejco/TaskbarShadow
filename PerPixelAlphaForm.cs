//
// Copyright © 2002-2004 Rui Godinho Lopes <rui@ruilopes.com>
// All rights reserved.
//
// This source file(s) may be redistributed unmodified by any means
// PROVIDING they are not sold for profit without the authors expressed
// written consent, and providing that this notice and the authors name
// and all copyright notices remain intact.
//
// Any use of the software in source or binary forms, with or without
// modification, must include, in the user documentation ("About" box and
// printed documentation) and internal comments to the code, notices to
// the end user as follows:
//
// "Portions Copyright © 2002-2004 Rui Godinho Lopes"
//
// An email letting me know that you are using it would be nice as well.
// That's not much to ask considering the amount of work that went into
// this.
//
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED. USE IT AT YOUT OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Microsoft.Win32;

/// <para>Your PerPixel form should inherit this class</para>
/// <author><name>Rui Godinho Lopes</name><email>rui@ruilopes.com</email></author>
namespace TaskbarShadow
{
    class PerPixelAlphaForm : Form
    {
        public PerPixelAlphaForm()
        {
            // This form should not have a border or else Windows will clip it.
            FormBorderStyle = FormBorderStyle.None;
        }

        IntPtr window = IntPtr.Zero;

        public void SetShadow(IntPtr wnd)
        {
            this.ShowInTaskbar = false;
            window = wnd;
            UpdateShadow();
        }
        public void UpdateShadow()
        { 
            Win32.RECT r = new Win32.RECT();
            Win32.GetWindowRect(window, out r);
            int[] loc = GetShadowLocation(r, Shadows.Default.Size);

            if (loc.Length == 5)
            {
                Bitmap b = new Bitmap(loc[2], loc[3]);
                using (Graphics g = Graphics.FromImage(b))
                {
                    LinearGradientBrush lb = null;

                    if (loc[4] == 0)
                    {
                        lb = new LinearGradientBrush(new Point(Shadows.Default.Size, 0), new Point(0, 0),
                        Color.FromArgb(Shadows.Default.Color1Opacity, Shadows.Default.Color1.R, Shadows.Default.Color1.G, Shadows.Default.Color1.B),
                        Color.FromArgb(Shadows.Default.Color2Opacity, Shadows.Default.Color2.R, Shadows.Default.Color2.G, Shadows.Default.Color2.B));
                    }
                    else if (loc[4] == 1)
                    {
                        lb = new LinearGradientBrush(new Point(0, Shadows.Default.Size), new Point(0, 0),
                        Color.FromArgb(Shadows.Default.Color1Opacity, Shadows.Default.Color1.R, Shadows.Default.Color1.G, Shadows.Default.Color1.B),
                        Color.FromArgb(Shadows.Default.Color2Opacity, Shadows.Default.Color2.R, Shadows.Default.Color2.G, Shadows.Default.Color2.B));
                    }
                    else if (loc[4] == 2)
                    {
                        lb = new LinearGradientBrush(new Point(0, 0), new Point(Shadows.Default.Size, 0),
                     Color.FromArgb(Shadows.Default.Color1Opacity, Shadows.Default.Color1.R, Shadows.Default.Color1.G, Shadows.Default.Color1.B),
                        Color.FromArgb(Shadows.Default.Color2Opacity, Shadows.Default.Color2.R, Shadows.Default.Color2.G, Shadows.Default.Color2.B));
                    }
                    else if (loc[4] == 3)
                    {
                        lb = new LinearGradientBrush(new Point(0, 0), new Point(0, Shadows.Default.Size),
                          Color.FromArgb(Shadows.Default.Color1Opacity, Shadows.Default.Color1.R, Shadows.Default.Color1.G, Shadows.Default.Color1.B),
                        Color.FromArgb(Shadows.Default.Color2Opacity, Shadows.Default.Color2.R, Shadows.Default.Color2.G, Shadows.Default.Color2.B));
                    }

                    g.FillRectangle(lb, 0, 0, b.Width, b.Height);
                }
                SetBitmap(b);

                this.Left = loc[0];
                this.Top = loc[1];
                this.Width = loc[2];
                this.Height = loc[3];
                this.TopMost = true;
            }
        }

        private int[] GetShadowLocation(Win32.RECT rect, int size)
        {
            Screen[] s = Screen.AllScreens;
            for (int i = 0; i < s.Length; i++)
            {
                if (rect.Left >= s[i].Bounds.Left && rect.Right <= s[i].Bounds.Right
                    && rect.Top >= s[i].Bounds.Top && rect.Bottom <= s[i].Bounds.Bottom)
                {
                    //Horizontal
                    if (rect.Width == s[i].Bounds.Width && rect.Height < s[i].Bounds.Height)
                    {
                        //Top
                        if (rect.Top == s[i].Bounds.Top)
                        {
                            return new int[] { rect.Left, rect.Bottom, rect.Width, size, 1 };
                        }
                        //Bottom
                        else if (rect.Bottom == s[i].Bounds.Bottom)
                        {
                            return new int[] { rect.Left, rect.Top - size, rect.Width, size, 3 };
                        }
                    }
                    //Vertical
                    else if (rect.Height == s[i].Bounds.Height && rect.Width < s[i].Bounds.Width)
                    {
                        //Left
                        if (rect.Left == s[i].Bounds.Left)
                        {
                            return new int[] { rect.Right, rect.Top, size, rect.Height, 0 };
                        }
                        else if (rect.Right == s[i].Bounds.Right)
                        {
                            return new int[] { rect.Left - size, rect.Top, size, rect.Height, 2 };
                        }
                    }
                }
            }
            return new int[] { 0 };
        }
        
        /// <para>Changes the current bitmap with a custom opacity level.  Here is where all happens!</para>
        public void SetBitmap(Bitmap bitmap)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // The ideia of this is very simple,
            // 1. Create a compatible DC with screen;
            // 2. Select the bitmap with 32bpp with alpha-channel in the compatible DC;
            // 3. Call the UpdateLayeredWindow.

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = (byte)Shadows.Default.ShadowOpacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    //Windows.DeleteObject(hBitmap); // The documentation says that we have to use the Windows.DeleteObject... but since there is no such method I use the normal DeleteObject from Win32 GDI and it's working fine without any resource leak.
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000 | 0x20 | 0x08000000 | 0x00000008; // This form has to have the WS_EX_LAYERED extended style
                return cp;
            }
        }       
    }
}