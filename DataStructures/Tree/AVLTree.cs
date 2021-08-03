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

        protected override void AfterAdd(Node<T> node)
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
                    Rebalance2(node);
                    break;
                }

            }
        }

        protected override void AfterRemove(Node<T> node)
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
                    Rebalance2(node);
                }

            }
        }


        public bool IsBalanced(Node<T> node)
        {
            return Math.Abs(((AVLNode)node).BalanceFactor()) <= 1;
        }

        protected override Node<T> CreateNode(T element, Node<T> node)
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
            if (parent.IsLeftChild())
            {
                if (node.IsLeftChild()) //LL
                {
                    RotateRight(grand);
                }
                else  //LR
                {
                    RotateLeft(parent);
                    RotateRight(grand);
                }
            }
            else
            {
                if (node.IsLeftChild()) //RL
                {
                    RotateRight(parent);
                    RotateLeft(grand);
                }
                else  //RR
                {
                    RotateLeft(grand);
                }
            }
        }


        /// <summary>
        /// 平衡操作
        /// </summary>
        /// <param name="grand"></param>
        private void Rebalance2(Node<T> grand)
        {
            var parent = ((AVLNode)grand).TallerChild();
            var node = ((AVLNode)parent).TallerChild();
            if (parent.IsLeftChild())
            {
                if (node.IsLeftChild()) //LL
                {
                    Rotate(grand, node.Left, node, node.Right, parent, parent.Right, grand, grand.Right);
                }
                else  //LR
                {
                    Rotate(grand, parent.Left, parent, node.Left, node, node.Right, grand, grand.Right);
                }
            }
            else
            {
                if (node.IsLeftChild()) //RL
                {
                    Rotate(grand, grand.Left, grand, node.Left, node, node.Right, parent, parent.Right);
                }
                else  //RR
                {
                    Rotate(grand, grand.Left, grand, parent.Left, parent, node.Left, node, node.Right);
                }
            }
        }

        private void Rotate(
            Node<T> r,
            Node<T> a, Node<T> b, Node<T> c, Node<T> d, Node<T> e, Node<T> f, Node<T> g)
        {
            d.Parent = r.Parent;
            if (r.IsLeftChild())
            {
                r.Parent.Left = d;
            }
            else if (r.IsRightChild())
            {
                r.Parent.Right = d;
            }
            else
            {
                _root = d;
            }

            //a-b-c
            b.Left = a;
            b.Right = c;
            if (a != null)
                a.Parent = b;
            if (c != null)
                c.Parent = b;

            UpdateHeight(b);

            //e-f-g
            f.Left = e;
            f.Right = g;
            if (e != null)
                e.Parent = f;
            if (g != null)
                g.Parent = f;

            UpdateHeight(f);


            //b-d-f
            d.Left = b;
            d.Right = f;
            b.Parent = d;
            f.Parent = d;
            UpdateHeight(d);


        }

        /// <summary>
        /// 左旋转
        /// </summary>
        /// <param name="node"></param>
        private void RotateLeft(Node<T> grand)
        {
            var parent = grand.Right;
            var child = parent.Left;
            grand.Right = child;
            parent.Left = grand;

            //1.让parent成为子树的根节点
            parent.Parent = grand.Parent;
            if (grand.IsLeftChild())
            {
                grand.Parent.Left = parent;
            }
            else if (grand.IsRightChild())
            {
                grand.Parent.Right = parent;
            }
            else //grand 是 root节点
            {
                _root = parent;
            }

            //2.
            if (child != null)
                child.Parent = grand;

            //3.更新grand parent
            grand.Parent = parent;

            //更新高度
            UpdateHeight(grand);
            UpdateHeight(parent);

        }

        /// <summary>
        /// 右旋转
        /// </summary>
        /// <param name="node"></param>
        private void RotateRight(Node<T> grand)
        {
            var parent = grand.Left;
            var child = parent.Right;
            grand.Left = child;
            parent.Right = grand;



            //1.让parent成为子树的根节点
            parent.Parent = grand.Parent;
            if (grand.IsLeftChild())
            {
                grand.Parent.Left = parent;
            }
            else if (grand.IsRightChild())
            {
                grand.Parent.Right = parent;
            }
            else //grand 是 root节点
            {
                _root = parent;
            }

            if (child != null)
                child.Parent = grand;

            //3.更新grand parent
            grand.Parent = parent;

            UpdateHeight(grand);
            UpdateHeight(parent);

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
                return IsLeftChild() ? Left : Right;
            }

            public override string ToString()
            {
                var parentStr = "null";
                if (Parent != null)
                    parentStr = Parent.Element.ToString();
                return Element + "_p(" + parentStr + ")_h(" + Height + ")";
            }
        }
    }
}
