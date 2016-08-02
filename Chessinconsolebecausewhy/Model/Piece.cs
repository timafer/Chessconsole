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
        public abstract bool movement();
    }
}
