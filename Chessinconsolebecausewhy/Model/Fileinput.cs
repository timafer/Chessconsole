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
                if (result.Length==1)
                {
                    string piece = processplace(s);
                    Console.WriteLine("-place the "+piece+" on "+s[2]+s[3]);
                    Board[(char.ToUpper(s[2]) - 64), char.ToUpper(s[3])-48].contains = piece;
                }
                else if (result.Length==2)
                {
                    Console.WriteLine("-moved the "+Board[char.ToUpper(result[0][0])-65, char.ToUpper(result[0][1])-48].contains +" at "+result[0][0]+result[0][1]+" to " + result[1][0] + result[1][1]);
                }
                else if (result.Length == 4)
                {
                    Console.WriteLine("4 hit");
                }
                else
                {
                    Console.WriteLine("Invalid line");
                }
            }
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
    }
}
