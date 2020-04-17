#pragma once
#include "MyString.h"
class LowerCaseString :public MyString
{
private: string str;

public: LowerCaseString(string str);
        virtual int GetLength();
        virtual string Shift();
};

