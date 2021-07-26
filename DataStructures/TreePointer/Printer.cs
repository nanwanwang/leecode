using System;
using System.Collections.Generic;
using System.Text;

namespace TreePointer
{
	public abstract class Printer
	{
		/**
		 * 二叉树的基本信息
		 */
		protected BinaryTreeInfo tree;

		public Printer(BinaryTreeInfo tree)
		{
			this.tree = tree;
		}

		/**
		 * 生成打印的字符串
		 */
		public abstract string PrintString();

		/**
		 * 打印后换行
		 */
		public void Println()
		{
			Print();
			Console.WriteLine();
		}

		/**
		 * 打印
		 */
		public void Print()
		{
            Console.Write(PrintString());
			
		}
	}

}
