using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSBackend.DocumentStorage;

namespace TDSBackend
{
    class Program
    {
        static void Main(string[] args)
        {
            //PUT TEST CODE HERE
            //Test dot product
            SparseVector v1 = new SparseVector();
            v1.AddElement(0, 1);
            v1.AddElement(2, 3);
            SparseVector v2 = new SparseVector();
            v2.AddElement(0, 5);
            v2.AddElement(1, 3);
            Console.WriteLine("The dot product of v1 and v2 is: " + SparseVector.DotProduct(v1, v2));

            //Test norm
            Console.WriteLine("The norm of v1 is: " + SparseVector.Norm(v1));

            //Test the document vector generator
            string input = "oh baby a tripple baby baby tripple oh oh oh oh";
            DocumentVector test = DocumentVectorGenerator.GenerateDocumentVector(input);
            test.Print();
            DocumentVectorGenerator.PrintTermMap();
            Console.ReadLine();
        }
    }
}
