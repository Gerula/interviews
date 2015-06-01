#include<stdio.h>

int main() {
    char s[] = "Hello world";
    int length = 0;
   
    int i = 0; 
    while (s[i]) {
        if (s[i] == ' ')
        {
            length = 0;
        }
        else
        {
            length++;
        }
        i++;
    }
    
    printf("Length is: %d", length);
}
