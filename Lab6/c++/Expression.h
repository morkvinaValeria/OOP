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
















/* float SetA(float a);
    float SetB(float b);
    float SetC(float c);
    float SetD(float d);
    float GetA();
    float GetB();
    float GetC();
    float GetD();*/