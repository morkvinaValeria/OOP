using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
    class MyList
    {
       private Node Head;
       private Node Tail;
        public MyList()
        {
            Head = null;
            Tail = null;
        }
       
        public void AddNode(Node NewNode)
        {
            NewNode.Next = null;
            if (Head == null)     
            {
                NewNode.Prev = null;   
                Head = Tail = NewNode;   
            }
            else
            {
                NewNode.Prev = Tail;    
                Tail.Next = NewNode;    
                Tail = NewNode;       
            }
        }
        public int ElementsMultiplicity5()
        {
            Node Current = Head;
            int index = 0, count = 0;
            while (Current != null)
            {
                if (Current.value % 5 == 0 && index % 2 == 0)
                    count++;
                index++;
                Current = Current.Next;
            }
            return count;
        }

        public void DeleteMoreThanAverage()
        {
            Node Current = Head;
            long av = Average();
            while (Current != null)
            {
                if (Current.value > av)
                    DeleteNode(Current);
                Current = Current.Next;
            }
        }
        private void DeleteNode(Node p)
        {
            Node Prev = p.Prev;
            Node After = p.Next;

            if (Prev != null && ListCount() != 1)
                Prev.Next = After;
            if (After != null && ListCount() != 1)
                After.Prev = Prev;

            if (p == Head)
                Head = p.Next;
            if (p == Tail)
                Tail = p.Prev;
        }
        private int ListCount()
        {
            Node Current = Head;
            int count = 0;
            while (Current != null)
            {
                count++;
                Current = Current.Next;
            }
            return count;
        }

        private long Average()
        {
            Node Current = Head;
            long sum = 0;
            while (Current != null)
            {
                sum += Current.value;
                Current = Current.Next;
            }
            sum /= ListCount();
            return sum;
        }
        ~MyList()
        {
            while (Head != null)
            {
                Tail = Head.Next;
                Head = Tail;
            }
        }
    }
}
