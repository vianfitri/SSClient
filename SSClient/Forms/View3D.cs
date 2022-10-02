using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSClient.Forms
{
    public partial class View3D : Form
    {
		[DllImport("User32.dll")]
		static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

		internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
		[DllImport("user32.dll")]
		internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

		[DllImport("user32.dll")]
		static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		private Process process;
		private IntPtr unityHWND = IntPtr.Zero;

		private const int WM_ACTIVATE = 0x0006;
		private readonly IntPtr WA_ACTIVE = new IntPtr(1);
		private readonly IntPtr WA_INACTIVE = new IntPtr(0);

		public View3D()
        {
            InitializeComponent();

			try
			{
				process = new Process();
				process.StartInfo.FileName = Application.StartupPath + "\\3D\\Bulkcarrier.exe";
				process.StartInfo.Arguments = "-parentHWND " + pnl3DView.Handle.ToInt32() + " " + Environment.CommandLine;
				process.StartInfo.UseShellExecute = true;
				process.StartInfo.CreateNoWindow = true;

				process.Start();

				process.WaitForInputIdle();
				// Doesn't work for some reason ?!
				//unityHWND = process.MainWindowHandle;
				EnumChildWindows(pnl3DView.Handle, WindowEnum, IntPtr.Zero);

				//unityHWNDLabel.Text = "Unity HWND: 0x" + unityHWND.ToString("X8");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
			}
		}

		private void ActivateUnityWindow()
		{
			SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
		}

		private void DeactivateUnityWindow()
		{
			SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
		}

		private int WindowEnum(IntPtr hwnd, IntPtr lparam)
		{
			unityHWND = hwnd;
			ActivateUnityWindow();
			return 0;
		}

        private void View3D_Activated(object sender, EventArgs e)
        {
			ActivateUnityWindow();
        }

        private void View3D_Deactivate(object sender, EventArgs e)
        {
			DeactivateUnityWindow();
        }

        private void View3D_FormClosed(object sender, FormClosedEventArgs e)
        {
			try
			{
				process.CloseMainWindow();

				Thread.Sleep(1000);
				while (process.HasExited == false)
					process.Kill();
			}
			catch (Exception)
			{

			}
		}

        private void pnl3DView_Resize(object sender, EventArgs e)
        {
			MoveWindow(unityHWND, 0, 0, pnl3DView.Width, pnl3DView.Height, true);
			ActivateUnityWindow();
		}
    }
}
