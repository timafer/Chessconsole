using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    abstract class Piece
    {
        public abstract string name { get; set; }
        public abstract bool hasmoved { get; set; }
        public abstract bool movement(int x1,int x2,int y1,int y2);
    }
}
