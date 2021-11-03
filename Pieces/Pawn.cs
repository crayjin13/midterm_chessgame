using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : CommonProperties
    {

        public bool isMovable(GameBoard _Game, Coordinate _Next)
        {

            sbyte increment;
            sbyte Doublemovechecker;
            bool foechecker;
            bool foeTester;
            if (IsWhite)
            {
                increment = 1;
                Doublemovechecker = 1;
                if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")))
                {
                    foechecker = !(_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                    foeTester = (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty") || foechecker);
                }
                else
                {
                    foeTester = _Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty");
                }
            }
            else
            {
                increment = -1;
                Doublemovechecker = 6;
                if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")))
                {
                    foechecker = (_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                    foeTester = (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty") || foechecker);
                }
                else
                {
                    foeTester = _Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty");
                }
            }

            if ((Current.X + increment == _Next.X) && (Current.Y == _Next.Y) && foeTester)
            {
                return true;
            }

            else if ((Current.X == Doublemovechecker) && (Current.X + 2 * increment == _Next.X) && (Current.Y == _Next.Y) && foeTester)
            {
                if (_Game.Chessboard[Current.X + increment, Current.Y].GetType().ToString().Contains("Empty"))
                {
                    for (int i = 0; i < _Game.Black.Count; i++)
                    {
                        if (_Game.Chessboard[Current.X, Current.Y] == _Game.Black[i])
                        {
                            enPassantfinder = (byte)i;
                        }
                    }
                    for (int i = 0; i < _Game.White.Count; i++)
                    {
                        if (_Game.Chessboard[Current.X, Current.Y] == _Game.White[i])
                        {
                            enPassantfinder = (byte)i;
                        }
                    }

                    _Game.Chessboard[Current.X, Current.Y].enPassantchecker = 2;
                    return true;
                }
            }

            else if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")))
            {
                if (IsWhite)
                {
                    foechecker = !(_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                }
                else
                {
                    foechecker = (_Game.Chessboard[_Next.X, _Next.Y].IsWhite);

                }
                if ((Current.X + increment == _Next.X) && ((Current.Y + 1 == _Next.Y) || (Current.Y - 1 == _Next.Y)) && foechecker)
                {
                    return true;

                }
            }
            else if ((_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")) && (Current.X + increment == _Next.X) && ((Current.Y + 1 == _Next.Y) || (Current.Y - 1 == _Next.Y)))
            {

                if (_Game.Chessboard[Current.X, _Next.Y].enPassantchecker == 1)
                {
                    didEnpassantmove = true;
                    return true;
                }
            }
            return false;

        }

        public Pawn(string color, byte _piecenum)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = 0;
            Current.Y = 0;
            piecenum = _piecenum;
            didMove = false;
            didMoveHelper = 0;
        }

        public Pawn(string color)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = 0;
            Current.Y = 0;
            didMoveHelper = 0;
            didMove = false;
        }

        public Pawn(string color, byte X, byte Y)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = X;
            Current.Y = Y;
            didMove = false;
        }
    }
}
