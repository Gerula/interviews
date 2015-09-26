// http://www.geeksforgeeks.org/print-all-non-increasing-sequences-of-sum-equal-to-a-given-number/
//
// Given a number x, print all possible non-increasing sequences with sum equals to x.
//

#include <vector>
#include <iostream>

using namespace std;

void sumEqual(int number, int sum, vector<int> result)
{
    if (sum == number) 
    {
        for (auto i: result) 
        {
            cout << i <<" ";
        }

        cout << endl;
    }

    for (int i = 1; i <= number; i++)
    {
        if ((i <= number - sum) && (sum == 0 || i <= result.back()))
        {
            result.push_back(i);
            sumEqual(number, sum + i, result);
            result.pop_back();
        }
    }
}

int main() 
{
    int number = 4;
    vector<int> result;
    sumEqual(number, 0, result);
    return 0;
}
