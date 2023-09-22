class Node {
    int val;
    Node next;

    public Node(int val) {
        this.val = val;
    }
}

class Answer {
    Node head;

    private void reverse(Node node, Node previous) {
    // Введите свое решение ниже
    if (node.next != null) {reverse(node.next, node);}
    else {head = node;}
    node.next = previous;
}

    public void reverse() {
        this.reverse(head, null);
    }
}
