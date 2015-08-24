bool isUgly(int num) {
    if (num == 0) {
        return false;
    }
    
    if (num == 1) {
        return true;
    }
    
    for (int i = 2; i < 6; i++) {
        while (num % i == 0) {
            num /= i;
        }
    }
    
    return num == 1;
}
