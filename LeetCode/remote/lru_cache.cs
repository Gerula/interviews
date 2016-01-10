//  https://leetcode.com/problems/lru-cache/
//
//   Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and set.
//
//   get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
//   set(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity,
//   it should invalidate the least recently used item before inserting a new item. 

public class Node {
    public Node prev;
    public Node next;
    public int val;
    public int key;
}

public class LRUCache {
    int Size;
    int Capacity;
    Dictionary<int, Node> cache;
    Node Head;
    Node Tail;
    
    public LRUCache(int capacity) {
        Size = 0;
        Capacity = capacity;
        cache = new Dictionary<int, Node>();
    }

    public int Get(int key) {
        if (cache.ContainsKey(key))
        {
            Head.prev = cache[key];
            if (cache[key].prev != null)
            {
                cache[key].prev = cache[key].next;
            }
            cache[key].next = Head.next;
            Head = cache[key];
            return Head.val;
        }
        
        return -1;
    }

    public void Set(int key, int value) {
        if (cache.ContainsKey(key))
        {
            Head.prev = cache[key];
            if (cache[key].prev != null)
            {
                cache[key].prev = cache[key].next;
            }
            
            cache[key].next = Head.next;
            Head = cache[key];
            cache[key].val = value;
            return;
        }
        
        var node = new Node();
        node.val = value;
        node.key = key;
        node.next = Head;
        if (Head != null)
        {
            Head.prev = node;
        }
        
        if (Tail == null)
        {
            Tail = node;
        }
        
        Head = node;
        cache[key] = Head;
        if (++Size > Capacity)
        {
            Tail.prev.next = null;
            cache.Remove(Tail.key);
            Tail = Tail.prev;
        }
    }
}
