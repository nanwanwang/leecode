namespace LeeCode.LinkedList
{
    /// <summary>
    /// https://leetcode-cn.com/problems/remove-linked-list-elements/
    /// </summary>
    public class _203_移除链表元素
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return head;
            var dummyHead = new ListNode();
            dummyHead.next = head;
            while (dummyHead.next!=null)
            {
                if (dummyHead.next.val == val) dummyHead.next = dummyHead.next.next;
                else
                {
                    dummyHead = dummyHead.next;
                }
               
            }

            return dummyHead;
        }
    }
}