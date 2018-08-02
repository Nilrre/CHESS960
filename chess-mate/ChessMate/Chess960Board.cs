using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMate
{
    class Chess960Board : Board
    {
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
            color = "black";
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

            for (int y = 0; y < 8; y++)
            {
                int num = getRandomNumber();
                
                Position p = new Position(0, y);
                board[p] = new Piece("rook", color, p);

                p = new Position(1, y);
                board[p] = new Piece("knight", color, p);

                p = new Position(2, y);
                board[p] = new Piece("bishop", color, p);

                p = new Position(3, y);
                board[p] = new Piece("queen", color, p);

                p = new Position(4, y);
                board[p] = new Piece("king", color, p);

                p = new Position(5, y);
                board[p] = new Piece("bishop", color, p);

                p = new Position(6, y);
                board[p] = new Piece("knight", color, p);

                p = new Position(7, y);
                board[p] = new Piece("rook", color, p);

                color = "white";
            }

        }

        private int getRandomNumber()
        {
            throw new NotImplementedException();
        }
    }
}
