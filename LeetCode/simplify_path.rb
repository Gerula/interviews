# Given an absolute path for a file (Unix-style), simplify it.
#
# For example,
# path = "/home/", => "/home"
# path = "/a/./b/../../c/", => "/c"
#

def simplify_path(path)
    path_tokens = path.split("/").reject{ |x| x.empty? || x == "." }
    stack = []
    path_tokens.each{ |x|
        if x == ".."
            stack.pop if stack.any?
        else
            stack.push(x)
        end
    }

    "/" << stack.join("/")
end

["/home/", "/a/./b/../../c/", "/home//foo/"].each { |path| puts simplify_path(path) }
