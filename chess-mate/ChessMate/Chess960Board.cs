using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
    class Chess960Board : Board
    {
        private List<int> usedAlready = new List<int>();
        private Random random = new Random();

        public int getUsedCount()
        {
            return usedAlready.Count;
        }

        public Chess960Board()
        {
            board = new Dictionary<Position, Piece>();

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; ++x)
                {
                    Position p = new Position(x, y);
                    board[p] = new Piece("blank", "none", p);
                }
            }

            string color = "black";
            for (int y = 1; y < 7; y += 5)
            {
                for (int x = 0; x < 8; ++x)
                {
                    Position p = new Position(x, y);
                    board[p] = new Piece("pawn", color, p);
                }
                color = "white";
            }


            //this is what needs to be changed
            Dictionary<int, string> pieceList = new Dictionary<int, string>()
            {
                { 0, "rook"},
                { 1, "knight"},
                { 2, "bishop"},
                { 3, "queen"},
                { 4, "king"},
                { 5, "bishop"},
                { 6, "knight"},
                { 7, "rook"}
            };
            string firstBishopsPlacement = "";
            for (int y = 0; y < 8; y++)
            {
                int num = getRandomNumber();
                while (usedAlready.Contains(num))
                {
                    num = getRandomNumber();
                }

                Position p = new Position(y, 7);
                Position p2 = new Position(y, 0);
                switch (num)
                {
                    case 0:
                    case 4:
                    case 7:
                        if (usedAlready.Contains(0))
                        {
                            if (usedAlready.Contains(4))
                            {
                                board[p2] = new Piece("rook", "black", p2);
                                board[p] = new Piece("rook", "white", p);
                                usedAlready.Add(7);

                            }
                            else
                            {
                                board[p2] = new Piece("king", "black", p2);
                                board[p] = new Piece("king", "white", p);
                                usedAlready.Add(4);
                            }
                        }
                        else
                        {
                            board[p2] = new Piece("rook", "black", p2);
                            board[p] = new Piece("rook", "white", p);
                            usedAlready.Add(0);
                        }
                        break;
                    case 1:
                    case 6:
                        board[p2] = new Piece("knight", "black", p2);
                        board[p] = new Piece("knight", "white", p);
                        if (usedAlready.Contains(1))
                        {
                            usedAlready.Add(6);
                        }
                        else
                        {
                            usedAlready.Add(1);
                        }
                        break;
                    case 2:
                    case 5:
                        if (firstBishopsPlacement == "")
                        {
                            board[p2] = new Piece("bishop", "black", p2);
                            board[p] = new Piece("bishop", "white", p);
                            if (y % 2 == 0)
                            {
                                firstBishopsPlacement = "white";
                            }
                            else
                            {
                                firstBishopsPlacement = "black";
                            }
                            usedAlready.Add(2);
                        }
                        else if (firstBishopsPlacement == "white")
                        {
                            if (y % 2 == 0)
                            {
                                y = y - 1;
                            }
                            else
                            {
                                board[p2] = new Piece("bishop", "black", p2);
                                board[p] = new Piece("bishop", "white", p);
                                usedAlready.Add(5);
                            }
                        }
                        else if (firstBishopsPlacement == "black")
                        {
                            if (y % 2 == 0)
                            {
                                board[p2] = new Piece("bishop", "black", p2);
                                board[p] = new Piece("bishop", "white", p);
                                usedAlready.Add(5);
                            }
                            else
                            {
                                y = y - 1;
                            }
                        }
                        break;
                    case 3:
                        board[p2] = new Piece("queen", "black", p2);
                        board[p] = new Piece("queen", "white", p);
                        usedAlready.Add(3);
                        break;
                    default:
                        break;
                }
            }
        }

        private int getRandomNumber()
        {
            return random.Next(0, 9);
        }

    }
}
