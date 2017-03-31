using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;
using TDSBackend.Indexing;

namespace TDSBackend.DocumentSimilarity
{
    public static class DocumentSimilarityCalculator
    {
        private static Index index;
        public static Dictionary<DocumentVector, double> GetDocumentSimilarityMap(DocumentVector inputVector)
        {
            //Returns a dictionary of document vectors where the key is the document vector and the value is the similarity to the input vector
            //Change to something other than a dictionary?
            List<DocumentVector> docsToCheck = new List<DocumentVector>();
            int[] inputTerms = inputVector.GetDocumentTerms();
            for (int i = 0; i < inputTerms.Length; i++)
            {
                docsToCheck.AddRange(index.getDocuments(inputTerms[i]));
            }
            Dictionary<DocumentVector, double> similarityMap = new Dictionary<DocumentVector, double>();
            for (int i = 0; i < docsToCheck.Count(); i++)
            {
                similarityMap.Add(docsToCheck.ElementAt(i), inputVector.GetDocumentSimilarity(docsToCheck.ElementAt(i)));
            }
            return similarityMap;
        }
        public static void SetIndex(Index ind)
        {
            DocumentSimilarityCalculator.index = ind;
        }
    }
}
