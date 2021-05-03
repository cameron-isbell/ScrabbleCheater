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
            TODO: NO IDEA WHY, BUT IT'S MAKING A MIN HEAP
                    doesn't matter too much, but still worth looking into
        */

        public static string[] Sort(List<string> SortMe)
        {
            //init heap
            Heap = new string[SortMe.Count];
            for (int i = 0; i < SortMe.Count; i++) {
                Heap[i] = SortMe[i];
            }

            //Build initial max heap
            for (int i = Heap.Length / 2 - 1; i >= 0; i--) {
                Heapify(Heap.Length, i);
            }

            for (int i = Heap.Length-1; i >= 0; i--) {
                Swap(0, i);
                Heapify(i, 0);
            }
            return Heap;
        }

        /*
            Create a max heap.
            Compare the root (max) to its left and right children
                if root < child: swap(child, root)
        */
        private static void Heapify(int n, int i) 
        {
            int max = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && Heap[left].CompareTo(Heap[max]) > 0) max = left;
            if (right < n && Heap[right].CompareTo(Heap[max]) > 0) max = right;

            if (max != i) {
                Swap(i, max);
                Heapify(n, max);
            }
        }

        private static void Swap(int i1, int i2)
        {
            string temp = Heap[i1];
            Heap[i1] = Heap[i2];
            Heap[i2] = temp;
        }
    }
}