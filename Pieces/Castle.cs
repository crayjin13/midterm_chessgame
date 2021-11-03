using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Castle : CommonProperties
    {

        public bool isMovable(GameBoard _Game, Coordinate _Next)
        {

            bool foechecker;
            bool foeTester;
            if (IsWhite)  //킹 클래스에서 주석 단것과 같은 원리 
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
            // 룩 행마법 
            if ((Current.X - _Next.X == 0)) //x값 변환없고 Y값만 움직일때 (가로로만 움직일때)
            {

                sbyte coordY = (sbyte)(_Next.Y - Current.Y);
                if (coordY == 0)
                {
                    return false;
                }
                sbyte incrementY = (sbyte)(coordY / Math.Abs(coordY)); 
                //Math.Abs(sbyte) = 8비트 부호 있는 정수의 절대 값을 반환 
                // Abs 의 범위는 0<= x <= 127
                sbyte incrementYY = incrementY;

                byte movablecount = 0;

                for (; (Math.Abs(incrementY) < Math.Abs(coordY)); incrementY += incrementYY)
                {// 범위를 모르는 경우 그냥 선언부와 증감식을 제거하고 for(;조건;)만 적으면 됨 그럼 while문처럼 쓰여짐 

              
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
            else if ((Current.Y - _Next.Y == 0))  // Y값 반환없고 X값만 움직일떄 ( 세로로만 움직일때)
            {
                sbyte coordX = (sbyte)(_Next.X - Current.X);
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


        public Castle(string color, byte _piecenum)
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

        public Castle(string color)
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

        public Castle(string color, byte X, byte Y)
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
