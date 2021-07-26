using System;
using System.Collections.Generic;
using System.Text;

namespace TreePointer
{
	public static  class BinaryTrees
	{

		public static void Print(BinaryTreeInfo tree)
		{
			Print(tree,  PrintStyle.LEVEL_ORDER);
		}

		public static void Println(BinaryTreeInfo tree)
		{
			Println(tree,  PrintStyle.LEVEL_ORDER);
		}

		public static void Print(BinaryTreeInfo tree, PrintStyle style)
		{
			if (tree == null || tree.Root() == null) return;
			Printer(tree, style).Print();
		}

		public static void Println(BinaryTreeInfo tree, PrintStyle style)
		{
			if (tree == null || tree.Root() == null) return;
			Printer(tree, style).Println();
		}

		public static string PrintString(BinaryTreeInfo tree)
		{
			return PrintString(tree,  PrintStyle.LEVEL_ORDER);
		}

		public static string PrintString(BinaryTreeInfo tree, PrintStyle style)
		{
			if (tree == null || tree.Root() == null) return null;
			return Printer(tree, style).PrintString();
		}

		private static Printer Printer(BinaryTreeInfo tree, PrintStyle style)
		{
			if (style == PrintStyle.INORDER) return new InorderPrinter(tree);
			return new LevelOrderPrinter(tree);
		}

		public enum PrintStyle
		{
			LEVEL_ORDER, INORDER
		}
	}
}
