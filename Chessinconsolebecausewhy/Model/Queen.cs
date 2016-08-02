using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Queen : Piece
    {
        public override string name { get; set; }
        public Queen()
        {
            name = "Queen";
        }
        public override bool movement()
        {
            throw new NotImplementedException();
        }
    }
}
