# Write an efficient hash to keep URLs
#

url = ["http://www.domain.net/X",
        "http://www.domain.net/X/y/z",
        "http://www.domain.net/X/y/a",
        "http://www.domain.net/X/y/a/b",
        "http://www.domain.net/X/a/b",
        "http://www.domain.net/X/b/a",
        "http://www.domain.net/X/b/x",
        "http://www.domain.net/a",
        "http://www.domain.net/a",
        "http://www.domain.net/s",
        "http://www.domain.net/s/a/b"]

class TrieNode < Struct.new(:value, :link, :finish)
    def inspec
        puts "#{value} #{link.inspect} #{finish}"
    end
end

class Trie 
    def initialize
        @root = TrieNode.new("root", [], false)
    end

    def exists_or_add?(url)
        tokens = url.split("/").reject{|x| x.empty?}
        iterator = @root
        exists = true
        tokens.each_with_index{ |token, index|
            previous = iterator
            iterator = get_next_token(iterator, token)
            if iterator.nil?
                new_node = TrieNode.new(token, [], index == tokens.length - 1)
                previous.link.push(new_node)
                iterator = new_node
                exists = false
            end
        }

        return exists 
    end

    def get_next_token(current, token)
        return current.link.find{ |t| t.value == token } unless current.nil? || current.link.nil?
        return nil
    end
end

b_hash = Trie.new

url.each { |url|
    b_hash.exists_or_add?(url)
}

puts url.map{|x| b_hash.exists_or_add?(x)}.reduce {|x, y| x && y}

puts b_hash.inspect
