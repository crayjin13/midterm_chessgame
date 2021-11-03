using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Matetester
    {
        public bool Matetest(GameBoard Game, Empty Emptyspace, Check Checker)
        {
            if (CommonProperties.whoseturn)
            {
                return !MatetestforWhite(Game, Emptyspace, Checker);
            }
            else
            {
                return !MatetestforBlack(Game, Emptyspace, Checker);
            }
        }
        public bool MatetestforWhite(GameBoard Game, Empty Emptyspace, Check Checker)
        {
            Coordinate CurrentCoord = new Coordinate();
            Coordinate NextCoord = new Coordinate();
            for (int i = 0; i < Game.White.Count; i++)
            {
                string typecheck = Game.White[i].GetType().ToString();

                CurrentCoord.X = Game.White[i].Current.X;
                CurrentCoord.Y = Game.White[i].Current.Y;
                for (byte j = 0; j < 8; j++)
                {
                    NextCoord.X = j;
                    for (byte k = 0; k < 8; k++)
                    {

                        NextCoord.Y = k;
                        switch (typecheck)
                        {
                            case "Chess.Pawn":
                                Pawn Pawnmover = new Pawn("WHITE");
                                Pawnmover = (Pawn)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Pawnmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }

                                }

                                break;

                            case "Chess.Bishop":

                                Bishop Bishopmover = new Bishop("a");
                                Bishopmover = (Bishop)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Bishopmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {

                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }
                                }
                                break;

                            case "Chess.Queen":

                                Queen Queenmover = new Queen("a");
                                Queenmover = (Queen)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Queenmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }
                                }
                                break;

                            case "Chess.Knight":

                                Knight Knightmover = new Knight("a");
                                Knightmover = (Knight)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Knightmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }
                                }
                                break;

                            case "Chess.Castle":

                                Castle Castlemover = new Castle("a");
                                Castlemover = (Castle)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Castlemover.isMovable(Game, NextCoord))
                                {
                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }

                                }
                                break;

                            case "Chess.King":

                                King Kingmover = new King("a");
                                Kingmover = (King)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Kingmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }

                                }


                                break;
                        }

                    }
                }
            }
            return false;

        }

        public bool MatetestforBlack(GameBoard Game, Empty Emptyspace, Check Checker)
        {
            Coordinate CurrentCoord = new Coordinate();
            Coordinate NextCoord = new Coordinate();
            for (int i = 0; i < Game.Black.Count; i++)
            {
                string typecheck = Game.Black[i].GetType().ToString();

                CurrentCoord.X = Game.Black[i].Current.X;
                CurrentCoord.Y = Game.Black[i].Current.Y;
                for (byte j = 0; j < 8; j++)
                {
                    NextCoord.X = j;
                    for (byte k = 0; k < 8; k++)
                    {

                        NextCoord.Y = k;
                        switch (typecheck)
                        {
                            case "Chess.Pawn":
                                Pawn Pawnmover = new Pawn("WHITE");
                                Pawnmover = (Pawn)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Pawnmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }

                                }

                                break;

                            case "Chess.Bishop":

                                Bishop Bishopmover = new Bishop("a");
                                Bishopmover = (Bishop)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Bishopmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {

                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }
                                }
                                break;

                            case "Chess.Queen":

                                Queen Queenmover = new Queen("a");
                                Queenmover = (Queen)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Queenmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }
                                }
                                break;

                            case "Chess.Knight":

                                Knight Knightmover = new Knight("a");
                                Knightmover = (Knight)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Knightmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }
                                }
                                break;

                            case "Chess.Castle":

                                Castle Castlemover = new Castle("a");
                                Castlemover = (Castle)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Castlemover.isMovable(Game, NextCoord))
                                {
                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }

                                }
                                break;

                            case "Chess.King":

                                King Kingmover = new King("a");
                                Kingmover = (King)Game.Chessboard[CurrentCoord.X, CurrentCoord.Y];
                                if (Kingmover.isMovable(Game, NextCoord))
                                {

                                    Game.Chessboard[CurrentCoord.X, CurrentCoord.Y].Move(Game, CurrentCoord, NextCoord, Emptyspace);
                                    if (!(Checker.Checktest(Game, NextCoord)))
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                    }
                                    else
                                    {
                                        Game.LastmoveReverser(Game, CurrentCoord, NextCoord, Emptyspace);
                                        return true;
                                    }

                                }


                                break;
                        }

                    }
                }
            }
            return false;

        }
    }
}
