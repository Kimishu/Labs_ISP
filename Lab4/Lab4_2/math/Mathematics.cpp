
#include "Mathematics.h"
 
int Sum (int a, int b) {
		

return a + b;
	

}

	

int Multiply (int a, int b) {


return a * b;

	
}

	

int Divide(int a, int b) {


return a / b;

	
}

	

int Mod(int a, int b) {
	
	
return a % b;

	
}

	

int Pow(int a, int degree) {

	
int value = 1;
	
while (degree--)
	
value *= a;

	
return value;
	
}


