using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Bishop : Piece
    {
        public override string name { get; set; }
        public Bishop()
        {
            name = "Bishop";
        }
        public override bool movement()
        {
            throw new NotImplementedException();
        }
    }
}
