#include "Expression.h"
Expression::Expression(){}

Expression::Expression(float a, float b, float c, float d)
{
    this->a = a;
    this->b = b;
    this->c = c;
    this->d = d;
}

float Expression::Calculate()
{
    if (b == 0)
        throw logic_error("Wrong b- it`s cannot be zero");
    if (24 + d - c < 0)
        throw invalid_argument("Wrong d and/or c - value of square root cannot be lower than zero");
    if (sqrt(24 + d - c) + a / b == 0)
        throw logic_error ("Wrong variables- denomination cannot be zero");
    return (float)((1 + a - b / 2) / (sqrt(24 + d - c) + a / b));
}




















/*
float Expression::SetA(float a)
{
    this->a = a;
}
float Expression::SetB(float b)
{
    this->b = b;
}
float Expression::SetC(float c)
{
    this->c = c;
}
float Expression::SetD(float d)
{
    this->d = d;
}
float Expression::GetA() { return a; }
float Expression::GetB() { return a; }
float Expression::GetC() { return a; }
float Expression::GetD() { return a; }*/