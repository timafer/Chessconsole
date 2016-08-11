using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinconsolebecausewhy.Model
{
    class Board
    {
        public bool iswhiteturn=true;
        public BoardSquare[,] board = new BoardSquare[8, 8];
        public Board()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    board[i, o] = new BoardSquare(true, null);
                    board[i, o].x = i;
                    board[i, o].y = o;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    if (i == 0 || i == 7)
                    {
                        placeends(o, i);
                    }
                }
            }
        }
        public void placeends(int i, int o)
        {
            bool b;
            if (o == 0)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            switch (i)
            {
                case 0:
                    place(i, o, b, "Rook");
                    break;
                case 1:
                    place(i, o, b, "Knight");
                    break;
                case 2:
                    place(i, o, b, "Bishop");
                    break;
                case 3:
                    place(i, o, b, "Queen");
                    break;
                case 4:
                    place(i, o, b, "King");
                    break;
                case 5:
                    place(i, o, b, "Bishop");
                    break;
                case 6:
                    place(i, o, b, "Knight");
                    break;
                case 7:
                    place(i, o, b, "Rook");
                    break;

            }
        }
        public string Piecename(int x, int y)
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
            string iswhite = "ERROR";
            if (x < 8 && y < 8)
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
                }
            }
            return iswhite;
        }
        public void updatecanbehit()
        {
            for (int x1 = 0; x1 < 8; x1++)
            {
                for (int y1 = 0; y1 < 8; y1++)
                {
                    if (board[x1, y1].piece != null)
                    {
                        if (board[x1, y1].piece.name == "Bishop" || board[x1, y1].piece.name == "Queen")
                        {
                            for (int x2 = 1; x2 < 7; x2++)
                            {
                                if (x1 + x2 > 7 || y1 + x2 > 7) { }
                                else if (checkpath(x1, y1, x1 + x2, y1 + x2))
                                {
                                    if (board[x1 + x2, y1 + x2].piece != null)
                                    {
                                        if (board[x1 + x2, y1 + x2].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 + x2, y1 + x2].canbehit = true;
                                            check(board[x1 + x2, y1 + x2]);
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                if (x1 - x2 < 0 || y1 + x2 > 7) { }
                                else if (checkpath(x1, y1, x1 - x2, y1 + x2))
                                {
                                    if (board[x1 - x2, y1 + x2].piece != null)
                                    {
                                        if (board[x1 - x2, y1 + x2].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 - x2, y1 + x2].canbehit = true;
                                            check(board[x1 - x2, y1 + x2]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1 - x2, y1 + x2].canbehit = true;
                                    }
                                   
                                }
                                if (x1 + x2 > 7 || y1 - x2 < 0) { }
                                else if (checkpath(x1, y1, x1 + x2, y1 - x2))
                                {
                                    if (board[x1 + x2, y1 - x2].piece != null)
                                    {
                                        if (board[x1 + x2, y1 - x2].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 + x2, y1 - x2].canbehit = true;
                                            check(board[x1 + x2, y1 - x2]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1 + x2, y1 - x2].canbehit = true;
                                    }
                                    
                                    
                                }
                                if (x1 - x2 < 0 || y1 - x2 < 0) { }
                                else if (checkpath(x1, y1, x1 - x2, y1 - x2))
                                    if (board[x1 - x2, y1 - x2].piece != null)
                                    {
                                        if (board[x1 - x2, y1 - x2].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 - x2, y1 - x2].canbehit = true;
                                            check(board[x1 - x2, y1 - x2]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1 - x2, y1 - x2].canbehit = true;
                                    }
                            }
                        }
                        if (board[x1, y1].piece.name == "Rook" || board[x1, y1].piece.name == "Queen")
                        {
                            for (int x2 = 1; x2 < 7; x2++)
                            {
                                if (x1 + x2 > 7) { }
                                else if (checkpath(x1, y1, x1 + x2, y1))
                                {
                                    if (board[x1 + x2, y1].piece != null)
                                    {
                                        if (board[x1 + x2, y1].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 + x2, y1 ].canbehit = true;
                                            check(board[x1 + x2, y1]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1 + x2, y1].canbehit = true;
                                    }
                                 }
                                if (x1 - x2 < 0) { }
                                else if (checkpath(x1, y1, x1 - x2, y1))
                                {
                                    if (board[x1 - x2, y1].piece != null)
                                    {
                                        if (board[x1 - x2, y1].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 - x2, y1].canbehit = true;
                                            check(board[x1 - x2, y1]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1 - x2, y1].canbehit = true;
                                    }
                                }
                                if (y1 - x2 < 0) { }
                                else if (checkpath(x1, y1, x1, y1 - x2))
                                {
                                    if (board[x1, y1 - x2].piece != null)
                                    {
                                        if (board[x1 , y1 - x2].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 , y1 - x2].canbehit = true;
                                            check(board[x1, y1 -x2]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1, y1 - x2].canbehit = true;
                                    }
                                }
                                if (y1 + x2 > 7) { }
                                else if (checkpath(x1, y1, x1, y1 + x2))
                                {
                                    if (board[x1 , y1 + x2].piece != null)
                                    {
                                        if (board[x1 , y1 + x2].iswhite != board[x1, y1].iswhite)
                                        {
                                            board[x1 , y1 + x2].canbehit = true;
                                            check(board[x1 , y1 + x2]);
                                        }
                                    }
                                    else
                                    {
                                        board[x1, y1 + x2].canbehit = true;
                                    }
                                }
                            }
                        }
                        if (board[x1, y1].piece.name == "Knight")
                        { 
                            if (x1 + 1 > 7|| y1 + 2 > 7) { }
                            else if (checkpath(x1, y1, x1 + 1, y1+2))
                            {
                                if (board[x1 + 1, y1+2].piece != null)
                                {
                                    if (board[x1 + 1, y1+2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 1, y1+2].canbehit = true;
                                        check(board[x1 + 1, y1+2]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 1, y1+2].canbehit = true;
                                }
                            }
                            if (x1 + 1 > 7 || y1 - 2 < 0) { }
                            else if (checkpath(x1, y1, x1 + 1, y1 -2))
                            {
                                if (board[x1 + 1, y1 - 2].piece != null)
                                {
                                    if (board[x1 + 1, y1 - 2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 1, y1 - 2].canbehit = true;
                                        check(board[x1 + 1, y1 - 2]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 1, y1 - 2].canbehit = true;
                                }
                            }
                            if (x1 - 1 < 0 || y1 + 2 > 7) { }
                            else if (checkpath(x1, y1, x1 - 1, y1 + 2))
                            {
                                if (board[x1 - 1, y1 + 2].piece != null)
                                {
                                    if (board[x1 - 1, y1 + 2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 - 1, y1 + 2].canbehit = true;
                                        check(board[x1 - 1, y1 + 2]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 1, y1 + 2].canbehit = true;
                                }
                            }
                            if (x1 - 1 <0 || y1 - 2 <0) { }
                            else if (checkpath(x1, y1, x1 - 1, y1 - 2))
                            {
                                if (board[x1 - 1, y1 - 2].piece != null)
                                {
                                    if (board[x1 - 1, y1 - 2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 - 1, y1 - 2].canbehit = true;
                                        check(board[x1 - 1, y1 - 2]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 1, y1 - 2].canbehit = true;
                                }
                            }
                            if (x1 + 2 > 7 || y1 + 1 > 7) { }
                            else if (checkpath(x1, y1, x1 + 2, y1 + 1))
                            {
                                if (board[x1 + 2, y1 + 1].piece != null)
                                {
                                    if (board[x1 + 2, y1 + 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 2, y1 + 1].canbehit = true;
                                        check(board[x1 + 2, y1 + 1]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 2, y1 + 1].canbehit = true;
                                }
                            }
                            if (x1 + 2 > 7 || y1 - 1 < 0) { }
                            else if (checkpath(x1, y1, x1 + 2, y1 - 1))
                            {
                                if (board[x1 + 2, y1 - 1].piece != null)
                                {
                                    if (board[x1 + 2, y1 - 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 2, y1 - 1].canbehit = true;
                                        check(board[x1 + 2, y1 - 1]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 2, y1 - 1].canbehit = true;
                                }
                            }
                            if (x1 - 2 < 0 || y1 + 1 > 7) { }
                            else if (checkpath(x1, y1, x1 - 2, y1 + 2))
                            {
                                if (board[x1 - 2, y1 + 1].piece != null)
                                {
                                    if (board[x1 - 2, y1 + 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 - 2, y1 + 1].canbehit = true;
                                        check(board[x1 - 2, y1 + 1]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 2, y1 + 1].canbehit = true;
                                }
                            }
                            if (x1 - 2 < 0 || y1 - 1 < 0) { }
                            else if (checkpath(x1, y1, x1 - 2, y1 - 1))
                            {
                                if (board[x1 - 2, y1 - 1].piece != null)
                                {
                                    if (board[x1 - 2, y1 - 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 - 2, y1 - 1].canbehit = true;
                                        check(board[x1 - 1, y1 - 2]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 2, y1 - 1].canbehit = true;
                                }
                            }

                        }
                        if (board[x1, y1].piece.name == "King")
                        {
                            if (x1 + 1 > 7) { }
                            else if (checkpath(x1, y1, x1 + 1, y1))
                            {
                                if (board[x1 + 1, y1 ].piece != null)
                                {
                                    if (board[x1 + 1, y1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 1, y1].canbehit = true;
                                        check(board[x1 + 1, y1]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 1, y1].canbehit = true;
                                }
                            }
                            if (x1 - 1 < 0) { }
                            else if (checkpath(x1, y1, x1 - 1, y1))
                            {
                                if (board[x1 - 1, y1].piece != null)
                                {
                                    if (board[x1 -1, y1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 -1, y1 ].canbehit = true;
                                        check(board[x1 -1, y1 ]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 1, y1].canbehit = true;
                                }
                            }
                            if (y1 - 1 < 0) { }
                            else if (checkpath(x1, y1, x1, y1 - 1))
                            {
                                if (board[x1 , y1 -1].piece != null)
                                {
                                    if (board[x1, y1 -1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1, y1 -1].canbehit = true;
                                        check(board[x1, y1 -1]);
                                    }
                                }
                                else
                                {
                                    board[x1, y1 - 1].canbehit = true;
                                }
                            }
                            if (y1 + 1 > 7) { }
                            else if (checkpath(x1, y1, x1, y1 + 1))
                            {
                                if (board[x1 , y1 + 1].piece != null)
                                {
                                    if (board[x1, y1 + 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1, y1 + 1].canbehit = true;
                                        check(board[x1 , y1 + 1]);
                                    }
                                }
                                else
                                {
                                    board[x1, y1 + 1].canbehit = true;
                                }
                            }
                            if (x1 + 1 > 7 || y1 + 1 > 7) { }
                            else if (checkpath(x1, y1, x1 + 1, y1 + 1))
                            {
                                if (board[x1 + 1, y1 + 1].piece != null)
                                {
                                    if (board[x1 + 1, y1 + 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 1, y1 + 1].canbehit = true;
                                        check(board[x1 + 1, y1 + 1]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 1, y1 + 1].canbehit = true;
                                }
                            }
                            if (x1 - 1 < 0 || y1 + 1 > 7) { }
                            else if (checkpath(x1, y1, x1 - 1, y1 + 1))
                            {
                                if (board[x1 -1, y1 + 1].piece != null)
                                {
                                    if (board[x1 -1, y1 + 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 -1, y1 + 1].canbehit = true;
                                        check(board[x1 -1, y1 + 1]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 1, y1 + 1].canbehit = true;
                                }
                            }
                            if (x1 + 1 > 7 || y1 - 1 < 0) { }
                            else if (checkpath(x1, y1, x1 + 1, y1 - 1))
                            {
                                if (board[x1 + 1, y1 -1].piece != null)
                                {
                                    if (board[x1 + 1, y1 -1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 + 1, y1 -1].canbehit = true;
                                        check(board[x1 + 1, y1 -1]);
                                    }
                                }
                                else
                                {
                                    board[x1 + 1, y1 - 1].canbehit = true;
                                }
                            }
                            if (x1 - 1 < 0 || y1 - 1 < 0) { }
                            else if (checkpath(x1, y1, x1 - 1, y1 - 1))
                            {
                                if (board[x1 - 1, y1 - 1].piece != null)
                                {
                                    if (board[x1 - 1, y1 - 1].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1 - 1, y1 - 1].canbehit = true;
                                        check(board[x1 - 1, y1 - 1]);
                                    }
                                }
                                else
                                {
                                    board[x1 - 1, y1 - 1].canbehit = true;
                                }
                            }

                        }
                        if (board[x1, y1].piece.name == "Pawn")
                        {
                            int x2 = 1;
                            if (x1 + x2 > 7 || y1 + x2 > 7) { }
                            else if (checkpath(x1, y1, x1 - x2, y1 + x2))
                            {
                                if (board[x1 + x2, y1 + x2].piece != null)
                                {
                                    if (board[x1 + x2, y1 + x2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1, y1].piece.diagminus = true;
                                        board[x1 + x2, y1 + x2].canbehit = true;
                                        check(board[x1 + x2, y1 + x2]);
                                    }
                                }
                            }
                            else
                            {

                            }
                            if (x1 - x2 < 0 || y1 + x2 > 7) { }
                            else if (checkpath(x1, y1, x1 - x2, y1 + x2))
                            {
                                if (board[x1 - x2, y1 + x2].piece != null)
                                {
                                    if (board[x1 - x2, y1 + x2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1, y1].piece.diagplus = true;
                                        board[x1 - x2, y1 + x2].canbehit = true;
                                        check(board[x1 - x2, y1 + x2]);
                                    }
                                }
                                else
                                {
                                    board[x1 - x2, y1 + x2].canbehit = true;
                                }

                            }
                            if (x1 + x2 > 7 || y1 - x2 < 0) { }
                            else if (checkpath(x1, y1, x1 + x2, y1 - x2))
                            {
                                if (board[x1 + x2, y1 - x2].piece != null)
                                {
                                    if (board[x1 + x2, y1 - x2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1, y1].piece.diagminus = true;
                                        board[x1 + x2, y1 - x2].canbehit = true;
                                        check(board[x1 + x2, y1 - x2]);
                                    }
                                }
                                else
                                {
                                    board[x1 + x2, y1 - x2].canbehit = true;
                                }
                            }
                            if (x1 - x2 < 0 || y1 - x2 < 0) { }
                            else if (checkpath(x1, y1, x1 - x2, y1 - x2))
                                if (board[x1 - x2, y1 - x2].piece != null)
                                {
                                    if (board[x1 - x2, y1 - x2].iswhite != board[x1, y1].iswhite)
                                    {
                                        board[x1, y1].piece.diagplus = true;
                                        board[x1 - x2, y1 - x2].canbehit = true;
                                        check(board[x1 - x2, y1 - x2]);
                                    }
                                }
                                else
                                {
                                    board[x1 - x2, y1 - x2].canbehit = true;
                                }
                        }
                        //foreach (BoardSquare s2 in board)
                        //{
                        //    if (s1.piece.movement(s1.x, s2.x, s1.y, s2.y))
                        //    {
                        //        if (checkpath(s1.x, s1.y, s2.x, s2.y))
                        //        {
                        //            s2.canbehit = true;
                        //            if (s2.piece != null)
                        //            {
                        //                if (s2.piece.name == "King" && s1.iswhite != s2.iswhite)
                        //                {
                        //                    Console.WriteLine("Check");
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }
        public void check(BoardSquare s)
        {
            if (s.piece != null)
            {
                if (s.piece.name == "King")
                {
                    Console.WriteLine("Check");
                }
            }

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
                        board[x, y].piece = new Pawn(iswhite);
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
                if (checkpath(x1, y1, x2, y2)||board[x1,y1].piece is Knight)
                {
                    if (iswhiteturn != board[x1, y1].iswhite)
                    {
                        board[x2, y2].piece = board[x1, y1].piece;
                        board[x2, y2].iswhite = board[x1, y1].iswhite;
                        board[x2, y2].piece.hasmoved = true;
                        board[x1, y1].piece = null;
                        success = true;
                        if (iswhiteturn)
                        {
                            iswhiteturn = false;
                        }
                        else
                        {
                            iswhiteturn = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not your turn");
                    }
                }
            }
            if (success)
            {
                updatecanbehit();
                print();
            }
            return success;

        }
        public bool capture(int x1, int y1, int x2, int y2)
        {
            bool success = false;
            if (board[x2, y2].piece != null && board[x1, y1].piece != null && board[x1, y1].piece.movement(x1,x2,y1,y2))
            {
                if ((checkpath(x1, y1, x2, y2) || board[x1, y1].piece is Knight)&&(board[x1,y1].iswhite!=board[x2,y2].iswhite))
                {
                    if (iswhiteturn != board[x1, y1].iswhite)
                    {
                        board[x2, y2].piece = board[x1, y1].piece;
                        board[x2, y2].iswhite = board[x1, y1].iswhite;
                        board[x2, y2].piece.hasmoved = true;
                        board[x1, y1].piece = null;
                        success = true;
                        if (iswhiteturn)
                        {
                            iswhiteturn = false;
                        }
                        else
                        {
                            iswhiteturn = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not your turn");
                    }
                }
                else
                {
                    Console.WriteLine("Are trying to take your own piece?");
                }
            }
            if (success)
            {
                updatecanbehit();
                print();
            }
            return success;

        }
        public bool castle(int x1, int y1, int x2, int y2,int x3,int y3,int x4,int y4)
        {
            bool success = false;
            if (board[x2, y2].piece == null && board[x1, y1].piece != null && board[x4, y4].piece == null && board[x3, y3].piece != null)
            {
                if (checkpath(x1, y1, x2, y2) || board[x1, y1].piece is Knight)
                {
                    if (iswhiteturn != board[x1, y1].iswhite)
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
                        if (iswhiteturn)
                        {
                            iswhiteturn = false;
                        }
                        else
                        {
                            iswhiteturn = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not your turn");
                    }
                }
            }
            if (success)
            {
                updatecanbehit();
                print();
            }
            return success;
        }
        bool checkpath(int x1, int y1, int x2, int y2)
        {
            bool success = true;
            if (y1 == y2 && x1 < x2)
            {
                for (int i = x1+1; i<x2; i++)
                {
                    if (board[i,y1].piece!=null)
                    {
                        success = false;
                    }
                }
            }
            else if (y1 == y2 && x1 > x2)
            {
                for (int i = x1-1; i > x2; i--)
                {
                    if (board[i, y1].piece != null)
                    {
                        success = false;
                    }
                }
            }
            else if (x1 == x2 && y1 < y2)
            {
                for (int i = y1+1; i < y2; i++)
                {
                    if (board[x1, i].piece != null)
                    {
                        success = false;
                    }
                }
            }
            else if (x1 == x2 && y1 > y2)
            {
                for (int i = y1-1; i > y2; i--)
                {
                    if (board[x1, i].piece != null)
                    {
                        success = false;
                    }
                }
            }
            else if(y1 > y2&& x1 > x2)
            { 
                for (int i = -1; y1+i > y2; i--)
                {
                    if (board[x1+i, y1+i].piece != null)
                    {
                        success = false;
                    }
                }
            }
            else if (y1 < y2 && x1 < x2)
            {
                for (int i = 1; y1+i < y2; i++)
                {
                    if (board[x1+i, y1+i].piece != null)
                    {
                        success = false;
                    }
                }
            }
            else if (y1 > y2 && x1 < x2)
            {
                for (int i = 1; x1+i < x2; i++)
                {
                    if (board[x1+i, y1-i].piece != null)
                    {
                        success = false;
                    }
                }
            }
            else
            {
                for (int i = 1; y1+i > y2; i++)
                {
                    if (x1 - i < 0 || y1 + i > 7)
                    {
                        success = false;
                    }
                    else if (board[x1-i, y1+i].piece != null)
                    {
                        success = false;
                    }
                }
            }
                return success;
        }

        public void print()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
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

