using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeeCode.Tree
{
    /// <summary>
    /// https://leetcode-cn.com/problems/invert-binary-tree/
    /// </summary>
    public class _226__翻转二叉树
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.left);

            InvertTree(root.right);

            return root;

        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
