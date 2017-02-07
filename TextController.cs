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
    public partial class TextController : Form
    {
        private readonly IControllText controllText = null;
        public TextController(IControllText _controllText)
        {
            InitializeComponent();
            controllText = _controllText;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            controllText.TextToPaint = textBox.Text;
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            controllText.MoveText(Convert.ToInt32(distanceNumericUpDown.Value),Direction.Up);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            controllText.MoveText(Convert.ToInt32(distanceNumericUpDown.Value), Direction.Left);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            controllText.MoveText(Convert.ToInt32(distanceNumericUpDown.Value), Direction.Right);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            controllText.MoveText(Convert.ToInt32(distanceNumericUpDown.Value), Direction.Down);
        }
    }
}
