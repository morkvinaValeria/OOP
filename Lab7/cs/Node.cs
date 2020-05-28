using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_7
{
    class Node
    {
       public long value;
       public Node Next, Prev;
       public Node(long value)
       {
            this.value = value;
       }
    }
}
