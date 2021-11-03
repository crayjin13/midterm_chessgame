using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Check
    {
        public bool Checktest(GameBoard _Game, Coordinate Current)
        {
            if ((_Game.Chessboard[Current.X, Current.Y].IsWhite))
            {
                return !(ChecktestWhite(_Game));
            }
            else
            {
                return !(ChecktestBlack(_Game));
            }
        }
        public bool ChecktestforRook(GameBoard _Game, Coordinate Current, byte _X, byte _Y)
        {
            if (_Game.Chessboard[Current.X, Current.Y].IsWhite)
            {
                return !(ChecktestforRookWhite(_Game, _X, _Y));
            }
            else
            {
                return !(ChecktestforRookBlack(_Game, _X, _Y));
            }
        }
        public bool ChecktestWhite(GameBoard _Game)
        {
            int i;
            King Kingmover1 = new King("White");
            for (i = 0; i < _Game.White.Count; i++)
            {
                if (_Game.White[i].GetType().ToString().Contains("King"))
                {
                    Kingmover1 = (King)_Game.White[i];
                    break;
                }
            }
            Coordinate _Next = Kingmover1.Current;
            string typecheck;
            for (i = 0; i < _Game.Black.Count; i++)
            {
                typecheck = _Game.Black[i].GetType().ToString();
                if (_Game.Black[i].Current.X == 99)
                {
                    continue;
                }
                switch (typecheck)
                {
                    case "Chess.Pawn":
                        Pawn Pawnmover = new Pawn("a");
                        Pawnmover = (Pawn)_Game.Black[i];
                        if (Pawnmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Bishop":
                        Bishop Bishopmover = new Bishop("a");
                        Bishopmover = (Bishop)_Game.Black[i];
                        if (Bishopmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Queen":
                        Queen Queenmover = new Queen("a");
                        Queenmover = (Queen)_Game.Black[i];
                        if (Queenmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Knight":
                        Knight Knightmover = new Knight("a");
                        Knightmover = (Knight)_Game.Black[i];
                        if (Knightmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }

                        break;
                    case "Chess.Castle":
                        Castle Castlemover = new Castle("a");
                        Castlemover = (Castle)_Game.Black[i];
                        if (Castlemover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.King":
                        King Kingmover2 = new King("a");
                        Kingmover2 = (King)_Game.Black[i];
                        if (Kingmover2.isMovable(_Game, _Next))
                        {
                            return true;

                        }
                        break;
                }
            }

            return false;
        }
        public bool ChecktestBlack(GameBoard _Game)
        {
            int i;
            King Kingmover1 = new King("BLACK");
            for (i = 0; i < _Game.Black.Count; i++)
            {
                if (_Game.Black[i].GetType().ToString().Contains("King"))
                {
                    Kingmover1 = (King)_Game.Black[i];
                    break;
                }
            }
            Coordinate _Next = Kingmover1.Current;
            string typecheck;
            for (i = 0; i < _Game.White.Count; i++)
            {
                typecheck = _Game.White[i].GetType().ToString();
                if (_Game.White[i].Current.X == 99)
                {
                    continue;
                }
                switch (typecheck)
                {
                    case "Chess.Pawn":
                        Pawn Pawnmover = new Pawn("a");
                        Pawnmover = (Pawn)_Game.White[i];
                        if (Pawnmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Bishop":
                        Bishop Bishopmover = new Bishop("a");
                        Bishopmover = (Bishop)_Game.White[i];
                        if (Bishopmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Queen":
                        Queen Queenmover = new Queen("a");
                        Queenmover = (Queen)_Game.White[i];
                        if (Queenmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Knight":
                        Knight Knightmover = new Knight("a");
                        Knightmover = (Knight)_Game.White[i];
                        if (Knightmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }

                        break;
                    case "Chess.Castle":
                        Castle Castlemover = new Castle("a");
                        Castlemover = (Castle)_Game.White[i];
                        if (Castlemover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.King":
                        King Kingmover2 = new King("a");
                        Kingmover2 = (King)_Game.White[i];
                        if (Kingmover2.isMovable(_Game, _Next))
                        {
                            return true;

                        }
                        break;
                }
            }

            return false;
        }
        public bool ChecktestforRookWhite(GameBoard _Game, byte _X, byte _Y)
        {
            int i;
            for (i = 0; i < _Game.Black.Count; i++)
            {
                Coordinate _Next = new Coordinate(_X, _Y);
                string typecheck = _Game.Black[i].GetType().ToString();
                switch (typecheck)
                {
                    case "Chess.Pawn":
                        Pawn Pawnmover = new Pawn("a");
                        Pawnmover = (Pawn)_Game.Black[i];
                        if (Pawnmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Bishop":
                        Bishop Bishopmover = new Bishop("a");
                        Bishopmover = (Bishop)_Game.Black[i];
                        if (Bishopmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Queen":
                        Queen Queenmover = new Queen("a");
                        Queenmover = (Queen)_Game.Black[i];
                        if (Queenmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Knight":
                        Knight Knightmover = new Knight("a");
                        Knightmover = (Knight)_Game.Black[i];
                        if (Knightmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }

                        break;
                    case "Chess.Castle":
                        Castle Castlemover = new Castle("a");
                        Castlemover = (Castle)_Game.Black[i];
                        if (Castlemover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.King":
                        King Kingmover2 = new King("a");
                        Kingmover2 = (King)_Game.Black[i];
                        if (Kingmover2.isMovable(_Game, _Next))
                        {
                            return true;

                        }
                        break;
                }
            }

            return false;
        }
        public bool ChecktestforRookBlack(GameBoard _Game, byte _X, byte _Y)
        {
            int i;
            for (i = 0; i < _Game.White.Count; i++)
            {
                Coordinate _Next = new Coordinate(_X, _Y);
                string typecheck = _Game.White[i].GetType().ToString();
                switch (typecheck)
                {
                    case "Chess.Pawn":
                        Pawn Pawnmover = new Pawn("a");
                        Pawnmover = (Pawn)_Game.White[i];
                        if (Pawnmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Bishop":
                        Bishop Bishopmover = new Bishop("a");
                        Bishopmover = (Bishop)_Game.White[i];
                        if (Bishopmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Queen":
                        Queen Queenmover = new Queen("a");
                        Queenmover = (Queen)_Game.White[i];
                        if (Queenmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.Knight":
                        Knight Knightmover = new Knight("a");
                        Knightmover = (Knight)_Game.White[i];
                        if (Knightmover.isMovable(_Game, _Next))
                        {
                            return true;
                        }

                        break;
                    case "Chess.Castle":
                        Castle Castlemover = new Castle("a");
                        Castlemover = (Castle)_Game.White[i];
                        if (Castlemover.isMovable(_Game, _Next))
                        {
                            return true;
                        }
                        break;
                    case "Chess.King":
                        King Kingmover2 = new King("a");
                        Kingmover2 = (King)_Game.White[i];
                        if (Kingmover2.isMovable(_Game, _Next))
                        {
                            return true;

                        }
                        break;
                }
            }

            return false;
        }
    }
}
