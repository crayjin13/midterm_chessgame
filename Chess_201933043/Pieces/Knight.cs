using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess
{
    public class Knight : CommonProperties
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
            sbyte distanceX = (sbyte)Math.Abs(Current.X - _Next.X);
            sbyte distanceY = (sbyte)Math.Abs(Current.Y - _Next.Y);
            float distance = distanceX * distanceX + distanceY * distanceY;

            if ((distance == 2 * 2 + 1) && foeTester)
            {
                return true;
            }

            return false;
        }

        public Knight(string color, byte _piecenum)
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

        public Knight(string color)
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

        public Knight(string color, byte X, byte Y)
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
