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
using SSClient.Class;

namespace SSClient.Forms
{
    public partial class fShipData : Form
    {
		[DllImport("User32.dll")]
		static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

		internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
		[DllImport("user32.dll")]
		internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

		[DllImport("user32.dll")]
		static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		private Process process;
		private IntPtr modelshipHWND = IntPtr.Zero;

		private const int WM_ACTIVATE = 0x0006;
		private readonly IntPtr WA_ACTIVE = new IntPtr(1);
		private readonly IntPtr WA_INACTIVE = new IntPtr(0);

		ShipData[] dataShip;

		public fShipData()
        {
            InitializeComponent();

			//try
			//{
			//	process = new Process();
			//	process.StartInfo.FileName = Application.StartupPath + "\\3D\\3DViewBulkcarrier.exe";
			//	process.StartInfo.Arguments = "-parentHWND " + pnlShipView.Handle.ToInt32() + " " + Environment.CommandLine;
			//	process.StartInfo.UseShellExecute = true;
			//	process.StartInfo.CreateNoWindow = true;

			//	process.Start();

			//	process.WaitForInputIdle();
			//	// Doesn't work for some reason ?!
			//	//unityHWND = process.MainWindowHandle;
			//	EnumChildWindows(pnlShipView.Handle, WindowEnum, IntPtr.Zero);
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
			//}
		}

		private void ActivateUnityWindow()
		{
			//SendMessage(modelshipHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
		}

		private void DeactivateUnityWindow()
		{
			//SendMessage(modelshipHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
		}

		private int WindowEnum(IntPtr hwnd, IntPtr lparam)
		{
			//modelshipHWND = hwnd;
			//ActivateUnityWindow();
			return 0;
		}

		private void fShipData_Resize(object sender, EventArgs e)
		{
			//MoveWindow(modelshipHWND, 0, 0, pnlShipView.Width, pnlShipView.Height, true);
			//ActivateUnityWindow();
		}

		// Close Unity application
		private void fShipData_FormClosed(object sender, FormClosedEventArgs e)
		{
			//try
			//{
			//	process.CloseMainWindow();

			//	Thread.Sleep(1000);
			//	while (process.HasExited == false)
			//		process.Kill();
			//}
			//catch (Exception)
			//{

			//}
		}

        private void fShipData_Activated(object sender, EventArgs e)
		{
			//ActivateUnityWindow();
		}

		private void fShipData_Deactivate(object sender, EventArgs e)
		{
			//DeactivateUnityWindow();
		}

        private void fShipData_Load(object sender, EventArgs e)
        {
			InitShipData();

			comboBox1.SelectedIndex = 0;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex != -1)
			{
				lblShipType.Text = dataShip[comboBox1.SelectedIndex].Name;
				lblLoa.Text = string.Format("{0} M", dataShip[comboBox1.SelectedIndex].LOA.ToString("F3"));
				lblLbp.Text = string.Format("{0} M", dataShip[comboBox1.SelectedIndex].LPP.ToString("F3"));
				lblBreadth.Text = string.Format("{0} M", dataShip[comboBox1.SelectedIndex].Breadth.ToString("F3"));
				lblDepth.Text = string.Format("{0} M", dataShip[comboBox1.SelectedIndex].Depth.ToString("F3"));
				lblDraft.Text = string.Format("{0} M", dataShip[comboBox1.SelectedIndex].Draft.ToString("F3"));

				if (comboBox1.SelectedIndex == 0)
				{
					pbShipImage.BackgroundImage = Properties.Resources.BC50000;
				}
				else if (comboBox1.SelectedIndex == 1)
				{
					pbShipImage.BackgroundImage = Properties.Resources.GC3650;
				}
				else if (comboBox1.SelectedIndex == 2)
				{
					pbShipImage.BackgroundImage = Properties.Resources.FC4180;
				}
			}
		}

		private void InitShipData()
		{
			dataShip = new ShipData[]
			{
				new ShipData()
				{
					Name = "BULK CARRIER 50000 DWT",
					LOA = 189.998f,
					LPP = 182.300f,
					Breadth = 30.500f,
					Depth = 17.500f,
					Draft = 12.800f
				},
				new ShipData()
				{
					Name = "GENERAL CARGO 3650 DWT",
					LOA = 98.0f,
					LPP = 92.0f,
					Breadth = 16.5f,
					Depth = 7.8f,
					Draft = 5.5f
				},
				new ShipData()
				{
					Name = "CONTAINER 4180 DWT",
					LOA = 98.0f,
					LPP = 92.0f,
					Breadth = 16.5f,
					Depth = 7.8f,
					Draft = 5.5f
				}
			};
		}
	}
}
