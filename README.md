# Console250722Mivney



\# this is a demo of adding a test project.



\## before it began (and some irrelevant stuff):

1. Prior to adding the test project I prepared a working .NetFramework project with Unit4, and some classes and solution.
2. This project supports all Unit4 functionality including all of Valerie Pekar's Turtle Frog and Bucket graphics (this includes printing binary trees among other features)
3. The project already has some tests in it (see the in program.cs's Node3a3Tests() which tests the solutions in /Node/Node3Solution.cs). static using was added to access the functions there with ease.
4. All other stuff like turtle, and frogs are in different folders but are part of the same namespace and same class Program (this is irrelevant for the purpose of testing T22Mivney, and just simplifies working with the graphic objects with students).



\## adding the test project:

1. The test project was created as a new NUnit3 type project under the solution (i.e. not a console project!!!)
2. I then added the soluiton to GitHub.
3. Next I'm adding, in the UnitestsProject a reference to the console project (right clicking dependencies and adding a project reference). For whomever clones this solution, this step will not be required, but I'm explaining anyways for those who try to replicate the process step by step. Commit, Push.
4. Getting ready for unit testing I made sure the Unitests project has all the access to the data structures and to the console project. Commit. Push.
5. At this stage I'm prompting GPT with the following prompt
    I want to demo an NUnit3 test project that tests functions in a Console project T22Mivney. The test project is already in the same solution and is referencing the Console project. 

    In the C# solution containing a Console project we will use an NUnit3 test project testing the following 2 functions:

    1.      /// <summary> 
            /// עזר - הסרת אובייקט מכל המקומות. 
            /// מבוססת Bead RemoveAll מבוססת על
            /// </summary>
            /// <param name="head"></param>
            /// <param name="obj"></param>
            /// <returns>the cleaned up chain</returns>
            public static Node<T> RemoveObjAny<T>(Node<T> head, T obj)

    2.         /// <summary>
            /// הסרת רצפים של מספרים זהים - להשאיר יחיד
            /// </summary>
            /// <param name="head"></param>
            public static void RemoveSequencesOfIdenticalNumbers(Node<int> head)

    Currently I have some very light test in the Console itself relying on a NodeToString function like this:

            public static void Node3a3Tests()
            {
                Node<int> c0 = BuildIntListFromString("5,5,5,4,5");
                var tmp = RemoveObjAny(c0, 5);
                Debug.Assert(NodeToString(tmp) == "4");


                var c4 = BuildIntListFromString("4,4,-5,-5,-5,8,8,4,6,-5,7,8,8,8,8,8,9");
                RemoveSequencesOfIdenticalNumbers(c4);
                Debug.Assert(NodeToString(c4) == "4 ⟶  -5 ⟶  8 ⟶  4 ⟶  6 ⟶  -5 ⟶  7 ⟶  8 ⟶  9");
            }  

    Please fill the following Nunit3 class with proper Unit Tests in whichever way you see fit. The NUnit3 project has correct access to the Console project and to the Data Structures.

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
6. at this stage GPT responds with full test using Assert.AreEqual. After a correction from me the tests are updated to new NUnit3 syntax and I copy the code to the test project. Tests Fail due to an infrastructeproblem. 
7. [Our chat is here](https://chatgpt.com/share/687fcb71-ee74-800e-8cf4-8f5ecca3f73c) 
8. I Commit Push in any case, and will continue to debug on the next version..
