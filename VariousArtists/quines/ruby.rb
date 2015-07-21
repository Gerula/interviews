def do_stuff
    s = [
    "   puts \"def do_stuff\"",
    "   puts \"    s = [\"",
    "   s.each { |x|",
    "       puts \"\"\" + x + \"\"\"",
    "   }",
    "   puts \"    ]\"",
    "   s.each { |x|",
    "       puts x",
    "   }",
    "   puts \"end\"",
    "   puts \"do_stuff\""
     ]
    puts "def do_stuff"
    puts "    s = ["
    s.each { |x|
        puts "\"" + x + "\""
    }
    puts "    ]"
    s.each { |x|
        puts x
    }
    puts "end"
    puts
    puts "do_stuff"
end

do_stuff
