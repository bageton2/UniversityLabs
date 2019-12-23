using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Practice2_1
{
    public class BinaryTreeNode<T> : IEnumerable where T : IComparable
    {
        private T Data { get; set; }

        public delegate void DelegateHandler(string message);
        public event DelegateHandler Notify;
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        private BinaryTreeNode<T> LeftNode { get; set; }

        private BinaryTreeNode<T> RightNode { get; set; }

        public void Add(BinaryTreeNode<T> newBinaryTree)
        {
            Notify?.Invoke($"New binary node {newBinaryTree.Data} added!");

            if (this.Data.CompareTo(newBinaryTree.Data) > 0)
            {
                if (this.LeftNode == null)
                {
                    this.LeftNode = newBinaryTree;
                }
                else
                {
                    this.LeftNode.Add(newBinaryTree);
                }
            }
            else
            {
                if (this.RightNode == null)
                {
                    this.RightNode = newBinaryTree;
                }
                else
                {
                    this.RightNode.Add(newBinaryTree);
                }
            }

        }

        public void PrintTree(int deepth = 0)
        {
            string indent = new string(' ', deepth);
            Console.WriteLine(indent + Data.ToString());

            deepth += 4;

            LeftNode?.PrintTree(deepth);
            RightNode?.PrintTree(deepth);
        }

        public IEnumerator GetEnumerator()
        {
            if (LeftNode != null)
            {
                foreach (var left in LeftNode)
                {
                    yield return left;
                }   
            }

            yield return Data;

            if (RightNode != null)
            {
                foreach (var right in RightNode)
                {
                    yield return right;
                }
            }
        }
    }
}
