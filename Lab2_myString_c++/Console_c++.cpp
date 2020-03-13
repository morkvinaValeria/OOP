#include"MyString.h"
#include"ContainerText.h"
#include <iostream>

using namespace std;
int main()
{
    char A[100] = { 'M','y',' ','n','a','m','e',' ','i','s',' ','L','e','r','a','\0' };
    char C[100] = { 'i',' ','a','m',' ','f','r','o','m',' ','S','u','m','y','\0' };
    MyString K = MyString(A);
    MyString B = MyString(C);
    ContainerText* literature = new ContainerText();
    literature->add(K);
   
    literature->remove(K);
   
    literature->clear();

    literature->add(K);

    literature->clear();

    literature->add(K);
    literature->add(B);
    
    literature->string_nums_by_length(15);

    literature->touppercase();
   
    literature->getkeystring(0);
  
 

    

    return 0;
}

