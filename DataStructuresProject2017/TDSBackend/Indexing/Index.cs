using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;

namespace TDSBackend.Indexing {

        /***************************************************************************** 
         *  This index class will create an dictionary of words and corresponding    *
         *  documents associated with that word. This will allow for fast retrevial  *
         *  of documents when a word is searched.                                    *
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

/********************************************************************************************/

        /** Method to populate the index given a DocumentVector | **/
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