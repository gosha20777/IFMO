public class ListNode {
	Object value;
    ListNode prev;
    ListNode next;

    public ListNode(Object value, ListNode prev, ListNode next) {
        assert value != null;
        this.value = value;
        this.prev = prev;
        this.next = next;
    }
}