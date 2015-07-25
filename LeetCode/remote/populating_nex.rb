struct TreeLinkNode *GetNext(struct TreeLinkNode *node) {
    struct TreeLinkNode *it = node->next;
    
    while (it != NULL) {
        if (it->left) {
            return it->left;
        }
        
        if (it->right) {
            return it->right;
        }
        
        it = it->next;
    }
    
    return it;
}

void connect(struct TreeLinkNode *root) {
    if (root == NULL) {
        return;
    }
    
    if (root->next) {
        connect(root->next);
    }
    
    if (root->left) {
        root->left->next = (root->right) ? root->right : GetNext(root);
        connect(root->left);
    }
    
    if (root->right) {
        root->right->next = GetNext(root);
        connect(root->right);
    }
}
