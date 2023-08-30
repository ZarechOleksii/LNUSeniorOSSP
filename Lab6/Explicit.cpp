#include<iostream>
#include<Windows.h>
#include<string>
using namespace std;

//pointer to functions in dll
typedef INT (CALLBACK* TMinimum) (LPINT selected, INT arrSize);
typedef BOOL(CALLBACK* TContains) (LPTSTR toCheck, INT checkedSize, LPTSTR toFind, INT foundSize, BOOL caseSensitive);
typedef DOUBLE(CALLBACK* TAverage) (LPINT numArr, INT arrSize);
typedef INT(CALLBACK* TCount) (LPTSTR text, INT textSize, CHAR counted, BOOL caseSensitive);

int Exit() {
	system("pause");
	return 0;
}

int DramaticExit(string funcName, HINSTANCE hDLL) {
	cout << "Function " << funcName << " not found" << endl;
	FreeLibrary(hDLL);
	return Exit();
}

int main() 
{
	string dllPath = "D:\\School\\GitHub\\OS&SPDLLs\\";
	string dllName = "OS&SP5DLL.dll";

	//load
	string fullPath = dllPath.append(dllName);
	HINSTANCE hDLL = LoadLibrary(fullPath.c_str());

	//check if loaded correctly both dll and functions
	if (hDLL == NULL) {
		cout << fullPath << " was not found" << endl;
		return Exit();
	}

	TMinimum Minimum = (TMinimum)GetProcAddress(hDLL, "Minimum");
	if (!Minimum) {
		return DramaticExit("Minimum", hDLL);
	}

	TContains Contains = (TContains)GetProcAddress(hDLL, "Contains");
	if (!Contains) {
		return DramaticExit("Contains", hDLL);
	}

	TAverage Average = (TAverage)GetProcAddress(hDLL, "Average");
	if (!Average) {
		return DramaticExit("Average", hDLL);
	}

	TCount Count = (TCount)GetProcAddress(hDLL, "Count");
	if (!Count) {
		return DramaticExit("Count", hDLL);
	}

	// testing
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

	//freeing
	FreeLibrary(hDLL);

	return Exit();
}