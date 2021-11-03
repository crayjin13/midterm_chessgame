using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace Chess
{
    public partial class Form1 : Form
    {  
        GameBoard Game = new GameBoard();
        GameEngine GameEngine = new GameEngine();
        Empty Emptyspace = new Empty();
        Check Checker = new Check();
        Matetester MateTester = new Matetester();
        Coordinate Current = new Coordinate();
        Coordinate Next = new Coordinate();
        Coordinate GetCoord = new Coordinate();
        Queen BlackPromoted = new Queen("BLACK");
        Queen WhitePromoted = new Queen("WHITE");

        string piecename;
        byte CoordChecker = 0;

        public Form1() 
        {
            InitializeComponent();
            //RUN 하자마자 보이는 기본 폼 어떤거 보이게 할지 설정하는거임 ( 시작버튼 누르기 전) 
            //기본값 true 로 들어가있어서 false 설정 안한거는 다 보임. 
            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;
            PromotedBlack.Visible = false;
            PromotedWhite.Visible = false;
            PromotedBlack.Enabled = false;
            PromotedWhite.Enabled = false;
            WhiteBishop1.Visible = false;
            WhiteBishop2.Visible = false;
            WhiteCastle1.Visible = false;
            WhiteCastle2.Visible = false;
            WhiteKnight1.Visible = false;
            WhiteKnight2.Visible = false;
            WhiteKing.Visible = false;
            WhiteQueen.Visible = false;

            WhitePawn1.Visible = false;
            WhitePawn2.Visible = false;
            WhitePawn3.Visible = false;
            WhitePawn4.Visible = false;
            WhitePawn5.Visible = false;
            WhitePawn6.Visible = false;
            WhitePawn7.Visible = false;
            WhitePawn8.Visible = false;

            BlackBishop1.Visible = false;
            BlackBishop2.Visible = false;
            BlackCastle1.Visible = false;
            BlackCastle2.Visible = false;
            BlackKnight1.Visible = false;
            BlackKnight2.Visible = false;
            BlackKing.Visible = false;
            BlackQueen.Visible = false;

            BlackPawn1.Visible = false;
            BlackPawn2.Visible = false;
            BlackPawn3.Visible = false;
            BlackPawn4.Visible = false;
            BlackPawn5.Visible = false;
            BlackPawn6.Visible = false;
            BlackPawn7.Visible = false;
            BlackPawn8.Visible = false;

            int xCoord;
            int yCoord;
            string drawertype;
            byte piecenumber;
            for (int i = 0; i < Game.White.Count; i++) //흰색팀 
            {
                drawertype = Game.White[i].GetType().ToString(); //어떤 피스 움직였는지
                piecenumber = Game.White[i].piecenum; 
                //비솝, 캐슬, 말, 폰쫄병 이것들은 각 팀에 2개에서 여러개씩 존재해서 번호 매겨서 같은팀피스끼리 어떤피스인지 확인가능

                xCoord = 2 + (60 * Game.White[i].Current.Y);
                yCoord = 3 + ((7 - Game.White[i].Current.X) * 60);


                switch (drawertype) // 다음엔 노가다 없이 하는 방법을.. 
                {
                    case "Chess.Pawn":  
                    //흰색 쫄따구 움직일떄 
                        switch (piecenumber)
                        {
                            case 1:
                                WhitePawn1.Location = new Point(xCoord, yCoord);

                                break;

                            case 2:
                                WhitePawn2.Location = new Point(xCoord, yCoord);
                                break;

                            case 3:
                                WhitePawn3.Location = new Point(xCoord, yCoord);
                                break;

                            case 4:
                                WhitePawn4.Location = new Point(xCoord, yCoord);
                                break;

                            case 5:
                                WhitePawn5.Location = new Point(xCoord, yCoord);
                                break;

                            case 6:
                                WhitePawn6.Location = new Point(xCoord, yCoord);
                                break;

                            case 7:
                                WhitePawn7.Location = new Point(xCoord, yCoord);
                                break;

                            case 8:
                                WhitePawn8.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.Knight":
                        switch (piecenumber)
                        {
                            case 1:
                                WhiteKnight1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                WhiteKnight2.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.Bishop":
                        switch (piecenumber)
                        {
                            case 1:
                                WhiteBishop1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                WhiteBishop2.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.Castle":
                        switch (piecenumber)
                        {
                            case 1:
                                WhiteCastle1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                WhiteCastle2.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.King":
                        WhiteKing.Location = new Point(xCoord, yCoord);
                        break;

                    case "Chess.Queen":
                        switch (piecenumber)
                        {
                            case 1:

                                WhiteQueen.Location = new Point(xCoord, yCoord);
                                break;
                            case 2: //폰 맨꼭대기 올라가면 퀸으로 바꿀꺼임 그떄 생기는 피스 
                                if (PromotedWhite.Enabled)
                                {
                                    PromotedWhite.Location = new Point(xCoord, yCoord);
                                }
                                break;
                        }
                        break;
                }
            }  
            for (int i = 0; i < Game.Black.Count; i++)      //블랙팀 
            {
                drawertype = Game.Black[i].GetType().ToString(); //어떤피스
                piecenumber = Game.Black[i].piecenum;  // 똑같이생긴피스중 몇번째꺼 
                xCoord = 2 + 60 * Game.Black[i].Current.Y;
                yCoord = 3 + ((7 - Game.Black[i].Current.X) * 60);

                switch (drawertype)
                {
                    case "Chess.Pawn":
                        switch (piecenumber)
                        {
                            case 1:
                                BlackPawn1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                BlackPawn2.Location = new Point(xCoord, yCoord);
                                break;

                            case 3:
                                BlackPawn3.Location = new Point(xCoord, yCoord);
                                break;

                            case 4:
                                BlackPawn4.Location = new Point(xCoord, yCoord);
                                break;

                            case 5:
                                BlackPawn5.Location = new Point(xCoord, yCoord);
                                break;

                            case 6:
                                BlackPawn6.Location = new Point(xCoord, yCoord);
                                break;

                            case 7:
                                BlackPawn7.Location = new Point(xCoord, yCoord);
                                break;

                            case 8:
                                BlackPawn8.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.Knight":
                        switch (piecenumber)
                        {
                            case 1:
                                BlackKnight1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                BlackKnight2.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.Bishop":
                        switch (piecenumber)
                        {
                            case 1:
                                BlackBishop1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                BlackBishop2.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.Castle":
                        switch (piecenumber)
                        {
                            case 1:
                                BlackCastle1.Location = new Point(xCoord, yCoord);
                                break;

                            case 2:
                                BlackCastle2.Location = new Point(xCoord, yCoord);
                                break;
                        }
                        break;
                    case "Chess.King":
                        BlackKing.Location = new Point(xCoord, yCoord);
                        break;

                    case "Chess.Queen":
                        switch (piecenumber)
                        {
                            case 1:

                                BlackQueen.Location = new Point(xCoord, yCoord);
                                break;
                            case 2:
                                if (PromotedBlack.Enabled)
                                {
                                    PromotedBlack.Location = new Point(xCoord, yCoord);
                                }
                                break;
                        }
                        break;
                }
            }


        }



     

     
        private void StartClick(object sender, EventArgs e)  // 화면에서 스타트 클릭하고 게임 시작 할때 첫 화면 어떤 피스들 보이게 하고 안보이게 할건지 조정
        {

            this.BackgroundImage = Properties.Resources.Chessboard;
            label1.Visible = false;
            label1.Enabled = false;
            button1.Visible = false;
            button1.Enabled = false;
            pictureBox1.Visible = true;
            WhiteBishop1.Visible = true;
            WhiteBishop2.Visible = true;
            WhiteCastle1.Visible = true;
            WhiteCastle2.Visible = true;
            WhiteKnight1.Visible = true;
            WhiteKnight2.Visible = true;
            WhiteKing.Visible = true;
            WhiteQueen.Visible = true;

            WhitePawn1.Visible = true;
            WhitePawn2.Visible = true;
            WhitePawn3.Visible = true;
            WhitePawn4.Visible = true;
            WhitePawn5.Visible = true;
            WhitePawn6.Visible = true;
            WhitePawn7.Visible = true;
            WhitePawn8.Visible = true;

            BlackBishop1.Visible = true;
            BlackBishop2.Visible = true;
            BlackCastle1.Visible = true;
            BlackCastle2.Visible = true;
            BlackKnight1.Visible = true;
            BlackKnight2.Visible = true;
            BlackKing.Visible = true;
            BlackQueen.Visible = true;

            BlackPawn1.Visible = true;
            BlackPawn2.Visible = true;
            BlackPawn3.Visible = true;
            BlackPawn4.Visible = true;
            BlackPawn5.Visible = true;
            BlackPawn6.Visible = true;
            BlackPawn7.Visible = true;
            BlackPawn8.Visible = true;
            CommonProperties.didEnpassantmove = false;
        }

        private void PieceClick(object sender, EventArgs e)  //화면에서 피스 클릭 후 움직일때 조정함 
        {

            GetCoord.Y = (byte)(((sender as PictureBox).Location.X / 60));
            GetCoord.X = (byte)((7 - (sender as PictureBox).Location.Y / 60));  // 60으로 나누는 이유는 피스 하나당 x 사이즈 60임 
            //https://stackoverflow.com/questions/44949089/picturebox-location-for-x-and-y-is-different-then-what-is-being-entered-in-prope
            // picturbox에서 사진가져올때 사이즈 어떻게하는지 

            if (CoordChecker == 0)
            {
                Current.X = GetCoord.X;
                Current.Y = GetCoord.Y;
                CoordChecker = 1;
                pictureBox1.Enabled = true;
                (sender as PictureBox).BackColor = Color.AliceBlue;
                piecename = (sender as PictureBox).Name;
            }

            else
            {
                switch (piecename)
                {
                    case "BlackKing":
                        BlackKing.BackColor = Color.Transparent;
                        break;

                    case "BlackQueen":
                        BlackQueen.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn1":
                        BlackPawn1.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn2":
                        BlackPawn2.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn3":
                        BlackPawn3.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn4":
                        BlackPawn4.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn5":
                        BlackPawn5.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn6":
                        BlackPawn6.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn7":
                        BlackPawn7.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn8":
                        BlackPawn8.BackColor = Color.Transparent;
                        break;
                    case "BlackBishop1":
                        BlackBishop1.BackColor = Color.Transparent;
                        break;

                    case "BlackBishop2":
                        BlackBishop2.BackColor = Color.Transparent;
                        break;

                    case "BlackKnight1":
                        BlackKnight1.BackColor = Color.Transparent;
                        break;

                    case "BlackKnight2":
                        BlackKnight2.BackColor = Color.Transparent;
                        break;
                    case "BlackCastle1":
                        BlackCastle1.BackColor = Color.Transparent;
                        break;
                    case "BlackCastle2":
                        BlackCastle2.BackColor = Color.Transparent;
                        break;
                    case "PromotedBlack":
                        PromotedBlack.BackColor = Color.Transparent;
                        break;
                    case "WhiteKing":
                        WhiteKing.BackColor = Color.Transparent;
                        break;

                    case "WhiteQueen":
                        WhiteQueen.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn1":
                        WhitePawn1.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn2":
                        WhitePawn2.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn4":
                        WhitePawn4.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn5":
                        WhitePawn5.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn6":
                        WhitePawn6.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn7":
                        WhitePawn7.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn8":
                        WhitePawn8.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn3":
                        WhitePawn3.BackColor = Color.Transparent;
                        break;
                    case "WhiteBishop1":
                        WhiteBishop1.BackColor = Color.Transparent;
                        break;

                    case "WhiteBishop2":
                        WhiteBishop2.BackColor = Color.Transparent;
                        break;

                    case "WhiteKnight1":
                        WhiteKnight1.BackColor = Color.Transparent;
                        break;

                    case "WhiteKnight2":
                        WhiteKnight2.BackColor = Color.Transparent;
                        break;
                    case "WhiteCastle1":
                        WhiteCastle1.BackColor = Color.Transparent;
                        break;
                    case "WhiteCastle2":
                        WhiteCastle2.BackColor = Color.Transparent;
                        break;
                    case "PromotedWhite":
                        PromotedWhite.BackColor = Color.Transparent;
                        break;
                }
                Next.X = GetCoord.X;
                Next.Y = GetCoord.Y;
                CoordChecker = 0;
                pictureBox1.Enabled = false;
                GameEngine.Run(Game, Current, Next, Checker, Emptyspace);
                if (GameEngine.anyChanges)
                {
                    GameEngine.anyChanges = false;
                    if (CommonProperties.reverserhelper)
                    {
                        CommonProperties.reverserhelper = false;
                        if (CommonProperties.whoseturn) //흰색턴이냐 
                        {
                            Game.White[CommonProperties.reversedPiece].Current.X = CommonProperties.reversercoord.X; 
                            Game.White[CommonProperties.reversedPiece].Current.Y = CommonProperties.reversercoord.Y;
                        }
                        else //검은턴이냐 
                        {
                            Game.Black[CommonProperties.reversedPiece].Current.X = CommonProperties.reversercoord.X;
                            Game.Black[CommonProperties.reversedPiece].Current.Y = CommonProperties.reversercoord.Y;

                        }
                    }

                    int xCoord;
                    int yCoord;
                    int piecenumber;
                    for (int i = 0; i < Game.White.Count; i++)
                    {
                        for (int j = 0; j < Game.Black.Count; j++)
                        {

                            if ((Game.White[i].Current.X == Game.Black[j].Current.X) && (Game.White[i].Current.Y == Game.Black[j].Current.Y))
                            {
                                if (CommonProperties.whoseturn)
                                {
                                    piecenumber = Game.White[i].piecenum;
                                    switch (Game.White[i].GetType().ToString())
                                    {
                                        case "Chess.Pawn":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    WhitePawn1.Dispose();
                                                    break;

                                                case 2:
                                                    WhitePawn2.Dispose();

                                                    break;

                                                case 3:
                                                    WhitePawn3.Dispose();

                                                    break;

                                                case 4:
                                                    WhitePawn4.Dispose();

                                                    break;

                                                case 5:
                                                    WhitePawn5.Dispose();

                                                    break;

                                                case 6:
                                                    WhitePawn6.Dispose();

                                                    break;

                                                case 7:
                                                    WhitePawn7.Dispose();

                                                    break;

                                                case 8:
                                                    WhitePawn8.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.Knight":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    WhiteKnight1.Dispose();
                                                    break;

                                                case 2:
                                                    WhiteKnight2.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.Bishop":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    WhiteBishop1.Dispose();
                                                    break;

                                                case 2:
                                                    WhiteBishop2.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.Castle":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    WhiteCastle1.Dispose();
                                                    break;

                                                case 2:
                                                    WhiteCastle2.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.King":

                                            break;

                                        case "Chess.Queen":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    WhiteQueen.Dispose();

                                                    break;
                                                case 2:
                                                    PromotedWhite.Dispose();
                                                    break;
                                            }
                                            break;
                                    }
                                    Game.White[i].Current.X = 99;
                                    Game.White[i].Current.Y = 99;
                                    Game.White.Remove(Game.White[i]);
                                    break;
                                }
                                else
                                {
                                    piecenumber = Game.Black[j].piecenum;

                                    switch (Game.Black[j].GetType().ToString())
                                    {
                                        case "Chess.Pawn":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    BlackPawn1.Dispose();
                                                    break;

                                                case 2:
                                                    BlackPawn2.Dispose();

                                                    break;

                                                case 3:
                                                    BlackPawn3.Dispose();

                                                    break;

                                                case 4:
                                                    BlackPawn4.Dispose();

                                                    break;

                                                case 5:
                                                    BlackPawn5.Dispose();

                                                    break;

                                                case 6:
                                                    BlackPawn6.Dispose();

                                                    break;

                                                case 7:
                                                    BlackPawn7.Dispose();

                                                    break;

                                                case 8:
                                                    BlackPawn8.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.Knight":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    BlackKnight1.Dispose();
                                                    break;

                                                case 2:
                                                    BlackKnight2.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.Bishop":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    BlackBishop1.Dispose();
                                                    break;

                                                case 2:
                                                    BlackBishop2.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.Castle":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    BlackCastle1.Dispose();
                                                    break;

                                                case 2:
                                                    BlackCastle2.Dispose();
                                                    break;
                                            }
                                            break;
                                        case "Chess.King":

                                            break;
                                        case "Chess.Queen":
                                            switch (piecenumber)
                                            {
                                                case 1:
                                                    BlackQueen.Dispose();

                                                    break;
                                                case 2:
                                                    PromotedBlack.Dispose();
                                                    break;
                                            }
                                            break;
                                    }
                                    Game.Black[j].Current.X = 99;
                                    Game.Black[j].Current.Y = 99;
                                    Game.Black.Remove(Game.Black[j]);
                                    break;
                                }
                            }

                        }
                    }
                    if (GameEngine.Promotionchecker(Game))
                    {
                        if (GameEngine.promotionCoord.X == 0)
                        {
                            for (int i = 0; i < Game.White.Count; i++)
                            {
                                if (Game.Black[i] == Game.Chessboard[0, GameEngine.promotionCoord.Y])
                                {
                                    Game.Black.Remove(Game.Black[i]);
                                    break;
                                }
                            }
                            switch (Game.Chessboard[0, GameEngine.promotionCoord.Y].piecenum)
                            {
                                case 1:
                                    BlackPawn1.Dispose();
                                    break;

                                case 2:
                                    BlackPawn2.Dispose();

                                    break;

                                case 3:
                                    BlackPawn3.Dispose();

                                    break;

                                case 4:
                                    BlackPawn4.Dispose();

                                    break;

                                case 5:
                                    BlackPawn5.Dispose();

                                    break;

                                case 6:
                                    BlackPawn6.Dispose();

                                    break;

                                case 7:
                                    BlackPawn7.Dispose();

                                    break;

                                case 8:
                                    BlackPawn8.Dispose();
                                    break;
                            }

                            BlackPromoted.Current.X = Game.Chessboard[0, GameEngine.promotionCoord.Y].Current.X;
                            BlackPromoted.Current.Y = Game.Chessboard[0, GameEngine.promotionCoord.Y].Current.Y;

                            BlackPromoted.didMove = true;
                            BlackPromoted.piecenum = 2;
                            BlackPromoted.IsWhite = Game.Chessboard[0, GameEngine.promotionCoord.Y].IsWhite;
                            PromotedBlack.Enabled = true;
                            PromotedBlack.Visible = true;
                            Game.Chessboard[0, GameEngine.promotionCoord.Y] = BlackPromoted;
                            Game.Black.Add(BlackPromoted);
                        }
                        else
                        {
                            for (int i = 0; i < Game.White.Count; i++)
                            {
                                if (Game.White[i] == Game.Chessboard[7, GameEngine.promotionCoord.Y])
                                {
                                    Game.White.Remove(Game.White[i]);
                                    break;
                                }
                            }
                            switch (Game.Chessboard[7, GameEngine.promotionCoord.Y].piecenum)
                            {
                                case 1:
                                    WhitePawn1.Dispose();
                                    break;

                                case 2:
                                    WhitePawn2.Dispose();

                                    break;

                                case 3:
                                    WhitePawn3.Dispose();

                                    break;

                                case 4:
                                    WhitePawn4.Dispose();

                                    break;

                                case 5:
                                    WhitePawn5.Dispose();

                                    break;

                                case 6:
                                    WhitePawn6.Dispose();

                                    break;

                                case 7:
                                    WhitePawn7.Dispose();

                                    break;

                                case 8:
                                    WhitePawn8.Dispose();
                                    break;
                            }
                            WhitePromoted.Current.X = Game.Chessboard[7, GameEngine.promotionCoord.Y].Current.X;
                            WhitePromoted.Current.Y = Game.Chessboard[7, GameEngine.promotionCoord.Y].Current.Y;

                            WhitePromoted.didMove = true;
                            WhitePromoted.piecenum = 2;
                            WhitePromoted.IsWhite = Game.Chessboard[7, GameEngine.promotionCoord.Y].IsWhite;
                            PromotedWhite.Enabled = true;
                            PromotedWhite.Visible = true;
                            Game.Chessboard[7, GameEngine.promotionCoord.Y] = WhitePromoted;
                            Game.White.Add(WhitePromoted);
                        }
                    }
                    // Beyaz taş 
                    for (int i = 0; i < Game.White.Count; i++)
                    {
                        string drawertype = Game.White[i].GetType().ToString();
                        piecenumber = Game.White[i].piecenum;

                        xCoord = 2 + (60 * Game.White[i].Current.Y);
                        yCoord = 3 + ((7 - Game.White[i].Current.X) * 60);


                        switch (drawertype)
                        {
                            case "Chess.Pawn":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhitePawn1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhitePawn2.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 3:
                                        WhitePawn3.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 4:
                                        WhitePawn4.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 5:
                                        WhitePawn5.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 6:
                                        WhitePawn6.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 7:
                                        WhitePawn7.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 8:
                                        WhitePawn8.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Knight":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhiteKnight1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhiteKnight2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Bishop":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhiteBishop1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhiteBishop2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Castle":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhiteCastle1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhiteCastle2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.King":
                                WhiteKing.Location = new Point(xCoord, yCoord);
                                break;

                            case "Chess.Queen":
                                switch (piecenumber)
                                {
                                    case 1:

                                        WhiteQueen.Location = new Point(xCoord, yCoord);
                                        break;
                                    case 2:
                                        if (PromotedWhite.Enabled)
                                        {
                                            PromotedWhite.Location = new Point(xCoord, yCoord);
                                        }
                                        break;
                                }
                                break;

                        }
                    }
                    // Siyah taş 
                    for (int i = 0; i < Game.Black.Count; i++)
                    {
                        string drawertype = Game.Black[i].GetType().ToString();
                        piecenumber = Game.Black[i].piecenum;

                        xCoord = 2 + 60 * Game.Black[i].Current.Y;
                        yCoord = 3 + ((7 - Game.Black[i].Current.X) * 60);

                        switch (drawertype)
                        {
                            case "Chess.Pawn":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackPawn1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackPawn2.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 3:
                                        BlackPawn3.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 4:
                                        BlackPawn4.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 5:
                                        BlackPawn5.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 6:
                                        BlackPawn6.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 7:
                                        BlackPawn7.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 8:
                                        BlackPawn8.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Knight":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackKnight1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackKnight2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Bishop":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackBishop1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackBishop2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Castle":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackCastle1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackCastle2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.King":
                                BlackKing.Location = new Point(xCoord, yCoord);
                                break;

                            case "Chess.Queen":
                                switch (piecenumber)
                                {
                                    case 1:

                                        BlackQueen.Location = new Point(xCoord, yCoord);
                                        break;
                                    case 2:
                                        if (PromotedBlack.Enabled)
                                        {
                                            PromotedBlack.Location = new Point(xCoord, yCoord);
                                        }
                                        break;
                                }
                                break;
                        }
                    }

                    if (MateTester.Matetest(Game, Emptyspace, Checker))
                    {
                        if (CommonProperties.whoseturn)
                        {
                            MessageBox.Show("BLACK SIDE HAS WON");
                        }
                        else
                        {
                            MessageBox.Show("WHITE SIDE HAS WON");
                        }
                    }
                }
            }
        }

        private void Boardclick(object sender, EventArgs e)
        {

            MouseEventArgs eM = (MouseEventArgs)e;

            GetCoord.Y = (byte)((eM.X / 60));
            GetCoord.X = (byte)(7 - (eM.Y / 60));
            if (CoordChecker == 1)
            {
                switch (piecename)
                {
                    case "BlackKing":
                        BlackKing.BackColor = Color.Transparent;
                        break;

                    case "BlackQueen":
                        BlackQueen.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn1":
                        BlackPawn1.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn2":
                        BlackPawn2.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn3":
                        BlackPawn3.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn4":
                        BlackPawn4.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn5":
                        BlackPawn5.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn6":
                        BlackPawn6.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn7":
                        BlackPawn7.BackColor = Color.Transparent;
                        break;

                    case "BlackPawn8":
                        BlackPawn8.BackColor = Color.Transparent;
                        break;
                    case "BlackBishop1":
                        BlackBishop1.BackColor = Color.Transparent;
                        break;

                    case "BlackBishop2":
                        BlackBishop2.BackColor = Color.Transparent;
                        break;

                    case "BlackKnight1":
                        BlackKnight1.BackColor = Color.Transparent;
                        break;

                    case "BlackKnight2":
                        BlackKnight2.BackColor = Color.Transparent;
                        break;
                    case "BlackCastle1":
                        BlackCastle1.BackColor = Color.Transparent;
                        break;
                    case "BlackCastle2":
                        BlackCastle2.BackColor = Color.Transparent;
                        break;
                    case "PromotedBlack":
                        PromotedBlack.BackColor = Color.Transparent;
                        break;
                    case "WhiteKing":
                        WhiteKing.BackColor = Color.Transparent;
                        break;

                    case "WhiteQueen":
                        WhiteQueen.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn1":
                        WhitePawn1.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn2":
                        WhitePawn2.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn4":
                        WhitePawn4.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn5":
                        WhitePawn5.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn6":
                        WhitePawn6.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn7":
                        WhitePawn7.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn8":
                        WhitePawn8.BackColor = Color.Transparent;
                        break;

                    case "WhitePawn3":
                        WhitePawn3.BackColor = Color.Transparent;
                        break;
                    case "WhiteBishop1":
                        WhiteBishop1.BackColor = Color.Transparent;
                        break;

                    case "WhiteBishop2":
                        WhiteBishop2.BackColor = Color.Transparent;
                        break;

                    case "WhiteKnight1":
                        WhiteKnight1.BackColor = Color.Transparent;
                        break;

                    case "WhiteKnight2":
                        WhiteKnight2.BackColor = Color.Transparent;
                        break;
                    case "WhiteCastle1":
                        WhiteCastle1.BackColor = Color.Transparent;
                        break;
                    case "WhiteCastle2":
                        WhiteCastle2.BackColor = Color.Transparent;
                        break;
                    case "PromotedWhite":
                        PromotedWhite.BackColor = Color.Transparent;
                        break;
                }
                pictureBox1.Enabled = false;
                Next.X = GetCoord.X;
                Next.Y = GetCoord.Y;
                CoordChecker = 0;
                GameEngine.Run(Game, Current, Next, Checker, Emptyspace);
                int xCoord;
                int yCoord;
                string drawertype;
                byte piecenumber;

                if (GameEngine.anyChanges && CommonProperties.drawHelper)
                {
                    GameEngine.anyChanges = false;
                    CommonProperties.drawHelper = false;
                    if ((CommonProperties.didEnpassantmove))
                    {
                        for (int i = 0; i < Game.White.Count; i++)
                        {
                            if ((Game.White[i].GetType().ToString().Contains("Pawn")))
                            {
                                for (int j = 0; j < Game.Black.Count; j++)
                                {
                                    if ((Game.Black[j].GetType().ToString().Contains("Pawn")))
                                    {
                                        if ((Game.Black[j].Current.Y == Game.White[i].Current.Y) && ((Game.Black[j].Current.X - 1 == Game.White[i].Current.X) || (Game.Black[j].Current.X + 1 == Game.White[i].Current.X)))
                                        {
                                            if (CommonProperties.whoseturn)
                                            {
                                                switch (Game.White[i].piecenum)
                                                {
                                                    case 1:
                                                        WhitePawn1.Dispose();
                                                        break;

                                                    case 2:
                                                        WhitePawn2.Dispose();

                                                        break;

                                                    case 3:
                                                        WhitePawn3.Dispose();

                                                        break;

                                                    case 4:
                                                        WhitePawn4.Dispose();

                                                        break;

                                                    case 5:
                                                        WhitePawn5.Dispose();

                                                        break;

                                                    case 6:
                                                        WhitePawn6.Dispose();

                                                        break;

                                                    case 7:
                                                        WhitePawn7.Dispose();

                                                        break;

                                                    case 8:
                                                        WhitePawn8.Dispose();
                                                        break;
                                                }
                                                Game.White.Remove(Game.White[i]);
                                                CommonProperties.didEnpassantmove = false;
                                            }
                                            else
                                            {
                                                switch (Game.Black[j].piecenum)
                                                {
                                                    case 1:
                                                        BlackPawn1.Dispose();
                                                        break;

                                                    case 2:
                                                        BlackPawn2.Dispose();

                                                        break;

                                                    case 3:
                                                        BlackPawn3.Dispose();

                                                        break;

                                                    case 4:
                                                        BlackPawn4.Dispose();

                                                        break;

                                                    case 5:
                                                        BlackPawn5.Dispose();

                                                        break;

                                                    case 6:
                                                        BlackPawn6.Dispose();

                                                        break;

                                                    case 7:
                                                        BlackPawn7.Dispose();

                                                        break;

                                                    case 8:
                                                        BlackPawn8.Dispose();
                                                        break;
                                                }
                                                Game.Black.Remove(Game.Black[j]);
                                                CommonProperties.didEnpassantmove = false;

                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                    if (GameEngine.Promotionchecker(Game))
                    {
                        if (GameEngine.promotionCoord.X == 0)
                        {
                            for (int i = 0; i < Game.White.Count; i++)
                            {
                                if (Game.Black[i] == Game.Chessboard[0, GameEngine.promotionCoord.Y])
                                {
                                    Game.Black.Remove(Game.Black[i]);
                                    break;
                                }
                            }
                            BlackPromoted.Current = Game.Chessboard[0, GameEngine.promotionCoord.Y].Current;
                            BlackPromoted.didMove = true;
                            BlackPromoted.piecenum = 2;
                            BlackPromoted.IsWhite = Game.Chessboard[0, GameEngine.promotionCoord.Y].IsWhite;
                            PromotedBlack.Enabled = true;
                            PromotedBlack.Visible = true;
                            Game.Chessboard[0, GameEngine.promotionCoord.Y] = BlackPromoted;
                            Game.Black.Add(BlackPromoted);
                        }
                        else
                        {
                            for (int i = 0; i < Game.White.Count; i++)
                            {
                                if (Game.White[i] == Game.Chessboard[7, GameEngine.promotionCoord.Y])
                                {
                                    Game.White.Remove(Game.White[i]);
                                    break;
                                }
                            }
                            WhitePromoted.Current = Game.Chessboard[7, GameEngine.promotionCoord.Y].Current;
                            WhitePromoted.didMove = true;
                            WhitePromoted.piecenum = 2;
                            WhitePromoted.IsWhite = Game.Chessboard[7, GameEngine.promotionCoord.Y].IsWhite;
                            PromotedWhite.Enabled = true;
                            PromotedWhite.Visible = true;
                            Game.Chessboard[7, GameEngine.promotionCoord.Y] = WhitePromoted;
                            Game.White.Add(WhitePromoted);
                        }
                    }

                    for (int i = 0; i < Game.White.Count; i++)
                    {
                        drawertype = Game.White[i].GetType().ToString();
                        piecenumber = Game.White[i].piecenum;

                        xCoord = 2 + (60 * Game.White[i].Current.Y);
                        yCoord = 3 + ((7 - Game.White[i].Current.X) * 60);


                        switch (drawertype)
                        {
                            case "Chess.Pawn":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhitePawn1.Location = new Point(xCoord, yCoord);

                                        break;

                                    case 2:
                                        WhitePawn2.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 3:
                                        WhitePawn3.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 4:
                                        WhitePawn4.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 5:
                                        WhitePawn5.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 6:
                                        WhitePawn6.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 7:
                                        WhitePawn7.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 8:
                                        WhitePawn8.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Knight":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhiteKnight1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhiteKnight2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Bishop":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhiteBishop1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhiteBishop2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Castle":
                                switch (piecenumber)
                                {
                                    case 1:
                                        WhiteCastle1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        WhiteCastle2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.King":
                                WhiteKing.Location = new Point(xCoord, yCoord);
                                break;

                            case "Chess.Queen":
                                switch (piecenumber)
                                {
                                    case 1:

                                        WhiteQueen.Location = new Point(xCoord, yCoord);
                                        break;
                                    case 2:
                                        if (PromotedWhite.Enabled)
                                        {
                                            PromotedWhite.Location = new Point(xCoord, yCoord);
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                    for (int i = 0; i < Game.Black.Count; i++)
                    {
                        drawertype = Game.Black[i].GetType().ToString();
                        piecenumber = Game.Black[i].piecenum;
                        xCoord = 2 + 60 * Game.Black[i].Current.Y;
                        yCoord = 3 + ((7 - Game.Black[i].Current.X) * 60);

                        switch (drawertype)
                        {
                            case "Chess.Pawn":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackPawn1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackPawn2.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 3:
                                        BlackPawn3.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 4:
                                        BlackPawn4.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 5:
                                        BlackPawn5.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 6:
                                        BlackPawn6.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 7:
                                        BlackPawn7.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 8:
                                        BlackPawn8.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Knight":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackKnight1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackKnight2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Bishop":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackBishop1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackBishop2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.Castle":
                                switch (piecenumber)
                                {
                                    case 1:
                                        BlackCastle1.Location = new Point(xCoord, yCoord);
                                        break;

                                    case 2:
                                        BlackCastle2.Location = new Point(xCoord, yCoord);
                                        break;
                                }
                                break;
                            case "Chess.King":
                                BlackKing.Location = new Point(xCoord, yCoord);
                                break;

                            case "Chess.Queen":
                                switch (piecenumber)
                                {
                                    case 1:

                                        BlackQueen.Location = new Point(xCoord, yCoord);
                                        break;
                                    case 2:
                                        if (PromotedBlack.Enabled)
                                        {
                                            PromotedBlack.Location = new Point(xCoord, yCoord);
                                        }
                                        break;
                                }
                                break;
                        }
                    }

                    if (MateTester.Matetest(Game, Emptyspace, Checker))
                    {
                        if (CommonProperties.whoseturn)
                        {
                            MessageBox.Show("BLACK SIDE HAS WON");
                        }
                        else
                        {
                            MessageBox.Show("WHITE SIDE HAS WON");
                        }
                    }
                }
            }
        }

    }
}








