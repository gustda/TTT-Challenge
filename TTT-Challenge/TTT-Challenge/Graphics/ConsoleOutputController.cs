using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Challenge.Model;

namespace TTT_Challenge.Graphics
{
    static class ConsoleOutputController
    {
        public static void PrintGamePlayOutput(Game actGame)
        {
            // Print Gameboard
            Gameboard.PrintGameBoard(actGame);                       
        }

        public static void PrintCommand(string command)
        {
            // check the command
            if (command != "")
            {
                Console.WriteLine(command);
            }
            else
            {
                // print default text if no command is set.
                Console.WriteLine("Hier könnte ein Commando stehen.");
                Console.Write("Kommando: ");
            }
        }
    }
}
