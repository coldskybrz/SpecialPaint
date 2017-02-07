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
    public partial class SizeDialog : Form
    {
        private Size size = new Size();
        public new Size Size
        {
            get
            {
                return size;
            }
        }
        public SizeDialog()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (widthTextBox.Text == string.Empty || heightTextBox.Text == string.Empty)
            {
                MessageBox.Show("Поля не могут быть пустыми!", "Ошибка!");
            }
            else
            {
                size.Width = Convert.ToInt32(widthTextBox.Text);
                size.Height = Convert.ToInt32(heightTextBox.Text);
                if (size.Width < 1 || size.Height < 1)
                {
                    MessageBox.Show("Ширина или высота не могут быть меньше, чем 1 пиксель!", "Ошибка!");
                }
            }
        }
        private void enteringTextEvent(object sender, EventArgs e)
        {
            TextBox ourSender = (sender as TextBox);
            if(Text.Length > 0)
            {
                for(int i = 0;i < ourSender.Text.Length;i++)
                {
                    if(!char.IsNumber((ourSender.Text[i])))
                    {
                        int selectionIndex = ourSender.SelectionStart;
                        ourSender.Text = ourSender.Text.Remove(i, 1);
                        ourSender.SelectionStart = selectionIndex-1;
                    }
                }
            }
        }
    }
}
