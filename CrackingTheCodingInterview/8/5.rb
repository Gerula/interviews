#  Implement an algorithm to print all valid (e.g., properly opened and closed) combi- nations of n-pairs of parentheses.
#

def print_paranthesis(str, pos,  n, open, closed)
    if closed == n
        puts str
        return
    end

    if open > closed
        str[pos] = ')'
        print_paranthesis(str, pos + 1, n, open, closed + 1)
    end
    if open < n
        str[pos] = '('
        print_paranthesis(str, pos + 1, n, open + 1, closed)
    end
end

print_paranthesis("", 0, 10, 0, 0)
