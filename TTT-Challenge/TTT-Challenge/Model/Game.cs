using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Challenge.Model
{
    public class Game
    {
        public GameResult Result { get; set; }
        public int MovesPlayerOne { get; set; }
        public int MovesPlayerTwo { get; set; }


        public Game()
        {
            // Set default value for the new game
            Result = GameResult.Open;
            MovesPlayerOne = 0;
            MovesPlayerTwo = 0;
        }
    }
}
