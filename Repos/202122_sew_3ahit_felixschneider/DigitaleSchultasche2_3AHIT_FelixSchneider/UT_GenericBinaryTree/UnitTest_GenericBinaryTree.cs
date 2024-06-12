using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericBinaryTree;

namespace UT_GenericBinaryTree
{
    [TestClass]
    public class UnitTest_GenericBinaryTree
    {
        [TestMethod]
        public void TestFind()
        {
            GenericTree<int> genericTree = new GenericTree<int>();
            genericTree.Insert(new int[] { 7, 1, 4, 2, 8, 3, 9 });
            Assert.AreEqual(genericTree.Find(8), genericTree.Root.Right);
        }

        [TestMethod]
        public void TestInsert()
        {
            GenericTree<int> genericTree = new GenericTree<int>();
            genericTree.Insert(new int[] { 7, 1, 4, 2, 8, 3, 9 });
            genericTree.Insert(6);
            genericTree.Insert(new Node<int>(5));
            Assert.AreEqual(genericTree.Root.Left.Data, 1);
            Assert.AreEqual(genericTree.Root.Left.Right.Left.Data, 2);
            Assert.AreEqual(genericTree.Root.Left.Right.Left.Right.Data, 3);
            Assert.AreEqual(genericTree.Root.Left.Right.Data, 4);
            Assert.AreEqual(genericTree.Root.Left.Right.Right.Left.Data, 5);
            Assert.AreEqual(genericTree.Root.Left.Right.Right.Data, 6);
            Assert.AreEqual(genericTree.Root.Data, 7);
            Assert.AreEqual(genericTree.Root.Right.Data, 8);
            Assert.AreEqual(genericTree.Root.Right.Right.Data, 9);
        }

        [TestMethod]
        public void TestGetDepth()
        {
            GenericTree<int> genericTree = new GenericTree<int>();
            genericTree.Insert(4);
            genericTree.Insert(1);
            genericTree.Insert(6);
            genericTree.Insert(7);
            genericTree.Insert(8);
            Assert.AreEqual(genericTree.GetDepth(), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(TreeIsEmpty))]
        public void TestTreeIsEmpty()
        {
            GenericTree<int> genericTree = new GenericTree<int>();
            genericTree.InOrder();
        }
    }
}
