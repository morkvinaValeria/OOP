#pragma once
struct Node
{
    long value;
    Node* Next, * Prev;
};

class MyList
{
 typedef Node* PNode;
 private:
     PNode Head;
     PNode Tail;
     int ListCount();
     void DeleteNode(PNode p);
     long Average();

 public:
     MyList();
     ~MyList();
     void AddNode(PNode NewNode);
     int ElementsMultiplicity5();
     void DeleteMoreThanAverage();
};

