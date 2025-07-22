using Unit4.CollectionsLib;
using static T22Mivney.NodeSolutions;

namespace UnitestsMivney
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // demo that the test project can Instanciate the data structures
            // as well as access functions from the Console project
            Node<int> c0 = BuildIntListFromString("5,5,5,4,5");
            PrintNode(c0);
            Console.WriteLine("CLEANUP");
            //test RemoveObjAny
            var tmp = RemoveObjAny(c0, 5);
            PrintNode(tmp);

            Assert.Pass();
        }
    }
}
