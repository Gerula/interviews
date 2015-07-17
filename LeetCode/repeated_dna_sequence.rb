#  All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG". When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.
#
#  Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.
#
#  For example,
#
#  Given s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT",
#
#  Return:
#  ["AAAAACCCCC", "CCCCCAAAAA"].
#

def find_repeated_dna_sequences(s)
    all = s.chars.each_cons(10).map { |x| x.join("") }.inject({}) { |acc, sequence|
        acc[sequence] ||= 0
        acc[sequence] += 1
        result << sequence if acc[sequence] > 1
        acc
    }

    result.uniq
end


puts find_repeated_dna_sequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT").inspect
