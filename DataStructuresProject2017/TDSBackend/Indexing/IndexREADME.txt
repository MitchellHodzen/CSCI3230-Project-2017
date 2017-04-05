Matthew Dudley - Index.cs Report

Index.cs is used to create an index of all words and map them to a corresponding list of DocumentVectors it is contained in.
I chose to use a dictionary with words as keys and a list of DocumentVectors the words are in as values for the index.
The index as a dictionary will speed up information retrieval due to the hashing the Dictionaty class uses and we can
directly pull the list of documentVectors out by its key which takes O(1) in most cases.

Index.cs has a indexPopulate(DocumentVector vector) method that takes in a DocumentVector in order to popluate the index. After taking in a DocumentVector
I store the words in an array by using the GetDocumentTerms() method in the DocumentVector class. I then loop through
the array of words to populate the index. If a word is already contained in the index I simply add the DocumentVector to the list ,at the word key, as a value. 
If the word is not already in the index then it will get added as the key and the DocumentVector it came from will get added to the list as the value.
The indexPopulate method has a worst case runtime of O(k) where k is the number of words from the DocumentVector. Worst case the method will loop
through k number of words and have to add all words as a key.

Index.cs also has a getDocuments(int key) method that returns the list of DocumentVectors by a specific key.
Retrieving a value by using its key is very fast, close to O(1), because the Dictionary class is implemented as a hash table.
This method is used after the user inputs a string or word to search. The DocumentSimularity classes uses the index to retreive
the list of DocumentVectors to preform its test.
