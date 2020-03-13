#pragma once
#include <iostream>
#include"pch.h"

using namespace std;


class MyString
{
private:
    char* str;

public:
    MyString();

    MyString(char* str);

    int length();

    int getwordsamount();

    int getCapitalWordId(int index);
   
    void toUpperCase();

    char* getkey();

    bool equal(MyString mystring);

    bool isEmpty();

};