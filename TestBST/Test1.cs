using NUnit.Framework;
using System;
using System.IO;
using BST_CA;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestBST
{
    public class BinarySearchTreeTests
    {
        private BinarySearchTree bst;

        [SetUp]
        public void Setup()
        {
            bst = new BinarySearchTree();
        }

        [Test]
        public void Insert_And_Search_Test()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);

            Assert.IsTrue(bst.Search(50));
            Assert.IsTrue(bst.Search(30));
            Assert.IsTrue(bst.Search(70));
            Assert.IsFalse(bst.Search(90));
        }

        [Test]
        public void Delete_NodeWithNoChildren_Test()
        {
            bst.Insert(40);
            bst.Insert(20);
            bst.Insert(60);

            Assert.IsTrue(bst.Delete(20));
            Assert.IsFalse(bst.Search(20));
        }

        [Test]
        public void Delete_NodeWithOneChild_Test()
        {
            bst.Insert(40);
            bst.Insert(20);
            bst.Insert(10); // child of 20

            Assert.IsTrue(bst.Delete(20));
            Assert.IsFalse(bst.Search(20));
            Assert.IsTrue(bst.Search(10));
        }

        [Test]
        public void Delete_NodeWithTwoChildren_Test()
        {
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);

            Assert.IsTrue(bst.Delete(70));
            Assert.IsFalse(bst.Search(70));
            Assert.IsTrue(bst.Search(60));
            Assert.IsTrue(bst.Search(80));
        }

        [Test]
        public void InOrderTraversal_Test()
        {
            bst.Insert(40);
            bst.Insert(20);
            bst.Insert(60);
            bst.Insert(10);
            bst.Insert(30);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                bst.InOrder();
                Assert.AreEqual("10 20 30 40 60 \n", sw.ToString());
            }
        }

        [Test]
        public void PreOrderTraversal_Test()
        {
            bst.Insert(40);
            bst.Insert(20);
            bst.Insert(60);
            bst.Insert(10);
            bst.Insert(30);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                bst.PreOrder();
                Assert.AreEqual("40 20 10 30 60 \n", sw.ToString());
            }
        }

        [Test]
        public void PostOrderTraversal_Test()
        {
            bst.Insert(40);
            bst.Insert(20);
            bst.Insert(60);
            bst.Insert(10);
            bst.Insert(30);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                bst.PostOrder();
                Assert.AreEqual("10 30 20 60 40 \n", sw.ToString());
            }
        }
    }
}
