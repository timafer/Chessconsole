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
        public bool canbehitbywhite { get; set; }
        public bool canbehitbyblack { get; set; }
        public bool whitechecker { get; set; }
        public bool blackchecker { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool check { get; set; }
        public BoardSquare(bool _iswhite,Piece _piece)
        {
            iswhite = _iswhite;
            piece = _piece;
            canbehitbyblack = false;
            canbehitbywhite = false;
        }
    }
}
