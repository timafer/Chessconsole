﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Bishop : Piece
    {
        public override string name { get; set; }
        public override bool hasmoved { get; set; }
        public Bishop()
        {
            name = "Bishop";
        }
        public override bool movement(int x1, int x2, int y1, int y2)
        {
            //if (x2-x1==y2-y1&&x1!=x2)
            //{
                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}