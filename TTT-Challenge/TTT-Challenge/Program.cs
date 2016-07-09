using GameLib;
using GameLib.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Challenge.Graphics;


namespace TTT_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new GameController();
            do
            {
                Console.Clear();
                // we have to do some Output
                ConsoleOutputController.PrintGamePlayOutput(controller.ActGame);

                if (controller.NextCommandState == CommandState.ShowHelp)
                {
                    // the player have requestet a Help message -> print it
                    ConsoleOutputController.PrintHelp();
                    // set NextCommand, to GetStone
                    controller.NextCommandState = CommandState.GetStone;
                }

                // print command to inform the player, what is to do next
                var nextPrompt = controller.GetNextPlayersPrompt();
                ConsoleOutputController.PrintCommand(nextPrompt);

                // Wait for user interaction
                var userInput = Console.ReadLine();
                // process user input
                controller.NextCommandState = controller.CheckAndProcessCommand(userInput);
            } while (controller.NextCommandState != CommandState.QuitGame);
            // quit game by leaving loop, so we return from Main() and leave the program
        }
    }
}
