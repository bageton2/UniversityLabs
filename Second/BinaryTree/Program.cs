using System;

namespace Practice2_1
{
    class Program
    {
        static void Main(string[] args) 
        {

            var binaryTree = new BinaryTreeNode<Student>(new Student("Fred", "Math", 1, new DateTime().Date));

            binaryTree.Notify += DisplayMessage;

            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", 1, new DateTime().Date)));
            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", 2, new DateTime().Date)));
            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", 3, new DateTime().Date)));
            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", 0, new DateTime().Date)));
            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", -1, new DateTime().Date)));
            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", 0.4, new DateTime().Date)));
            binaryTree.Add(new BinaryTreeNode<Student>(new Student("Fred", "Math", 1.2, new DateTime().Date)));
            
            foreach ( var a in binaryTree)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine(new string('_',12));

            binaryTree.PrintTree();
        }
        
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
