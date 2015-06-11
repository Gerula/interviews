#include<stdio.h>

typedef unsigned int us;

us swap(us x, int i, int j)
{
    us lo = ((x >> i) & 1);
    us hi = ((x >> j) & 1);
    if (lo ^ hi) {
        x ^= ((1 << i) | (1 << j));
    }    

    return x;
}

int main() {
    us n = 43261596;
    int size = sizeof(n) * 8;
    for (int i = 0; i < size / 2; i++) {
        n = swap(n, i, size - i - 1);
    }
    
    printf("%d\n", n);
    return 0;
}
