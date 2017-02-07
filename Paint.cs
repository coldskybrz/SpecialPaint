using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialPaint
{
    public partial class Paint : Form
    {
        private ToolStripMenuItem currentToolChecked = null;
        public Paint()
        {
            InitializeComponent();
            paintToolStrip.ChangedTool += new EventHandler(changedToolPaintToolStripMenu);
            currentToolChecked = penToolStripMenuItem;
            CheckEnabledWindows();
        }

        private Layer AddLayer(bool openFile)
        {
            Layer newLayer = new Layer(paintToolStrip,openFile);
            if (!newLayer.IsDisposed)
            {
                newLayer.MdiParent = this;
                newLayer.TakeColor += new MouseEventHandler(layerTakeColor);
                newLayer.Show();
            }
            return newLayer;
        }
        private void CheckEnabledWindows()
        {
            openInWindowToolStripMenuItem.Enabled = windowToolStripMenuItem.HasDropDownItems;
            saveAsToolStripMenuItem.Enabled = windowToolStripMenuItem.HasDropDownItems;
            saveToolStripMenuItem.Enabled = windowToolStripMenuItem.HasDropDownItems;
        }
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLayer(false);
        }
        private void layerTakeColor(object sender, MouseEventArgs e)
        {
            Bitmap colorImage = new Bitmap((sender as Layer).Image);
            paintToolStrip.ChangeCurrentColor(colorImage.GetPixel(e.X,e.Y));
            colorImage.Dispose();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLayer(true);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer currentLayer = (ActiveMdiChild as Layer);
            if (currentLayer != null)
            {
                currentLayer.Save();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer currentLayer = (ActiveMdiChild as Layer);
            if(currentLayer != null)
            {
                currentLayer.SaveAs();
            }
        }

        private void changedToolPaintToolStripMenu(object sender, EventArgs e)
        {
            currentToolChecked.Checked = false;
            switch(paintToolStrip.CurrentTool)
            {
                case Tool.Ellipse:
                    currentToolChecked = ellipseToolStripMenuItem;
                    break;
                case Tool.Eraser:
                    currentToolChecked = eraserToolStripMenuItem;
                    break;
                case Tool.Line:
                    currentToolChecked = lineToolStripMenuItem;
                    break;
                case Tool.Pen:
                    currentToolChecked = penToolStripMenuItem;
                    break;
                case Tool.Pipette:
                    currentToolChecked = pipetteToolStripMenuItem;
                    break;
                case Tool.Rectangle:
                    currentToolChecked = rectangleToolStripMenuItem;
                    break;
                case Tool.Text:
                    currentToolChecked = textToolStripMenuItem;
                    break;
            }
            currentToolChecked.Checked = true;
        }
        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Pen);
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Text);
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Eraser);
        }

        private void pipetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Pipette);
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Line);
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Rectangle);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintToolStrip.PickTool(Tool.Ellipse);
        }

        private void openInWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Layer currentLayer = (ActiveMdiChild as Layer);
            if (currentLayer != null)
            {
                currentLayer.Open();
            }
        }

        private void Paint_MdiChildActivate(object sender, EventArgs e)
        {
            CheckEnabledWindows();
        }
    }
}
