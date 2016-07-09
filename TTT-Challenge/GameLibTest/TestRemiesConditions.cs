using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib.Model;
using GameLib;

namespace TTT_Challenge_Test
{
    [TestClass]
    public class TestRemiesConditions
    {
        // X O X
        //   X O
        // O X O
        [TestMethod]
        public void TestCondition1()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'a', 0);
            testGame.SetStone(Player.PlayerOne, 'b', 1);
            testGame.SetStone(Player.PlayerOne, 'b', 2);
            testGame.SetStone(Player.PlayerOne, 'c', 0);

            testGame.SetStone(Player.PlayerTwo, 'a', 2);
            testGame.SetStone(Player.PlayerTwo, 'b', 0);
            testGame.SetStone(Player.PlayerTwo, 'c', 1);
            testGame.SetStone(Player.PlayerTwo, 'c', 2);

            Assert.IsTrue(testGame.Result == GameResult.Remies);
        }
    }
}
