using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib.Controller;
using GameLib;

namespace TTT_Challenge
{
    [TestClass]
    public class TestGetNextPlayersPrompt
    {
        private GameController testGameController;

        public TestGetNextPlayersPrompt()
        {
            testGameController = new GameController();            
        }

        [TestMethod]
        public void TestPlayer1GetStone()
        {
            string expected = "Spieler 1: Spielstein setzten";
            
            testGameController.ActPlayer = Player.PlayerOne;
            testGameController.NextCommandState = CommandState.GetStone;

            string testValue = testGameController.GetNextPlayersPrompt();

            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void TestPlayer1GetStoneOnceAgainOccupiedField()
        {
            string expected = "Spieler 1: Feld bereits belegt, erneut Spielstein setzten";

            testGameController.ActPlayer = Player.PlayerOne;
            testGameController.NextCommandState = CommandState.GetStoneOnceAgainOccupiedField;

            string testValue = testGameController.GetNextPlayersPrompt();

            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void TestPlayer1GetStoneOnceAgainUnknownCommand()
        {
            string expected = "Spieler 1: Eingabe ungültig, erneut Spielstein setzten";

            testGameController.ActPlayer = Player.PlayerOne;
            testGameController.NextCommandState = CommandState.GetStoneOnceAgainUnknownCommand;

            string testValue = testGameController.GetNextPlayersPrompt();

            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void TestPlayer1UnknownCommand()
        {
            string expected = "Spieler 1: Eingabe ungültig, erneut Spielstein setzten";

            testGameController.ActPlayer = Player.PlayerOne;
            testGameController.NextCommandState = CommandState.UnknownCommand;

            string testValue = testGameController.GetNextPlayersPrompt();

            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void TestPlayer2GetStone()
        {
            string expected = "Spieler 2: Spielstein setzten";

            testGameController.ActPlayer = Player.PlayerTwo;
            testGameController.NextCommandState = CommandState.GetStone;

            string testValue = testGameController.GetNextPlayersPrompt();

            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void TestPlayerNone()
        {
            string expected = "Alle Felder belegt, Spiel ist beendet.";

            testGameController.ActPlayer = Player.None;
            testGameController.NextCommandState = CommandState.GetStone;

            string testValue = testGameController.GetNextPlayersPrompt();

            Assert.AreEqual(expected, testValue);
        }
    }
}
