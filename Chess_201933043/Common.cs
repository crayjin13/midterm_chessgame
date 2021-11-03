using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    public class Coordinate //보드판 좌표, 피스 좌표 
    {
        public byte X { get; set; }
        public byte Y { get; set; }

        public Coordinate()
        {
            X = 0;
            Y = 0;
        }
        
        public Coordinate(byte _X, byte _Y)
        {
            this.X = _X;
            this.Y = _Y;
        }

    }
    public abstract class CommonProperties
    {
        public bool IsWhite { get; set; } //흰색피스 = true 
        public bool didMove { get; set; } //피스 움직임. 
        public byte didMoveHelper { get; set; } // 무브 카운트 
        public Coordinate Current = new Coordinate(); //피스(기물) 최근 위치 
        public static bool whoseturn = true;  // 누구차례냐 , true = white 
        public byte piecenum; // 똑같이 생긴 피스중 어떤 피스 
        public static bool drawHelper; 
        public static bool reverserhelper; 
        public static Coordinate reversercoord = new Coordinate(); 
        public static byte reversedPiece; 
        public static bool isEmpty; //빈칸인지 확인 
        public byte enPassantchecker { get; set; } 
        //앙파상: 쫄병들 특수기술로 상대 쫄병이 두칸 점프했을떄 내피스가 상대피스 바로 옆에 있으면 대각선으로 이동하면서 먹을수 있는 내 최애 기술 
        public static byte enPassantfinder { get; set; }
        public static bool didEnpassantmove { get; set; }
        public void Move(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            if (!(whoseturn ^ _Game.Chessboard[Current.X, Current.Y].IsWhite))   
            {  // 여기서 ^ 연산자는 양쪽 결과가 같지 않으면 연산자 != 과 같은 결과를 컴퓨팅함 !
                //(true ^ true);    // output: False  ==> 화이트 컬러 이거나 
                //(false ^ false);  // output: False  ==> 블랙컬러일때 
                // (true ^ false);   // output: True
                //(false ^ true);   // output: True
                whoseturn = !whoseturn;  //  (디폴트값 =  True) 다음사람 턴으로 변경하는거임 
                _Game.Chessboard[_Current.X, _Current.Y].didMove = true;  //  움직임 확인 저장.
    // Gameboard 클래스 안에는 CommonProperties class 배열을 만들어놨고 그 배열의 변수가 Chessboard임 
                _Game.Chessboard[_Current.X, _Current.Y].didMoveHelper++; //움직임 카운트 증가 

                if (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty"))  // 움직이려고 하는곳이 빈칸일때
                {
                    isEmpty = true;
                }
                else if (!(_Game.Chessboard[_Next.X, _Next.Y].IsWhite)) // 움직이려고하는 위치에 검정피스 있을때 
                {
                    isEmpty = false;


                    for (byte i = 0; i < _Game.Black.Count; i++)
                    {
                        if (_Game.Chessboard[_Next.X, _Next.Y] == _Game.Black[i])
                        {
                            reversedPiece = i; 
                            break;
                        }
                    }
                    reverserhelper = true;
                    reversercoord.X = _Game.Chessboard[_Next.X, _Next.Y].Current.X;
                    reversercoord.Y = _Game.Chessboard[_Next.X, _Next.Y].Current.Y;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = 99; 
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = 99;
                }
                else // 움직이려는 위치에 화이트 피스 있을때 
                {
                    isEmpty = false;

                    for (byte i = 0; i < _Game.White.Count; i++)
                    {
                        if (_Game.Chessboard[_Next.X, _Next.Y] == _Game.White[i])
                        {

                            reversedPiece = i;
                            break;
                        }
                    }
                    reverserhelper = true;
                    reversercoord.X = _Game.Chessboard[_Next.X, _Next.Y].Current.X;
                    reversercoord.Y = _Game.Chessboard[_Next.X, _Next.Y].Current.Y;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = 99;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = 99;
                }

                _Game.Chessboard[_Next.X, _Next.Y] = _Game.Chessboard[_Current.X, _Current.Y];
                _Game.Chessboard[Current.X, Current.Y] = _Emptyspace;
                _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
                _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
                drawHelper = true;

                if (CommonProperties.didEnpassantmove) //앙파상 !! 많이 쓸일 없지만 내 최애 기능
                {
                    if (_Game.Chessboard[_Next.X, _Next.Y].IsWhite)
                    {
                        _Game.Chessboard[_Next.X - 1, _Next.Y] = _Emptyspace;
                    }
                    else
                    {
                        _Game.Chessboard[_Next.X + 1, _Next.Y] = _Emptyspace;
                    }
                }
            }
        }

        //여기 밑으론 아직 작동안됨

        public void Rookmover1(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            _Game.Chessboard[_Next.X, _Next.Y] = _Game.Chessboard[_Current.X, _Current.Y];
            _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
            _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;

            _Game.Chessboard[_Current.X, _Current.Y] = _Emptyspace;
            _Game.Chessboard[_Current.X, 5] = _Game.Chessboard[_Current.X, 7];
            _Game.Chessboard[_Current.X, 5].Current.Y = 5;
            _Game.Chessboard[_Current.X, 7] = _Emptyspace;
            _Game.Chessboard[_Current.X, 5].didMove = true;
            _Game.Chessboard[_Next.X, _Next.Y].didMove = true;
            if (_Game.Chessboard[Current.X, Current.Y].IsWhite)
            {
                whoseturn = false;
            }
            else whoseturn = true;
        }

        public void Rookmover2(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            _Game.Chessboard[_Next.X, _Next.Y] = _Game.Chessboard[_Current.X, _Current.Y];
            _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
            _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
            _Game.Chessboard[_Current.X, _Current.Y] = _Emptyspace;
            _Game.Chessboard[_Current.X, 3] = _Game.Chessboard[_Current.X, 0];
            _Game.Chessboard[_Current.X, 3].Current.Y = 3;
            _Game.Chessboard[_Current.X, 0] = _Emptyspace;
            _Game.Chessboard[_Current.X, 3].didMove = true;
            _Game.Chessboard[_Next.X, _Next.Y].didMove = true;
            if (_Game.Chessboard[Current.X, Current.Y].IsWhite)
            {
                whoseturn = false;
            }
            else whoseturn = true;
        }

    }
}
