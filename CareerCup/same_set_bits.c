// http://www.careercup.com/question?id=5086215957118976

#include <stdio.h>

int swap_bits(int n, int i, int j);
int next_greater(int n);

int main() {
    for (int i = 1; i < 10; i++) {
        printf("%d -> %d \n", i, next_greater(i)); 
    }

    return 0;
}

int swap_bits(int n, int i, int j) {
    if (((n >> i) & 1) ^ ((n >> j) & 1)) {
        return n ^ ((1 << i) | (1 << j));
    }

    return n;
}

int next_greater(int n) {
    for (int i = 1; i < sizeof(int) * 8; i++) {
        int x = swap_bits(n, i, i - 1);
        if (n != x) {
            return x;
        }
    }

    return -1;
}

