#include"MyString.h"
#include"pch.h"
#include"ContainerText.h"
#include <iostream>
using namespace std;

    void ContainerText::add(MyString string)
    {
        if (!text[length - 1].isEmpty())
        {
            length = (3 * length) / 2 + 1;
            MyString* newtext = new MyString[length];

            for (int i = 0; i < string_nums; i++)
            {
                newtext[i] = text[i];
            }

            text = newtext;
        }
        text[string_nums] = string;
        string_nums++;
    }

    void ContainerText::remove(MyString string)
    {
        int index = 0;
        int i = 0;
        while (i < string_nums && !string.equal(text[i]))
        {
            index = i;
            i++;
        }

        for (int j = index; j < string_nums; j++)
        {
            text[j] = text[j + 1];
        }
        text[string_nums] = MyString();
        string_nums--;
    }

    void ContainerText::clear()
    {
        for (int i = 0; i < string_nums; i++)
        {
            text[i] = MyString();
        }
        string_nums = 0;
    }

    void ContainerText::touppercase()
    {
        for (int i = 0; i < string_nums; i++)
        {
            text[i].toUpperCase();
        }
    }

    char* ContainerText::getkeystring(int index)
    {
        return text[index].getkey();
    }

    int ContainerText::string_nums_by_length(int length)
    {
        int nums = 0;
        for (int i = 0; i < string_nums; i++)
        {
            if (text[i].length() == length)
            {
                nums++;
            }
        }
        return nums;
    }
/*
    void ContainerText::text_output()
    {
        for (int i = 0; i < string_nums; i++)
        {
            for (int j = 0; j < text[i].length(); j++)
            {
                cout << text[i].str[j];//к строке и номеру символа к ней(строки)

            }
            cout << endl;

        }

    }*/
