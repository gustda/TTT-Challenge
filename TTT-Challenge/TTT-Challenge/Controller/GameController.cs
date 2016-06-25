﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Challenge.Graphics;
using TTT_Challenge.Model;

namespace TTT_Challenge.Controller
{
    class GameController
    {
        private Game actGame;

        public GameController()
        { }

        private void StartGame()
        {
            // generate a new instance of game
            actGame = new Game();
        }

        private string NextCommand = "";

        public void Run()
        {
            // we have to start a new Game
            StartGame();

            // we have to do some Output
            ConsoleOutputController.PrintGamePlayOutput(actGame);

            // print command to inform the player, what is to do next
            ConsoleOutputController.PrintCommand(NextCommand);

            // Wait for user interaction
            Console.ReadLine();
            return;
        }
    }
}