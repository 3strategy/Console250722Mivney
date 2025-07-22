using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
using static T22Mivney.NodeSolutions;

namespace T22Mivney
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //Main1(); // Turtle program
            //Main2(); // Frog program

            Node3a3Tests(); // Node program
        }

        // these were the early tests. 
        // for unit testing in project Tests3rdTry
        public static void Node3a3Tests()
        {
            Node<int> c0 = BuildIntListFromString("5,5,5,4,5");
            PrintNode(c0);
            Console.WriteLine("CLEANUP");
            //test RemoveObjAny
            var tmp = RemoveObjAny(c0, 5);
            PrintNode(tmp);

            var c4 = BuildIntListFromString("4,4,-5,-5,-5,8,8,4,6,-5,7,8,8,8,8,8,9");
            PrintNode(c4);
            // test RemoveSequencesOfIdenticalNumbers
            RemoveSequencesOfIdenticalNumbers(c4);
            Console.WriteLine("after shrinking identical sequences");
            PrintNode(c4);
            Console.WriteLine("print again");
            PrintNode(c4);


            var c2 = BuildIntListFromString("4,-1,4,-3,-3,4,4,-5,-5,-3,-5");
            PrintNode(c2);
            var l1 = BuildIntListFromString("4,-5,99");
            //test IsSubList
            Console.WriteLine($"l1 is{(IsSubList(l1, c2) ? "" : " NOT a")} sublist of c2");
        }
    }
}
