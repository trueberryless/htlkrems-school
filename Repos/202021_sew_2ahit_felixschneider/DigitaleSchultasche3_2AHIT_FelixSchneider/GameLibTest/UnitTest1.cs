using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibary;

namespace GameLibTest
{
    [TestClass]
    public class UnitTest1
    {
        TicTacToe ttt = new TicTacToe();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual('a', ttt.SetElement(1));
            Assert.AreEqual('0', ttt.GetWinner());
            Assert.AreEqual('b', ttt.SetElement(4));
            Assert.AreEqual('0', ttt.GetWinner());
            Assert.AreEqual('a', ttt.SetElement(2));
            Assert.AreEqual('0', ttt.GetWinner());
            Assert.AreEqual('b', ttt.SetElement(5));
            Assert.AreEqual('0', ttt.GetWinner());
            Assert.AreEqual('a', ttt.SetElement(3));
            Assert.AreEqual('a', ttt.GetWinner());
        }
    }
}
