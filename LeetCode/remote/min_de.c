// https://leetcode.com/submissions/detail/34432710/

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
int minDepth(struct TreeNode* root) {
    if (!root) {
        return 0;
    }
    
    return depth(root);
}

int depth(struct TreeNode* root) {
    if (root == NULL) {
        return INT_MAX;
    } 
    
    if (!root->left && !root->right) {
        return 1;
    }
    
    int left = depth(root->left);
    int right = depth(root->right);
    return 1 + ((left < right) ? left : right);
}
