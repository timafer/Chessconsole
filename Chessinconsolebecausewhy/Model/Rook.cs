using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Rook : Piece
    {
        public override string name { get; set; }
        public Rook()
        {
            name = "Rook";
        }
        public override bool movement()
        {
            throw new NotImplementedException();
        }
    }
}
