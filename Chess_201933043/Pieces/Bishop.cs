using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Bishop : CommonProperties
    {


        public bool isMovable(GameBoard _Game, Coordinate _Next)
        {

            bool foechecker;
            bool foeTester;
            if (IsWhite) //흰색피스 턴일떄 
            {
                if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty"))) 
                    //빈공간 아니라면 
                {
                    foechecker = !(_Game.Chessboard[_Next.X, _Next.Y].IsWhite); // 같은 흰색 피스로 못움직임, 검정피스만 먹을수있음  검정피스 = foechecker true;
                    foeTester = (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty") || foechecker);   //비어있거나, 검은색피스있는위치면 true
                                                                                                                           
                }
                else 
                {
                    //흰색턴인데 움직이려는 칸 빈공간이면 비솝원래자리 좌표가져와서 비었다고 표시해줌 
                    foeTester = _Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty");
                }
            }
            else //블랙피스 턴일때
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
            if ((coordY == 0 || coordX == 0) || !(Math.Abs(coordX) == Math.Abs(coordY)))
            {
                return false;
            }
            sbyte incrementX = (sbyte)(coordX / Math.Abs(coordX));
            sbyte incrementY = (sbyte)(coordY / Math.Abs(coordY));

            sbyte incrementXX = incrementX;
            sbyte incrementYY = incrementY;

            byte movablecount = 0;

            // 범위를 모르는 경우 그냥 선언부와 증감식을 제거하고 for(;조건;)만 적으면 됨 그럼 while문처럼 쓰여짐 
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

            return false;
        }

        public Bishop(string color, byte _piecenum) //블랙인지 화이트인지 구분하고 비솝2개씩있어서 1,2 피스넘버로 구분하기위해 2개의 파라미터 적용
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

        public Bishop(string color)
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

        public Bishop(string color, byte X, byte Y)  // 움직인 좌표값 넣어줌 
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
