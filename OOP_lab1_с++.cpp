#include <iostream>
#include <ctime>
#include <stdio.h>

void Function1(int& x);
int Function2(int y, int z);
using namespace std;

void Function1(int& x)
{
    int x0 = x;
    for (int i = 0; i < sizeof(int) * 8; i++)
    {
        x = x ^ (1 << i);
        if ((x0 & (1 << i)) != 0) break;
    }
}

int Function2(int y, int z)
{

    if ((y ^ z) == 0)
    {
        return 0;
    }
    for (int i = sizeof(int) * 8; i >= 0; i--)
    {
        int Ay = y & (1 << i);
        int Az = z & (1 << i);
        if (i == sizeof(int) * 8) {

            if ((y ^ z) < 0) {
                if ((Ay != 0) && (Az == 0)) {
                    return -1;
                }
                if ((Az != 0) && (Ay == 0)) {
                    return 1;
                }
            }
            continue;
        }
        else if ((y ^ z) > 0) {
            if ((Ay != 0) && (Az == 0)) {
                return 1;
            }
            if ((Az != 0) && (Ay == 0)) {
                return -1;
            }
        }
    }


}
int main()
{
    srand(time(NULL));
    int x = 2;//rand()%10-7;
    Function1(x);

    int y = 3;
    int z = 20;
    cout << Function2(y, z);
}
