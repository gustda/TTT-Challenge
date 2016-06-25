using System;
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

        private void StartGame()
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
                // we have to do some Output
                ConsoleOutputController.PrintGamePlayOutput(ActGame);

                // print command to inform the player, what is to do next
                var nextPrompt = GetNextPlayersPrompt();
                ConsoleOutputController.PrintCommand(nextPrompt);

                // Wait for user interaction
                var userInput = Console.ReadLine();
                // process user input
                NextCommandState = CheckAndProcessCommand(userInput);
            } while (true);
        }

        private CommandState CheckAndProcessCommand(string command)
        {
            switch (command)
            {
                default:
                    return CommandState.UnknownCommand;
            }
        }

        public string GetNextPlayersPrompt()
        {
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
