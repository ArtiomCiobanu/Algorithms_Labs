using Lab1.Models;

namespace Lab1.BinaryTreeItems
{
    public class BinaryTreeNode
    {
        public Aircraft Value { get; set; }

        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public override string ToString() => Value.ToString();
    }
}