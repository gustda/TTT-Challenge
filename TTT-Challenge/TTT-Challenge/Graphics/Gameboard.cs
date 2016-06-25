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
            Console.WriteLine();
            Console.WriteLine("   A B C");
            Console.WriteLine(" 0 {0}|{1}|{2}",
                GetGameStone(actGame.Gameboard['a'][0]),
                GetGameStone(actGame.Gameboard['b'][0]),
                GetGameStone(actGame.Gameboard['c'][0]));
            Console.WriteLine("   -+-+-");
            Console.WriteLine(" 1 {0}|{1}|{2}",
                GetGameStone(actGame.Gameboard['a'][1]),
                GetGameStone(actGame.Gameboard['b'][1]),
                GetGameStone(actGame.Gameboard['c'][1]));
            Console.WriteLine("   -+-+-");
            Console.WriteLine(" 2 {0}|{1}|{2}",
                GetGameStone(actGame.Gameboard['a'][2]),
                GetGameStone(actGame.Gameboard['b'][2]),
                GetGameStone(actGame.Gameboard['c'][2]));
            Console.WriteLine();
        }

        private static string GetGameStone(GameStoneState state)
        {
            switch (state)
            {
                case GameStoneState.Free:
                    return " ";
                case GameStoneState.PlayerOne:
                    return "X";
                case GameStoneState.PlayerTwo:
                    return "O";
            }
            return "";
        }
    }
}
