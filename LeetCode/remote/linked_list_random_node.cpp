//  https://leetcode.com/problems/linked-list-random-node/

//  Not accepted for some fucking reason

class Solution {
public:
    /** @param head The linked list's head. Note that the head is guanranteed to be not null, so it contains at least one node. */
    Solution(ListNode* head) {
        list_head = head;
    }
    
    /** Returns a random node's value. */
    int getRandom() {
        auto start = list_head;
        auto result = start;
        auto n = 1;
        while (start != NULL) {
            n++;
            if ((rand() % n) == 0) {
                result = start;
            }
            
            start = start->next;
        }
        
        return result->val;
    }
    
private:
    ListNode* list_head;
};

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.getRandom();
 */
