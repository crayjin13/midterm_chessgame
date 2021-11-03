using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Chess
{ 
    public class GameBoard      //체스 보드판 시작
    {
        public CommonProperties[,] Chessboard = new CommonProperties[8, 8];
        //왼쪽 밑에를 [0,0] , 왼쪽 위를 [7,0] 으로  전체판을 의미 [세로, 가로] 

        public List<CommonProperties> Black = new List<CommonProperties>();
        // 블랙 피스 담을 리스트
        public List<CommonProperties> White = new List<CommonProperties>();
        // 화이트 피스 담을 리스트 

        public GameBoard()
        {
            King BlackKing = new King("BLACK");
            Queen BlackQueen = new Queen("BLACK", 1);
            Castle BlackCastle1 = new Castle("BLACK", 1);
            Castle BlackCastle2 = new Castle("BLACK", 2);
            Bishop BlackBishop1 = new Bishop("BLACK", 1);
            Bishop BlackBishop2 = new Bishop("BLACK", 2);
            Knight BlackKnight1 = new Knight("BLACK", 1);
            Knight BlackKnight2 = new Knight("BLACK", 2);
            Pawn BlackPawn1 = new Pawn("BLACK", 1);
            Pawn BlackPawn2 = new Pawn("BLACK", 2);
            Pawn BlackPawn3 = new Pawn("BLACK", 3);
            Pawn BlackPawn4 = new Pawn("BLACK", 4);
            Pawn BlackPawn5 = new Pawn("BLACK", 5);
            Pawn BlackPawn6 = new Pawn("BLACK", 6);
            Pawn BlackPawn7 = new Pawn("BLACK", 7);
            Pawn BlackPawn8 = new Pawn("BLACK", 8);
            Empty Emptyspace = new Empty();
            for (byte i = 2; i < 6; i++)  //  가운데 비어있는 체스판 세로 4줄 의미함.
            {
                for (byte j = 0; j < 8; j++) //비어있는 체스판 가로 8줄  
                {
                    Chessboard[i, j] = Emptyspace; // 비어있는 체스판이라고 배열에 값 선언해줌.
                }
            }

            Black.Add(BlackKing);
            Black.Add(BlackQueen);
            Black.Add(BlackCastle1);
            Black.Add(BlackCastle2);
            Black.Add(BlackBishop1);
            Black.Add(BlackBishop2);
            Black.Add(BlackKnight1);
            Black.Add(BlackKnight2);
            Black.Add(BlackPawn1);
            Black.Add(BlackPawn2);
            Black.Add(BlackPawn3);
            Black.Add(BlackPawn4);
            Black.Add(BlackPawn5);
            Black.Add(BlackPawn6);
            Black.Add(BlackPawn7);
            Black.Add(BlackPawn8);

            King WhiteKing = new King("WHITE");
            Queen WhiteQueen = new Queen("WHITE", 1);
            Castle WhiteCastle1 = new Castle("WHITE", 1);
            Castle WhiteCastle2 = new Castle("WHITE", 2);
            Bishop WhiteBishop1 = new Bishop("WHITE", 1);
            Bishop WhiteBishop2 = new Bishop("WHITE", 2);
            Knight WhiteKnight1 = new Knight("WHITE", 1);
            Knight WhiteKnight2 = new Knight("WHITE", 2);
            Pawn WhitePawn1 = new Pawn("WHITE", 1);
            Pawn WhitePawn2 = new Pawn("WHITE", 2);
            Pawn WhitePawn3 = new Pawn("WHITE", 3);
            Pawn WhitePawn4 = new Pawn("WHITE", 4);
            Pawn WhitePawn5 = new Pawn("WHITE", 5);
            Pawn WhitePawn6 = new Pawn("WHITE", 6);
            Pawn WhitePawn7 = new Pawn("WHITE", 7);
            Pawn WhitePawn8 = new Pawn("WHITE", 8);
            White.Add(WhiteKing);
            White.Add(WhiteQueen);
            White.Add(WhiteCastle1);
            White.Add(WhiteCastle2);
            White.Add(WhiteBishop1);
            White.Add(WhiteBishop2);
            White.Add(WhiteKnight1);
            White.Add(WhiteKnight2);
            White.Add(WhitePawn1);
            White.Add(WhitePawn2);
            White.Add(WhitePawn3);
            White.Add(WhitePawn4);
            White.Add(WhitePawn5);
            White.Add(WhitePawn6);
            White.Add(WhitePawn7);
            White.Add(WhitePawn8);

            // 좌표찍어줌 (Common class 파일안에 있는 CommonProperties 클래스 배열 
            Chessboard[0, 0] = WhiteCastle1;
            Chessboard[0, 1] = WhiteKnight1;
            Chessboard[0, 2] = WhiteBishop1;
            Chessboard[0, 3] = WhiteQueen;
            Chessboard[0, 4] = WhiteKing;
            Chessboard[0, 5] = WhiteBishop2;
            Chessboard[0, 6] = WhiteKnight2;
            Chessboard[0, 7] = WhiteCastle2;

            Chessboard[1, 0] = WhitePawn1;
            Chessboard[1, 1] = WhitePawn2;
            Chessboard[1, 2] = WhitePawn3;
            Chessboard[1, 3] = WhitePawn4;
            Chessboard[1, 4] = WhitePawn5;
            Chessboard[1, 5] = WhitePawn6;
            Chessboard[1, 6] = WhitePawn7;
            Chessboard[1, 7] = WhitePawn8;

            Chessboard[7, 0] = BlackCastle1;
            Chessboard[7, 1] = BlackKnight1;
            Chessboard[7, 2] = BlackBishop1;
            Chessboard[7, 3] = BlackQueen;
            Chessboard[7, 4] = BlackKing;
            Chessboard[7, 5] = BlackBishop2;
            Chessboard[7, 6] = BlackKnight2;
            Chessboard[7, 7] = BlackCastle2;

            Chessboard[6, 0] = BlackPawn1;
            Chessboard[6, 1] = BlackPawn2;
            Chessboard[6, 2] = BlackPawn3;
            Chessboard[6, 3] = BlackPawn4;
            Chessboard[6, 4] = BlackPawn5;
            Chessboard[6, 5] = BlackPawn6;
            Chessboard[6, 6] = BlackPawn7;
            Chessboard[6, 7] = BlackPawn8;

            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++) 
                {
                    if (!(Chessboard[i, j].GetType().ToString().Contains("Empty"))) 
                        //체스판 전체 좌표 검사해서 Empty 라고 지정된 좌표 아닌곳에 그에 맞는 피스를 current 변수에 저장해줌
                    {
                        Chessboard[i, j].Current.X = i;
                        Chessboard[i, j].Current.Y = j;
                    }
                }
            }

        }











        public void PieceRemover(GameBoard _Game, Coordinate _Next, Empty Emptyspace)
            // 남의 피스 먹은거, 내 피스 먹힌거 없애기 
        {
            if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")))
            { //비어있는 좌표 아닌지 먼저 체크하고 ( 비어있으면 지울  필요 없으니까 )
                if (_Game.Chessboard[_Next.X, _Next.Y].IsWhite) // 옮기려는 좌표에 위치한 피스가 흰색일때
                { 
                    for (int i = 0; i < _Game.White.Count; i++) //카운트함수를 이용해서 간단히 리스트안에 갯수 셈과 동시에 범위 지정
                    {
                        if (_Game.White[i] == _Game.Chessboard[_Next.X, _Next.Y])
                        { //같은 좌표 들어오면 없애버리기 
                            _Game.White.Remove(_Game.White[i]); //Remove 함수를 이용하여 흰색 피스 리스트 안에서 아예 지워준다. 
                        }

                    }
                }
                else //  옮기려는 좌표에 위치한 피스가 블랙일때
                {
                    for (int i = 0; i < _Game.Black.Count; i++)
                    {
                        if (_Game.Black[i] == _Game.Chessboard[_Next.X, _Next.Y])
                        {
                            _Game.Black.Remove(_Game.Black[i]);
                        }

                    }
                }

            }
        }









        
        public void LastmoveReverser(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace) 
        {
            if (_Game.Chessboard[_Next.X, _Next.Y].didMoveHelper == 1) //움직임 감지 
            {
                _Game.Chessboard[_Next.X, _Next.Y].didMove = false;
                _Game.Chessboard[_Next.X, _Next.Y].didMoveHelper--;  //
            }
            _Game.Chessboard[_Current.X, _Current.Y] = _Game.Chessboard[_Next.X, _Next.Y];
            _Game.Chessboard[_Current.X, _Current.Y].Current.X = _Current.X;
            _Game.Chessboard[_Current.X, _Current.Y].Current.Y = _Current.Y;
            CommonProperties.whoseturn = !CommonProperties.whoseturn;
            if ((CommonProperties.isEmpty))
            {
                _Game.Chessboard[_Next.X, _Next.Y] = _Emptyspace;
                CommonProperties.isEmpty = false;
            }
            else
            {
                if (CommonProperties.whoseturn)
                {
                    _Game.Chessboard[_Next.X, _Next.Y] = _Game.Black[CommonProperties.reversedPiece];
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
                }
                else
                {
                    _Game.Chessboard[_Next.X, _Next.Y] = _Game.White[CommonProperties.reversedPiece];
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
                }
            }
            CommonProperties.reverserhelper = false;

        }
    }

    public class Empty : CommonProperties
    {

    }
}
