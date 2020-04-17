using System;
using System.Collections.Generic;
using System.Text;

namespace lab4_sharp
{
	class Rhombus
    {
		private Coord A , B , C,  D ;

		public Rhombus() { }

		public Rhombus(Coord A, Coord B, Coord C, Coord D)
		{
			this.A = A;
			this.B = B;
			this.C = C;
			this.D = D;
		}

		public Rhombus(Rhombus obj)
	    {
		  A = obj.A;
		  B = obj.B;
		  C = obj.C;
		  D = obj.D;
	    }

        private float Length(Coord A, Coord B)
	    {
			return (float)Math.Sqrt(Math.Pow((B.x - A.x), 2) + Math.Pow((B.y - A.y), 2));
	    }

       public float Square()
	   {
		 return (Length(A, C) * Length(B, D)) / 2; ;
	   }

	   public float Perimeter()
	   {
		 return 4 * Length(A, B);
	   }

	  public Coord GetCoordinate(int point_number)
	  {
		return point_number == 1 ? A : point_number == 2 ? B : point_number == 3 ? C : D;
	  }

	  public static Rhombus operator*(Rhombus v,int d)
	  {
		Rhombus temp = new Rhombus();
		temp.A.x = v.A.x * d;
		temp.A.y = v.A.y * d;
		temp.B.x = v.B.x * d;
		temp.B.y = v.B.y * d;
		temp.C.x = v.C.x * d;
		temp.C.y = v.C.y * d;
		temp.D.x = v.D.x * d;
		temp.D.y = v.D.y * d;
		return temp;
	  }
		
	  public static Rhombus operator -(Rhombus a, Rhombus b)
      {
	    Rhombus temp = new Rhombus();
	    temp.A.x = a.A.x - b.A.x;
		temp.A.y = a.A.y - b.A.y;
		temp.B.x = a.B.x - b.B.x;
		temp.B.y = a.B.y - b.B.y;
		temp.C.x = a.C.x - b.C.x;
		temp.C.y = a.C.y - b.C.y;
		temp.D.x = a.D.x - b.D.x;
		temp.D.y = a.D.y - b.D.y;
		return temp;
      }
    }
}
