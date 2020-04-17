#pragma once
#include "MyString.h"

class DigitalString : public MyString
{
private: string str;

public: 
     DigitalString(string str);
     virtual int GetLength();
     virtual string Shift();

};

