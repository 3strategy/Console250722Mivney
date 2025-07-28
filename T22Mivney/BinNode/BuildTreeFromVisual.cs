using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unit4.CollectionsLib;

namespace T22Mivney
{
    public partial class BinNodeSolutions
    {
        /// <summary>
        /// Builds a binary tree from a simple *visual* text layout.
        /// Each non‑blank line is treated as a tree level; any sequence of digits (optionally
        /// preceded by '-') represents one node value.  Children are attached to parents
        /// strictly in the order they appear (breadth‑first).  Blank / whitespace‑only lines
        /// are ignored so you may keep empty visual rows for readability.
        /// </summary>
        /// <remarks>
        /// This parser is intentionally simple: it is designed for **unit‑test scaffolding**
        /// where we only care that every value ends up somewhere in the tree (shape is not
        /// validated).
        /// </remarks>
        public static BinNode<int> BuildTreeFromVisual(string[] lines)
        {
            if (lines == null || lines.Length == 0)
                return null;

            /* 1️⃣  Remove blank lines */
            var nonBlank = new List<string>();
            foreach (var line in lines)
                if (!string.IsNullOrWhiteSpace(line))
                    nonBlank.Add(line);

            if (nonBlank.Count == 0)
                return null;

            /* 2️⃣  Extract integer tokens (supports negatives & multi‑digit) */
            var levelNodes = new List<List<BinNode<int>>>();
            var intRegex = new Regex(@"-?\d+");

            foreach (var line in nonBlank)
            {
                var matches = intRegex.Matches(line);
                var nodes = new List<BinNode<int>>();
                foreach (Match m in matches)
                    nodes.Add(new BinNode<int>(int.Parse(m.Value)));
                levelNodes.Add(nodes);
            }

            if (levelNodes[0].Count == 0)
                return null;

            /* 3️⃣  Breadth‑first linking of children → parents */
            var root = levelNodes[0][0];
            var parents = new System.Collections.Generic.Queue<BinNode<int>>();
            parents.Enqueue(root);

            int levelIndex = 1;
            while (levelIndex < levelNodes.Count && parents.Count > 0)
            {
                var children = levelNodes[levelIndex];
                int childIdx = 0;
                int parentCount = parents.Count;

                for (int i = 0; i < parentCount; i++)
                {
                    var parent = parents.Dequeue();

                    // Left child
                    if (childIdx < children.Count)
                    {
                        var left = children[childIdx++];
                        parent.SetLeft(left);
                        parents.Enqueue(left);
                    }

                    // Right child
                    if (childIdx < children.Count)
                    {
                        var right = children[childIdx++];
                        parent.SetRight(right);
                        parents.Enqueue(right);
                    }
                }

                levelIndex++;
            }

            return root;
        }
    }
}
