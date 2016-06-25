using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Challenge.Model
{
    public class Game
    {
        public GameResult Result { get; private set; }

        public Dictionary<char, GameStoneState[]> Gameboard;
        private int Moves=0;
        private const int maxMoves=9;

        public Game()
        {
            // Set default value for the new game
            Result = GameResult.Open;

            // setup a clear gameboard
            InitGameboard();
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
            switch(player)
            {
                case Player.PlayerOne:
                    Gameboard[column][row] = GameStoneState.PlayerOne;
                    break;
                case Player.PlayerTwo:
                    Gameboard[column][row] = GameStoneState.PlayerTwo;
                    break;
            }
            Moves++;
            CheckGameResult();
            return true;
        }

        private void CheckGameResult()
        {
            if(Moves>=maxMoves)
            {
                Result = GameResult.Remies;
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
    }
}
