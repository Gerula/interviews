#include<stdio.h>

int main() {
    int x = 2;
    int pow = 7;
    
    int result = x;
    while (pow > 1) {
        if (pow % 2 == 0) {
            result = result * x * x;
        } else {
            result = result * x * x * x;
        }
        pow /= 2;
    }
    
    printf("%d \n", result);
    return 1;
}
