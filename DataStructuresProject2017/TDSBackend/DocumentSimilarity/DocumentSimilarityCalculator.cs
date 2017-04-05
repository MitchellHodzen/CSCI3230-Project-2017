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
            List<DocumentVector> similarDocs = new List<DocumentVector>();
            int[] inputTerms = inputVector.GetDocumentTerms();
            HashSet<DocumentVector> docsToCheck = new HashSet<DocumentVector>();
            Console.WriteLine("Getting documents from index...");
            for (int i = 0; i < inputTerms.Length; i++)
            {
                similarDocs.AddRange(index.getDocuments(inputTerms[i]));
            }
            Console.WriteLine("Cleaning returned similar doc index...");
            foreach (DocumentVector dv in similarDocs)
            {
                docsToCheck.Add(dv);
            }
            Dictionary<DocumentVector, double> similarityMap = new Dictionary<DocumentVector, double>();
            Console.WriteLine("Calculating similarity map...");
            Console.WriteLine("Docs to check: " + docsToCheck.Count());
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
