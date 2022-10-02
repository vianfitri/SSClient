using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViControls
{
    [DefaultEvent("_TextChanged")]
    public partial class ViTextBox : UserControl
    {
        #region Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.HotPink;
        private bool isFocused = false;

        private int borderRadius = 0;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        #endregion

        #region Constructor
        public ViTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        [Category("ViControls Props")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

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
        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("ViControls Props")]
        public bool PasswordChar
        {
            get { return isPasswordChar; }
            set
            {
                isPasswordChar = value;
                txtBase.UseSystemPasswordChar = value;
            }
        }

        [Category("ViControls Props")]
        public bool Multiline
        {
            get { return txtBase.Multiline; }
            set { txtBase.Multiline = value; }
        }

        [Category("ViControls Props")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                txtBase.BackColor = value;
            }
        }

        [Category("ViControls Props")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                txtBase.ForeColor = value;
            }
        }

        [Category("ViControls Props")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                txtBase.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("ViControls Props")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                return txtBase.Text;
            }
            set
            {
                txtBase.Text = value;
                SetPlaceholder();
            }
        }

        [Category("ViControls Props")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        [Category("ViControls Props")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        [Category("ViControls Props")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPasswordChar)
                    txtBase.ForeColor = value;
            }
        }

        [Category("ViControls Props")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                txtBase.Text = "";
                SetPlaceholder();
            }
        }
        #endregion

        #region Overridden Method
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)
            {
                //Fields
                var rectBorderSmooth = this.ClientRectangle;
                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    // Drawing
                    this.Region = new Region(pathBorderSmooth);
                    if (borderRadius > 15) SetTextBoxRoundedRegion();
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)
                    {
                        // Draw Border Smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);

                        // Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        // Draw Border Smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);

                        // Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        #endregion

        #region Private Method
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtBase.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                txtBase.Text = placeholderText;
                txtBase.ForeColor = placeholderColor;
                if (isPasswordChar)
                    txtBase.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                txtBase.Text = "";
                txtBase.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    txtBase.UseSystemPasswordChar = true;
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(txtBase.ClientRectangle, borderRadius - borderSize);
                txtBase.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(txtBase.ClientRectangle, borderSize * 2);
                txtBase.Region = new Region(pathTxt);
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void UpdateControlHeight()
        {
            if (txtBase.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                txtBase.Multiline = true;
                txtBase.MinimumSize = new Size(0, txtHeight);
                txtBase.Multiline = false;

                this.Height = txtBase.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void txtBase_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void txtBase_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void txtBase_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void txtBase_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void txtBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void txtBase_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }

        private void txtBase_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
        #endregion

        #region Events
        public event EventHandler _TextChanged;
        #endregion
    }
}
