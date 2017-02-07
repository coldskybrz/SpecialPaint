using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialPaint
{
    public interface IControllText
    {
        string TextToPaint { get; set; }
        void MoveText(int distance, Direction direction);
    }
}
