using System;
using System.Collections.Generic;

namespace Scrabble_Player
{
    class HeapSort
    {
        private static string[] Heap;

        /*
            Public function for Player to call. 
            Returns an array of string from max -> min. 
        */
        public static string[] Sort(List<string> SortMe)
        {
            Heap = new string[SortMe.Count];
            for (int i = 0; i < SortMe.Count; i++) {
                Heap[i] = SortMe[i];
            }
            
            string[] sorted = new string[Heap.Length];
            for (int i = 0; i < SortMe.Count; i++) {
                Heapify((Heap.Length-1) - i, Heap);
                sorted[i] = Pull(i);
            }

            return sorted;
        }

        /*
            Push maximum string to the root node.
        */
        private static void Heapify(int pos, string[] arr) 
        {
            int right = pos;
            int left = right-1;
            int root = (right-1) / 2;

            //determine which child node is larger
            int comp;
            if (left < 0) comp = right;
            else comp = (Heap[right].CompareTo(Heap[left]) > 0) ? right : left;

            if (Heap[comp].CompareTo(Heap[root]) > 0) {
                string temp = Heap[comp];
                Heap[comp] = Heap[root];
                Heap[root] = temp;
            }
            
            //if no more nodes, return up.
            if (pos-2 < 0) return;
            Heapify(pos-2, Heap);
        }

        /*
            Remove and return the root node. 
        */
        private static string Pull(int numRm)
        {
            string temp = Heap[0];
            Heap[0] = Heap[(Heap.Length-1)-numRm];
            Heap[(Heap.Length-1)-numRm] = temp;

            return temp;
        }
    }
}