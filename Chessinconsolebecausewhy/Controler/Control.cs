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
        Model.Board board;
        List<string> input;
        const int asciibal = 65;
        const int firstbal = 49;
        const int arrayrange = 7;
        public Control(string filepathintial)
        {
            filepath = filepathintial;
            board = new Model.Board();
        }
        public void start()
        {
            Model.Fileinput finput = new Model.Fileinput(filepath);
            input = finput.runinput();
            process();
        }
        public void process()
        {
            foreach (string s in input)
            {
                string[] result = s.Split(' ');
                if (result.Length == 1)
                {
                    if (Model.prossess.testrange(char.ToUpper(s[2]) - asciibal, char.ToUpper(s[3]) - firstbal))
                    {
                        Console.WriteLine("Out of range");
                    }
                    else
                    {
                        Model.prossess.processplace(s,board);
                            Console.WriteLine("-Placed the " +board.Piececolor(char.ToUpper(s[2])-asciibal,char.ToUpper(s[3])-firstbal)+" "+board.Piecename(char.ToUpper(s[2]) - asciibal, char.ToUpper(s[3]) - firstbal) +" on " + s[2] + s[3]);
                    }
                }
                else if (result.Length == 2)
                {
                    String pc2=Model.prossess.prossesmove(result, board);
                    int x1 = char.ToUpper(result[0][0]) - asciibal;
                    int y1 = char.ToUpper(result[0][1]) - firstbal;
                    int x2 = char.ToUpper(result[1][0]) - asciibal;
                    int y2 = char.ToUpper(result[1][1]) - firstbal;
                    if (pc2[0] != 'E')
                    {
                        Console.Write("-Moved the " + board.Piececolor(x2, y2)+" "+ board.Piecename(x2, y2)+" at "+result[0][0]+result[0][1]+" to "+ result[1][0] + result[1][1]);
                        if (result[0].Length==3)
                        {
                            if (result[0][2] == '*')
                            {
                                Console.WriteLine(" and captured "+pc2);
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
                else if (result.Length == 4)
                {
                    int x1 = char.ToUpper(result[0][0]) - asciibal;
                    int y1 = char.ToUpper(result[0][1]) - firstbal;
                    int x2 = char.ToUpper(result[1][0]) - asciibal;
                    int y2 = char.ToUpper(result[1][1]) - firstbal;
                    string e=Model.prossess.prossesmove(result, board);
                    if (e[0] != 'E')
                    {
                        Console.WriteLine("-Switched the "+board.Piececolor(x2,y2)+" "+board.Piecename(x2,y2)+" at "+ result[0][0] + result[0][1] +" and the "+ board.Piececolor(x1, y1) + " " + board.Piecename(x1, y1)+" at "+ result[1][0] + result[1][1]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid line");
                }
            }
        }

    }
}
