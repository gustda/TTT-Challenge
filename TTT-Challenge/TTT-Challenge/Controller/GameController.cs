﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Challenge.Graphics;
using TTT_Challenge.Model;

namespace TTT_Challenge.Controller
{
    public class GameController
    {
        private Game ActGame;

        public GameController()
        {

        }

        public void StartGame()
        {
            // generate a new instance of game
            ActGame = new Game();
            NextCommandState = CommandState.GetStone;
            ActPlayer = Player.PlayerOne;
        }

        public CommandState NextCommandState { get; set; }
        public Player ActPlayer { get; set; }

        public void Run()
        {
            // we have to start a new Game
            StartGame();
            do
            {
                Console.Clear();
                // we have to do some Output
                ConsoleOutputController.PrintGamePlayOutput(ActGame);

                if(NextCommandState == CommandState.ShowHelp)
                {
                    // the player have requestet a Help message -> print it
                    ConsoleOutputController.PrintHelp();
                    // set NextCommand, to GetStone
                    NextCommandState = CommandState.GetStone;
                }

                // print command to inform the player, what is to do next
                var nextPrompt = GetNextPlayersPrompt();
                ConsoleOutputController.PrintCommand(nextPrompt);

                // Wait for user interaction
                var userInput = Console.ReadLine();
                // process user input
                NextCommandState = CheckAndProcessCommand(userInput);
            } while (NextCommandState!= CommandState.QuitGame);
            // quit game by leaving loop, so we return to Main() and leave the program
        }

        public CommandState CheckAndProcessCommand(string command)
        {
            command=command.ToLower();
            if (ActGame.Result == GameResult.Open)
            {
                // process stone input, only stone commands have a length of two chars
                if (command.Length == 2)
                {
                   return ProcessStoneCommand(command);
                }
            }

            // process non gameplay commands
            switch (command)
            {
                case "neu":
                    StartGame();
                    return NextCommandState;
                case "ende":
                    return CommandState.QuitGame;
                case "?":
                    return CommandState.ShowHelp;

                default:
                    return CommandState.UnknownCommand;
            }
        }

        private CommandState ProcessStoneCommand(string command)
        {
            char column = command[0];
            int row;
            try
            {
                row = Convert.ToInt16(command.Substring(1));
            }
            catch
            {
                return CommandState.UnknownCommand;
            }
            if (ActGame.CheckValidCoordinate(column, row))
            {
                if (ActGame.SetStone(ActPlayer, command[0], row))
                {
                    NextPlayer();
                    return CommandState.GetStone;
                }
                else
                {
                    return CommandState.GetStoneOnceAgainOccupiedField;
                }
            }
            return CommandState.UnknownCommand;
        }

        private void NextPlayer()
        {
            if (ActPlayer == Player.None)
            {
                ActPlayer = Player.PlayerOne;
                return;
            }
            if (ActPlayer == Player.PlayerOne)
            {
                ActPlayer = Player.PlayerTwo;
                return;
            }
            if (ActPlayer == Player.PlayerTwo)
                ActPlayer = Player.PlayerOne;

        }

        public string GetNextPlayersPrompt()
        {
            if(ActGame.Result!= GameResult.Open)
            {
                switch(ActGame.Result)
                {
                    case GameResult.Remies:
                        return "Game Over";
                    default:
                        return "Not yet implemented";
                }
            }

            string playerText = "";
            switch (ActPlayer)
            {
                case Player.None:
                    // game over, return from here, we don't have to do anything more
                    return "Alle Felder belegt, Spiel ist beendet.";

                case Player.PlayerOne:
                    playerText = "Spieler 1: ";
                    break;
                case Player.PlayerTwo:
                    playerText = "Spieler 2: ";
                    break;
            }

            string commandText = "";
            switch (NextCommandState)
            {
                case CommandState.GetStone:
                    commandText = "Spielstein setzten";
                    break;
                case CommandState.GetStoneOnceAgainOccupiedField:
                    commandText = "Feld bereits belegt, erneut Spielstein setzten";
                    break;
                case CommandState.GetStoneOnceAgainUnknownCommand:
                case CommandState.UnknownCommand:
                    commandText = "Eingabe ungültig, erneut Spielstein setzten";
                    break;
            }

            var output = String.Format("{0}{1}", playerText, commandText);
            return output;
        }
    }
}
