#pragma once
#include"MyString.h"
#include <iostream>
#include"pch.h"
using namespace std;


class ContainerText
{
private:
    int length = 5;
    MyString* text = new MyString[length];
    int string_nums;
public:
    void add(MyString string);

    void remove(MyString string);

    void clear();

    void touppercase();

    char* getkeystring(int index);

    int string_nums_by_length(int length);

    void text_output();
};