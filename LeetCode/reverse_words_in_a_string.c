#include <stdio.h>
#include <string.h>

void reverse(char *s, int left, int right) {
    while (left < right)
    {
        char c = s[left];
        s[left++] = s[right];
        s[right--] = c;
    }
}

int main() {
    char s[] = "the sky is blue";
    printf("%s \n", s);
    reverse(s, 0, strlen(s) - 1);
    int last = 0;
    for (int i = 0; i < strlen(s); i++) {
        if (s[i] == ' ') {
            reverse(s, last, i - 1);
            last = i + 1;
            continue;
        }

        if (i == strlen(s) - 1) {
            reverse(s, last, i);
        }
    }
    printf("%s \n", s);
    return 1;
}
