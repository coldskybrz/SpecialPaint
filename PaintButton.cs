using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpecialPaint
{
    public partial class PaintButton : UserControl
    {
        private Color stroke;
        private Image image;
        private string imagePath;
        private Graphics graphics;
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                if (value == string.Empty || !File.Exists(value))
                {
                    Image = null;
                    imagePath = null;
                }
                else
                {
                    imagePath = value;
                    Image = new Bitmap(new Bitmap(imagePath),ClientSize.Width,ClientSize.Height);
                }
            }
        }
        private Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                RefreshPaint();
            }
        }
        public Color Stroke
        {
            get
            {
                return stroke;
            }
            set
            {
                stroke = value;
                RefreshPaint();
            }
        }

        public PaintButton()
        {
            InitializeComponent();
        }
        public void RefreshPaint()
        {
            graphics = Graphics.FromHwnd(Handle);
            InvokePaint(this, new PaintEventArgs(graphics, ClientRectangle));
            graphics.Dispose();
        }
        private void PaintButton_Paint(object sender, PaintEventArgs e)
        {
            if(Image != null && File.Exists(ImagePath))
            {
                e.Graphics.DrawImage(Image,new Point(0,0));
            }
            else if(BackColor != Color.Empty)
            {
                using (SolidBrush p = new SolidBrush(BackColor))
                {
                    e.Graphics.FillRectangle(p, e.ClipRectangle);
                }
            }
            if (Stroke != Color.Empty)
            {
                Pen p = new Pen(Stroke);
                e.Graphics.DrawLine(p, new Point(0, 0), new Point(ClientSize.Width, 0));
                e.Graphics.DrawLine(p, new Point(0, 0), new Point(0, ClientSize.Height));
                e.Graphics.DrawLine(p, new Point(ClientSize.Width - 1, 0), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
                e.Graphics.DrawLine(p, new Point(0, ClientSize.Height - 1), new Point(ClientSize.Width - 1, ClientSize.Height - 1));
                p.Dispose();
            }
        }
    }
}
