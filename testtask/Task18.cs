using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace testtask
{
    class Task18
    {
        private Node[,] nodes;
        private int xLen;
        private int yLen;
        int maxPath = 0;

        public Task18()
        {
            ReadData();
            FillNeigbors();
        }

        public int FindMaxPath()
        {
            Node start = nodes[0, 0];
            start.PathValue = start.Value;
            Queue<Node> nodesToProceed = new Queue<Node>();
            nodesToProceed.Enqueue(start);
            while (nodesToProceed.Count > 0)
            {
                var current = nodesToProceed.Dequeue();
                foreach (var node in current.Neighbors.Where(x=>!x.Proceeded))
                {
                    if (!nodesToProceed.Contains(node))
                    {
                        nodesToProceed.Enqueue(node);
                    }
                    if (current.PathValue + node.Value > node.PathValue)
                    {
                        node.PathValue = current.PathValue + node.Value;
                        if (node.PathValue > maxPath)
                        {
                            maxPath = node.PathValue;
                        }
                    }
                }
                current.Proceeded = true;
            }
            return maxPath;
        }

        #region fill data
        private void ReadData()
        {
            string[] lines = File.ReadAllLines("triangle.txt");
            xLen = lines.Length;
            yLen = lines[lines.Length-1].Split(' ').Length;
            nodes = new Node[xLen, yLen];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length; j++)
                {
                    nodes[i, j] = new Node(Int32.Parse(numbers[j]));
                }
            }
        }

        private void FillNeigbors()
        {
            for (int i = 0; i < xLen; i++)
            {
                for (int j = 0; j < yLen; j++)
                {
                    var current = nodes[i, j];
                    if (current == null) continue;
                    if(i+1<xLen)
                    {
                        //bottom
                        current.Neighbors.Add(nodes[i + 1, j]);
                        if (j + 1 < yLen)
                        {
                            //right bottom
                            var bottomR = nodes[i + 1, j + 1];
                            if (bottomR != null)
                            {
                                current.Neighbors.Add(bottomR);
                            }
                        }
                        //left bottom
                        //if (j - 1 >= 0)
                        //{
                        //    var bottomL = nodes[i + 1, j - 1];
                        //    if (bottomL != null)
                        //    {
                        //        current.Neighbors.Add(bottomL);
                        //    }
                        //}
                    }
                }
            }
        }
        #endregion fill data
    }
    class Node
    {
        public int Value { get; set; }

        public int PathValue { get; set; }

        public bool Proceeded { get; set; }

        public List<Node> Neighbors { get; set; }

        public Node(int value)
        {
            Value = value;
            PathValue = 0;
            Proceeded = false;
            Neighbors = new List<Node>();
        }
    }
}
