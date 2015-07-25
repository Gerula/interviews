// https://leetcode.com/submissions/detail/34131616/

void connect(struct TreeLinkNode *root) {
    if (!root) {
        return;
    }
    
    if (root->left) {
        root->left->next = root->right;
        if (root->next) {
            root->right->next = root->next->left;
        }
    }
    
    connect(root->left);
    connect(root->right);
}
