import ctypes
import os

dirName = os.path.dirname(__file__)
dllPath = os.path.join(dirName, "OS&SP5DLL.dll")
hDLL = ctypes.WinDLL(dllPath)
Minimum = hDLL.Minimum
Minimum.restype = ctypes.c_int
Contains = hDLL.Contains
Contains.restype = ctypes.c_bool
Contains.argtypes = [ctypes.c_char_p, ctypes.c_int, ctypes.c_char_p, ctypes.c_int, ctypes.c_bool]
Average = hDLL.Average
Average.restype = ctypes.c_double
Count = hDLL.Count
Count.restype = ctypes.c_int
Count.argtypes = [ctypes.c_char_p, ctypes.c_int, ctypes.c_char, ctypes.c_bool]


def minimum(values):
    length = len(values)
    Minimum.argtypes = [ctypes.c_int*length, ctypes.c_int]
    arr = (ctypes.c_int * length)()

    for i in range(length):
        arr[i] = values[i]

    return Minimum(arr, length * 4)


def contains(text, to_find, case_sensitivity):

    return Contains(ctypes.c_char_p(text.encode('ansi')),
                    len(text) + 1,
                    ctypes.c_char_p(to_find.encode('ansi')),
                    len(to_find) + 1,
                    case_sensitivity)


def average(values):
    length = len(values)
    Average.argtypes = [ctypes.c_int*length, ctypes.c_int]
    arr = (ctypes.c_int * length)()

    for i in range(length):
        arr[i] = values[i]

    return Average(arr, length * 4)


def count(text, char, case_sensitivity):
    return Count(ctypes.c_char_p(text.encode('ansi')),
                 len(text) + 1,
                 ctypes.c_char(char.encode('ansi')),
                 case_sensitivity)


if __name__ == '__main__':
    minValue = minimum([3, 1, -5, 6, 0])
    if minValue != -5:
        print(f'Error in Minimum function, result has to be -5, not {minValue}')
    else:
        print('Minimum function works correctly')

    textToSearch = 'SoMe text'
    textToFind = 'ome'
    resultContains = contains(textToSearch, textToFind, False)
    if resultContains is True:
        print('Contains function works correctly with no regard for case')
    else:
        print(f'Error in Contains function when case is not taken into account, ' +
              f'result has to be false, not {resultContains}')

    resultContains = contains(textToSearch, textToFind, True)
    if resultContains is False:
        print('Contains function works correctly with case sensitive values')
    else:
        print(f'Error in Contains function when case is taken into account, ' +
              f'result has to be false, not {resultContains}')

    averageNum = average([8, 5, 4, 2])
    if averageNum == 4.75:
        print('Average function works correctly')
    else:
        print(f'Average function works incorrectly, result has to be 4.75, not {averageNum}')

    textToFilter = 'Occurrences of letter O will be counted here'
    letter = 'o'
    occurrences = count(textToFilter, letter, True)
    if occurrences == 2:
        print('Count function works correctly with case sensitive values')
    else:
        print(f'Error in Count function when case is taken into account, result has to be 2, not {occurrences}')

    occurrences = count(textToFilter, letter, False)
    if occurrences == 4:
        print('Count function works correctly with case insensitive values')
    else:
        print(f'Error in Count function when case is not taken into account, result has to be 4, not {occurrences}')
