using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Queen : CommonProperties
    {


        public bool isMovable(GameBoard _Game, Coordinate _Next)
        {

            bool foechecker;
            bool foeTester;
            if (IsWhite)
            {
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
            sbyte coordX = (sbyte)(_Next.X - Current.X);
            sbyte coordY = (sbyte)(_Next.Y - Current.Y);
            if (Math.Abs(coordX) == Math.Abs(coordY))
            {
                if (coordY == 0 || coordX == 0)
                {
                    return false;
                }
                sbyte incrementX = (sbyte)(coordX / Math.Abs(coordX));
                sbyte incrementY = (sbyte)(coordY / Math.Abs(coordY));

                sbyte incrementXX = incrementX;
                sbyte incrementYY = incrementY;

                byte movablecount = 0;

                for (; ((Math.Abs(incrementX) < Math.Abs(coordX)) && (Math.Abs(incrementY) < Math.Abs(coordY))); incrementX += incrementXX, incrementY += incrementYY)
                {
                    if (_Game.Chessboard[Current.X + incrementX, Current.Y + incrementY].GetType().ToString().Contains("Empty"))
                    {
                        movablecount++;
                    }
                }
                if ((Math.Abs(coordX) == Math.Abs(coordY)) && foeTester && (movablecount == Math.Abs(coordX) - 1))
                {
                    return true;
                }

            }
            else if ((Current.X - _Next.X == 0))
            {
                if (coordY == 0)
                {
                    return false;
                }
                sbyte incrementY = (sbyte)(coordY / Math.Abs(coordY));

                sbyte incrementYY = incrementY;

                byte movablecount = 0;

                for (; (Math.Abs(incrementY) < Math.Abs(coordY)); incrementY += incrementYY)
                {
                    if (_Game.Chessboard[Current.X, Current.Y + incrementY].GetType().ToString().Contains("Empty"))
                    {
                        movablecount++;
                    }
                }
                if (foeTester && (movablecount == Math.Abs(coordY) - 1))
                {
                    return true;
                }


            }
            else if ((Current.Y - _Next.Y == 0))
            {
                if (coordX == 0)
                {
                    return false;
                }
                sbyte incrementX = (sbyte)(coordX / Math.Abs(coordX));
                sbyte incrementXX = incrementX;

                byte movablecount = 0;

                for (; (Math.Abs(incrementX) < Math.Abs(coordX)); incrementX += incrementXX)
                {
                    if (_Game.Chessboard[Current.X + incrementX, Current.Y].GetType().ToString().Contains("Empty"))
                    {
                        movablecount++;
                    }
                }
                if (foeTester && (movablecount == Math.Abs(coordX) - 1))
                {
                    return true;

                }
            }

            return false;
        }

        public Queen(string color)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = 0;
            Current.Y = 0;
            didMove = false;
            didMoveHelper = 0;

        }
        public Queen(string color, byte _piecenum)
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
        public Queen(string color, byte X, byte Y)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = X;
            Current.Y = Y;
            didMove = false;
            didMoveHelper = 0;

        }
    }
}
