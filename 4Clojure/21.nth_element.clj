;;  Write a function which returns the Nth element from a sequence.
;;  No nth
(fn [array n]
  (if (= 0 n)
    (first array)
    (recur (rest array) (dec n))))
