//  https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
//  Follow up for problem "Populating Next Right Pointers in Each Node".
//
//  What if the given tree could be any binary tree? Would your previous solution still work?
//
//  Note:
//
//      You may only use constant extra space.
//  https://leetcode.com/submissions/detail/55380871/
//
//  Submission Details
//  61 / 61 test cases passed.
//      Status: Accepted
//      Runtime: 40 ms
//          
//          Submitted: 0 minutes ago
class Solution {
public:
    void connect(TreeLinkNode *root) {
        TreeLinkNode *temp = new TreeLinkNode(0);
        while (root != NULL)
        {
            TreeLinkNode *child = temp;
            while (root != NULL)
            {
                if (root->left != NULL)
                {
                    child->next = root->left;
                    child = child->next;
                }
                
                if (root->right != NULL)
                {
                    child->next = root->right;
                    child = child->next;
                }
                
                root = root->next;
            }
            
            root = temp->next;
            child->next = NULL;
        }
        
        delete temp;
    }
};
