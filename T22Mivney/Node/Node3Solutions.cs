using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
using static System.Net.Mime.MediaTypeNames;

namespace T22Mivney
{
    public partial class NodeSolutions
    {
        /// <summary>
        /// תת קבוצה בשרשראות
        /// Checks if the first list is a sublist of the second list.
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool IsSubList(Node<int> list1, Node<int> list2)
        {
            if (list1 == null)
                return true; // empty pattern matches
            else if (list2 == null)
                return false;

            while (list2 != null)
            {
                bool match = true; // close on any failue
                var seekHead = list2;
                var partternHead = list1;
                while (partternHead != null)//foreach (var col in pattern)
                {
                    if (seekHead == null || seekHead.GetValue() != partternHead.GetValue())
                    {
                        match = false; // if any color does not match, we fail
                        break;
                    }
                    seekHead = seekHead.GetNext(); // advance to next bead
                    partternHead = partternHead.GetNext(); // advance to next bead
                }

                if (match)
                    return true;

                list2 = list2.GetNext(); // advance to next bead in the chain
            }

            return false;
        }



        /// <summary>
        /// הסרת רצפים של מספרים זהים - להשאיר יחיד
        /// </summary>
        /// <param name="head"></param>
        public static void RemoveSequencesOfIdenticalNumbers(Node<int> head)
        {
            while (head != null && head.HasNext())
            {
                var nxt = head.GetNext();
                if (nxt.GetValue() == head.GetValue())
                    head.SetNext(nxt.GetNext()); // skip the next node
                else // קידום סלקטיבי - כדי לא לקפוץ במקרה שיש רצף 
                    head = head.GetNext(); // move to the next node
            }
        }



        /// <summary>
        /// עזר - הסרת אובייקט מכל המקומות. 
        /// מבוססת Bead RemoveAll מבוססת על
        /// </summary>
        /// <param name="head"></param>
        /// <param name="obj"></param>
        /// <returns>the cleaned up chain</returns>
        public static Node<T> RemoveObjAny<T>(Node<T> head, T obj)
        {
            if (head == null)
                return null; // Nothing to remove
            while (head != null && head.GetValue().Equals(obj)) // need to jump posibly a few times.  
                head = head.GetNext(); // החלפת הראש

            var current = head;

            while (current != null)
            {
                while (current.GetNext() != null &&
                    current.GetNext().GetValue().Equals(obj))
                {// קפיצה כל עוד מתקיים תנאי למקרה שיש רצף
                    current.SetNext(current.GetNext().GetNext());
                }
                // מתקדמים.
                current = current.GetNext();
            }

            return head;
        }


        #region Auxiliary methods for testing
        /// <summary
        /// Builds a linked list of integers from a comma-separated string of numbers.
        /// </summary>
        /// <param name="numbersString">A string containing comma-separated integers (e.g., "1,2,3").</param>
        /// <returns>The head of the linked list, or null if the string is empty.</returns>
        public static Node<int> BuildIntListFromString(string numbersString)
        {
            string[] sNums = numbersString.Split(',');
            if (sNums.Length == 0 || string.IsNullOrWhiteSpace(sNums[0]))
                return null;
            Node<int> head = new Node<int>(int.Parse(sNums[sNums.Length - 1]));
            for (int i = sNums.Length - 2; i >= 0; i--)
                head = new Node<int>(int.Parse(sNums[i]), head);

            return head;
        }

        public static void PrintNode(Node<int> head)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // To support special characters like "⟶"

            //Console.WriteLine(TOSTring(head));
            if (head != null)
            {
                if (head.GetValue() < 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write(head.GetValue());

                var next = head.GetNext();
                if (next != null)
                {
                    Console.Write(" ⟶  ");
                    PrintNode(next);
                }
                else Console.WriteLine();
            }

        }

        /// <summary>
        /// אולי דרך להקל על בדיקות - הפיכה למחרוזת של שרשרת
        /// </summary>
        /// <param name="head"></param>
        public static string NodeToString(Node<int> head)
        {
            string result = string.Empty;
            if (head == null)
                return string.Empty;
            if (!head.HasNext())
                return head.GetValue().ToString(); // no next, so we are done
            return head.GetValue() + " ⟶ " + NodeToString(head.GetNext());
        }
        #endregion
    }
}
