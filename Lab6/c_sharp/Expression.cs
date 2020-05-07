using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    class Expression
    {
        public float a {get; set;}
        public float b {get; set;}
        public float c {get; set;}
        public float d {get; set;}
        public Expression() { }

        public Expression(float a, float b, float c, float d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        public float Calculate()
        {
            if (b == 0)
                throw new DivideByZeroException(message: "Wrong b- it`s cannot be zero");
            if (24 + d - c < 0)
                throw new ArithmeticException(message: "Wrong d and/or c - value of square root cannot be lower than zero");
            if (Math.Sqrt(24 + d - c) + a / b == 0)
                throw new ArithmeticException(message: "Wrong variables- denomination cannot be zero");
            return (float)((1 + a - b / 2) / (Math.Sqrt(24 + d - c) + a / b)); 
        }
    }
}
