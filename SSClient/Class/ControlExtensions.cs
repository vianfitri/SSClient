using System;
using System.Collections.Generic;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSClient.Class
{
    public static class ControlExtensions
    {
        public static Bitmap ControlToImage(this Control control)
        {
            Bitmap ControlImage = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(ControlImage, new Rectangle(0, 0, control.Width, control.Height));
            return ControlImage;
        }

        public static Bitmap FormClientAreaToImage(this Form form)
        {
            using (Bitmap frmImage = form.ControlToImage())
            {
                Point origin = form.PointToScreen(new Point(0, 0));
                int diffx = origin.X - form.Left;
                int diffy = origin.Y - form.Top;

                int clientareawidth = form.ClientSize.Width;
                int clientareaheight = form.ClientSize.Height;
                Bitmap ClientAreaImage = new Bitmap(clientareawidth, clientareaheight);
                using (Graphics gr = Graphics.FromImage(ClientAreaImage))
                {
                    gr.DrawImage(frmImage, 0, 0,
                        new Rectangle(diffx, diffy, clientareawidth, clientareaheight),
                        GraphicsUnit.Pixel);
                }
                return ClientAreaImage;
            }
        }
    }
}
