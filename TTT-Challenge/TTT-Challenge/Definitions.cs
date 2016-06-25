using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Challenge
{
    public enum GameResult
    {
        Open,
        PlayerOneWins,
        PalyerTwoWins,
        Remies,
    }

    public enum GameStoneState
    {
        Free,
        PlayerOne,
        PlayerTwo,
    }            

    public enum CommandState
    {
        UnknownCommand,
    }
}
