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
        public override bool hasmoved { get; set; }
        public bool diagplus { get; set; }
        public bool diagminus { get; set; }
        bool iswhite { get; set; }
        public Pawn(bool Iswhite)
        {
            name = "Pawn";
            iswhite = Iswhite;
        }
        public override bool movement(int y1, int y2, int x1, int x2)
        {
            if ((!hasmoved && x2 - x1 == 2&&y1==y2) || (!hasmoved && x2 - x1 == -2 && y1 == y2) || (x2 - x1 == 1 && y1 == y2) || (x2 - x1 == -1 && y1 == y2) || (iswhite && diagminus && y2 - y1 == -1 && x2 - x1 == 1) || (!iswhite && diagminus && x2 - x1 == 1 && x2 - x1 == 1) ||
                (iswhite && diagplus && x2 - x1 == -1 && x2 - x1 == -1) || (!iswhite && diagplus && x2 - x1 == 1 && x2 - x1 == -1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
