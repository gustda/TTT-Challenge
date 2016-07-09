using GameLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write("Kommando: ");
            }
            else
            {
                // print default text if no command is set.
                Console.WriteLine("Fehler: Hier sollte ein Kommando stehen.");                
            }
        }

        public static void PrintHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Es können die folgenden Kommandos verwendet werden:");
            Console.WriteLine("- '?' zeigt die Hilfe an ;-)");
            Console.WriteLine("- 'neu' Startet ein neues Spiel.");
            Console.WriteLine("- 'ende' Beendet das Spiel.");
            Console.WriteLine("- 'a0' Setzte einen Stein auf das Feld A - 0, es können nach dem selben prinzip andere Koordinaten angegeben werden.");
            Console.WriteLine();
        }
    }
}
