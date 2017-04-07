For document cleaning code
Line 15 sends Regex.Replace a string to parse through, a pattern of white spacing to look for, and a string to replace each occurence with. Takes O(n)
time where n is the number of characters in the first string.
Line 16 sends Regex.Replace a string to parse through, a pattern of white spacing and words to look for, and a string to replace each occurence
that aren't a space or a word. Takes O(n) time where n is the number of characters to search through. 
Both lines go character by character.
Line 17 takes the string and puts all of its charcters to lowercase.