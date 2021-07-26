using System;

namespace TreePointer
{
	public interface BinaryTreeInfo
	{
		/**
		 * who is the root node
		 */
		object Root();
		/**
		 * how to get the left child of the node
		 */
		object Left(Object node);
		/**
		 * how to get the right child of the node
		 */
		object Right(Object node);
		/**
		 * how to print the node
		 */
		object String (Object node);
}

}
