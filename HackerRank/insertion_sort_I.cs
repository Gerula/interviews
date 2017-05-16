//  https://www.hackerrank.com/challenges/insertionsort1

using System;
using System.Collections.Generic;
using System.IO;
class Solution {
static void insertionSort(int[] ar) {
    var element = ar[ar.Length - 1];
    var i = ar.Length - 2;
    while (i >= 0 && ar[i] >= element) {
        ar[i + 1] = ar[i];
        Console.WriteLine(String.Join(" ", ar));
        i--;
    }
    
    ar[i + 1] = element;
    Console.WriteLine(String.Join(" ", ar));
}
