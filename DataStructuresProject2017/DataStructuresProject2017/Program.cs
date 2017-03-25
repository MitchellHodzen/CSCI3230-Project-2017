using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresProject2017.DocumentStorage;

namespace DataStructuresProject2017
{
    class Program
    {
        static void Main(string[] args)
        {
            //PUT TEST CODE HERE

            string input = "oh baby a tripple baby baby tripple oh oh oh oh";
            DocumentVector test = DocumentVectorGenerator.GenerateDocumentVector(input);
            test.Print();
            DocumentVectorGenerator.PrintTermMap();
            Console.ReadLine();
        }
    }
}
