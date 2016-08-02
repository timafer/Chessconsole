using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Knight : Piece
    {
        public override string name { get; set; }
        public Knight()
        {
            name = "Knight";
        }
        public override bool movement()
        {
            throw new NotImplementedException();
        }
    }
}
