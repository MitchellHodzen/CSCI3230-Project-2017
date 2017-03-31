using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;
using TDSBackend.Indexing;
using TDSBackend.DocumentSimilarity;
namespace TDSBackend
{
    public class Backend
    {
        public Backend(string location)
        {
            Index index = new Index();

            //Create document vectors and populate index here

            DocumentSimilarityCalculator.SetIndex(index);
        }
        public Dictionary<DocumentVector, double> GetSortedSimilarityList(string input)
        {
            DocumentVector inputVector = DocumentVectorGenerator.GenerateDocumentVector(input, null);
            return DocumentSimilarityCalculator.GetDocumentSimilarityMap(inputVector);
        }
    }
}
