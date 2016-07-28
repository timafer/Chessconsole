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
        public static Model.BoardSquare[,] Board = new Model.BoardSquare[8, 8];
        public Control(string filepathintial)
        {
            filepath = filepathintial;
            makeboard();
        }
        public void start()
        {
            Model.Fileinput finput = new Model.Fileinput(filepath,Board);
            finput.runinput();
            printboard();
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
        public void printboard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    if (Board[i, o].contains.Equals("Empty"))
                    {
                        Console.Write(" --");
                    }
                    else
                    {
                        string[] result = Board[i, o].contains.Split(' ');
                        if (result[1].Equals("Knight"))
                        {
                            Console.Write(" " + result[0][0] + "N");
                        }
                        else
                        {
                            Console.Write(" " + result[0][0] + result[1][0]);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
