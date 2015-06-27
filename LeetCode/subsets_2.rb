class Array
    def subsets
        subsets_rec(self, [], 0)
    end

    def subsets_rec(a, set, step)
        puts set.inspect
        i = step
        while i < a.size
            if !set.any? || set[-1] <= a[i]
                subsets_rec(a, set + [a[i]], i + 1)
            end
            while i < a.size - 1 && a[i] == a[i + 1]
                i += 1
            end
            i += 1
        end
    end
end

[1, 2, 2].subsets
