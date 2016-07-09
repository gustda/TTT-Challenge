using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Model
{
    public class Game
    {
        public GameResult Result { get; private set; }

        public Dictionary<char, GameStoneState[]> Gameboard;
        private int Moves = 0;
        private const int maxMoves = 9;

        List<List<Coordinate>> WinOpportunities;

        public Game()
        {
            // Set default value for the new game
            Result = GameResult.Open;

            // setup a clear gameboard
            InitGameboard();

            // set win opportunities
            SetWinOpportunities();
        }

        private void InitGameboard()
        {
            Gameboard = new Dictionary<char, GameStoneState[]>();
            for (int i = 0; i < 3; i++)
            {
                GameStoneState[] gameRow = new GameStoneState[3];
                gameRow[0] = GameStoneState.Free;
                gameRow[1] = GameStoneState.Free;
                gameRow[2] = GameStoneState.Free;
                switch (i)
                {
                    case 0:
                        Gameboard.Add('a', gameRow);
                        break;
                    case 1:
                        Gameboard.Add('b', gameRow);
                        break;
                    case 2:
                        Gameboard.Add('c', gameRow);
                        break;
                }
            }
        }

        public bool SetStone(Player player, char column, int row)
        {
            if (GameStoneState.Free != Gameboard[column][row])
                return false;
            switch (player)
            {
                case Player.PlayerOne:
                    Gameboard[column][row] = GameStoneState.PlayerOne;
                    break;
                case Player.PlayerTwo:
                    Gameboard[column][row] = GameStoneState.PlayerTwo;
                    break;
            }
            Moves++;
            // we have added a stone, so check if the game is over
            CheckGameResult();
            return true;
        }

        private void CheckGameResult()
        {
            CheckWinner();

            if (Result == GameResult.Open)
            {
                CheckRemies();
            }

            if (Result == GameResult.Open)
            {
                if (Moves >= maxMoves)
                {
                    Result = GameResult.Remies;
                }
            }
        }

        public bool CheckValidCoordinate(char column, int row)
        {
            if (!Gameboard.ContainsKey(column))
                return false;
            if (Gameboard[column].Length <= row)
                return false;
            return true;
        }

        private void SetWinOpportunities()
        {
            WinOpportunities = new List<List<Coordinate>>();

            var c1 = new Coordinate();
            var c2 = new Coordinate();
            var c3 = new Coordinate();

            #region row 1
            var row1 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'a';
            c1.Row = 0;
            row1.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'b';
            c2.Row = 0;
            row1.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'c';
            c3.Row = 0;
            row1.Add(c3);
            WinOpportunities.Add(row1);
            #endregion row 1

            #region row 2
            var row2 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'a';
            c1.Row = 1;
            row2.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'b';
            c2.Row = 1;
            row2.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'c';
            c3.Row = 1;
            row2.Add(c3);
            WinOpportunities.Add(row2);
            #endregion row 2

            #region row 3
            var row3 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'a';
            c1.Row = 2;
            row3.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'b';
            c2.Row = 2;
            row3.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'c';
            c3.Row = 2;
            row3.Add(c3);
            WinOpportunities.Add(row3);
            #endregion row 3

            #region column 1
            var column1 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'a';
            c1.Row = 0;
            column1.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'a';
            c2.Row = 1;
            column1.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'a';
            c3.Row = 2;
            column1.Add(c3);
            WinOpportunities.Add(column1);
            #endregion column 1

            #region column 2
            var column2 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'b';
            c1.Row = 0;
            column2.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'b';
            c2.Row = 1;
            column2.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'b';
            c3.Row = 2;
            column2.Add(c3);
            WinOpportunities.Add(column2);
            #endregion column 2

            #region column 3
            var column3 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'c';
            c1.Row = 0;
            column3.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'c';
            c2.Row = 1;
            column3.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'c';
            c3.Row = 2;
            column3.Add(c3);
            WinOpportunities.Add(column3);
            #endregion column 3

            #region dig 1
            var dig1 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'a';
            c1.Row = 0;
            dig1.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'b';
            c2.Row = 1;
            dig1.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'c';
            c3.Row = 2;
            dig1.Add(c3);
            WinOpportunities.Add(dig1);
            #endregion dig 1

            #region dig 2
            var dig2 = new List<Coordinate>();
            c1 = new Coordinate();
            c1.Column = 'a';
            c1.Row = 2;
            dig2.Add(c1);
            c2 = new Coordinate();
            c2.Column = 'b';
            c2.Row = 1;
            dig2.Add(c2);
            c3 = new Coordinate();
            c3.Column = 'c';
            c3.Row = 0;
            dig2.Add(c3);
            WinOpportunities.Add(dig2);
            #endregion dig 2
        }

        private void CheckWinner()
        {
            foreach (List<Coordinate> opportunity in WinOpportunities)
            {
                if (Gameboard[opportunity[0].Column][opportunity[0].Row] == Gameboard[opportunity[1].Column][opportunity[1].Row]
                    && Gameboard[opportunity[0].Column][opportunity[0].Row] == Gameboard[opportunity[2].Column][opportunity[2].Row])
                {
                    // all stones have the same value -> chek who is the winner
                    switch (Gameboard[opportunity[0].Column][opportunity[0].Row])
                    {
                        case GameStoneState.PlayerOne:
                            Result = GameResult.PlayerOneWins;
                            return;
                        case GameStoneState.PlayerTwo:
                            Result = GameResult.PalyerTwoWins;
                            return;
                    }
                    // stone are all free, no new geme result, check next
                }
            }
        }

        private void CheckRemies()
        {
            // the condition to detect a Remies
            // every condition has at least min one of both game stones
            // so we do some math
            int FailedWinOpportunities = 0;
            foreach (List<Coordinate> opportunity in WinOpportunities)
            {
                GameStoneState firstDetectedStone = GameStoneState.Free;
                foreach (Coordinate coord in opportunity)
                {
                    // set first stone
                    if (firstDetectedStone == GameStoneState.Free)
                    {
                        if (GameStoneState.Free != Gameboard[coord.Column][coord.Row])
                            firstDetectedStone = Gameboard[coord.Column][coord.Row];
                    }
                    else
                    {
                        // check with the first stone
                        if (GameStoneState.Free != Gameboard[coord.Column][coord.Row])
                        {
                            if (firstDetectedStone != Gameboard[coord.Column][coord.Row])
                            {
                                FailedWinOpportunities++;
                                break;                                
                            }
                        }
                    }
                }
            }

            if (WinOpportunities.Count == FailedWinOpportunities)
            {
                Result = GameResult.Remies;
            }
        }
    }
}
