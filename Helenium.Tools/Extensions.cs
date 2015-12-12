using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Helenium.Tools
{
    /// <summary>
    /// GDI and NativeMethods Imports
    /// </summary>
    public class NativeMethods
    {
        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <param name="nXDest">The n x dest.</param>
        /// <param name="nYDest">The n y dest.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hObjectSource">The h object source.</param>
        /// <param name="nXSrc">The n x source.</param>
        /// <param name="nYSrc">The n y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll")]
        internal static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
        /// <summary>
        /// Creates the compatible bitmap.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll")]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        /// <summary>
        /// Creates the compatible dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        /// <summary>
        /// Deletes the dc.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll")]
        internal static extern bool DeleteDC(IntPtr hDC);
        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="hObject">The h object.</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr hObject);
        /// <summary>
        /// Selects the object.
        /// </summary>
        /// <param name="hDC">The h dc.</param>
        /// <param name="hObject">The h object.</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll")]
        internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        /// <summary>
        /// Gets the desktop window.
        /// </summary>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern IntPtr GetDesktopWindow();
        /// <summary>
        /// Gets the window dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern IntPtr GetWindowDC(IntPtr hWnd);
        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="rect">The rect.</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hDC">The h dc.</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
    }

    /// <summary>
    /// GDI Rect struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// The left
        /// </summary>
        public int left;
        /// <summary>
        /// The top
        /// </summary>
        public int top;
        /// <summary>
        /// The right
        /// </summary>
        public int right;
        /// <summary>
        /// The bottom
        /// </summary>
        public int bottom;
    }

    /// <summary>
    /// Control class extension methods and tools
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// The srccopy
        /// </summary>
        public const int SRCCOPY = 13369376;

        /// <summary>
        /// Gets the data URL.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static string GetDataURL(Bitmap bitmap)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            var a = stream.ToArray();

            string s = "<img border=\"1\" src=\"data:image/"
                        + "png"
                        + ";base64,"
                        + Convert.ToBase64String(a) + "\" />";

            return s;
        }
        /// <summary>
        /// Saves Control screenshot
        /// </summary>
        /// <param name="control">Control</param>
        /// <returns>
        /// Bitmap with screenshot
        /// </returns>
        public static Bitmap DrawToImage(this Control control)
        {
            try
            {
                return (Bitmap)control.Invoke((Func<Bitmap>)delegate() { return CaptureWindow(control.Handle); });
            }
            catch
            {
                return new Bitmap(10, 10);
            }
        }

        /// <summary>
        /// Captures the whole screen
        /// </summary>
        /// <returns>
        /// Bitmap with screenshot
        /// </returns>
        public static Bitmap CaptureScreen()
        {
            return CaptureWindow(NativeMethods.GetDesktopWindow());
        }

        /// <summary>
        /// Captures given window by handle
        /// </summary>
        /// <param name="handle">Window handle</param>
        /// <returns>
        /// Bitmap with screenshot
        /// </returns>
        public static Bitmap CaptureWindow(IntPtr handle)
        {

            IntPtr hdcSrc = NativeMethods.GetWindowDC(handle);

            RECT windowRect = new RECT();
            NativeMethods.GetWindowRect(handle, ref windowRect);

            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            IntPtr hdcDest = NativeMethods.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = NativeMethods.CreateCompatibleBitmap(hdcSrc, width, height);

            IntPtr hOld = NativeMethods.SelectObject(hdcDest, hBitmap);
            NativeMethods.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRCCOPY);
            NativeMethods.SelectObject(hdcDest, hOld);
            NativeMethods.DeleteDC(hdcDest);
            NativeMethods.ReleaseDC(handle, hdcSrc);

            Bitmap image = Image.FromHbitmap(hBitmap);
            NativeMethods.DeleteObject(hBitmap);

            return image;
        }

        /// <summary>
        /// Implementation of Invoke to be called when needed
        /// </summary>
        /// <param name="control">Control to use</param>
        /// <param name="action">Action to call</param>
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
