#pragma once
#include <stdexcept>
using namespace std;
class Expression
{
private:
    float a, b, c, d;
public: 
    Expression();
    Expression(float a, float b, float c, float d);
    float Calculate();
   
};
