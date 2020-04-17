#include "DigitalString.h"


DigitalString::DigitalString(string str)
{
    this->str = str;
    for (int i = 0; i < GetLength(); i++)
    {
        if (!(this->str[i] >= '0') || !(this->str[i] <= '9'))
        {
            this->str = this->str.erase(i, 1);
            i--;
        }
    }
}

int DigitalString::GetLength() { return size(str); }

string DigitalString::Shift()
{
    char temp;
    temp = str[GetLength() - 1];
    for (int i = GetLength()-1; i >= 1; i--)
        str[i] = str[i - 1];
    str[0] = temp;
    return str;
}