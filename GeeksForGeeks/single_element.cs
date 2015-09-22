// http://www.geeksforgeeks.org/find-the-element-that-appears-once-in-a-sorted-array/
//
// 
// Find the element that appears once in a sorted array
//
// Given a sorted array in which all elements appear twice (one after one) and one element appears only once. Find that element in O(log n) complexity.
//
using System;
using System.Collections.Generic;

static class Program {
    static int SingleElement(this List<int> elements) {
        int low = 0;
        int high = elements.Count - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (mid % 2 == 0) {
                if (elements[mid] == elements[mid + 1]) {
                    low = mid + 2;
                } else {
                    high = mid;
                }
            } else {
                if (elements[mid] == elements[mid - 1]) {
                    low = mid - 2;
                } else {
                    high = mid - 1;
                }
            }
        }

        return elements[low]; 
    }

    static void Main() {
        if (4 != new List<int> {1, 1, 3, 3, 4, 5, 5, 7, 7, 8, 8}.SingleElement()) {
            throw new Exception("U r dumb!");
        }

        if (8 != new List<int> {1, 1, 3, 3, 4, 4, 5, 5, 7, 7, 8}.SingleElement()) {
            throw new Exception("U r dumb!");
        }

        Console.WriteLine("U r probably not dumb");
    }
}
