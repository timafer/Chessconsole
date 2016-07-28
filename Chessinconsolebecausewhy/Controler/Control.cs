using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Controler
{
    class Control
    {
        string filepath;
        Model.BoardSquare[,] Board = new Model.BoardSquare[8, 8];
        public Control(string filepathintial)
        {
            filepath = filepathintial;
            makeboard();
        }
        public void start()
        {
            Model.Fileinput finput = new Model.Fileinput(filepath,Board);
            finput.runinput();
        }
        public void makeboard()
        {
            for(int i=0;i<8;i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    Board[o, i] = new Model.BoardSquare("Empty");
                }
            }
        }
    }
}
