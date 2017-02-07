using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SpecialPaint
{
    public partial class PaintToolStrip : UserControl, IPaintData
    {
        public event EventHandler ChangedTool = null;

        private List<PaintButton> buttons = new List<PaintButton>();
        private PaintButton currentButton = null;
        private PaintButton currentColorButton = null;
        private Font paintFont = new Font(DefaultFont,DefaultFont.Style);
        public Font PaintFont
        {
            get
            {
                return paintFont;
            }
        }
        public bool Fill
        {
            get
            {
                return fillCheckBox.Checked;
            }
        }
        public float StrokeSize
        {
            get
            {
                return Convert.ToInt32(strokeSize.Value);
            }
        }

        public Tool CurrentTool
        {
            get
            {
                Tool tool = Tool.Pen;
                if (currentButton == ellipseButton)
                {
                    tool = Tool.Ellipse;
                }
                else if (currentButton == penButton)
                {
                    tool = Tool.Pen;
                }
                else if (currentButton == lineButton)
                {
                    tool = Tool.Line;
                }
                else if (currentButton == rectangleButton)
                {
                    tool = Tool.Rectangle;
                }
                else if (currentButton == textButton)
                {
                    tool = Tool.Text;
                }
                else if (currentButton == pipetteButton)
                {
                    tool = Tool.Pipette;
                }
                else if (currentButton == eraserButton)
                {
                    tool = Tool.Eraser;
                }
                return tool;
            }
        }
        public DashStyle DashStyle
        {
            get
            {
                DashStyle dashStyle = DashStyle.Solid;
                string ourItem = dashStyleComboBox.GetItemText(dashStyleComboBox.SelectedItem);
                if (ourItem == "Dash")
                {
                    dashStyle = DashStyle.Dash;
                }
                else if (ourItem == "Dash-Dot")
                {
                    dashStyle = DashStyle.DashDot;
                }
                else if (ourItem == "Dash-Dot-Dot")
                {
                    dashStyle = DashStyle.DashDotDot;
                }
                else if (ourItem == "Dot")
                {
                    dashStyle = DashStyle.Dot;
                }
                return dashStyle;
            }
        }
        public Color FirstColor
        {
            get
            {
                return currentColorButton.BackColor;
            }
        }
        public Color SecondColor
        {
            get
            {
                Color c;
                if(currentColorButton == secondColorButton)
                {
                    c = firstColorButton.BackColor;
                }
                else
                {
                    c = secondColorButton.BackColor;
                }
                return c;
            }
        }

        public PaintToolStrip()
        {
            InitializeComponent();
            InitCustom();
        }
        private void InitCustom()
        {
            buttons.Add(penButton);
            penButton.ImagePath = @"..\..\icons\pencil.png";

            buttons.Add(textButton);
            textButton.ImagePath = @"..\..\icons\text.png";

            buttons.Add(eraserButton);
            eraserButton.ImagePath = @"..\..\icons\eraser.png";

            buttons.Add(pipetteButton);
            pipetteButton.ImagePath = @"..\..\icons\pipette.png";

            buttons.Add(lineButton);
            lineButton.ImagePath = @"..\..\icons\line.png";

            buttons.Add(rectangleButton);
            rectangleButton.ImagePath = @"..\..\icons\rectangle.png";

            buttons.Add(ellipseButton);
            ellipseButton.ImagePath = @"..\..\icons\ellipse.png";
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Stroke = Color.Black;
                buttons[i].Click += ClickButtons;
            }

            currentButton = penButton;
            currentButton.Stroke = Color.Red;
            PickTool(Tool.Pen);

            currentColorButton = firstColorButton;
            currentColorButton.Stroke = Color.Red;
            secondColorButton.Stroke = Color.Black;

            Anchor = ((AnchorStyles)((((AnchorStyles.Top)| AnchorStyles.Left)| AnchorStyles.Right)));
            Dock = DockStyle.Top;

            firstColorButton.MouseDown += MouseDownColorButtons;
            secondColorButton.MouseDown += MouseDownColorButtons;

            dashStyleComboBox.SelectedItem = "Solid";
        }
        public void ChangeCurrentColor(Color color)
        {
            currentColorButton.BackColor = color;
        }
        public void PickTool(Tool tool)
        {
            PickTool(GetToolButton(tool));
        }
        private void PickTool(PaintButton tool)
        {
            if (tool != currentButton)
            {
                currentButton.Stroke = Color.Black;
                tool.Stroke = Color.Red;
                currentButton = tool;
                if (ChangedTool != null)
                {
                    ChangedTool.Invoke(this, new EventArgs());
                }
            }
        }
        private void ChangeDashStyle(DashStyle dashStyle)
        {
            switch (dashStyle)
            {
                case DashStyle.Solid:
                    dashStyleComboBox.SelectedItem = "Solid";
                    break;
                case DashStyle.Dash:
                    dashStyleComboBox.SelectedItem = "Dash";
                    break;
                case DashStyle.DashDot:
                    dashStyleComboBox.SelectedItem = "Dash-Dot";
                    break;
                case DashStyle.DashDotDot:
                    dashStyleComboBox.SelectedItem = "Dash-Dot-Dot";
                    break;
                case DashStyle.Dot:
                    dashStyleComboBox.SelectedItem = "Dot";
                    break;
            }
        }
        private PaintButton GetToolButton(Tool tool)
        {
            PaintButton gettingTool = null;
            switch (tool)
            {
                case Tool.Ellipse:
                    gettingTool = ellipseButton;
                    break;
                case Tool.Eraser:
                    gettingTool = eraserButton;
                    break;
                case Tool.Line:
                    gettingTool = lineButton;
                    break;
                case Tool.Pen:
                    gettingTool = penButton;
                    break;
                case Tool.Pipette:
                    gettingTool = pipetteButton;
                    break;
                case Tool.Rectangle:
                    gettingTool = rectangleButton;
                    break;
                case Tool.Text:
                    gettingTool = textButton;
                    break;
            }
            return gettingTool;
        }
        private void MouseDownColorButtons(object sender, MouseEventArgs e)
        {
            PaintButton ourSender = (sender as PaintButton);
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    if (ourSender != currentColorButton)
                    {
                        currentColorButton.Stroke = Color.Black;
                        ourSender.Stroke = Color.Red;
                        currentColorButton = ourSender;
                    }
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    ColorDialog dialogColor = new ColorDialog();
                    if (dialogColor.ShowDialog() == DialogResult.OK)
                    {
                        ourSender.BackColor = dialogColor.Color;
                    }
                    dialogColor.Dispose();
                    break;
            }
        }
        private void ClickButtons(object sender, EventArgs e)
        {
            PickTool((sender as PaintButton));
        }

        private void fontChangeButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                paintFont = fontDialog.Font;
            }
            fontDialog.Dispose();
        }
    }
    public enum Tool
    {
        Pen,
        Text,
        Eraser,
        Pipette,
        Line,
        Rectangle,
        Ellipse
    }
}
