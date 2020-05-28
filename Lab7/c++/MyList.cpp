#include "MyList.h"
#include <iostream>
using namespace std;

MyList::MyList()
{
    Head = NULL;
    Tail = NULL;
}
MyList::~MyList()                          
{
    while (Head)                
    {
        Tail = Head->Next;           
        delete Head;                  
        Head = Tail;                 
    }
}
void MyList:: AddNode(PNode NewNode)
{
    NewNode->Next = NULL;
    if (Head == NULL)           
    {
        NewNode->Prev = NULL;  
        Head = Tail = NewNode; 
    }
    else
    {
        NewNode->Prev = Tail;   
        Tail->Next = NewNode;    
        Tail = NewNode;      
    }
}
int MyList::ElementsMultiplicity5()
{
    PNode Current = Head;
    int index = 0, count = 0;
    while (Current != NULL)
    {
        if (Current->value % 5 == 0 && index % 2 == 0)
            count++;
        index++;
        Current = Current->Next;
    }
    return count;
}

void MyList::DeleteMoreThanAverage()
{
    PNode Current = Head;
    long av = Average();
    while (Current != NULL)
    {
        if (Current->value > av)
            DeleteNode(Current);
        Current = Current->Next;
    }
}
void MyList::DeleteNode(PNode p)
{
    PNode Prev = p->Prev; 
    PNode After = p->Next; 

    if (Prev != NULL && ListCount() != 1) 
        Prev->Next = After;  
    if (After != NULL && ListCount() != 1) 
        After->Prev = Prev;   

    if (p == Head) 
        Head = p->Next;   
    if (p == Tail)
        Tail = p->Prev; 
    delete p;
}
int MyList::ListCount()
{
    PNode Current = Head;
    int count = 0;
    while (Current != NULL)
    {
        count++;
        Current = Current->Next;
    }
    return count;
}

long MyList::Average()
{
    PNode Current = Head;
    long sum = 0;
    while (Current != NULL)
    {
        sum += Current->value;
        Current = Current->Next;
    }
    sum /= ListCount();
    return sum;
}