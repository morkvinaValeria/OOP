#pragma once
#include <iostream>
#include <string>
using namespace std;

class MyString
{
public:
    virtual int GetLength()=0;
    virtual string Shift()=0;
   
};

