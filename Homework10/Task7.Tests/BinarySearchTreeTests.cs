using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task7;

namespace Task7.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void BinarySearchTreeAdd()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(5, null);
            //var nodeToAdd1 = new Node<int, string>(1);
            //var nodeToAdd2 = new Node<int, string>(10);
            //var nodeToAdd3 = new Node<int, string>(3);
            bool expectedVal = true, retVal;
            //act
            retVal = binSearchTree.Add(1,null);
            binSearchTree.Add(10, null);
            binSearchTree.Add(3, null);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeAddInNullShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<string, string> binSearchTree = new BinarySearchTree<string, string>("5", null);
            //act
            binSearchTree.Add(null, null);
            //assert

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeRemoveInNullShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<string, string> binSearchTree = new BinarySearchTree<string, string>("5",null);
            //act
            binSearchTree.Remove(null);
            //assert

        }
        [TestMethod]
        public void BinarySearchTreeRemove()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(10, null);
            bool expectedVal = true, retVal;
            //act
            retVal = binSearchTree.Add(1, null);
            binSearchTree.Add(15, null);
            binSearchTree.Add(19, null);
            binSearchTree.Add(20, null);
            binSearchTree.Add(18, null);
            binSearchTree.Add(12, null);
            binSearchTree.Add(11, null);
            binSearchTree.Add(13, null);
            binSearchTree.Remove(15);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void BinarySearchTreeGetValueByKeyIn19OutYahoo()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(10,null);
            string expectedVal = "yahoo!", retVal;
            //act
            binSearchTree.Add(1, null);
            binSearchTree.Add(15, null);
            binSearchTree.Add(19, "yahoo!");
            binSearchTree.Add(20, null);
            binSearchTree.Add(18, null);
            binSearchTree.Add(12, null);
            binSearchTree.Add(11, null);
            binSearchTree.Add(13, null);
            retVal = binSearchTree.GetValueByKey(19);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearchTreeGetValueByKeyInNonExitingKeyShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(10,null);
            //act
            var retVal = binSearchTree.GetValueByKey(123);
            //assert
        }

        [TestMethod]
        public void BinarySearchTreeTraverseInOrder()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(10, null);
            IEnumerable<int> expectedVal = new int[] { 1, 10, 11, 12, 13, 15, 18, 19, 20 };
            IEnumerable<int> retVal;
            //act
            binSearchTree.Add(1, null);
            binSearchTree.Add(15, null);
            binSearchTree.Add(19, null);
            binSearchTree.Add(20, null);
            binSearchTree.Add(18, null);
            binSearchTree.Add(12, null);
            binSearchTree.Add(11, null);
            binSearchTree.Add(13, null);
            retVal = binSearchTree.Traverse(TraverseOrder.inorder);
            //assert
            IEnumerator<int> enumExpectedVal = expectedVal.GetEnumerator();
            IEnumerator<int> enumRetVal = retVal.GetEnumerator();
            while (enumExpectedVal.MoveNext())
            {
                enumRetVal.MoveNext();
                Assert.AreEqual(enumExpectedVal.Current, enumRetVal.Current);
            }
        }
        [TestMethod]
        public void BinarySearchTreeTraversePostOrder()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(10, null);
            IEnumerable<int> expectedVal = new int[] { 1, 11, 13, 12, 18, 20, 19, 15, 10 };
            IEnumerable<int> retVal;
            //act
            binSearchTree.Add(1, null);
            binSearchTree.Add(15, null);
            binSearchTree.Add(19, null);
            binSearchTree.Add(20, null);
            binSearchTree.Add(18, null);
            binSearchTree.Add(12, null);
            binSearchTree.Add(11, null);
            binSearchTree.Add(13, null);
            retVal = binSearchTree.Traverse(TraverseOrder.postorder);
            //assert
            IEnumerator<int> enumExpectedVal = expectedVal.GetEnumerator();
            IEnumerator<int> enumRetVal = retVal.GetEnumerator();
            while (enumExpectedVal.MoveNext())
            {
                enumRetVal.MoveNext();
                Assert.AreEqual(enumExpectedVal.Current, enumRetVal.Current);
            }
        }
        [TestMethod]
        public void BinarySearchTreeTraversePreOrder()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(10, null);
            IEnumerable<int> expectedVal = new int[] { 10, 1, 15, 12, 11, 13, 19, 18, 20 };
            IEnumerable<int> retVal;
            //act
            binSearchTree.Add(1, null);
            binSearchTree.Add(15, null);
            binSearchTree.Add(19, null);
            binSearchTree.Add(20, null);
            binSearchTree.Add(18, null);
            binSearchTree.Add(12, null);
            binSearchTree.Add(11, null);
            binSearchTree.Add(13, null);
            retVal = binSearchTree.Traverse(TraverseOrder.preorder);
            //assert
            IEnumerator<int> enumExpectedVal = expectedVal.GetEnumerator();
            IEnumerator<int> enumRetVal = retVal.GetEnumerator();
            while (enumExpectedVal.MoveNext())
            {
                enumRetVal.MoveNext();
                Assert.AreEqual(enumExpectedVal.Current, enumRetVal.Current);
            }
        }
    }
}
