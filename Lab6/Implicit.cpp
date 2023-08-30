#include <iostream>
#include <Windows.h>
using namespace std;

extern "C" __declspec(dllimport) INT(__stdcall Minimum) (LPINT selected, INT arrSize);
extern "C" __declspec(dllimport) BOOL(__stdcall Contains) (LPTSTR toCheck, INT checkedSize, LPTSTR toFind, INT foundSize, BOOL caseSensitive);
extern "C" __declspec(dllimport) DOUBLE(__stdcall Average) (LPINT numArr, INT arrSize);
extern "C" __declspec(dllimport) INT(__stdcall Count) (LPTSTR text, INT textSize, CHAR counted, BOOL caseSensitive);

int main()
{
	int findMin[5] = { 3, 1, -5, 6, 0 };
	int min = Minimum(findMin, sizeof(findMin));

	if (min != -5) {
		cout << "Error in Minimum function, result has to be -5, not " << min << endl;
	}
	else {
		cout << "Minimum funciton works correctly" << endl;
	}

	char text[] = "SoMe text";
	char find[] = "ome";

	bool resultContains = Contains(text, sizeof(text), find, sizeof(find), false);

	if (resultContains) {
		cout << "Contains funciton works correctly with no regard for case" << endl;
	}
	else {
		cout << "Error in Contains function when case is not taken into account, result has to be true, not " << resultContains << endl;
	}

	bool resultContains2 = Contains(text, sizeof(text), find, sizeof(find), true);

	if (!resultContains2) {
		cout << "Contains funciton works correctly with case sensitive values" << endl;
	}
	else {
		cout << "Error in Contains function when case is taken into account, result has to be false, not " << resultContains << endl;
	}

	int toBeAveraged[4] = { 8, 5, 4, 2 }; //average is 4.75
	double average = Average(toBeAveraged, sizeof(toBeAveraged));
	if (average == 4.75) {
		cout << "Average funciton works correctly" << endl;
	}
	else {
		cout << "Average funciton works incorrectly, result has to be 4.75, not " << average << endl;
	}

	char text2[] = "Occurences of letter O will be counted here"; // o is here 2 times for lower case and 4 times for case insensitive
	char letter = 'o';
	int occurences1 = Count(text2, sizeof(text2), letter, true);

	if (occurences1 == 2) {
		cout << "Count funciton works correctly with case sensitive values" << endl;
	}
	else {
		cout << "Error in Count function when case is taken into account, result has to be 2, not " << occurences1 << endl;
	}

	int occurences2 = Count(text2, sizeof(text2), letter, false);

	if (occurences2 == 4) {
		cout << "Count funciton works correctly with case insensitive values" << endl;
	}
	else {
		cout << "Error in Count function when case is not taken into account, result has to be 4, not " << occurences2 << endl;
	}
	
	system("pause");
	return 0;
}