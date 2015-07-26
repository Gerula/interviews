// https://leetcode.com/submissions/detail/34278741/

bool searchMatrix(int** matrix, int matrixRowSize, int matrixColSize, int target) {
    int line = 0;
    int column = matrixColSize - 1;
    while (line < matrixRowSize && column >= 0) {
        if (matrix[line][column] == target) {
            return true;
        }
        
        if (matrix[line][column] < target) {
            line++;
        } else {
            column--;
        }
    }
    
    return false;
}
