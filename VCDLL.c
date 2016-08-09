/*
32位Dll
*/

int __stdcall add(int a, int b)
{
	return (a + b);
}

int __stdcall addp(int* a)
{
	int t = 0;
	t = *a;
	return 2 * t;
}

int* __stdcall padd(int a)
{

	static int *pp;
    static	int b;
	b = a*2;

	pp = &b;


	return pp;
}
