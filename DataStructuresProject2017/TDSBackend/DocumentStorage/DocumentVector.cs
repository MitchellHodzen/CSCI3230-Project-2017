using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDSBackend.DocumentStorage
{
    /*A documentVector contains all necessary information about a particular document
    The documentLocation contains information about where to find the document on the harddrive
    The internalVector contains information about which words appear in the document and the frequency of those words*/

    public class DocumentVector
    {
        private string documentLocation;
        private SparseVector internalVector;

        public DocumentVector(String documentLocation, SparseVector internalVector)
        {
            this.documentLocation = documentLocation;
            this.internalVector = internalVector;
        }

        public int[] GetDocumentTerms()
        {
            //Returns an array which contains the index positions of the words which appear in the document
            return internalVector.GetNonZeroIndexPositions();
        }
        public string GetDocumentLocation()
        {
            return documentLocation;
        }
        public void Print()
        {
            //Prints out the internal vector of the document, used for testing
            internalVector.PrintVector();
        }
    }
}
