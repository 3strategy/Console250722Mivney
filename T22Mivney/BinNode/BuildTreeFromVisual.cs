using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unit4.CollectionsLib;

namespace T22Mivney
{
    public partial class BinNodeSolutions
    {
        /// <summary>
        /// Build a binary tree from a space-indented visual layout.  It now honours the *horizontal
        /// position* of each number so children are attached to the correct parent (e.g. a far‑right
        /// value below an 8 becomes 8’s child, not a preceding node’s).
        /// Each non‑blank line is treated as a tree level; any sequence of digits (optionally
        /// preceded by '-') represents one node value.  Children are attached to parents
        /// strictly in the order they appear (breadth‑first).  Blank / whitespace‑only lines
        /// are ignored so you may keep empty visual rows for readability.
        public static BinNode<int> BuildTreeFromVisual(string[] lines)
        {
            if (lines == null || lines.Length == 0)
                return null;

            /* 1️⃣  Filter out blank lines */
            var nonBlank = new List<string>();
            foreach (string line in lines)
                if (!string.IsNullOrWhiteSpace(line))
                    nonBlank.Add(line);
            if (nonBlank.Count == 0)
                return null;

            /* 2️⃣  Parse each line into (node, horizontal‑pos) tokens */
            var intRegex = new Regex(@"-?\d+");

            var levels = new List<List<(BinNode<int> node, int pos)>>();
            foreach (string line in nonBlank)
            {
                var row = new List<(BinNode<int>, int)>();
                foreach (Match m in intRegex.Matches(line))
                {
                    int centre = m.Index + m.Length / 2; // rough midpoint of the token
                    row.Add((new BinNode<int>(int.Parse(m.Value)), centre));
                }
                levels.Add(row);
            }

            if (levels[0].Count == 0)
                return null;

            /* 3️⃣  Link children to parents based on horizontal ranges */
            var currentParents = levels[0];
            for (int lvl = 1; lvl < levels.Count; lvl++)
            {
                var children = levels[lvl];
                int cIdx = 0;
                var nextParents = new List<(BinNode<int>, int)>();

                for (int p = 0; p < currentParents.Count; p++)
                {
                    var (parentNode, parentPos) = currentParents[p];
                    // boundary is halfway between this parent and the next parent (or +∞ for last)
                    int boundary = (p == currentParents.Count - 1)
                        ? int.MaxValue
                        : (parentPos + currentParents[p + 1].pos) / 2;

                    while (cIdx < children.Count && children[cIdx].pos < boundary)
                    {
                        var (childNode, childPos) = children[cIdx++];
                        if (childPos < parentPos)
                            parentNode.SetLeft(childNode);
                        else
                            parentNode.SetRight(childNode);
                        nextParents.Add((childNode, childPos));
                    }
                }

                currentParents = nextParents;
            }

            // Root is the very first token parsed
            return levels[0][0].node;
        }
    }
}
