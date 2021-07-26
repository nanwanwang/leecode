using System;
using System.Collections.Generic;
using System.Text;

namespace TreePointer
{
    /**

   ┌───381────┐
   │          │
┌─12─┐     ┌─410─┐
│    │     │     │
9  ┌─40─┐ 394 ┌─540─┐
   │    │     │     │
  35 ┌─190 ┌─476 ┌─760─┐
     │     │     │     │
    146   445   600   800
    
 * @author MJ Lee
 *
 */
    public class LevelOrderPrinter : Printer
    {
        /**
         * 节点之间允许的最小间距（最小只能填1）
         */
        private static int MIN_SPACE = 1;
        private Node root;
        private int minX;
        private int maxWidth;

        public LevelOrderPrinter(BinaryTreeInfo tree) : base(tree)
        {

            root = new Node(tree.Root(), tree);
            maxWidth = root.width;
        }


        public override string PrintString()
        {
            // nodes用来存放所有的节点
            List<List<Node>> nodes = new List<List<Node>>();
            fillNodes(nodes);
            cleanNodes(nodes);
            compressNodes(nodes);
            addLineNodes(nodes);

            int rowCount = nodes.Count;

            // 构建字符串
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < rowCount; i++)
            {
                if (i != 0)
                {
                    str.Append("\n");
                }

                List<Node> rowNodes = nodes[i];
                StringBuilder rowSb = new StringBuilder();
                foreach (var node in rowNodes)
                {
                    int leftSpace = node.x - rowSb.Length - minX;
                    rowSb.Append(Strings.Blank(leftSpace));
                    rowSb.Append(node.str);
                }


                str.Append(rowSb);
            }

            return str.ToString();
        }

        /**
         * 添加一个元素节点
         */
        public Node addNode(List<Node> nodes, object btNode)
        {
            Node node = null;
            if (btNode != null)
            {
                node = new Node(btNode, tree);
                maxWidth = Math.Max(maxWidth, node.width);
                nodes.Add(node);
            }
            else
            {
                nodes.Add(null);
            }
            return node;
        }

        /**
         * 以满二叉树的形式填充节点
         */
        public void fillNodes(List<List<Node>> nodes)
        {
            if (nodes == null) return;
            // 第一行
            List<Node> firstRowNodes = new List<Node>();
            firstRowNodes.Add(root);
            nodes.Add(firstRowNodes);

            // 其他行
            while (true)
            {
                List<Node> preRowNodes = nodes[nodes.Count - 1];
                List<Node> rowNodes = new List<Node>();

                bool notNull = false;

                foreach (var node in preRowNodes)
                {
                    if (node == null)
                    {
                        rowNodes.Add(null);
                        rowNodes.Add(null);
                    }
                    else
                    {
                        Node left = addNode(rowNodes, tree.Left(node.btNode));
                        if (left != null)
                        {
                            node.left = left;
                            left.parent = node;
                            notNull = true;
                        }

                        Node right = addNode(rowNodes, tree.Right(node.btNode));
                        if (right != null)
                        {
                            node.right = right;
                            right.parent = node;
                            notNull = true;
                        }
                    }
                }


                // 全是null，就退出
                if (!notNull) break;
                nodes.Add(rowNodes);
            }
        }

        /**
         * 删除全部null、更新节点的坐标
         */
        public void cleanNodes(List<List<Node>> nodes)
        {
            if (nodes == null) return;

            int rowCount = nodes.Count;
            if (rowCount < 2) return;

            // 最后一行的节点数量
            int lastRowNodeCount = nodes[rowCount - 1].Count;

            // 每个节点之间的间距
            int nodeSpace = maxWidth + 2;

            // 最后一行的长度
            int lastRowLength = lastRowNodeCount * maxWidth
                    + nodeSpace * (lastRowNodeCount - 1);

          

            for (int i = 0; i < rowCount; i++)
            {
                List<Node> rowNodes = nodes[i];

                int rowNodeCount = rowNodes.Count;
                // 节点左右两边的间距
                int allSpace = lastRowLength - (rowNodeCount - 1) * nodeSpace;
                int cornerSpace = allSpace / rowNodeCount - maxWidth;
                cornerSpace >>= 1;

                int rowLength = 0;
                for (int j = 0; j < rowNodeCount; j++)
                {
                    if (j != 0)
                    {
                        // 每个节点之间的间距
                        rowLength += nodeSpace;
                    }
                    rowLength += cornerSpace;
                    Node node = rowNodes[j];
                    if (node != null)
                    {
                        // 居中（由于奇偶数的问题，可能有1个符号的误差）
                        int deltaX = (maxWidth - node.width) >> 1;
                        node.x = rowLength + deltaX;
                        node.y = i;
                    }
                    rowLength += maxWidth;
                    rowLength += cornerSpace;
                }
                // 删除所有的null
                rowNodes.RemoveAll(x=>x==null);
            }
        }

        /**
         * 压缩空格
         */
        public void compressNodes(List<List<Node>> nodes)
        {
            if (nodes == null) return;

            int rowCount = nodes.Count;
            if (rowCount < 2) return;

            for (int i = rowCount - 2; i >= 0; i--)
            {
                List<Node> rowNodes = nodes[i];

                foreach (var node in rowNodes)
                {
                    Node left = node.left;
                    Node right = node.right;
                    if (left == null && right == null) continue;
                    if (left != null && right != null)
                    {
                        // 让左右节点对称
                        node.balance(left, right);

                        // left和right之间可以挪动的最小间距
                        int leftEmpty = node.leftBoundEmptyLength();
                        int rightEmpty = node.rightBoundEmptyLength();
                        int empty = Math.Min(leftEmpty, rightEmpty);
                        empty = Math.Min(empty, (right.x - left.rightX()) >> 1);

                        // left、right的子节点之间可以挪动的最小间距
                        int space = left.minLevelSpaceToRight(right) - MIN_SPACE;
                        space = Math.Min(space >> 1, empty);

                        // left、right往中间挪动
                        if (space > 0)
                        {
                            left.translateX(space);
                            right.translateX(-space);
                        }

                        // 继续挪动
                        space = left.minLevelSpaceToRight(right) - MIN_SPACE;
                        if (space < 1) continue;

                        // 可以继续挪动的间距
                        leftEmpty = node.leftBoundEmptyLength();
                        rightEmpty = node.rightBoundEmptyLength();
                        if (leftEmpty < 1 && rightEmpty < 1) continue;

                        if (leftEmpty > rightEmpty)
                        {
                            left.translateX(Math.Min(leftEmpty, space));
                        }
                        else
                        {
                            right.translateX(-Math.Min(rightEmpty, space));
                        }
                    }
                    else if (left != null)
                    {
                        left.translateX(node.leftBoundEmptyLength());
                    }
                    else
                    { // right != null
                        right.translateX(-node.rightBoundEmptyLength());
                    }
                }
            }
        }

        public void addXLineNode(List<Node> curRow, Node parent, int x)
        {
            Node line = new Node("─");
            line.x = x;
            line.y = parent.y;
            curRow.Add(line);
        }

        public Node addLineNode(List<Node> curRow, List<Node> nextRow, Node parent, Node child)
        {
            if (child == null) return null;

            Node top = null;
            int topX = child.topLineX();
            if (child == parent.left)
            {
                top = new Node("┌");
                curRow.Add(top);

                for (int x = topX + 1; x < parent.x; x++)
                {
                    addXLineNode(curRow, parent, x);
                }
            }
            else
            {
                for (int x = parent.rightX(); x < topX; x++)
                {
                    addXLineNode(curRow, parent, x);
                }

                top = new Node("┐");
                curRow.Add(top);
            }

            // 坐标
            top.x = topX;
            top.y = parent.y;
            child.y = parent.y + 2;
            minX = Math.Min(minX, child.x);

            // 竖线
            Node bottom = new Node("│");
            bottom.x = topX;
            bottom.y = parent.y + 1;
            nextRow.Add(bottom);

            return top;
        }

        public void addLineNodes(List<List<Node>> nodes)
        {
            List<List<Node>> newNodes = new List<List<Node>>();

            int rowCount = nodes.Count;
            if (rowCount < 2) return;

            minX = root.x;

            for (int i = 0; i < rowCount; i++)
            {
                List<Node> rowNodes = nodes[i];
                if (i == rowCount - 1)
                {
                    newNodes.Add(rowNodes);
                    continue;
                }

                List<Node> newRowNodes = new List<Node>();
                newNodes.Add(newRowNodes);

                List<Node> lineNodes = new  List<Node>();
                newNodes.Add(lineNodes);

                foreach (var node in rowNodes)
                {
                    addLineNode(newRowNodes, lineNodes, node, node.left);
                    newRowNodes.Add(node);
                    addLineNode(newRowNodes, lineNodes, node, node.right);
                }
            }

            nodes.Clear();
            nodes.AddRange(newNodes);
        }

        public class Node
        {
            /**
             * 顶部符号距离父节点的最小距离（最小能填0）
             */
            private static int TOP_LINE_SPACE = 1;

            public object btNode { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
            public Node parent { get; set; }
            /**
			 * 首字符的位置
			 */
            public int x { get; set; }
            public int y { get; set; }
            public int TreeHeight { get; set; }
            public string str { get; set; }
            public int width { get; set; }

            private void init(string str)
            {
                str = (str == null) ? "null" : str;
                str = str == string.Empty ? " " : str;

                width = str.Length;
                this.str = str;
            }

            public Node(string str)
            {
                init(str);
            }

            public Node(object btNode, BinaryTreeInfo opetaion)
            {
                init(opetaion.String(btNode).ToString());

                this.btNode = btNode;
            }

            /**
             * 顶部方向字符的X（极其重要）
             * 
             * @return
             */
            public int topLineX()
            {
                // 宽度的一半
                int delta = width;
                if (delta % 2 == 0)
                {
                    delta--;
                }
                delta >>= 1;

                if (parent != null && this == parent.left)
                {
                    return rightX() - 1 - delta;
                }
                else
                {
                    return x + delta;
                }
            }

            /**
             * 右边界的位置（rightX 或者 右子节点topLineX的下一个位置）（极其重要）
             */
            public int rightBound()
            {
                if (right == null) return rightX();
                return right.topLineX() + 1;
            }

            /**
             * 左边界的位置（x 或者 左子节点topLineX）（极其重要）
             */
            public int leftBound()
            {
                if (left == null) return x;
                return left.topLineX();
            }

            /**
             * x ~ 左边界之间的长度（包括左边界字符）
             * 
             * @return
             */
            public int leftBoundLength()
            {
                return x - leftBound();
            }

            /**
             * rightX ~ 右边界之间的长度（包括右边界字符）
             * 
             * @return
             */
            public int rightBoundLength()
            {
                return rightBound() - rightX();
            }

            /**
             * 左边界可以清空的长度
             * 
             * @return
             */
            public int leftBoundEmptyLength()
            {
                return leftBoundLength() - 1 - TOP_LINE_SPACE;
            }

            /**
             * 右边界可以清空的长度
             * 
             * @return
             */
            public int rightBoundEmptyLength()
            {
                return rightBoundLength() - 1 - TOP_LINE_SPACE;
            }

            /**
             * 让left和right基于this对称
             */
            public void balance(Node left, Node right)
            {
                if (left == null || right == null)
                    return;
                // 【left的尾字符】与【this的首字符】之间的间距
                int deltaLeft = x - left.rightX();
                // 【this的尾字符】与【this的首字符】之间的间距
                int deltaRight = right.x - rightX();

                int delta = Math.Max(deltaLeft, deltaRight);
                int newRightX = rightX() + delta;
                right.translateX(newRightX - right.x);

                int newLeftX = x - delta - left.width;
                left.translateX(newLeftX - left.x);
            }

            public int treeHeight(Node node)
            {
                if (node == null) return 0;
                if (node.TreeHeight != 0) return node.TreeHeight;
                node.TreeHeight = 1 + Math.Max(
                        treeHeight(node.left), treeHeight(node.right));
                return node.TreeHeight;
            }

            /**
             * 和右节点之间的最小层级距离
             */
            public int minLevelSpaceToRight(Node right)
            {
                int thisHeight = treeHeight(this);
                int rightHeight = treeHeight(right);
                int minSpace = int.MaxValue;
                for (int i = 0; i < thisHeight && i < rightHeight; i++)
                {
                    int space = right.levelInfo(i).LeftX
                            - this.levelInfo(i).RightX;
                    minSpace = Math.Min(minSpace, space);
                }
                return minSpace;
            }

            public LevelInfo levelInfo(int level)
            {
                if (level < 0) return null;
                int levelY = y + level;
                if (level >= treeHeight(this)) return null;

                List<Node> list = new List<Node>();
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(this);

                // 层序遍历找出第level行的所有节点
                while (queue.Count != 0)
                {
                    Node node = queue.Dequeue();
                    if (levelY == node.y)
                    {
                        list.Add(node);
                    }
                    else if (node.y > levelY) break;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                Node left = list[0];
                Node right = list[list.Count - 1];
                return new LevelInfo(left, right);
            }

            /**
             * 尾字符的下一个位置
             */
            public int rightX()
            {
                return x + width;
            }

            public void translateX(int deltaX)
            {
                if (deltaX == 0) return;
                x += deltaX;

                // 如果是LineNode
                if (btNode == null) return;

                if (left != null)
                {
                    left.translateX(deltaX);
                }
                if (right != null)
                {
                    right.translateX(deltaX);
                }
            }
        }

        public class LevelInfo
        {
            public int LeftX { get; set; }
            public int RightX { get; set; }

            public LevelInfo(Node left, Node right)
            {
                this.LeftX = left.leftBound();
                this.RightX = right.rightBound();
            }
        }
    }
}
