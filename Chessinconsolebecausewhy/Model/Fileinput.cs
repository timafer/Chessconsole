using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Fileinput
    {
        string filepath = "";
        List<string> lines = new List<string>();
        const int asciibal = 65;
        const int firstbal = 49;
        const int arrayrange = 8;
        Model.BoardSquare[,] Board;
        public Fileinput(string path, Model.BoardSquare[,] board)
        {
            filepath = path;
            Board = board;
        }
        public void runinput()
        {           
            try
            {
                string fileline;
                System.IO.StreamReader file =new System.IO.StreamReader(filepath);
                while ((fileline = file.ReadLine()) != null)
                {
                    lines.Add(fileline);
                }
                process();
                file.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }
        }
        public void process()
        {
            foreach (string s in lines) {
                string[] result = s.Split(' ');
                if (result.Length == 1)
                {
                    if (testrange(char.ToUpper(s[2]) - asciibal, char.ToUpper(s[3]) - firstbal))
                    {
                        Console.WriteLine("Out of range");
                    }
                    else
                    {
                        string piece = processplace(s);
                        Console.WriteLine("-place the " + piece + " on " + s[2] + s[3]);
                        Board[(char.ToUpper(s[2]) - asciibal), char.ToUpper(s[3]) - firstbal].contains = piece;
                    }
                }
                else if (result.Length == 2)
                {
                    Console.WriteLine(prossesmove(result));
                }
                else if (result.Length == 4)
                {
                    string[] move1 = { result[0], result[1] };
                    string[] move2 = { result[2], result[3]};
                    Console.WriteLine(prossesmove(move1)+", "+ prossesmove(move2));
                }
                else
                {
                    Console.WriteLine("Invalid line");
                }
            }
            Controler.Control.Board = Board;
        }
        public string processplace(string line)
        {
            line = line.ToUpper();
            string result = "";
            switch (line[1])
            {
                case 'L':
                    result += "White ";
                    break;
                case 'D':
                    result += "Black ";
                    break;
                default:
                    result += "Invalid Color";
                    break;

            }
            switch (line[0])
            {
                case 'K':
                    result+="King";
                    break;
                case 'Q':
                    result += "Queen";
                    break;
                case 'B':
                    result += "Bishop";
                    break;
                case 'N':
                    result += "Knight";
                    break;
                case 'R':
                    result += "Rook";
                    break;
                case 'P':
                    result += "Pawn";
                    break;
                default:
                    result += "invalid piece";
                    break;
            }
            return result;
        }
        public string prossesmove(string[] result)
        {
            int s11 = char.ToUpper(result[0][0]) - asciibal;
            int s12 = char.ToUpper(result[0][1]) - firstbal;
            int s21 = char.ToUpper(result[1][0]) - asciibal;
            int s22 = char.ToUpper(result[1][1]) - firstbal;
            string print;
            if (testrange(s11, s12))
            {
                print = "First placement out of range";
            }
            else if (testrange(s21, s22))
            {
                print = "Second placement out of range";
            }
            else {
                if (result[0].Length == 2)
                {
                    if (Board[s11, s12].contains.Equals("Empty"))
                    {
                        print = ("-Tried to move piece at " + result[0][0] + result[0][1] + " to " + result[1][0] + result[1][1] + " but it was empty");
                    }
                    else
                    {
                        print = ("-moved the " + Board[s11, s12].contains + " at " + result[0][0] + result[0][1] + " to " + result[1][0] + result[1][1]);
                        Board[s21, s22].contains = Board[s11, s12].contains;
                        Board[s11, s12].contains = "Empty";
                    }
                }
                else if (result[0][2].Equals('*'))
                {
                    if (Board[s11, s12].contains.Equals("Empty"))
                    {
                        print = ("-Tried to move piece at " + result[0][0] + result[0][1] + " to take piece at " + result[1][0] + result[1][1] + " but it was empty");
                    }
                    else if (Board[s11, s12].contains.Equals("Empty"))
                    {
                        print = ("-moved the " + Board[s11, s12].contains + " at " + result[0][0] + result[0][1] + " to try to take the piece at" + result[1][0] + result[1][1] + "But it was empty");
                        Board[s21, s22].contains = Board[s11, s12].contains;
                        Board[s11, s12].contains = "Empty";
                    }
                    else
                    {
                        print = ("-moved the " + Board[s11, s12].contains + " at " + result[0][0] + result[0][1] + " to " + result[1][0] + result[1][1] + " and took the " + Board[s21, s22].contains);
                        Board[s21, s22].contains = Board[s11, s12].contains;
                        Board[s11, s12].contains = "Empty";
                    }
                }
                else
                {
                    print = ("Invalid 3 charater on movement");
                }
            }
                return print;
        }
        public bool testrange(int i1,int i2)
        {
            bool outofrange = false;
            if (i1 > arrayrange || i2 > arrayrange || i1 < 0 || i2 < 0)
            {
                outofrange = true;
            }
            return outofrange;
        }
    }
}
