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
            //Placeholder:
            String st1 = "The brown cow chewed on the grass";
            String st2 = "The moon looks beautiful tonight";
            DocumentVector d1 = DocumentVectorGenerator.GenerateDocumentVector(st1, "doc1");
            DocumentVector d2 = DocumentVectorGenerator.GenerateDocumentVector(st2, "doc2");
            List<DocumentVector> dlist = new List<DocumentVector>();
            dlist.Add(d1);
            dlist.Add(d2);
            index.populateIndex(dlist);



            DocumentSimilarityCalculator.SetIndex(index);
        }
        public Dictionary<DocumentVector, double> GetSortedSimilarityList(string input)
        {
            DocumentVector inputVector = DocumentVectorGenerator.GenerateInputVector(input);
            return DocumentSimilarityCalculator.GetDocumentSimilarityMap(inputVector);
        }
    }
}
