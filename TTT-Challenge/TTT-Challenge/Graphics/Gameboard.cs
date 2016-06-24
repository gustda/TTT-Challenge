using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Challenge.Model;

namespace TTT_Challenge.Graphics
{
    static class Gameboard
    {
        public static void PrintGameBoard(Game actGame)
        {
            // first we start with a print of a gameboard without 
            // handling any gamestones
            Console.WriteLine(" A B C");
            Console.WriteLine("0 | | ");
            Console.WriteLine(" -+-+-");
            Console.WriteLine("1 | | ");
            Console.WriteLine(" -+-+-");
            Console.WriteLine("2 | | ");
        }
    }
}
