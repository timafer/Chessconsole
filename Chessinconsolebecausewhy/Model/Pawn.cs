using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Pawn:Piece
    {
        public override string name { get; set; }
        public Pawn()
        {
            name = "Pawn";
        }
        public override bool movement()
        {
            throw new NotImplementedException();
        }
    }
}
