/*
 * Унифицированный алгоритм, который работает для любых 
 * направлений сортировок, и для поиска либо первого, либо последнего,
 * либо любого элемента из дублирующих.
 * (Код ужасен. Просто подключаю как библиотеку и копипастю что когда то написал)
 */

enum ElementToChoose
{
	First,
	Last,
	NoCare
}

/// <summary>
/// Finds element equal to value in sorted array in range [low, high)
/// </summary>
static int binarySearch(int value, int[] array, bool ascendingOrder, ElementToChoose elementToChoose, int low, int high) {
	// return valid invalid position
	if (low >= high)
		return -(low + 1);

	// return first or last found element
	if (elementToChoose == ElementToChoose.First)
		if (value == array[low])
			return low;

	int last = high - 1;

	if (elementToChoose == ElementToChoose.Last)
		if (value == array[last])
			return last;

	int mid = low + (high - low) / 2;

	// we have found some element
	if (value == array[mid]) {
		switch (elementToChoose) {
			case ElementToChoose.NoCare:
				return mid;

			case ElementToChoose.First:
				if (mid - low <= 1)
					// array[mid] is the earliest element in array, return it
					// because array[low] != value && array[low+1] == value, where mid == low + 1
					return mid;
				else
					// try to find first element
					// don't forget to capture current element {|0, 0|, 1} -> {0, 0}
					return binarySearch(value, array, ascendingOrder, elementToChoose, low, mid + 1);
			case ElementToChoose.Last:
				if (last - mid <= 1)
					// array[mid] is the last element in array, return it
					// because array[last] != value && array[last - 1] == value, where mid == last - 1
					return mid;
				else
					// try to find last element
					// don't forget to capture current element {0, |0, 1|} -> {0, 1}
					return binarySearch(value, array, ascendingOrder, elementToChoose, mid, high);
		}
	}

	// choose left or right half, depending on sorting order & comparing value and mid
	if ((value < array[mid]) ^ !ascendingOrder)
		return binarySearch(value, array, ascendingOrder, elementToChoose, low, mid);
	else
		return binarySearch(value, array, ascendingOrder, elementToChoose, mid + 1, high);
}