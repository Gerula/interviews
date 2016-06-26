;;  Count the number of elements in an array without using count,
;;  size or length operators (or their equivalents).
;;  The input and output portions will be handled automatically by the grader.
;;  You only need to write a function with the recommended method signature.

;;  5/5 passed!
(fn[lst]
  ((fn [lst len]
    (if (empty? lst)
        len
        (recur (rest lst) (inc len)))) lst 0))
