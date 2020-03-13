#pragma once
#include"pch.h"
#include <iostream>
#include"MyString.h"
using namespace std;


    MyString::MyString()
    {
        str = nullptr;
    }
    MyString::MyString(char* str)
    {
        int length = 0;
        int i = 0;
        while (str[i] != '\0')
        {
            length++;
            i++;
        }
        this->str = new char[length + 1];
        for (int j = 0; j < length + 1; j++)
        {
            this->str[j] = str[j];
        }
    }

    int  MyString::length()
    {
        int length = 0;
        int i = 0;
        if (str == nullptr) { return length; }
        while (str[i] != '\0')
        {
            length++;
            i++;
        }
        return length;
    }

    int  MyString::getwordsamount()
    {
        int amount = 0;
        for (int i = 0; i < length(); i++)
        {
            if (str[i] == ' ')
            {
                amount++;
            }
        }
        return amount + 1;
    }

    int  MyString::getCapitalWordId(int index)
    {
        int id = 0;
        int current_index = 1;

        for (int i = 0; i < length(); i++)
        {
            if (str[i] == ' ')
            {
                if (current_index == index)
                {
                    return id;
                }
                id = i + 1;
                current_index++;
                i++;
            }

        }
        return id;
    }
    void  MyString::toUpperCase()
    {
        for (int i = 0; i < this->getwordsamount(); i++)
        {
            if ((this->str[getCapitalWordId(i + 1)] >= 'a') && (this->str[getCapitalWordId(i + 1)] <= 'z'))
                this->str[getCapitalWordId(i + 1)] = (char)(this->str[getCapitalWordId(i + 1)] - 32);
        }
    }

    char* MyString::getkey()
    {
        char* key = new char[getwordsamount()];
        for (int i = 1; i <= getwordsamount(); i++)
        {
            key[i - 1] = str[getCapitalWordId(i)];
        }//индексы-0, слова-1
        key[getwordsamount()] = '\0';
        return key;
    }

    bool  MyString::equal(MyString mystring)
    {
        int equals = 0;
        if (this->str == mystring.str) return true;
        if (length() == mystring.length())
        {
            for (int i = 0; i < length(); i++)
            {
                if (str[i] == mystring.str[i]) {
                    equals++;
                }
            }
            if (equals == length())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else {
            return false;
        }
    }
    bool  MyString::isEmpty()
    {
        return length() == 0;
    }

