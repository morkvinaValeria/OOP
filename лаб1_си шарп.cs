using System;

namespace name1
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();
			int x = rnd.Next(-10, 10);
			Function1(ref x);
			int y = rnd.Next(-10, 10);
			int z = rnd.Next(-10, 10);
			Function2(y, z);

		}
		static void Function1(ref int x)
		{
			int x0 = x;
			for (int i = 0; i < sizeof(int) * 8; i++)
			{
				x = x ^ (1 << i);
				if ((x0 & (1 << i)) != 0) break;
			}
		}
		static int Function2(int y, int z)
		{
			if ((y ^ z) == 0)
			{
				return 0;
			}
			for (int i = 32; i >= 0; i--)
			{
				int Ay = y & (1 << i);
				int Az = z & (1 << i);

				if (i == sizeof(int) * 8)
				{
					if ((y ^ z) < 0)
					{
						if ((Ay != 0) && (Az == 0))
						{
							return -1;
						}
						if ((Az != 0) && (Ay == 0))
						{
							return 1;
						}
					}
					continue;
				}
				else if ((y ^ z) > 0)
				{
					if ((Ay != 0) && (Az == 0))
					{
						return 1;
					}
					if ((Az != 0) && (Ay == 0))
					{
						return -1;
					}
				}
			}
			return 1;

		}
	}
}

