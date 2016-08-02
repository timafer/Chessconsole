using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
     static class prossess
    {
        public static bool testrange(int i1, int i2)
        {
            bool outofrange = false;
            if (i1 > arrayrange || i2 > arrayrange || i1 < 0 || i2 < 0)
            {
                outofrange = true;
            }
            return outofrange;
        }
        public static string processplace(string line)
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
                    result += "King";
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
        public static string prossesmove(string[] result)
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
    }
}
