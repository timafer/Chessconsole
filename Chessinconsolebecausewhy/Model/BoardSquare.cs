using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class BoardSquare
    {
        public bool iswhite{ get; set;}
        public Piece piece {get; set;}
        public BoardSquare(bool _iswhite,Piece _piece)
        {
            iswhite = _iswhite;
            piece = _piece;
        }
    }
}
