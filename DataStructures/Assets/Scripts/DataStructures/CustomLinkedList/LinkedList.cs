namespace DataStructures.CustomLinkedList
{
    public sealed class LinkedListNode<T>
    {
        internal T item;
        internal LinkedListNode<T> next;
        internal LinkedListNode<T> previous;

        public LinkedListNode(T item)
        {
            this.item = item;
            next = null;
            previous = null;
        }
    
        public LinkedListNode<T> Next => next;
        public LinkedListNode<T> Previous => previous;
        public T Item => item;
    }

    public class LinkedList<T>
    {
        int count;
        LinkedListNode<T> head;
        LinkedListNode<T> tail;

        public int Count => count;
        public LinkedListNode<T> Head => head;
        public LinkedListNode<T> Tail => tail;

        public LinkedListNode<T> AddLast(T item)
        {
            count++;

            LinkedListNode<T> newNode = new LinkedListNode<T>(item);
            if (tail == null)
            {
                tail = newNode;
                head = tail;
                return newNode;
            }

            tail.next = newNode;
            newNode.previous = tail;
            tail = newNode;
            return newNode;
        }

        public LinkedListNode<T> AddFirst(T item)
        {
            count++;
            
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);

            if (head == null)
            {
                head = newNode;
                return newNode;
            }

            head.previous = newNode;
            newNode.next = head;
            head = newNode;
            return newNode;
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> previousNode, T item)
        {
            count++;
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);

            newNode.next = previousNode.next;
            newNode.previous = previousNode;

            if (previousNode.next != null) previousNode.next.previous = newNode;
            else
            {
                tail = newNode;
            }
            previousNode.next = newNode;

            return newNode;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> nextNode, T item)
        {
            count++;
            LinkedListNode<T> newNode = new LinkedListNode<T>(item);

            newNode.next = nextNode;
            newNode.previous = nextNode.Previous;

            if(nextNode.previous != null) nextNode.previous.next = newNode;
            else
            {
                head = newNode;
            }
            nextNode.previous = newNode;
            
            return newNode;
        }

        public void Remove(LinkedListNode<T> node)
        {
            count--;
            
            LinkedListNode<T> previousNode = Equals(node, head) ? null : node.previous;
            LinkedListNode<T> nextNode = Equals(node, tail) ? null : node.next;

            if(previousNode != null) previousNode.next = nextNode;
            else head = node.next;
            
            if (nextNode != null) nextNode.previous = previousNode;
            else tail = node.previous;
        }
        
        public void RemoveLast()
        {
            count--;
            tail = tail.previous;
            tail.next = null;
        }

        public void RemoveFirst()
        {
            count--;
            head = head.next;
            head.previous = null;
        }

        public void RemoveAfter(LinkedListNode<T> previousNode)
        {
            count--;
            LinkedListNode<T> nextNode = previousNode.next;
            if (Equals(nextNode, tail))
            {
                previousNode.next = null;
                tail = previousNode;
                return;
            }
            
            previousNode.next = nextNode.next;
            nextNode.next.previous = previousNode;
        }

        public void RemoveBefore(LinkedListNode<T> nextNode)
        {
            count--;
            LinkedListNode<T> previousNode = nextNode.previous;
            if (Equals(previousNode, head))
            {
                nextNode.previous = null;
                head = nextNode;
                return;
            }
            
            nextNode.previous = previousNode.previous;
            previousNode.previous.next = nextNode;
        }

        public LinkedListNode<T> Find(T item)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (Equals(current.item, item))
                {
                    return current;
                }
                current = current.next;
            }

            return null;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (Equals(current.item, item))
                {
                    return true;
                }
                current = current.next;
            }

            return false;
        }
    }
}