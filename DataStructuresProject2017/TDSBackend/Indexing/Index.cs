using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;

namespace TDSBackend.Indexing {

    /***************************************************************************** 
     * Index.cs will create an index of all words in the text files and map      *
     * them to the documents they are contained in. This index will allow        *
     * for fast information retrieval due to the index using a hash to search    *
     * for values by given a key.                                                *
     *****************************************************************************/

    public class Index {
        
        private static Dictionary<int, List<DocumentVector>> index;

        public Index() {
            index = new Dictionary<int, List<DocumentVector>>();
        }

        /** Method to get values per key **/
        public List<DocumentVector> getDocuments(int key) {
            return index[key];
        }//end of getDocuments

        /** Method to populate the index given a DocumentVector | O(n) where n is the number of words in the vector **/
        public void indexPopulate(DocumentVector vector) {

            //get the words from the vector
            int[] words = vector.GetDocumentTerms();

            for (int j = 0; j < words.Length; j++)
            {
                //if key is already in the index
                if (index.ContainsKey(words[j]))
                {
                    //add the vector to the key
                    index[words[j]].Add(vector);
                }
                else
                {
                    //if the key is not in the index, add both the key and vector
                    index.Add(words[j], new List<DocumentVector>() { vector });
                }
            }
        }//end of indexPopulate method
    }
}//end of Index.cs