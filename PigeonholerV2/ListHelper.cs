﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PigeonholerV2
{
    static class ListHelper
    {
        public static void SelectSort(this List<int> list)
        {
            var length = list.Count;
            for (int i = 0; i < length; i++)
            {
                var lowest = list[0];
                var index = 0;
                for (int j = 0; j < length - i; j++)
                {
                    if (lowest > list[j])
                    {
                        lowest = list[j];
                        index = j;
                    }
                }
                list.Add(lowest);
                list.RemoveAt(index);
            }
        }

        public static void InsertionSort(this List<int> list)
        {
            var length = list.Count;
            var store = 0;
            for (int i = 0; i < length; i++)
            {
                store = list[i];
                var j = i - 1;
                while (j >= 0 && list[j] > store)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = store;
            }
        }

        public static void MergeSort(this List<int> list)
        {
            if (list.Count > 1)
            {
                var Split = splitList(list);
                Split[0].MergeSort();
                Split[1].MergeSort();
                list.Clear();
                list.AddRange(Merge(Split[0], Split[1]));
            }
        }

        private static List<int> Merge(List<int> a, List<int> b)
        {
            var finalLength = a.Count + b.Count;

            var result = new List<int>();

            int ia = 0, ib = 0;

            while (ia < a.Count || ib < b.Count)
            {
                if (ia < a.Count && ib < b.Count)
                {
                    if (a[ia] <= b[ib])
                    {
                        result.Add(a[ia]);
                        ia++;
                    }
                    else
                    {
                        result.Add(b[ib]);
                        ib++;
                    }
                }
                else if (ia < a.Count)
                {
                    result.Add(a[ia]);
                    ia++;
                }
                else if (ib < b.Count)
                {
                    result.Add(b[ib]);
                    ib++;
                }

            }
            return result;

        }

        private static List<List<int>> splitList(List<int> list)
        {
            var listLength = list.Count;

            var a = new List<int>();
            var b = new List<int>();

            for (int i = 0; i < listLength / 2; i++)
            {
                a.Add(list[i]);
            }
            for (int i = listLength / 2; i < listLength; i++)
            {
                b.Add(list[i]);
            }

            var result = new List<List<int>>
            {
                a,
                b
            };

            return result;
        }

        public static void QuickSort(this List<int> list)
        {
            var listlength = list.Count;
            if (listlength > 1)
            {
                var pivot = FindPivot(list);
                var pival = list[pivot];
                list.RemoveAt(pivot);
                list.Add(pival);

                var a = new List<int>();
                var b = new List<int>();
                for (int i = 0; i < listlength - 1; i++)
                {
                    if (list[i] < pival)
                    {
                        a.Add(list[i]);
                    }
                    else
                    {
                        b.Add(list[i]);
                    }
                }

                //var a = list.GetRange(0, lastStash);
                //var b = list.GetRange(lastStash, listlength - lastStash);
                a.QuickSort();
                b.QuickSort();
                list.Clear();
                list.AddRange(a);
                list.Add(pival);
                list.AddRange(b);
            }
        }

        private static int FindPivot(List<int> list)
        {
            var listlength = list.Count;
            if(listlength < 3)
            {
                return 0;
            }

            var midpoint = listlength / 2;

            var pivot = 0;
            var options = new List<int>()
            {
                list[0],
                list[midpoint],
                list[listlength - 1]
            };

            options.Remove(options.Min());
            options.Remove(options.Max());
            var pival = options.FirstOrDefault();

            if (pival == list[midpoint]) pivot = midpoint;
            if (pival == list[listlength - 1]) pivot = listlength - 1;

            return pivot;

        }

        public static bool IsSorted(this List<int> list)
        {
            var listlength = list.Count;
            for (int i = 0; i < listlength - 1; i++)
            {
                if (list[i] > list[i + 1]) return false;
            }
            return true;
        }

    }
}
