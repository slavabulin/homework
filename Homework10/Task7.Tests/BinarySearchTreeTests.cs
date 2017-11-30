using System;
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
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(new Node<int, string>(5));
            var nodeToAdd1 = new Node<int, string>(1);
            var nodeToAdd2 = new Node<int, string>(10);
            var nodeToAdd3 = new Node<int, string>(3);
            bool expectedVal = true, retVal;
            //act
            retVal = binSearchTree.Add(nodeToAdd1, binSearchTree.root);
            binSearchTree.Add(nodeToAdd2, binSearchTree.root);
            binSearchTree.Add(nodeToAdd3, binSearchTree.root);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeAddInNullShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<string, string> binSearchTree = new BinarySearchTree<string, string>(new Node<string, string>("5"));
            var nodeToAdd1 = new Node<string, string>(null);
            //act
            binSearchTree.Add(nodeToAdd1, binSearchTree.root);
            //assert

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeRemoveInNullShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<string, string> binSearchTree = new BinarySearchTree<string, string>(new Node<string, string>("5"));
            var nodeToAdd1 = new Node<string, string>(null);
            //act
            binSearchTree.Remove(nodeToAdd1, binSearchTree.root);
            //assert

        }
        [TestMethod]
        public void BinarySearchTreeRemove()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(new Node<int, string>(10));
            bool expectedVal = true, retVal;
            //act
            retVal = binSearchTree.Add(new Node<int, string>(1), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(15), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(19), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(20), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(18), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(12), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(11), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(13), binSearchTree.root);
            binSearchTree.Remove(new Node<int, string>(15), binSearchTree.root);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        public void BinarySearchTreeGetValueByKeyIn19OutYahoo()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(new Node<int, string>(10));
            string expectedVal = "yahoo!", retVal;
            //act
            binSearchTree.Add(new Node<int, string>(1), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(15), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(19, "yahoo!"), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(20), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(18), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(12), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(11), binSearchTree.root);
            binSearchTree.Add(new Node<int, string>(13), binSearchTree.root);
            retVal = binSearchTree.GetValueByKey(19, binSearchTree.root);
            //assert
            Assert.AreEqual(expectedVal, retVal);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeGetValueByKeyInNullShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(new Node<int, string>(10));
            //act
            var retVal = binSearchTree.GetValueByKey(123, null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearchTreeGetValueByKeyInNonExitingKeyShouldThrowExcptn()
        {
            //arrange
            BinarySearchTree<int, string> binSearchTree = new BinarySearchTree<int, string>(new Node<int, string>(10));
            //act
            var retVal = binSearchTree.GetValueByKey(123, binSearchTree.root);
            //assert
        }


    }
}
