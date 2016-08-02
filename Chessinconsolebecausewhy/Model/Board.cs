using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Board
    {
        public BoardSquare[,] board = new BoardSquare[8, 8];
        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    board[o, i] = new BoardSquare(true,null);
                }
            }
        }
        public string Piecename(int x,int y)
        {
            string name = "";
            if (x < 8 && y < 8)
            {
                if (board[x, y].piece == null)
                {
                    name = "ERROR";
                }
                else
                {
                    name = board[x, y].piece.name;
                }
            }
            return name;
        }
        public string Piececolor(int x, int y)
        {
            string iswhite="ERROR";
            if (x<8&&y<8)
            {
                if (board[x, y].piece != null)
                {
                    if (board[x, y].iswhite)
                    {
                        iswhite = "White";
                    }
                    else
                    {
                        iswhite = "Black";
                    }
                } }
            return iswhite;
        }
        public bool place(int x,int y,bool iswhite,string piece)
        {
            bool success = false;
            if (board[x,y].piece==null)
            {
                switch (piece)
                {
                    case "King":
                        board[x, y].piece = new King();
                        success = true;
                        break;
                    case "Queen":
                        board[x, y].piece = new Queen();
                        success = true;
                        break;
                    case "Bishop":
                        board[x, y].piece = new Bishop();
                        success = true;
                        break;
                    case "Knight":
                        board[x, y].piece = new Knight();
                        success = true;
                        break;
                    case "Rook":
                        board[x, y].piece = new Rook();
                        success = true;
                        break;
                    case "Pawn":
                        board[x, y].piece = new Pawn();
                        success = true;
                        break;
                    default:
                        break;
                }
                board[x, y].iswhite = iswhite;
            }
            return success;
        }
        public bool move(int x1,int y1,int x2,int y2)
        {
            bool success = false;
            if (board[x2, y2].piece == null && board[x1, y1].piece != null && board[x1, y1].piece.movement(x1, x2, y1, y2))
            {
                board[x2, y2].piece = board[x1, y1].piece;
                board[x2, y2].iswhite = board[x1, y1].iswhite;
                board[x2, y2].piece.hasmoved = true;
                board[x1, y1].piece=null;
                success = true;
            }
            //if (success)
            //{
            //    print();
            //}
            return success;

        }
        public bool capture(int x1, int y1, int x2, int y2)
        {
            bool success = false;
            if (board[x2, y2].piece != null && board[x1, y1].piece != null && board[x1, y1].piece.movement(x1,x2,y1,y2))
            {
                board[x2, y2].piece = board[x1, y1].piece;
                board[x2, y2].iswhite = board[x1, y1].iswhite;
                board[x2, y2].piece.hasmoved = true;
                board[x1, y1].piece = null;
                success = true;
            }
            //if (success)
            //{
            //    print();
            //}
            return success;

        }
        public bool castle(int x1, int y1, int x2, int y2,int x3,int y3,int x4,int y4)
        {
            bool success = false;
            if (board[x2, y2].piece == null && board[x1, y1].piece != null && board[x4, y4].piece == null && board[x3, y3].piece != null)
            {
                board[x2, y2].piece = board[x1, y1].piece;
                board[x2, y2].iswhite = board[x1, y1].iswhite;
                board[x2, y2].piece.hasmoved = true;
                board[x1, y1].piece = null;
                board[x4, y4].piece = board[x3, y3].piece;
                board[x4, y4].iswhite = board[x3, y3].iswhite;
                board[x4, y4].piece.hasmoved = true;
                board[x3, y3].piece = null;
                success = true;
            }
            //if (success)
            //{
            //    print();
            //}
            return success;
        }
        public void print()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board[x, y].piece==null)
                    {
                        Console.Write(" --");
                    }
                    else
                    {
                        if (board[x,y].piece.name.Equals("Knight"))
                        {
                            if (board[x,y].iswhite)
                            {
                                Console.Write(" WN");
                            }
                            else
                            {
                                Console.Write(" BN");
                            }
                        }
                        else
                        {
                            if (board[x, y].iswhite)
                            {
                                Console.Write(" W"+board[x,y].piece.name[0]);
                            }
                            else
                            {
                                Console.Write(" B"+board[x,y].piece.name[0]);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

