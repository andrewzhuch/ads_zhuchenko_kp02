using System;
public enum BinSide
{
    Left,
    Right
}
public class BinaryTree
{
    public int? Data { get; private set; } //ordinary data is an integer but it can be a null as well, so i used System.Nullable<T> in simple form '?'
    public BinaryTree Left { get; set; }
    public BinaryTree Right { get; set; }
    public BinaryTree Parent { get; set; }
    public void InsertValue(int data)
    {
        if (Data == null || Data == data)
        {
            Data = data;
            return;
        }
        if (Data > data)
        {
            if (Left == null)
            {
                Left = new BinaryTree();
            }
            Insert(data, Left, this);
        }
        else
        {
            if (Right == null)
            {
                Right = new BinaryTree();
            }
            Insert(data, Right, this);
        }
    }
    private void Insert(int data, BinaryTree node, BinaryTree parent)
    {
 
        if (node.Data == null || node.Data == data)
        {
            node.Data = data;
            node.Parent = parent;
            return;
        }
        if (node.Data > data)
        {
            if (node.Left == null)
            {
                node.Left = new BinaryTree();
            }
            Insert(data, node.Left, node);
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new BinaryTree();
            }
            Insert(data, node.Right, node);
        }
    }
    public static void Print(BinaryTree node)
    {
        if (node != null)
        {
            if (node.Parent == null)
            {
                Console.WriteLine("ROOT:{0}", node.Data);
            }
            else
            {
                if (node.Parent.Left == node)
                {
                    Console.WriteLine("Left for {1}  --> {0}", node.Data, node.Parent.Data);
                }
 
                if (node.Parent.Right == node)
                {
                    Console.WriteLine("Right for {1} --> {0}", node.Data, node.Parent.Data);
                }
            }
            if (node.Left != null)
            {
                Print(node.Left);
            }
            if (node.Right != null)
            {
                Print(node.Right);
            }
        }
    }
}
