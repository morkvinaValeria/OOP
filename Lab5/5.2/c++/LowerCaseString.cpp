#include "LowerCaseString.h"
using namespace std;

LowerCaseString :: LowerCaseString(string str)
{
    this->str = str;
    for (int i = 0; i < GetLength(); i++) {
        this->str[i] = towlower(this->str[i]);
    }
    for (int i = 0; i < GetLength(); i++)
    {
        if ((!(this->str[i] >= 'a') || !(this->str[i] <= 'z')))
        {
            this->str = this->str.erase(i, 1);
            i--;
        }
    }
}

    string LowerCaseString :: Shift()
    {
        char temp;
        temp = str[0];
        for (int i = 0; i < GetLength() - 1; i++)
        {
            str[i] = str[i + 1];
        }
        str[GetLength() - 1] = temp;
        return str;
    }

    int  LowerCaseString::GetLength() 
    { return size(str); }