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
 
    public enum Player
    {
        None,
        PlayerOne,
        PlayerTwo,
    }

    public enum CommandState
    {
        QuitGame,
        UnknownCommand,
        GetStone,
        GetStoneOnceAgainUnknownCommand,
        GetStoneOnceAgainOccupiedField,
    }
}
