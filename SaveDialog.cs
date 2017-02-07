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
    public partial class SaveDialog : Form
    {
        public SaveDialog(string fileName)
        {
            InitializeComponent();
            fileLabel.Text = fileName + "?";
        }
    }
}
