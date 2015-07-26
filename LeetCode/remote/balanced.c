// https://leetcode.com/submissions/detail/34298404/


/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
 
bool isBalanced(struct TreeNode* root) {
    return balanced(root) != -1;
}

int balanced(struct TreeNode* root) {
    if (root == NULL) {
        return 0;
    }
    
    int left = balanced(root->left);
    int right = balanced(root->right);
    
    if (left == -1 || right == -1 || abs(left - right) > 1) {
        return -1;
    }
    
    if (left > right) {
        return left + 1; 
    }
    
    return right + 1;
}
