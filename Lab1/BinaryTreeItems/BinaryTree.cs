using System;
using System.Collections.Generic;

namespace Lab1.BinaryTreeItems
{
    public class BinaryTree
    {
        public BinaryTreeNode RootNode { get; set; }

        public void Insert(BinaryTreeNode node)
        {
            var currentNode = RootNode;

            while (true)
            {
                if (currentNode.Value.Price > node.Value.Price)
                {
                    currentNode = currentNode.Right;
                }
                else if (currentNode.Value.Price > node.Value.Price)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    Console.WriteLine("Already exists");
                    break;
                }
            }
        }
    }
}