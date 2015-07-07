def do_stuff(value, function)
    function.call(value)
end

i = 10
func = -> (a) { a + i }
puts do_stuff(5, func) 
i = 11
puts do_stuff(5, func)

