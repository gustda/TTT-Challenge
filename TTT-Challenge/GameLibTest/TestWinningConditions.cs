﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib;
using GameLib.Model;

namespace TTT_Challenge_Test
{
    [TestClass]
    public class TestWinningConditions
    {
        [TestMethod]
        public void TestRow1()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'a', 0);
            testGame.SetStone(Player.PlayerOne, 'b', 0);
            testGame.SetStone(Player.PlayerOne, 'c', 0);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestRow2()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'a', 1);
            testGame.SetStone(Player.PlayerOne, 'b', 1);
            testGame.SetStone(Player.PlayerOne, 'c', 1);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestRow3()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'a', 2);
            testGame.SetStone(Player.PlayerOne, 'b', 2);
            testGame.SetStone(Player.PlayerOne, 'c', 2);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestCol1()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'a', 0);
            testGame.SetStone(Player.PlayerOne, 'a', 1);
            testGame.SetStone(Player.PlayerOne, 'a', 2);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestCol2()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'b', 0);
            testGame.SetStone(Player.PlayerOne, 'b', 1);
            testGame.SetStone(Player.PlayerOne, 'b', 2);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestCol3()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'c', 0);
            testGame.SetStone(Player.PlayerOne, 'c', 1);
            testGame.SetStone(Player.PlayerOne, 'c', 2);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestDig1()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'a', 0);
            testGame.SetStone(Player.PlayerOne, 'b', 1);
            testGame.SetStone(Player.PlayerOne, 'c', 2);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

        [TestMethod]
        public void TestDig2()
        {
            Game testGame = new Game();

            testGame.SetStone(Player.PlayerOne, 'c', 0);
            testGame.SetStone(Player.PlayerOne, 'b', 1);
            testGame.SetStone(Player.PlayerOne, 'a', 2);

            Assert.IsTrue(testGame.Result == GameResult.PlayerOneWins);
        }

    }
}
