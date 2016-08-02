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
        public King()
        {
            name = "King";
        }

        public override bool movement()
        {
            throw new NotImplementedException();
        }
    }
}
