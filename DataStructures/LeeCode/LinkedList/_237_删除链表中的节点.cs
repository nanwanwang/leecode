namespace LeeCode.LinkedList
{
    /// <summary>
    /// https://leetcode-cn.com/problems/delete-node-in-a-linked-list/
    /// </summary>
    public class _237_删除链表中的节点
    {
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }


}