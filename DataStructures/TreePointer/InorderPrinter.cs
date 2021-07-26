using System;
using System.Collections.Generic;
using System.Text;

namespace TreePointer
{
    public class InorderPrinter : Printer
    {
        private static string rightAppend;
        private static string leftAppend;
        private static string blankAppend;
        private static string lineAppend;
        //static {
        //	int length = 2;
        //rightAppend = "┌" + Strings.repeat("─", length);
        //	leftAppend = "└" + Strings.repeat("─", length);
        //	blankAppend = Strings.blank(length + 1);
        //	lineAppend = "│" + Strings.blank(length);
        //}

        public InorderPrinter(BinaryTreeInfo tree) : base(tree)
        {

        }


        public override string PrintString()
        {
            StringBuilder str = new StringBuilder(
                    PrintString(tree.Root(), " ", " ", " "));
            str.Remove(str.Length - 1, 1);
            //str.deleteCharAt(str.Length - 1);
            return str.ToString();
        }

        /**
         * 生成node节点的字符串
         * @param nodePrefix node那一行的前缀字符串
         * @param leftPrefix node整棵左子树的前缀字符串
         * @param rightPrefix node整棵右子树的前缀字符串
         * @return
         */
        private string PrintString(
                object node,
                string nodePrefix,
                string leftPrefix,
                string rightPrefix)
        {
            object left = tree.Left(node);
            object right = tree.Right(node);
            string str = tree.String(node).ToString();

            int length = str.Length;
            if (length % 2 == 0)
            {
                length--;
            }
            length >>= 1;

            String nodeString = "";
            if (right != null)
            {
                rightPrefix += Strings.Blank(length);
                nodeString += PrintString(right,
                        rightPrefix + rightAppend,
                        rightPrefix + lineAppend,
                        rightPrefix + blankAppend);
            }
            nodeString += nodePrefix + str + "\n";
            if (left != null)
            {
                leftPrefix += Strings.Blank(length);
                nodeString += PrintString(left,
                        leftPrefix + leftAppend,
                        leftPrefix + blankAppend,
                        leftPrefix + lineAppend);
            }
            return nodeString;
        }
    }

}
