using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ViControls
{
    public class ViButton : Button
    {
        #region Fields
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;
        #endregion

        #region Constructor
        public ViButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }
        #endregion

        #region Properties
        [Category("ViControls Props")]
        public int BorderSize 
        {
            get { return borderSize; }
            set 
            { 
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("ViControls Props")]
        public int BorderRadius 
        {
            get { return borderRadius; }
            set 
            {
                if (value <= this.Height)
                    borderRadius = value;
                else
                    borderRadius = this.Height;
                this.Invalidate();
            }
        }

        [Category("ViControls Props")]
        public Color BorderColor 
        { 
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }  
        }

        [Category("ViControls Props")]
        public Color BackgroundColor
        {
            get { return this.BackColor;  }
            set
            {
                this.BackColor = value;
            }
        }

        [Category("ViControls Props")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set
            {
                this.ForeColor = value;
            }
        }
        #endregion

        #region Overridden Method
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (BorderRadius > 2) // Rounded Button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
                    using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - 1F))
                    using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                    using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;

                    //Button Surface
                    this.Region = new Region(pathSurface);

                    //Draw Surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button Border
                    if (BorderSize >= 1)
                        //Draw Control Border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                //Button Surface
                this.Region = new Region(rectSurface);

                //Button Border
                if(BorderSize >= 1)
                {
                    using (Pen penBorder = new Pen(BorderColor, BorderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);

        }
        #endregion

        #region Private Method
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
        #endregion

        #region Events
        #endregion
    }
}
