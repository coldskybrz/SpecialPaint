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
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    public partial class Layer : Form, IControllText
    {
        public event MouseEventHandler TakeColor = null;

        private bool mouseDown = false;
        private bool textEnteringStatus = false;
        private bool savedChanges = true;
        private string textToPaint = null;
        private string filePath = null;
        private Point lastMouseDownCoords = new Point();
        private Point lastMouseMoveCoords = new Point();
        private Point previousLastMouseMoveCoords = new Point();
        private Point textCoords = new Point();
        private Graphics imageGraphics = null;
        private Graphics handleGraphics = null;
        private Pen pen = null;
        private SolidBrush brush = null;
        private readonly IPaintData paintData = null;
        public string TextToPaint 
        { 
            get
            {
                return textToPaint;
            }
            set
            {
                textToPaint = value;
                if(textEnteringStatus)
                {
                    handleGraphics.DrawImage(Image, new Point());
                    handleGraphics.DrawString(TextToPaint, paintData.PaintFont, Brush, textCoords);
                }
            }
        }
        public Pen Pen
        {
            get
            {
                pen.Color = paintData.FirstColor;
                pen.DashStyle = paintData.DashStyle;
                pen.Width = paintData.StrokeSize;
                return pen;
            }
        }
        public SolidBrush Brush
        {
            get
            {
                brush.Color = paintData.SecondColor;
                return brush;
            }
        }
        public Image Image
        {
            get
            {
                return pictureBox.Image;
            }
            set
            {
                pictureBox.Image = value;
                pictureBox.ClientSize = Image.Size;
            }
        }
        public Layer(IPaintData _paintData, bool openFile)
        {
            InitializeComponent();
            paintData = _paintData;
            InitializeData(openFile);
        }
        private void InitializeData(bool openFile)
        {
            if (openFile)
            {
                if(!Open())
                {
                    this.Dispose();
                }
            }
            else
            {
                SizeDialog sizeDialog = new SizeDialog();
                if (sizeDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel || sizeDialog.Size.Height < 1 || sizeDialog.Width < 1)
                {
                    this.Dispose();
                }
                else
                {
                    Image = new Bitmap(sizeDialog.Size.Width,sizeDialog.Size.Height);
                }
            }
            if (Image != null)
            {
                imageGraphics = Graphics.FromImage(Image);
                if (!openFile)
                {
                    imageGraphics.Clear(Color.White);
                }
                handleGraphics = Graphics.FromHwnd(pictureBox.Handle);
                pen = new Pen(paintData.FirstColor);
                brush = new SolidBrush(paintData.SecondColor);
            }
        }
        public void MoveText(int distance, Direction direction)
        {
            if (textEnteringStatus)
            {
                handleGraphics.DrawImage(Image, new Point());
                switch (direction)
                {
                    case Direction.Down:
                        textCoords.Y += distance;
                        break;
                    case Direction.Up:
                        textCoords.Y -= distance;
                        break;
                    case Direction.Left:
                        textCoords.X -= distance;
                        break;
                    case Direction.Right:
                        textCoords.X += distance;
                        break;
                }
                if (textCoords.X < 0)
                {
                    textCoords.X = 0;
                }
                else if (textCoords.X+distance > Image.Size.Width)
                {
                    textCoords.X = Image.Size.Width-distance;
                }
                if (textCoords.Y < 0)
                {
                    textCoords.Y = 0;
                }
                else if (textCoords.Y+distance > Image.Size.Height)
                {
                    textCoords.Y = Image.Size.Height - distance;
                }
                handleGraphics.DrawString(TextToPaint, paintData.PaintFont, Brush, textCoords);
            }
        }
        public void EnterText()
        {
            if(textEnteringStatus)
            {
                imageGraphics.DrawString(TextToPaint, paintData.PaintFont, Brush, textCoords);
                savedChanges = false;
            }
        }
        public void CancelText()
        {
            if(textEnteringStatus)
            {
                handleGraphics.DrawImage(Image, new Point());
            }
        }
        private void DrawEllipse(Graphics graphics)
        {
            Rectangle coords = new Rectangle(lastMouseDownCoords.X,lastMouseDownCoords.Y, lastMouseMoveCoords.X - lastMouseDownCoords.X,lastMouseMoveCoords.Y - lastMouseDownCoords.Y);
            if(paintData.Fill)
            {
                graphics.FillEllipse(Brush, coords);
            }
            graphics.DrawEllipse(Pen, coords);
        }
        private void DrawRectangle(Graphics graphics)
        {
            Rectangle coords = new Rectangle();
            coords.Width = lastMouseMoveCoords.X > lastMouseDownCoords.X ? lastMouseMoveCoords.X - lastMouseDownCoords.X : lastMouseDownCoords.X - lastMouseMoveCoords.X;
            coords.X = lastMouseMoveCoords.X > lastMouseDownCoords.X ? lastMouseDownCoords.X : lastMouseMoveCoords.X;
            coords.Height = lastMouseMoveCoords.Y > lastMouseDownCoords.Y ? lastMouseMoveCoords.Y - lastMouseDownCoords.Y : lastMouseDownCoords.Y - lastMouseMoveCoords.Y;
            coords.Y = lastMouseMoveCoords.Y > lastMouseDownCoords.Y ? lastMouseDownCoords.Y : lastMouseMoveCoords.Y;
            if (paintData.Fill)
            {
                graphics.FillRectangle(Brush, coords);
            }
            graphics.DrawRectangle(Pen, coords);
        }
        private void DrawLine(Graphics graphics)
        {
            graphics.DrawLine(Pen, lastMouseDownCoords.X, lastMouseDownCoords.Y, lastMouseMoveCoords.X, lastMouseMoveCoords.Y);
        }
        private void DrawPen(Graphics graphics)
        {
            graphics.DrawLine(Pen, previousLastMouseMoveCoords, lastMouseMoveCoords);
        }
        private void DrawEraser(Graphics graphics)
        {
            Pen secondColorPen = new Pen(paintData.SecondColor,paintData.StrokeSize);
            graphics.DrawLine(secondColorPen, previousLastMouseMoveCoords, lastMouseMoveCoords);
            secondColorPen.Dispose();
        }
        private void DrawInGraphics(Graphics graphics)
        {
            switch(paintData.CurrentTool)
            {
                case Tool.Ellipse:
                    DrawEllipse(graphics);
                    break;
                case Tool.Rectangle:
                    DrawRectangle(graphics);
                    break;
                case Tool.Line:
                    DrawLine(graphics);
                    break;
                case Tool.Pen:
                    DrawPen(graphics);
                    DrawPen(imageGraphics);
                    break;
                case Tool.Eraser:
                    DrawEraser(graphics);
                    DrawEraser(imageGraphics);
                    break;
            }
        }
        private void PaintText()
        {
            TextController textController = new TextController(this);
            TextToPaint = string.Empty;
            textCoords = lastMouseDownCoords;
            textEnteringStatus = true;
            if(textController.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EnterText();
            }
            else
            {
                CancelText();
            }
            TextToPaint = null;
            textCoords = new Point(0, 0);
            textEnteringStatus = false;
        }
        public bool Save()
        {
            bool saved = false;
            saveFileDialog.FileName = Text;
            if(filePath == null || filePath == string.Empty || !System.IO.File.Exists(filePath))
            {
                saved = SaveAs();
            }
            else
            {
                Image.Save(filePath);
                savedChanges = true;
            }
            saveFileDialog.FileName = null;
            return saved;
        }
        public bool SaveAs()
        {
            bool saved = true;
            saveFileDialog.FileName = Text;
            string formatFile = Text.Substring(Text.LastIndexOf('.'));
            if(formatFile == ".png")
            {
                saveFileDialog.FilterIndex = 1;
            }
            else if(formatFile == ".png")
            {
                saveFileDialog.FilterIndex = 2;
            }
            else if(formatFile == ".jpg")
            {
                saveFileDialog.FilterIndex = 3;
            }
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image.Save(saveFileDialog.FileName);
                filePath = saveFileDialog.FileName;
                Text = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                savedChanges = true;
            }
            else
            {
                saved = false;
            }
            saveFileDialog.DefaultExt = null;
            saveFileDialog.FileName = null;
            return saved;
        }
        public bool Open()
        {
            bool opened = false;
            DialogResult dResult = System.Windows.Forms.DialogResult.None;
            if (!savedChanges)
            {
               dResult = ShowSaveDialog();
            }
            if(dResult != System.Windows.Forms.DialogResult.Cancel && openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Image != null)
                {
                    Image.Dispose();
                }
                Image copy = Image.FromFile(openFileDialog.FileName);
                Image = new Bitmap(copy);
                copy.Dispose();
                filePath = openFileDialog.FileName;
                Text = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                openFileDialog.FileName = null;
                opened = true;
                savedChanges = true;
            }
            return opened;
        }
        public DialogResult ShowSaveDialog()
        {
            SaveDialog saveDialog = new SaveDialog(Text);
            DialogResult dialogR = System.Windows.Forms.DialogResult.None;
            bool stopAsking = true;
            do
            {
                stopAsking = true;
                dialogR = saveDialog.ShowDialog();
                switch (dialogR)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        stopAsking = Save();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    case System.Windows.Forms.DialogResult.Ignore:
                        break;
                }
            }
            while (!stopAsking);
            return dialogR;
        }
        private void TakeColorEvent()
        {
            if (TakeColor != null)
            {
                MouseEventArgs mouseEventArgs = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left | System.Windows.Forms.MouseButtons.Right, 1, lastMouseDownCoords.X, lastMouseDownCoords.Y, 0);
                TakeColor.Invoke(this, mouseEventArgs);
            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastMouseDownCoords = e.Location;
            switch(paintData.CurrentTool) 
            {
                case Tool.Pipette:
                    TakeColorEvent();
                    break;
                case Tool.Text:
                    PaintText();
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            previousLastMouseMoveCoords = lastMouseMoveCoords;
            lastMouseMoveCoords = e.Location;
            if (mouseDown)
            {
                handleGraphics.DrawImage(Image, new Point());
                DrawInGraphics(handleGraphics);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseDown = false;
                DrawInGraphics(imageGraphics);
                handleGraphics.DrawImage(Image, new Point());
                savedChanges = false;
            }
        }

        private void Layer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!savedChanges)
            {
                if (ShowSaveDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Layer_FormClosed(object sender, FormClosedEventArgs e)
        {
            imageGraphics.Dispose();
            handleGraphics.Dispose();
            Image.Dispose();
            pen.Dispose();
            brush.Dispose();
        }
    }
}
