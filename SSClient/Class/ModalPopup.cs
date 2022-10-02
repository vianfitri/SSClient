using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSClient.Class
{
    [ToolboxItem(false)]
    public class ModalPopup : UserControl
    {
        private Form OwnerForm;
        private Control Content;

        #region Constructor
        public ModalPopup()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }
        #endregion

        #region Method
        public void Init(Form OwnerForm, Control Content)
        {
            this.Name = "PopupControl";
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.Content = Content;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.OwnerForm = OwnerForm;
        }

        public void ShowPopup()
        {
            DrawPopupBackGround();
            this.Dock = DockStyle.Fill;
            this.Controls.Add(Content);
            Content.BringToFront();
            OwnerForm.Controls.Add(this);
            this.BringToFront();
        }

        public void ClosePopup()
        {
            this.OwnerForm.Controls.Remove(this);
            this.Content.Dispose();
            this.BackgroundImage.Dispose();
            this.Dispose();
            GC.Collect();
        }

        private void DrawPopupBackGround()
        {
            this.BackgroundImage = OwnerForm.FormClientAreaToImage();
            using (Graphics grp = Graphics.FromImage(this.BackgroundImage)) {
                using (Brush brush = new SolidBrush(Color.FromArgb(90, Color.Black)))
                {
                    grp.FillRectangle(brush, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height);
                }
            }
        }
        #endregion
    }
}
