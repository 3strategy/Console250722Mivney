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
