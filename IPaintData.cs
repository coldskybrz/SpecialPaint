using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SpecialPaint
{
    public interface IPaintData
    {
        Font PaintFont { get;}
        bool Fill { get;}
        float StrokeSize { get;}
        Tool CurrentTool { get;}
        DashStyle DashStyle { get;}
        Color FirstColor { get;}
        Color SecondColor { get; }
    }
}
