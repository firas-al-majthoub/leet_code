/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    ListNode resHead = null;
    ListNode resTail = null;
    int carry = 0;

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        while (true)
        {
            if (l1 == null && l2 == null & carry == 0)
                break;

            int num1 = l1?.val ?? 0;
            int num2 = l2?.val ?? 0;
            int sum = num1 + num2 + carry;

            int val = sum < 10 ? sum : sum - 10;
            addToList(val);
            carry = sum < 10 ? 0 : 1;

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return resHead;
    }

    private void addToList(int val)
    {
        if (resHead == null)
        {
            resHead = resTail = new ListNode(val);
        }
        else
        {
            resTail.next = new ListNode(val);
            resTail = resTail.next;
        }
    }
}
