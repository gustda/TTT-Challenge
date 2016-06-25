using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TTT_Challenge.Controller;

namespace TTT_Challenge
{
    [TestClass]
    public class TestCheckAndProcessCommand
    {
        private GameController testGameController = new GameController();

        public TestCheckAndProcessCommand()
        {
            testGameController.StartGame();
        }

        [TestMethod]
        public void TestInvalidCoordinateInput()
        {
            string input="D4";
            CommandState expected= CommandState.UnknownCommand;

            var actual=testGameController.CheckAndProcessCommand(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFreeField()
        {
            string input = "a1";
            CommandState expected = CommandState.GetStone;

            var actual = testGameController.CheckAndProcessCommand(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOccupiedField()
        {
            string input = "a1";
            CommandState expected = CommandState.GetStoneOnceAgainOccupiedField;

            // set field one time
            testGameController.CheckAndProcessCommand(input);
            // set the same field again
            var actual = testGameController.CheckAndProcessCommand(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
