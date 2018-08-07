// <copyright file="Chess960BoardTest.cs">Copyright ©  2014</copyright>
using System;
using ChessMate;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChessMate.Tests
{
    [TestClass]
    public class Chess960Test
    {
        [TestMethod]
        public void CheckToSeeIfBoardHasBeenRandomized()
        {
            Chess960Board chess960Board;
            do
            {
                chess960Board = new Chess960Board();
            } while (chess960Board.getUsedCount() != 8);


            Board board = new Board();

            List<bool> isBoardSame = new List<bool>();
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; ++x)
                {
                    Position p = new Position(x, y);
                    isBoardSame.Add(board.at(p).Equals(chess960Board.at(p)));
                }
            }

            Assert.AreEqual(true, isBoardSame.Contains(false));
        }

        [TestMethod]
        public void AreKingsAcrossFromEachother()
        {
            Chess960Board chess960Board;
            do
            {
                chess960Board = new Chess960Board();
            } while (chess960Board.getUsedCount() != 8);


            Position whiteKing = chess960Board.findKing("white");
            Position blackKing = chess960Board.findKing("black");

            Assert.AreEqual(true, whiteKing.x == blackKing.x);
        }

        [TestMethod]
        public void IsWhiteKingBetweenWhiteRooks()
        {
            Chess960Board board;
            do
            {
                board = new Chess960Board();
            } while (board.getUsedCount() != 8);

            Position kingPosition = board.findKing("white");
            List<Position> listOfRooks = board.findRooks("white");

            Assert.AreEqual(true, kingPosition.x > listOfRooks[0].x);
            Assert.AreEqual(true, kingPosition.x < listOfRooks[1].x);
        }

        [TestMethod]
        public void AreWhiteBishopsOnDifferentColoredSquares()
        {
            Chess960Board board;
            do
            {
                board = new Chess960Board();
            } while (board.getUsedCount() != 8);

            List<Position> listOfBishops = board.findBishops("white");
            int num = (listOfBishops[0].x % 2);
            int num1 = (listOfBishops[1].x % 2);

            Assert.AreEqual(false, num == num1);
        }

        [TestMethod]
        public void AreAllWhiteSpecialPiecesThere()
        {
            Chess960Board board;
            do
            {
                board = new Chess960Board();
            } while (board.getUsedCount() != 8);

            List<Piece> list = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                list.Add(board.at(new Position(i, 7)));
            }

            Dictionary<string, int> count = new Dictionary<string, int>()
            {
                { "rook", 0},
                { "knight", 0},
                { "king", 0},
                { "queen", 0},
                { "bishop", 0},
            };

            foreach(var element in list)
            {
                count[element.getType()]++;
            }

            Assert.AreEqual(2, count["rook"]);
            Assert.AreEqual(2, count["knight"]);
            Assert.AreEqual(2, count["bishop"]);
            Assert.AreEqual(1, count["king"]);
            Assert.AreEqual(1, count["queen"]);
        }

    }
}
