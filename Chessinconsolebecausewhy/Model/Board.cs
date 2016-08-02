﻿using System;
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
            if (board[x,y].piece==null)
            {
                name = "ERROR";
            }
            else
            {
                name = board[x, y].piece.name;
            }
            return name;
        }
        public bool Piececolor(int x, int y)
        {
            bool iswhite=false;
            if (board[x, y].piece == null)
            {
            }
            else
            {
                iswhite = board[x, y].iswhite;
            }
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
                        board[x, y].piece = new Pawn(); success = true;
                        success = true;
                        break;
                    default:
                        break;
                }
                board[x, y].iswhite = iswhite;
            }
            return success;
        }
        public bool move(int x1,int x2,int y1,int y2)
        {
            bool success = false;
            if (board[x2, y2].piece == null&& board[x1, y1].piece != null&& board[x1, y1].piece.movement)
            {
                board[x2, y2].piece = board[x1, y1].piece;
                board[x2, y2].iswhite = board[x1, y1].iswhite;
                board[x1, y1].piece=null;
            }
            return success;

        }
        public bool capture(int x1,int x2, int y1, int y2)
        {
            bool success = false;
            if (board[x2, y2].piece != null && board[x1, y1].piece != null && board[x1, y1].piece.movement)
            {
                board[x2, y2].piece = board[x1, y1].piece;
                board[x2, y2].iswhite = board[x1, y1].iswhite;
                board[x1, y1].piece = null;
            }
            return success;

        }
        public bool castle(int x1, int x2, int y1, int y2)
        {
            bool success = false;
            if (board[x2, y2].piece != null && board[x1, y1].piece != null && board[x2, y2].piece.movement)
            {
                Piece tempp = board[x2, y2].piece;
                bool tempc = board[x2, y2].iswhite;
                board[x2, y2].piece = board[x1, y1].piece;
                board[x2, y2].iswhite = board[x1, y1].iswhite;
                board[x1, y1].piece = tempp;
                board[x1, y1].iswhite = tempc;
            }
            return success;
        }
        public void print()
        {
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
                                Console.Write("BN");
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
                                Console.Write(" B"+board[x, y].piece.name[0]);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }

    }
}