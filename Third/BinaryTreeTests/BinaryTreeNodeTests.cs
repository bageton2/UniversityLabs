using NUnit.Framework;
using Practice3_1;
using System;


namespace Practice3_1Tests
{
    public class BinaryTreeNodeTests
    {
        private BinaryTreeNode<Student> nodeStudent_20;
        private BinaryTreeNode<Student> nodeStudent_10;

        [SetUp]
        public void Initialize()
        {
            string studentName = "Jordan";
            string testName = "Math";
            int testScore_20 = 20;
            int testScore_10 = 10;
            DateTime testDate = DateTime.Today;

            nodeStudent_10 = new BinaryTreeNode<Student>(new Student(studentName, testName, testScore_10, testDate));
            nodeStudent_20 = new BinaryTreeNode<Student>(new Student(studentName, testName, testScore_20, testDate));
        }


        [Test]
        public void Add_NewStudentNodeToPrevious_ShouldPutNewNodeToRightSideOfPrevious()
        {
            //act
            nodeStudent_10.Add(nodeStudent_20);

            //assert

            Assert.AreEqual(nodeStudent_10.LeftNode, null);
            Assert.AreEqual(nodeStudent_10.RightNode, nodeStudent_20);
        }

        [Test]
        public void Add_NewStudentNodeToPrevious_ShouldPutNewNodeToLeftSideOfPrevious()
        { 
            //act
            nodeStudent_20.Add(nodeStudent_10);

            //assert

            Assert.AreEqual(nodeStudent_20.RightNode, null);
            Assert.AreEqual(nodeStudent_20.LeftNode, nodeStudent_10);
        }

        [Test]
        public void Add_NewIntNodeToPrevious_ShouldPutNewNodeToRightSideOfPrevious()
        {
            //arrange

            BinaryTreeNode<int> binaryTree = new BinaryTreeNode<int>(10);

            BinaryTreeNode<int> node = new BinaryTreeNode<int>(20);

            // act

            binaryTree.Add(node);
            
            //assert

            Assert.AreEqual(binaryTree.LeftNode, null);
            Assert.AreEqual(binaryTree.RightNode, node);
        }

        [Test]
        public void GetDataByForeach_BinaryTree_10_4_12_Return_4_10_12()
        {
            //arrange
            BinaryTreeNode<int> binaryTree = new BinaryTreeNode<int>(10);
            binaryTree.Add(new BinaryTreeNode<int>(4));
            binaryTree.Add(new BinaryTreeNode<int>(12));

            // act

            string result = string.Empty;
            foreach(int item in binaryTree)
            {
                result += item;
            }

            //assert

            Assert.AreEqual(result, "41012");
        }

        [Test]
        public void Add_NodeStudent_10ToNodeStudent_20_NotifyInvoked()
        {
            // arrange

            bool invoked = false;
            nodeStudent_10.Notify += ((param) => invoked = true);

            // act

            nodeStudent_10.Add(nodeStudent_20);

            //assert
            Assert.IsTrue(invoked);

        }
    }
}
