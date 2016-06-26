;;  Update the values of a list with their absolute values. The input and output portions will be handled automatically during grading. You only need to write a function with the recommended method signature.

(fn[lst]
    (map #(max % (- %)) lst))

