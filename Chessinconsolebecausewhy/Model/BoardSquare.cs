using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class BoardSquare
    {
        public string contains { get; set; }
        public BoardSquare(string currentpiece)
        {
            contains = currentpiece;
        }
    }
}
