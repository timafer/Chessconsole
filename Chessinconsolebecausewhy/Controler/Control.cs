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
            input=finput.runinput();
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
                        string piece = Model.prossess.processplace(s);
                        Console.WriteLine("-place the " + piece + " on " + s[2] + s[3]);
                    }
                }
                else if (result.Length == 2)
                {
                    Console.WriteLine(Model.prossess.prossesmove(result));
                }
                else if (result.Length == 4)
                {
                    string[] move1 = { result[0], result[1] };
                    string[] move2 = { result[2], result[3] };
                    Console.WriteLine(Model.prossess.(move1) + ", " + Model.prossess.prossesmove(move2));
                }
                else
                {
                    Console.WriteLine("Invalid line");
                }
            }
        }

}
