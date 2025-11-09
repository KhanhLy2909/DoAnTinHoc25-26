using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Ly_Winf
{
    public class AVLTree
    {
        public AVLNode Root;

        private int Height(AVLNode n) => n?.Height ?? 0;

        private int GetBalance(AVLNode n) => n == null ? 0 : Height(n.Left) - Height(n.Right);

        private AVLNode RotateRight(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private AVLNode RotateLeft(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public AVLNode Insert(AVLNode node, int key, string[] data)
        {
            if (node == null) return new AVLNode(key, data);

            if (key < node.Key)
                node.Left = Insert(node.Left, key, data);
            else if (key > node.Key)
                node.Right = Insert(node.Right, key, data);
            else
            {
                node.Data = data;
                return node;
            }

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

            // Left Left
            if (balance > 1 && key < node.Left.Key)
                return RotateRight(node);

            // Right Right
            if (balance < -1 && key > node.Right.Key)
                return RotateLeft(node);

            // Left Right
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right Left
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }


        public void InOrder(AVLNode node, List<string[]> result)
        {
            if (node == null) return;
            InOrder(node.Left, result);
            result.Add(node.Data);
            InOrder(node.Right, result);
        }


        public int GetHeight()
        {
            return Height(Root);
        }

        public int CountLeafNodes()
        {
            return CountLeafNodes(Root);
        }

        private int CountLeafNodes(AVLNode node)
        {
            if (node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;
            return CountLeafNodes(node.Left) + CountLeafNodes(node.Right);
        }

        public int FindMin()
        {
            if (Root == null) throw new Exception("Cây rỗng!");
            AVLNode current = Root;
            while (current.Left != null)
                current = current.Left;
            return current.Key;
        }

        public int FindMax()
        {
            if (Root == null) throw new Exception("Cây rỗng!");
            AVLNode current = Root;
            while (current.Right != null)
                current = current.Right;
            return current.Key;
        }

        public AVLNode Search(AVLNode node, int key)
        {
            if (node == null)
                return null;

            if (key == node.Key)
                return node;
            else if (key < node.Key)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);
        }


    }
}
