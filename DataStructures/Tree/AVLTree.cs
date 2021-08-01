using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class AVLTree<T> : BinarySearchTree<T>
    {
        public AVLTree() : this(null)
        {

        }

        public AVLTree(Comparer<T> comparer) : base(comparer)
        {

        }

        protected new void AfterAdd(Node<T> node)
        {
            // while循环找到的是添加的节点网上找第一个不平衡的父节点
            while ((node = node.Parent) != null)
            {
                //是否平衡
                if (IsBalanced(node))
                {
                    //更新高度
                    UpdateHeight(node);
                }
                else
                {
                    //恢复平衡
                    Rebalance(node);
                    break;
                }

            }
        }

        public bool IsBalanced(Node<T> node)
        {
            return Math.Abs(((AVLNode)node).BalanceFactor()) <= 1;
        }

        protected new Node<T> CreateNode(T element, Node<T> node)
        {
            return new AVLNode(element, node);
        }

        private void UpdateHeight(Node<T> node)
        {
            ((AVLNode)node).UpdateHeight();
        }

        /// <summary>
        /// 平衡操作
        /// </summary>
        /// <param name="grand"></param>
        private void Rebalance(Node<T> grand)
        {
            var parent = ((AVLNode)grand).TallerChild();
            var node = ((AVLNode)parent).TallerChild();
        }

        public class AVLNode : Node<T>
        {
            public AVLNode(T element, Node<T> parent) : base(element, parent)
            {

            }
            public int Height { get; set; } = 1;

            public int BalanceFactor()
            {
                int leftHeight = Left == null ? 0 : ((AVLNode)Left).Height;
                int rightHeight = Right == null ? 0 : ((AVLNode)Right).Height;
                return leftHeight - rightHeight;
            }

            public void UpdateHeight()
            {
                int leftHeight = Left == null ? 0 : ((AVLNode)Left).Height;
                int rightHeight = Right == null ? 0 : ((AVLNode)Right).Height;
                Height = 1 + Math.Max(leftHeight, rightHeight);
            }

            public Node<T> TallerChild()
            {
                int leftHeight = Left == null ? 0 : ((AVLNode)Left).Height;
                int rightHeight = Right == null ? 0 : ((AVLNode)Right).Height;
                if (leftHeight > rightHeight) return Left;
                if (leftHeight < rightHeight) return Right;
                //高度一样返回 g节点相对于其父节点的位置方向一样
                return IsLeftChild() ? Left:Right;
            }
        }
    }
}
