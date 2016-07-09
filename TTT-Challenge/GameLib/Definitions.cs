using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
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
        Free=0,
        PlayerOne=1,
        PlayerTwo=2,
    }           
 
    public enum Player
    {
        None,
        PlayerOne,
        PlayerTwo,
    }

    public enum CommandState
    {
        ShowHelp,
        QuitGame,
        UnknownCommand,
        GetStone,
        GetStoneOnceAgainUnknownCommand,
        GetStoneOnceAgainOccupiedField,
    }
}
