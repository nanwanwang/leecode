namespace LeeCode.LinkedList
{
    /// <summary>
    /// https://leetcode-cn.com/problems/reverse-linked-list/
    /// </summary>
    public class _206_反转链表
    {
        /// <summary>
        /// 递归方式
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            var newHead = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }
        
        /// <summary>
        /// 非递归
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList2(ListNode head) {
            if (head == null || head.next == null)
                return head;
            ListNode newHead = null;
            while (head != null)
            {
                var temp = head.next;
                head.next = newHead;
                newHead  = head;
                head = temp;
            }

            return newHead;
        }
    }
}