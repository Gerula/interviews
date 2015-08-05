using System;

class ListNode {
    public int Value { get; set; }
    public ListNode Link { get; set; }
    public override String ToString() {
        return String.Format("{0} {1}", Value, (Link != null)? Link.ToString() : String.Empty);
    }
}

class TreeNode {
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public ListNode ToList() {
        ListNode head = null;
        Listify(ref head);
        return head;
    }

    public void Listify(ref ListNode head) {
        if (Left == null && Right == null) {
            head = new ListNode { 
                                 Value = this.Value,
                                 Link = head 
                                };
        } else {
            if (Right != null) {
                Right.Listify(ref head);
            }

            if (Left != null) {
                Left.Listify(ref head);
            }
        }
    }
}

class Program {
    static void Main() {
        TreeNode root = new TreeNode {
            Value = 1,
            Left = new TreeNode {
                Value = 2,
                Left = new TreeNode {
                    Value = 3,
                    Left = null,
                    Right = null
                },
                Right = new TreeNode {
                    Value = 4,
                    Left = null,
                    Right = null
                }
            },
            Right = new TreeNode {
                Value = 5,
                Left = null,
                Right = null
            }
        };

        Console.WriteLine(root.ToList());
    }
}
