namespace LeeCode.LinkedList
{
    /// <summary>
    /// https://leetcode-cn.com/problems/linked-list-cycle/
    /// 快慢指针
    /// </summary>
    public class _141_环形链表
    {
        public bool HasCycle(ListNode head)
        {
            if (head?.next == null) return false;
            var slow = head;
            var fast = head.next.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) return true;
            }

            return false;
        }
    }
}