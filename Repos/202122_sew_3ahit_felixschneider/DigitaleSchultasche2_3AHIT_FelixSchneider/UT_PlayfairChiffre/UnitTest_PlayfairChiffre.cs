using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayfairChiffre;

namespace UT_PlayfairChiffre
{
    [TestClass]
    public class UnitTest_PlayfairChiffre
    {
        [TestMethod]
        public void TestEncryption()
        {
            PlayfairChiffre.PlayfairChiffre pc = new PlayfairChiffre.PlayfairChiffre("Snowball");

            string test = pc.Encryption("Euston saw I was not Sue");
            Assert.AreEqual(test, "AZBMWOAFDRSDNOBQASCZ");
        }

        [TestMethod]
        public void TestDecryption()
        {
            PlayfairChiffre.PlayfairChiffre pc = new PlayfairChiffre.PlayfairChiffre("Snowball");

            string test = pc.Decryption("CAWLTAXWYMMENEKZ");
            Assert.AreEqual(test, "LENDMEYOURTABLET");
        }
    }
}