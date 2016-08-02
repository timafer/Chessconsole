using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class King : Piece
    {
        public override string name { get; set; }

        public override bool hasmoved{get;set;}

        public King()
        {
            name = "King";
        }

        public override bool movement(int x1, int x2, int y1, int y2)
        {
            return true;
        }
    }
}
